using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ServerAdapter
{
    public class ClientObject
    {
        public NetworkStream Stream { get; private set; }
        public TcpClient client;
        Form1 server; // объект сервера


        public ClientObject()
        {

        }

        public ClientObject(TcpClient tcpClient, Form1 serverObject)
        {
            client = tcpClient;
            server = serverObject;
            Stream = client.GetStream();
            //serverObject.AddConnection(this);
        }

        public void Process()
        {
            try
            {
                /* if (Id == "" || Id == "-1" || Id == null)
                 {
                     Id = Guid.NewGuid().ToString();
                     server.BroadcastMessage("<id=" + Id + ">", this);
                 }
                 else
                 {
                     server.BroadcastMessage("<id=OK>", this);
                 }
                 */
                // в бесконечном цикле получаем сообщения от клиента
                while (true)
                {
                    try
                    {
                                  string message = GetMessage();
                        server.ClientWrite(message);
                        //         receiveOut(message);
                    }
                    catch (Exception err)
                    {
                        server.ServerWrite("Error process : "+ err.Message);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                server.ServerWrite("выход из Process()");
            }
        }

        public string GetMessage()
        {
            byte[] data = new byte[256]; // буфер для получаемых данных
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = Stream.Read(data, 0, data.Length);
                builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                if (builder.ToString() == "")
                {
                    continue;
                }
            }
            while (Stream.DataAvailable);

            return builder.ToString();
            
        }
    }
}