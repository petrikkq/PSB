/* Форма Personal_data.
* Язык: C#
* Краткое описание:
*   С помощью данной формы происходит регистрация нового пользователя.
* Функции, используемые в форме:
*   button1_click – добавление нового пользователя в БД;
*   textBox1_KeyPress - проверка на ввод символов;
*   textBox2_KeyPress - проверка на ввод символов;
*   pictureBox4_Click - Закрытие формы.
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
using System.Diagnostics;

namespace PSB
{
    public partial class Personal_data : Form
    {

        public Personal_data()
        {
            InitializeComponent();            
        }

        /*pictureBox4_Click - закрытие программы.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*button1_Click - регистрация нового пользователя.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        * Локальные переменные:
        *   connectionString - строка подключения;
        *   cann - переменная, для соединения с базой данных;
        *   d2 - переменная для чтения базы данных;
        *   command - SQL – запрос;
        *   sql - строка запроса;
        *   sql2 - строка запроса;
        *   proccessName - строка названия Management Studio.
        */
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cann;
            SqlCommand comand;
            SqlDataReader d2;
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=UTMP;Integrated Security=True";
            cann = new SqlConnection(connectionString);
            cann.Open();
            try
            {
                string sql = "insert into PRACTICE.DIC_LOGINS select '" + textBox1.Text + "','" + textBox2.Text + "'";
                comand = new SqlCommand(sql, cann);
                comand.ExecuteNonQuery();
                string sql2 = "use UTMP; create login " + textBox1.Text + " with password = '" + textBox2.Text + "'; create user " + textBox1.Text + " For login " + textBox1.Text + "; Alter role db_owner ADD MEMBER " + textBox1.Text + ";DENY SELECT, INSERT, UPDATE, DELETE ON SCHEMA ::PRACTICE TO " + textBox1.Text;
                comand = new SqlCommand(sql2, cann);
                comand.ExecuteNonQuery();
                cann.Close();
                this.Close();
                string proccessName = "SSMS";
                if (Process.GetProcessesByName(proccessName).Any() == true)
                {
                    MessageBox.Show("Приложение уже запущено!", "Информация!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Process.Start("C:/Program Files (x86)/Microsoft SQL Server Management Studio 18/Common7/IDE/Ssms.exe");
                }
            }
            catch
            {
                MessageBox.Show("Недопустимый формат логина или пароля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /*textBox1_KeyPress - проверка на ввод символов.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '_' || e.KeyChar == (char)Keys.Back)
            {
            }
            else
            {
                e.Handled = true;
            }
            textBox1.MaxLength = 8;
        }

        /*textBox2_KeyPress - проверка на ввод символов.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == '_' || e.KeyChar == (char)Keys.Back)
            {
            }
            else
            {
                e.Handled = true;
            }
            textBox2.MaxLength = 8;
        }
    }
}
