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

namespace MonitorCLClassLibrary
{
    public class ClientWork : IDisposable
    {
        public User user = new User();
        public string Host { get; set; } 
        public int Port { get; set; } 
        TcpClient client;
        NetworkStream stream;

        Thread thread;

        public void Connect()
        {
            thread = new Thread(new ThreadStart(ConnectThread));
            thread.Start();
        }

        private void ConnectThread()
        {
            client = new TcpClient();
            try
            {
                client.Connect(Host, Port); //подключение клиента
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
                isConnect = true;
            }
            catch (Exception ex)
            {
                isConnect = false;
                Debug.WriteLine(ex.Message);
                Debug.WriteLine("reconnect");
                Thread.Sleep(1000);
                ConnectThread();
            }
            finally
            {
            }
        }





        public delegate void ReceiveDelegate(string message);
        public delegate void IsConnected(bool check);
        ReceiveDelegate receiveOut;
        IsConnected isConnectedOut;
        private Thread receiveThread;
        private Thread connectedThread;
        private int countEmpty = 0;
        private bool isConnect = false;


        public bool IsConnect
        {
            get { return isConnect; }
        }

        public void setReceiveOut(ReceiveDelegate receive)
        {
            receiveOut = receive;
        }

        public void setIsConnectOut(IsConnected isConnected)
        {
            isConnectedOut = isConnected;
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

        Image img;
        public void SendSupport(string subject, string body, Image screen)
        {
            /*  JsonPack jp = new JsonPack();
              jp.login = "1";
              jp.password = "2";

              ImageConverter converter = new ImageConverter();
              var bytes = (byte[])converter.ConvertTo(screen, typeof(byte[]));
              List<byte[]> list = new List<byte[]>();
              list.Add(bytes);
              jp.images = list;

              string str = jp.getJsonStr();

              var ms = new MemoryStream(jp.getJson(str).images[0]);
              Image image = Image.FromStream(ms);

              img = image;*/
            //throw new NotImplementedException();
        }
        public Image getImg()
        {
            return img;
        }


        // отправка сообщений
        public void SendMessage(string message)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);
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
          //                  Connect(host, port, idClient, login, password);
                        continue;
                    }
                    else
                        countEmpty = 0;


                    string message = builder.ToString();
              /*      JsonPack jsPack = new JsonPack();
                    jsPack.GetJson(message);
                    if (jsPack.CheckTime(1000000) && jsPack.CheckSignature(Settings.Default.privateKey))
                        if (jsPack.header.metod == "cmd")
                        {
                            message = jsPack.data.text;
                        }
                        */
                    receiveOut(message);
                }
                catch
                {
                    Debug.WriteLine("Подключение прервано!"); //соединение было прервано
                    Disconnect();
        //            Connect(host, port, idClient, login, password);
                }
            }
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
    }
}
