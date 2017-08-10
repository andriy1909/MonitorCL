using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using MonitorCLClassLibrary;
using System.IO;
using MonitorCLClassLibrary.Model;
using MonitorCLClassLibrary.JSON;
using Microsoft.Win32;
using System.ComponentModel;

namespace MonitorCLClassLibrary
{
    public class ClientWork : IDisposable
    {
        public User user = new User();
        public string IP { get; set; }
        public int Port { get; set; }
        private TcpClient client;
        private NetworkStream stream;
        private int countEmpty = 0;
        private Thread receiveThread;

        public int status_Delete { get; private set; } = -1;

        Thread thread;

        public ResultCode Register(string serialKey)
        {
            client = new TcpClient();
            JsonPack json = new JsonPack();
            json.data = new JSDRegister()
            {
                key = serialKey,
                Id_1 = BaseBoard.GetSerialNumber(),
                Id_2 = Bios.GetSerialNumber(),
                computerName = OperatingSystemScan.GetNamePC()
            };

            try
            {
                client.Connect(IP, Port);
                stream = client.GetStream();
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                if (GetErrorCode(err) == 10061)
                    return ResultCode.NoConnection;
                else
                    return ResultCode.Error;
            } 

            if (!client.Connected)
            {
                return ResultCode.NoConnection;
            }
            else
            {
                SendMessage(json.ToString());

                JsonPack receive = ReceiveOneMessage();

                if (!receive.Accept)
                {
                    if (receive.Errors == "NotValidKey")
                        return ResultCode.NotValidKey;
                    else
                        return ResultCode.Error;
                }
                else
                {
                    // запускаем новый поток для получения данных
                    receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                    receiveThread.Start(); //старт потока
                    return ResultCode.OK;
                }
            }
        }

        public bool Login()
        {
            string LicenceKey = GetLicenseKey();
            JsonPack pack = new JsonPack();
            JSDLogin data = new JSDLogin()
            {
                LicenseKey = LicenceKey,
                UniqPC = pack.GetUniqPC()
            };
            pack.data = data;
            pack.metod = data.GetType().Name;

            try
            {
                client.Connect(IP, Port);
                stream = client.GetStream();
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                    return false;
            }

            if (!client.Connected)
            {
                return false;
            }
            else
            {
                SendMessage(pack.ToString());

                JsonPack receive = ReceiveOneMessage();

                if (!receive.Accept)
                {
                        return false;
                }
                else
                { 
                    // запускаем новый поток для получения данных
                    receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                    receiveThread.Start(); //старт потока
                    return true;
                }
            }

            //return false;
        }

        private int GetErrorCode(Exception e)
        {
            Win32Exception winEx = e as Win32Exception;
            if (winEx != null)
                return winEx.ErrorCode;

            if (e.InnerException != null)
                return GetErrorCode(e.InnerException);

            return -1;
        }

        public void SetAutoRun(string path, bool value)
        {
            try
            {
                RegistryKey reg = Registry.LocalMachine.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (value)
                {
                    if (reg.GetValue(new FileInfo(path).Name).ToString() != path)
                        reg.SetValue(new FileInfo(path).Name, path);
                }
                else
                {
                    reg.DeleteValue(new FileInfo(path).Name);
                }
            }
            catch (Exception err)
            {
                LogList.Add(err.Message);
            }
        }

        public string GetLicenseKey()
        {
            try
            {
                RegistryKey reg = Registry.LocalMachine.OpenSubKey
                    ("SOFTWARE\\CompLife\\MonitorCLClient", true);

                if (reg.GetValue("MonitorCLClient") != null)
                    return reg.GetValue("LicenseKey").ToString();
                else
                    return null;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                LogList.Add(err.Message);
                return null;
            }
        }

        public void SetActiveKey(string key)
        {
            try
            {
                RegistryKey reg = Registry.LocalMachine.OpenSubKey
                    ("SOFTWARE\\CompLife\\MonitorCLClient", true);

                reg.SetValue("LicenseKey", key);
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                LogList.Add(err.Message);
            }
        }

        /// <summary>
        /// отправка сообщений
        /// </summary>
        /// <param name="message">сообщене</param>
        public void SendMessage(string message)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);
        }

        public JsonPack ReceiveOneMessage()
        {
            try
            {
                byte[] data = new byte[64]; // буфер для получаемых данных
                StringBuilder builder = new StringBuilder();
                int bytes = 0;
                do
                {
                    bytes = stream.Read(data, 0, data.Length);
                    builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                }
                while (stream.DataAvailable);

                JsonPack json = new JsonPack();
                if (json.GetJson(builder.ToString()))
                {
                    return json;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                Debug.WriteLine("Подключение прервано!"); //соединение было прервано
                Disconnect();

                return null;
            }
        }

        /// <summary>
        /// получение сообщений
        /// </summary>        
        void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[64]; // буфер для получаемых данных
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    if (builder.ToString() == "")
                    {
                        countEmpty++;
                        if (countEmpty >= 50)
                            continue;
                    }
                    else
                        countEmpty = 0;

                    JsonPack pack = new JsonPack();
                    if (pack.GetJson(builder.ToString()))
                        ProcessQuery(pack);
                    else
                        ProcessQuery(null);
                }
                catch
                {
                    Debug.WriteLine("Подключение прервано!"); //соединение было прервано
                    Disconnect();
                    //            Connect(host, port, idClient, login, password);
                }
            }
        }

        private void ProcessQuery(JsonPack query)
        {
            if (query == null)
                return;
            switch (query.metod)
            {
                case "m1":

                    break;
                case "m2":

                    break;
                case "m3":

                    break;
                default:
                    break;
            }
        }

        public bool SendToSupport(string subject, string body, Image screen)
        {
              JsonPack jp = new JsonPack();

              ImageConverter converter = new ImageConverter();
              var bytes = (byte[])converter.ConvertTo(screen, typeof(byte[]));
              List<byte[]> list = new List<byte[]>();
              list.Add(bytes);

              string str = jp.ToString();

            //var ms = new MemoryStream(jp.GetJson(str).images[0]);
            var ms = new MemoryStream();
            Image image = Image.FromStream(ms);

              img_Delete = image;
            //throw new NotImplementedException();
            return false;
        }

        public void Disconnect()
        {
            if (stream != null)
                stream.Close();//отключение потока
            if (client != null)
                client.Close();//отключение клиента
            Environment.Exit(0); //завершение процесса
        }

        public void Dispose()
        {
            //
        }  



        #region _Delete


        public void Connect_Delete()
        {
            thread = new Thread(new ThreadStart(ConnectThread_Delete));
            thread.Start();
        }

        private void ConnectThread_Delete()
        {
            client = new TcpClient();
            try
            {
                client.Connect(IP, Port); //подключение клиента
                stream = client.GetStream(); // получаем поток

                /*
                                JsonPack jsPack = new JsonPack();
                                JsonHeader jsHeader = new JsonHeader("reg");
                                jsHeader.setLoginPassword("login", "password");
                                jsHeader.setToken("12345");
                                JsonData jsData = new JsonData();
                                jsData.text = "Hello";
                                jsPack.data = jsData;
                                jsPack.header = jsHeader;
                                jsPack.SetSignature(Settings.Default.privateKey);
                                //SendMessage(jsPack.GetJsonStr());
                                byte[] data = Encoding.Unicode.GetBytes(jsPack.GetJsonStr());
                                stream.Write(data, 0, data.Length);
                                */
                if (!client.Connected)
                    throw new NotImplementedException();

                // запускаем новый поток для получения данных
                receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.Start(); //старт потока
                isConnect_Delete = true;
            }
            catch (Exception ex)
            {
                isConnect_Delete = false;
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("reconnect");
                Thread.Sleep(1000);
                ConnectThread_Delete();
            }
            finally
            {
            }
        }






        public delegate void ReceiveDelegate_Delete(string message);
        public delegate void IsConnected_Delete(bool check);
        ReceiveDelegate_Delete receiveOut_Delete;
        IsConnected_Delete isConnectedOut_Delete;
        private bool isConnect_Delete = false;


        public bool IsConnect_Delete
        {
            get { return isConnect_Delete; }
        }

        public void setReceiveOut_Delete(ReceiveDelegate_Delete receive)
        {
            receiveOut_Delete = receive;
        }

        public void setIsConnectOut_Delete(IsConnected_Delete isConnected)
        {
            isConnectedOut_Delete = isConnected;
        }
        /*
                public void Connect(string ip, int port, Guid id, string login, string password)
                {
                    user.Login = login;
                    user.Password = password;
                    Host = ip;
                    this.Port = port;
                    connectedThread = new Thread(new ThreadStart(Connect));
                    connectedThread.Start();
                }

                public void Connect()
                {
                    client = new TcpClient();
                    try
                    {
                        client.Connect(Host, Port); //подключение клиента
                        stream = client.GetStream(); // получаем поток


                        JsonPack jsPack = new JsonPack();
                        JsonHeader jsHeader = new JsonHeader("reg");
                        jsHeader.setLoginPassword("login", "password");
                        jsHeader.setToken("12345");
                        JsonData jsData = new JsonData();
                        jsData.text = "Hello";
                        jsPack.data = jsData;
                        jsPack.header = jsHeader;
                        jsPack.SetSignature(Settings.Default.privateKey);
                        //SendMessage(jsPack.GetJsonStr());
                        byte[] data = Encoding.Unicode.GetBytes(jsPack.GetJsonStr());
                        stream.Write(data, 0, data.Length);

                        if (!client.Connected)
                            throw new NotImplementedException();

                        // запускаем новый поток для получения данных
                        receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                        receiveThread.Start(); //старт потока
                        isConnect = true;
                    }
                    catch (Exception ex)
                    {
                        isConnect = false;
                        Debug.WriteLine(ex.Message);
                        Debug.WriteLine("reconnect");
                        Thread.Sleep(1000);
                        Connect();
                    }
                    finally
                    {
                    }
                }
        */

        Image img_Delete = new Bitmap("");
        public Image getImg_Delete()
        {
            return img_Delete;
        }



        #endregion
    }
}
