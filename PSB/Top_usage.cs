/* Форма Top_usage.
* Язык: C#
* Краткое описание:
*   Вывод топ пользователей по использованию ресурсов.
* Переменные, используемые в форме:
*   cann - переменная, для соединения с базой данных;
*   d2 - переменная для чтения базы данных;
*   command - SQL – запрос;
*   dt – переменная для загрузки таблицы.
* Функции, используемые в форме:
*   button1_Click – топ пользователей по использованию ресурсов;
*   textBox1_Leave – дизайн поля для ввода процента отображаемых пользователей;
*   textBox1_Click - дизайн поля для ввода процента отображаемых пользователей;
*   pictureBox4_Click - закрытие формы;
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
    public partial class Top_usage : Form
    {
        SqlConnection cann;
        SqlCommand comand;
        SqlDataReader d2;
        DataTable dt;
        public Top_usage()
        {
            InitializeComponent();
        }

        /*button1_Click - топ пользователей по использованию ресурсов.
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
                string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=UTMP;Integrated Security=True";
                cann = new SqlConnection(connectionString);
                cann.Open();
                if (comboBox1.Text == "Logical_reads")
                {
                    string sql1 = "exec practice.top_resource_usage " + textBox1.Text;
                    comand = new SqlCommand(sql1, cann);
                }
                else if (comboBox1.Text == "Cpu")
                {
                    string sql1 = "exec practice.top_resource_usage_CPU " + textBox1.Text;
                    comand = new SqlCommand(sql1, cann);
                }
                else if (comboBox1.Text == "Ram")
                {
                    string sql1 = "exec practice.top_resource_usage_Ram " + textBox1.Text;
                    comand = new SqlCommand(sql1, cann);
                }
                d2 = comand.ExecuteReader();
                dt = new DataTable();
                dt.Load(d2);
                bindingSource1.DataSource = dt;
                dataGridView1.DataSource = bindingSource1;
                cann.Close();
            }
            catch { }
        }

        /*textBox1_Click - дизайн поля для ввода процента отображаемых пользователей.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите значение")
            {
                textBox1.Clear();
            }
            panel1.BackColor = Color.FromArgb(63, 169, 221);
            textBox1.ForeColor = Color.FromArgb(63, 169, 221);
        }

        /*textBox1_Leave - дизайн поля для ввода процента отображаемых пользователей.
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
                textBox1.Text = "Введите значение";
            }
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
