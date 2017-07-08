using MonitorCLClient.Properties;
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

namespace MonitorCLClient
{
    public class ClientWork : IDisposable
    {
        private string login = "";
        private string password = "";
        private string host = "127.0.0.1";
        private int port = 11000;
        private Guid idClient = Guid.Empty;
        TcpClient client;
        NetworkStream stream;
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

        public void Connect(string ip, int port, Guid id, string login, string password)
        {
            this.login = login;
            this.password = password;
            host = ip;
            this.port = port;
            connectedThread = new Thread(new ThreadStart(Connect));
            connectedThread.Start();
        }

        public void Connect()
        {
            client = new TcpClient();
            try
            {
                client.Connect(host, port); //подключение клиента
                stream = client.GetStream(); // получаем поток

           //     byte[] data = Encoding.Unicode.GetBytes(id.ToString());
           //     stream.Write(data, 0, data.Length);

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


        Image img;
        public void SendSupport(string subject, string body, Image screen)
        {
            JsonPack jp = new JsonPack();
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

            img = image;
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
                            Connect(host, port, idClient, login, password);
                        continue;
                    }
                    else
                        countEmpty = 0;

                    receiveOut(builder.ToString());
                }
                catch
                {
                    Debug.WriteLine("Подключение прервано!"); //соединение было прервано
                    Disconnect();
                    Connect(host, port, idClient, login, password);
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
   