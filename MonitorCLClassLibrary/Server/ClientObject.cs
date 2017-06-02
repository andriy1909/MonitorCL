using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MonitorCLClassLibrary;
using System.Diagnostics;
using JSON;

namespace MonitorCLClassLibrary
{
    public class ClientObject
    {
        public User user = new User();
        public NetworkStream Stream { get; private set; }
        public TcpClient client;
        ServerObject server; // объект сервера

        MonitoringDB db = new MonitoringDB();



        public ClientObject()
        {

        }

        public ClientObject(TcpClient tcpClient, ServerObject serverObject)
        {
            client = tcpClient;
            server = serverObject;
            Stream = client.GetStream();
            //serverObject.AddConnection(this);
        }

        public ResultCode TryLogin()
        {
            JsonPack jsPack = GetMessage();
          //  if (jsPack == null)
                return ResultCode.Error;

        /*    switch (jsPack.header.metod)
            {
                case Metods.Regisration:
                    List<User> users = db.Users.ToList();
                    User user = users.Find(x => x.Login == jsPack.header.login);
                    if (user!= null)
                        return StateUser.LoginExist;
                    else
                    {
                        user = new User()
                        {
                            Login = jsPack.header.login,
                            Password=jsPack.header.password
                            //Name=
                        }

                        return StateUser.Login;
                    }
                case Metods.Login:
                    users = db.Users.ToList();
                    user = users.Find(x => x.Login == jsPack.header.login);
                    //if (user!=null)
                    return 0;
                default:
                    return 0;
            }*/
        }
        // чтение входящего сообщения и преобразование в строку
        public JsonPack GetMessage()
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

            JsonPack jsPack = new JsonPack();
            if (jsPack.GetJson(builder.ToString()))
            {
                return jsPack;
            }
            else
            {
                return null;
            }

        }












     /*   ReceiveDelegate receiveOut;
        public string login = "";

        public string Id { get; protected set; }

        public void setId(string id)
        {
            Id = id;
        }

        public void setReceiveOut(ReceiveDelegate receive)
        {
            receiveOut = receive;
        }
        */

        // чтение входящего сообщения и преобразование в строку
        public string GetMessage0()
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

            /*
                        string message = builder.ToString();
                        JsonPack jsPack = new JsonPack();
                        jsPack.GetJson(message);
                        if (jsPack.CheckTime(1000000) && jsPack.CheckSignature(Properties.Settings.Default.privateKey) && jsPack.header.getLoginPassword() == "login:password" && jsPack.header.metod == "")
                            switch (jsPack.header.metod)
                            {
                                case "cmd":

                                    break;
                                default:
                                    break;
                            }*/
            return builder.ToString();
        }


        // закрытие подключения
        public void Close()
        {
            if (Stream != null)
                Stream.Close();
            if (client != null)
                client.Close();
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
              //          string message = GetMessage();
               //         receiveOut(message);
                    }
                    catch (Exception err)
                    {
                        Debug.WriteLine("Error process : {0}", err.Message);
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
                // в случае выхода из цикла закрываем ресурсы
    //            server.RemoveConnection(this.Id);
                Debug.WriteLine("выход из Process()");
                Close();
            }
        }
    }
}
