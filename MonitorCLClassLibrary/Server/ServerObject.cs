using MonitorCLClassLibrary.JSON;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace MonitorCLClassLibrary
{
    public class ServerObject
    {
        static public TcpListenerEx tcpListener;// сервер для прослушивания
        private string IP;
        private int Port;
        public List<ClientObject> clients = new List<ClientObject>();// все подключения
        private Thread listenerThread;

        public ServerObject()
        {

        }

        public void StartListener(string ip, int port)
        {
            IP = ip;
            Port = port;
            listenerThread = new Thread(Listen);
            listenerThread.Start();
        }

        public void Listen()
        {
            try
            {
                tcpListener = new TcpListenerEx(IPAddress.Parse(IP), Port);
                tcpListener.Start();
                Debug.WriteLine("Сервер запущен.");

                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();

                    ClientObject clientObject = new ClientObject(tcpClient, this);
                    AddConnection(clientObject);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Disconnect();
            }
        }

        public void AddConnection(ClientObject clientObject)
        {
            JsonPack json = clientObject.GetMessage();
            switch (json.metod)
            {
                case "JSDRegister":

                    break;
                case "JSDLogin":

                    throw new NotImplementedException();
                    break;
                default:
                    break;
            }

            if (clientObject.TryLogin() == ResultCode.Login)
            {
                Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                clientThread.Start();
            }
        }












        public void RemoveConnection(string login)
        {
            // получаем по id закрытое подключение
            //  ClientObject client = clients.FirstOrDefault(c => c.login == login);
            // и удаляем его из списка подключений
            //   if (client != null)
            //       clients.Remove(client);
        }







        public delegate void ReceiveDelegate(string message);

        public ReceiveDelegate receiveOut;

        public void setReceiveOut(ReceiveDelegate receive)
        {
            receiveOut = receive;
        }

        public void setConnectIpAndPort(string ip, int port)
        {
            IP = ip;
            Port = port;
        }

        public void Listen(int u)
        {
            try
            {
                tcpListener = new TcpListenerEx(IPAddress.Parse(IP), Port);
                tcpListener.Start();
                Debug.WriteLine("Сервер запущен.");

                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();

                    ClientObject clientObject = new ClientObject(tcpClient, this);
                    //clientObject.setReceiveOut(receiveOut);
                    //clientObject.setId(clientObject.GetMessage());
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Disconnect();
            }
        }

        // отключение всех клиентов
        public void Disconnect()
        {
            //***остановка сервера только после закрития всех подключений**

            tcpListener.Stop(); //остановка сервера

            for (int i = 0; i < clients.Count; i++)
            {
                clients[i].Close(); //отключение клиента
            }
            //     Environment.Exit(0); //завершение процесса
        }

        // трансляция сообщения подключенным клиентам
        public void BroadcastMessage(string message, string id)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);

            //   ClientObject client = clients.Find(x => x.Id == id);
            //   if (client != null)
            {
                //      client.Stream.Write(data, 0, data.Length); //передача данных
            }
        }

        // трансляция сообщения подключенным клиентам
        public void BroadcastMessage(string message, ClientObject client)
        {
            byte[] data = Encoding.Unicode.GetBytes(message);

            if (client != null)
            {
                client.Stream.Write(data, 0, data.Length); //передача данных
            }
            else
            {
                Debug.WriteLine("Error no client");
            }
        }
        public void BroadcastMessage(string message)
        {
            ClientObject client = clients.First();
            byte[] data = Encoding.Unicode.GetBytes(message);

            if (client != null)
            {
                client.Stream.Write(data, 0, data.Length); //передача данных
            }
            else
            {
                Debug.WriteLine("Error no client");
            }
        }

        public void SaveUserList()
        {
            string pathToFile = "";// Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\" + Application.CompanyName + "\\" + Application.ProductName;
            if (!Directory.Exists(pathToFile))
                Directory.CreateDirectory(pathToFile);

            FileStream stream = new FileStream(pathToFile + "\\Users.data", FileMode.OpenOrCreate, FileAccess.Write);

            TripleDESCryptoServiceProvider cryptic = new TripleDESCryptoServiceProvider();

            cryptic.Key = ASCIIEncoding.ASCII.GetBytes("a6200ebd6482c34649dce491");
            cryptic.IV = ASCIIEncoding.ASCII.GetBytes("a54e8d95");

            CryptoStream crStream = new CryptoStream(stream,
               cryptic.CreateEncryptor(), CryptoStreamMode.Write);


            byte[] data = ASCIIEncoding.ASCII.GetBytes("Hello World!");

            crStream.Write(data, 0, data.Length);

            crStream.Close();
            stream.Close();
        }

        public void LoadUserList()
        {
            string pathToFile = "";// Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\" + Application.CompanyName + "\\" + Application.ProductName;
            if (!Directory.Exists(pathToFile))
                Directory.CreateDirectory(pathToFile);

            if (File.Exists(pathToFile + "\\Users.data"))
            {
                FileStream stream = new FileStream(pathToFile + "\\Users.data", FileMode.Open, FileAccess.Read);

                TripleDESCryptoServiceProvider cryptic = new TripleDESCryptoServiceProvider();

                cryptic.Key = ASCIIEncoding.ASCII.GetBytes("a6200ebd6482c34649dce491");
                cryptic.IV = ASCIIEncoding.ASCII.GetBytes("a54e8d95");

                CryptoStream crStream = new CryptoStream(stream,
                    cryptic.CreateDecryptor(), CryptoStreamMode.Read);

                StreamReader reader = new StreamReader(crStream);

                string data = reader.ReadToEnd();
                Console.WriteLine(data);
                Console.ReadKey();

                reader.Close();
                stream.Close();
            }
        }

        /// <summary>
        /// Криптование и запись объекта в бинарный файл.
        /// </summary>
        /// <param name="obj">Объект для сериализации, криптования и записи.</param>
        /// <param name="fileName">Целевой файл.</param>
        public void EncryptBinarySave(object obj, string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);

            try
            {
                byte[] key = Encoding.ASCII.GetBytes("4c80926c217b8ccd");
                RijndaelManaged RMCrypto = new RijndaelManaged();
                CryptoStream cryptStream = new CryptoStream(fs, RMCrypto.CreateEncryptor(key, null), CryptoStreamMode.Write);

                BinaryFormatter ft = new BinaryFormatter();
                ft.Serialize(cryptStream, clients);
                cryptStream.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Failed to encrypt. Reason: " + e.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        /// <summary>
        /// Загрузка и декриптование из бинарного файла.
        /// </summary>
        /// <param name="fileName">Исходный файл.</param>
        public void DecryptBinaryLoad(string fileName)
        {
            string pathToFile = "";// Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\" + Application.CompanyName + "\\" + Application.ProductName;
            if (!Directory.Exists(pathToFile))
                Directory.CreateDirectory(pathToFile);

            if (File.Exists(pathToFile + "\\Users.data"))
            {
                FileStream fs = new FileStream(fileName, FileMode.Open);

                try
                {
                    byte[] key = Encoding.ASCII.GetBytes("4c80926c217b8ccd");
                    RijndaelManaged RMCrypto = new RijndaelManaged();
                    CryptoStream cryptStream = new CryptoStream(fs, RMCrypto.CreateDecryptor(key, null), CryptoStreamMode.Read);

                    BinaryFormatter formatter = new BinaryFormatter();
                    clients = (List<ClientObject>)formatter.Deserialize(cryptStream);
                    cryptStream.Close();
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Failed to decrypt. Reason: " + e.Message);
                }
                finally
                {
                    fs.Close();
                }
            }
        }

        public void SendCommad(string command)
        {
            /*    JsonPack jsPack = new JsonPack();
                JsonHeader jsHeader = new JsonHeader("cmd");
                JsonData jsData = new JsonData();
                jsData.text = command;
                jsPack.data = jsData;
                jsPack.header = jsHeader;
                jsPack.SetSignature(Settings.Default.privateKey);
                BroadcastMessage(jsPack.GetJsonStr(), clients[0]);*/
        }
    }
}
