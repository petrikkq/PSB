/* ОБОЗНАЧЕНИЕ ПРИЧИН УДАЛЕНИЯ СЕССИЙ ПОЛЬЗОВАТЕЛЯ:
 * 0 - БЛОКИРОВАНИЕ БОЛЕЕ ПРИОРИТЕНОГО ПОЛЬЗОВАТЕЛЯ;
 * 1 - БЛОКИРОВКА ПО ПРИЧИНЕ ОТСУТСТВИЯ ОГРАНИЧЕНИЯ НА БЛОКИРУЮЩЕГО ПОЛЬЗОВАТЕЛЯ;
 * 2 - СЕССИЯ ПОТРЕБЛЯЕТ CPU БОЛЬШЕ,ЧЕМ ПОЛОЖЕНО;
 * 3 - СЕССИЯ ПОТРЕБЛЯЕТ LOGICAL_READS БОЛЬШЕ,ЧЕМ ПОЛОЖЕНО;
 * 4 - СЕССИЯ ПОТРЕБЛЯЕТ RAM БОЛЬШЕ,ЧЕМ ПОЛОЖЕНО;
 * 5 - СЕССИЯ УДАЛЕНА АДМИНИСТРАТОРОМ 
 */

/* Форма Message.
* Язык: C#
* Краткое описание:
*   С помощью данной формы обычный пользователь может посмотреть свои уведомления.
* Переменные, используемые в форме:
*   cann - переменная, для соединения с базой данных;
*   d2 - переменная для чтения базы данных;
*   command - SQL – запрос.
* Функции, используемые в форме:
*   pictureBox4_Click - Открытие формы Information.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PSB
{

    public partial class Message : Form
    {
        SqlConnection cann;
        SqlDataReader d2;
        SqlCommand comand;
        public Message()
        {
            InitializeComponent();
            Label[] label = new Label[6];
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=UTMP;Integrated Security=True";
            cann = new SqlConnection(connectionString);
            cann.Open();
            string sql1 = "select SESSION_ID, MESSAGE from PRACTICE.INFORMATION WHERE LOGIN_ID = " + DataBank.id;
            comand = new SqlCommand(sql1, cann);
            DataTable t2 = new DataTable();
            d2 = comand.ExecuteReader();
            t2.Load(d2);
            int q = 0;
            for (int i = 0; i < t2.Rows.Count; i++)
            {
                if (t2.Rows[i]["MESSAGE"].ToString() != "")
                {
                    q = 1;
                    break;
                }
                label4.Text = "У Вас нет уведомлений";

            }
            if (q == 1)
            {
                for (int i = 0; i < t2.Rows.Count; i++)
                {
                    label[i] = new Label();
                    label[i].Location = new Point(12, 65 + 35 * i);
                    label[i].Font = new Font("Times New Roman", 12, System.Drawing.FontStyle.Bold);
                    label[i].ForeColor = Color.FromArgb(63, 169, 221);
                    label[i].AutoSize = true;
                    if (t2.Rows[i]["MESSAGE"].ToString() == "0")
                    {
                        label[i].Text = "Ваша сессия " + t2.Rows[i]["SESSION_ID"] + " блокирует более приоритетного пользователя";
                    }
                    else if (t2.Rows[i]["MESSAGE"].ToString() == "1")
                    {
                        label[i].Text = "Ваша сессия " + t2.Rows[i]["SESSION_ID"] + " блокирует пользователя с ограниченным доступом";
                    }
                    else if (t2.Rows[i]["MESSAGE"].ToString() == "5")
                    {
                        label[i].Text = "Ваша сессия " + t2.Rows[i]["SESSION_ID"] + " была удалена";
                    }
                    else if (t2.Rows[i]["MESSAGE"].ToString() == "2")
                    {
                        label[i].Text = "Ваша сессия " + t2.Rows[i]["SESSION_ID"] + " использует CPU больше, чем положено";
                    }
                    else if (t2.Rows[i]["MESSAGE"].ToString() == "3")
                    {
                        label[i].Text = "Ваша сессия " + t2.Rows[i]["SESSION_ID"] + " использует LOGICAL_READS больше, чем положено";
                    }
                    else if (t2.Rows[i]["MESSAGE"].ToString() == "4")
                    {
                        label[i].Text = "Ваша сессия " + t2.Rows[i]["SESSION_ID"] + " использует RAM больше, чем положено";
                    }
                    this.Controls.Add(label[i]);
                }
            }
            cann.Close();
        }

        /*pictureBox4_Click - закрытие формы.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
