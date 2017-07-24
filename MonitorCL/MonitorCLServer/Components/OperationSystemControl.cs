using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MonitorCLServer
{
    public partial class OperationSystemControl : UserControl
    {
        public OperationSystemControl()
        {
            InitializeComponent();

            Dock = DockStyle.Fill;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public string[] descOS = "Операційна система;Номер зборки;Пакет оновлень;Назва комп'ютера;Часова зона;Рівень шифрування;Розмір оперативної пам'яті;Файл підкачки;Макс. розмір файла підкачки;Дата встановлення;Останій запуск ОС;Локальний час;Макс. памяті може бути виділено процесу;Кількість користувачів;Архітектура ОС;Тип системи;Головний користувач;Серійний номер;Статус;Диск на якому встановлена ОС;Версія ОС".Split(';');
        public string[] fieldOS = "Microsoft Windows 7 Профессиональная;7601;Service Pack 1;DELL-CORE2-01;UTC+3;256;3931,60МБ(4025968КБ);1754,33МБ(1796444КБ);3072МБ(3145728КБ);23.01.2017 10:16:42;20.07.2017 9:02:14;20.07.2017 12:28:50;7,99ТБ(8589934464КБ);1;64-bit;Рабочая станция;Dell;00371-OEM-9306127-90311;OK;C:;6.1.7601".Split(';');

        private void OperationSystemControl_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < fieldOS.Length; i++)
            {
                dataGridView1.Rows.Add(new object[] { imageList1.Images[i], descOS[i], fieldOS[i] });
            }
        }
    }
}