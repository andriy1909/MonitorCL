using MonitorCLClassLibrary;
using MonitorCLServer.Properties;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorCLServer
{
    public class ServerObject
    {
        /// <summary>
        /// сервер для прослушивания
        /// </summary>
        static public TcpListenerEx tcpListener;
        public string IP { get; protected set; }
        public int Port { get; protected set; }

        /// <summary>
        /// все подключения
        /// </summary>
        public List<ClientObject> clients = new List<ClientObject>();

        public delegate void ReceiveDelegate(string message);

        public ReceiveDelegate receiveOut;

        public ServerObject()
        {

        }

        public void AddConnection(ClientObject clientObject)
        {
            string message = clientObject.GetMessage();
            JsonPack jsPack = new JsonPack();
            jsPack.GetJson(message);
            if (jsPack.CheckTime(1000000) && jsPack.CheckSignature(Settings.Default.privateKey) && jsPack.header.getLoginPassword()=="login:password")
                clients.Add(clientObject);
            else
                clientObject.Close();
        }
        public void RemoveConnection(string id)
        {
            // получаем по id закрытое подключение
            ClientObject client = clients.FirstOrDefault(c => c.Id == id);
            // и удаляем его из списка подключений
            if (client != null)
                clients.Remove(client);
        }

        public void setReceiveOut(ReceiveDelegate receive)
        {
            receiveOut = receive;
        }

        public void setConnectIpAndPort(string ip, int port)
        {
            IP = ip;
            Port = port;
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
                    clientObject.setReceiveOut(receiveOut);
                    clientObject.setId(clientObject.GetMessage());
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

            ClientObject client = clients.Find(x => x.Id == id);
            if (client != null)
            {
                client.Stream.Write(data, 0, data.Length); //передача данных
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

        public void SaveUserList()
        {
            string pathToFile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\" + Application.CompanyName + "\\" + Application.ProductName;
            if (!Directory.Exists(pathToFile))
                Directory.CreateDirectory(pathToFile);

            FileStream stream = new FileStream(pathToFile+ "\\Users.data", FileMode.OpenOrCreate, FileAccess.Write);

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
            string pathToFile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\" + Application.CompanyName + "\\" + Application.ProductName;
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
            string pathToFile = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\" + Application.CompanyName + "\\" + Application.ProductName;
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
    }
}
