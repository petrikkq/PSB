/* Форма Insert_Exception.
* Язык: C#
* Краткое описание:
*   С помощью данной формы происходит добавление ограничений на пользователя.
* Переменные, используемые в форме:
*   cann - переменная, для соединения с базой данных;
*   d2 - переменная для чтения базы данных;
*   command - SQL – запрос;
*   dt – переменная для загрузки таблицы.
* Функции, используемые в форме:
*   button1_Click - занесение данных в таблицу;
*   comboBox1_SelectedIndexChanged - ограничения на ввод данных в поля;
*   Insert_Exception_KeyPress - ограничение на ввод символов.
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
    public partial class Insert_Exception : Form
    {
        SqlConnection cann;
        SqlCommand comand;
        SqlDataReader d2;
        DataTable dt;
        public Insert_Exception()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
        }

        /*button1_Click - занесение данных в таблицу.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        * Локальные переменные:
        *   connectionString - строка подключения;
        *   sql1 - строка запроса;
        *   sql2 - строка запроса;
        *   sql3 - строка запроса.
        */
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=UTMP;Integrated Security=True";
            cann = new SqlConnection(connectionString);
            cann.Open();
            if (comboBox1.Text == "Time")
            {
            try {  
                textBox5.Enabled = false;
                string sql1 = "Insert Into practice.Exception Values (" + textBox1.Text + ",'" + textBox2.Text + "','" + textBox3.Text + "',null,null,'" + comboBox1.Text + "'," + textBox6.Text + "," + textBox7.Text + ")";
                comand = new SqlCommand(sql1, cann);
                comand.ExecuteNonQuery();
            }catch
            {
                MessageBox.Show("Вы неверно заполнили поля", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            }
            if (comboBox1.Text == "Exclusive")
            {
                string sql2 = "Insert Into practice.Exception Values (" + textBox1.Text + ", null, null, null, null,'" + comboBox1.Text + "'," + textBox6.Text + "," + textBox7.Text + ")";
                comand = new SqlCommand(sql2, cann);
                comand.ExecuteNonQuery();
            }
            if (comboBox1.Text == "Date")
            {
                try
                {
                    string sql3 = "Insert Into practice.Exception Values (" + textBox1.Text + ",null,null," + textBox4.Text + "," + textBox5.Text + ",'" + comboBox1.Text + "'," + textBox6.Text + "," + textBox7.Text + ")";
                    comand = new SqlCommand(sql3, cann);
                    comand.ExecuteNonQuery();
                }catch
                {
                    MessageBox.Show("Вы неверно заполнили поля", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            cann.Close();
            this.Close();
        }

        /*comboBox1_SelectedIndexChanged - ограничения на ввод данных в поля.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Exclusive")
            {
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
            }
            else if (comboBox1.Text == "Time")
            {
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
            }
            else if (comboBox1.Text == "Date")
            {
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
            }
        }

        /*Insert_Exception_KeyPress - ограничение на ввод символов.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        * Локальная переменная:
        *   number - вводимый символ.
        */
        private void Insert_Exception_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 58) 
            {
                e.Handled = true;
            }
        }
    }
}
