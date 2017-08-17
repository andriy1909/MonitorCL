using ServerAdapter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerAdapter
{
    public partial class Form1 : Form
    {
        static public TcpListenerEx tcpListener;// сервер для прослушивания
        private string IP = "127.0.0.1";
        private int Port = 11000;
        public List<ClientObject> clients = new List<ClientObject>();// все подключения
        private Thread listenerThread;

        public Form1()
        {
            InitializeComponent();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            StartListener();
        }

        public void ServerWrite(string message)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(ServerWrite), new object[] { message });
                return;
            }
            rtbServer.Text = message + Environment.NewLine + rtbServer.Text;
        }
        public void ClientWrite(string message)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action<string>(ClientWrite), new object[] { message });
                return;
            }
            rtbClient.Text = message + Environment.NewLine + rtbClient.Text;
        }

        public void StartListener()
        {
            listenerThread = new Thread(Listen);
            listenerThread.Start();
        }

        public void Listen()
        {
                tcpListener = new TcpListenerEx(IPAddress.Parse(IP), Port);
                tcpListener.Start();
                if (tcpListener.Active)
                {
                    ServerWrite("Сервер запущен.");
                }
                else
                {
                    ServerWrite("Сервер не запущен.");
                }

            try
            {
                while (true)
                {
                    TcpClient tcpClient = tcpListener.AcceptTcpClient();

                    ServerWrite("-new client");

                    ClientObject clientObject = new ClientObject(tcpClient, this);
                    clients.Add(clientObject);
                    Thread clientThread = new Thread(new ThreadStart(clientObject.Process));
                    clientThread.Start();
                }
            }
            catch(Exception err)
            {
                ServerWrite(err.Message);
            }
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            tcpListener.Stop();
            ServerWrite("Сервер Остановлен.");
        }

        private void btRestart_Click(object sender, EventArgs e)
        {
            if (tcpListener.Active)
            {
                tcpListener.Stop();
                ServerWrite("Сервер Остановлен.");
            }
            listenerThread = new Thread(Listen);
            listenerThread.Start();
        }
    }
}
