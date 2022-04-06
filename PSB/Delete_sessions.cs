/* Форма Delete_sessions.
* Язык: C#
* Краткое описание:
*   С помощью данной формы происходит удаление сессий пользователей.
* Переменные, используемые в форме:
*   cann - переменная, для соединения с базой данных;
*   d2 - переменная для чтения базы данных;
*   command - SQL – запрос;
*   dt – переменная для загрузки таблицы.
* Функции, используемые в форме:
*   button1_Click - удаление и вывод удаленных сессий;
*   textBox1_KeyPress - ограничение на ввод символов;
*   pictureBox4_Click - закрытие формы;
*   textBox1_Click - дизайн поля для ввода Zhurnal_id;
*   textBox1_Click - дизайн поля для ввода Zhurnal_id.
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
    public partial class Delete_sessions : Form
    {
        SqlConnection cann;
        SqlCommand comand;
        SqlDataReader d2;
        DataTable dt;
        public Delete_sessions()
        {
            InitializeComponent();
        }

        /*button1_Click - открытие формы Department.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        * Локальные переменные:
        *   connectionString - строка подключения;
        *   sql1 - строка запроса.
        */
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "")
                {
                    string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=UTMP;Integrated Security=True";
                    cann = new SqlConnection(connectionString);
                    cann.Open();
                    string sql1 = "exec PRACTICE.DELETE_SESSION3 " + textBox1.Text + "; Select * from PRACTICE.DELETED_SESSIONS";
                    comand = new SqlCommand(sql1, cann);
                    d2 = comand.ExecuteReader();
                    dt = new DataTable();
                    dt.Load(d2);
                    bindingSource1.DataSource = dt;
                    dataGridView1.DataSource = bindingSource1;
                    cann.Close();
                }
                else MessageBox.Show("Вы не заполнили Zhurnal_id", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch { }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 48 || e.KeyChar >= 59) && e.KeyChar != 8)
                e.Handled = true;
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

        /*textBox1_Click - дизайн поля для ввода Zhurnal_id.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите Zhurnal_Id")
            {
                textBox1.Clear();
            }
            panel1.BackColor = Color.FromArgb(63, 169, 221);
            textBox1.ForeColor = Color.FromArgb(63, 169, 221);
        }

        /*textBox1_Leave - дизайн поля для ввода Zhurnal_id.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.ForeColor = Color.WhiteSmoke;
            panel1.BackColor = Color.WhiteSmoke;
            if (textBox1.Text == "")
            {
                textBox1.Text = "Введите Zhurnal_Id";
            }
        }
    }
}
