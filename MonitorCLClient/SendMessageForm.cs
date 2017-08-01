using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using MonitorCLClassLibrary;

namespace MonitorCLClient
{
    public partial class SendMessageForm : Form
    {
        const int minHeight = 385;
        const int maxHeight = 615;

        private ClientWork client;
        private Image BM = null;

        public SendMessageForm(ClientWork client=null)
        {
            InitializeComponent();
            this.client = client;
            this.Height = minHeight;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
            Thread.Sleep(250);
            BM = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics GH = Graphics.FromImage(BM as Image);
            GH.CopyFromScreen(0, 0, 0, 0, BM.Size);
            pictureBox1.Image = BM;
            //label3.Visible = true;
            Show();
            this.Height = maxHeight;
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if (tbSubject.Text == "")
                MessageBox.Show("Введите тему!");
            else
                if (rbBody.Text == "")
                MessageBox.Show("Введите сообщение!");
            else
            {
                client.SendSupport(tbSubject.Text, rbBody.Text, BM);
                MessageBox.Show("Письмо отправленое!" + Environment.NewLine + "Ожидайте специалист с вами свяжется.");
                Close();
            }
        }
    }
}
