using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorCLServer
{
    class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#pragma warning disable CS0436 // Тип конфликтует с импортированным типом
            Application.Run(new MainForm());
#pragma warning restore CS0436 // Тип конфликтует с импортированным типом
        }
    }
}
