using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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
            clients.Add(clientObject);
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

    }
}
