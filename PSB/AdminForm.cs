/* Форма AdminForm.
* Язык: C#
* Краткое описание:
*   С помощью данной формы происходит авторизация.
* Переменные, используемые в форме:
*   cann - переменная, для соединения с базой данных;
*   d2 - переменная для чтения базы данных;
*   command - SQL – запрос;
*   dt – переменная для загрузки таблицы.
* Функции, используемые в форме:
*   comboBox1_SelectedIndexChanged - выбор таблицы для просмотра информации;
*   button1_Click – генерация тестовых данных;
*   button2_Click – открытие формы Delete_sessions;
*   button3_Click - открытие формы Top_usage;
*   button4_Click - открытие формы Insert_Exception;
*   button5_Click - просмотр таблицы Information;
*   dataGridView1_CellClick - построение графика использования ресурсов;
*   button6_Click - изменение данных в таблице Exception;
*   button7_Click - удаление данных в таблице Exception;
*   pictureBox4_Click - закрытие программы;
*   pictureBox5_Click - свернуть программу.
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
    public partial class AdminForm : Form
    {
        SqlConnection cann;
        SqlCommand comand;
        SqlDataReader d2;
        DataTable dt;
        public AdminForm()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox1.SelectedIndex = 0;
            button1.Enabled = false;
            button1.Enabled = false;
            button4.Visible = false;
            textBox1.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            button7.Visible = false;

        }

        /*comboBox1_SelectedIndexChanged - выбор таблицы для просмотра информации.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        * Локальные переменные:
        *   connectionString - строка подключения;
        *   sql2 - строка запроса.
        */
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=UTMP;Integrated Security=True";
            cann = new SqlConnection(connectionString);
            cann.Open();
            if (comboBox1.Text == "Information")
            {
                label5.Text = "Введите Zhurnal_id";
                textBox1.Visible = true;
                button1.Enabled = true;
                button5.Visible = true;
            }
            else
            {
                button5.Visible = false;
                button1.Enabled = false;
                label5.Text = "";
                textBox1.Visible = false;
                string sql2 = "Select * From practice." + comboBox1.Text;
                comand = new SqlCommand(sql2, cann);
                d2 = comand.ExecuteReader();
                dt = new DataTable();
                dt.Load(d2);
                bindingSource1.DataSource = dt;
                dataGridView1.DataSource = bindingSource1;
            }
            if (comboBox1.Text == "Exception")
            {
                button6.Visible = true;
                button7.Visible = true;
                button1.Enabled = false;
                button4.Visible = true;
            } else
            {
                button4.Visible = false;
                button6.Visible = false;
                button7.Visible = false;
            }
            cann.Close();
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
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=UTMP;Integrated Security=True";
            cann = new SqlConnection(connectionString);
            cann.Open();
            string sql1 = "exec practice.Data_Generation1";
            comand = new SqlCommand(sql1, cann);
            comand.ExecuteNonQuery();
            cann.Close();
        }

        /*button2_Click - открытие формы Delete_sessisons.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        * Локальная переменная:
        *   delete_sessions - переменная для открытия формы "Delete_sessions".
        */
        private void button2_Click(object sender, EventArgs e)
        {
            Delete_sessions delete_sessions = new Delete_sessions();
            delete_sessions.ShowDialog();
        }

        /*button3_Click - открытие формы Top_usage.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        * Локальная переменная:
        *   top_usage - переменная для открытия формы "Top_usage".
        */
        private void button3_Click(object sender, EventArgs e)
        {
            Top_usage top_usage = new Top_usage();
            top_usage.ShowDialog();
        }

        /*button4_Click - открытие формы Insert_Exception.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        * Локальная переменная:
        *   insert_exception - переменная для открытия формы "Insert_Exception".
        */
        private void button4_Click(object sender, EventArgs e)
        {
            Insert_Exception insert_exception = new Insert_Exception();
            insert_exception.ShowDialog();
        }

        /*button5_Click - просмотр таблицы Information.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        * Локальные переменные:
        *   connectionString - строка подключения;
        *   sql1 - строка запроса.
        */
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=UTMP;Integrated Security=True";
                cann = new SqlConnection(connectionString);
                cann.Open();
                string sql1 = "Select ROW_NUMBER() OVER(ORDER BY a.zhurnal_id ASC) AS 'Row Number', a.* From practice." + comboBox1.Text + " a WHERE ZHURNAL_ID = " + textBox1.Text;
                comand = new SqlCommand(sql1, cann);
                d2 = comand.ExecuteReader();
                dt = new DataTable();
                dt.Load(d2);
                bindingSource1.DataSource = dt;
                dataGridView1.DataSource = bindingSource1;
                cann.Close();
            }
            catch
            {
            }
        }

        /*button5_Click - просмотр таблицы Information.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        * Локальные переменные:
        *   x - переменная для построения графика по количеству лоигческих чтений;
        *   y - переменная для построения графика по количеству лоигческих чтений;
        *   q - переменная для построения графика по использованию оперативной памяти;
        *   a - переменная для построения графика по использованию оперативной памяти;
        *   w - переменная для построения графика по использованию центрального процессора;
        *   s - переменная для построения графика по использованию центрального процессора.
        */
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                chart1.Series[0].Points.Clear();
                chart1.Series[1].Points.Clear();
                chart1.Series[2].Points.Clear();
                DataBank.id = e.RowIndex;
                DataBank.id1 = Convert.ToInt32(dataGridView1.Rows[DataBank.id].Cells[0].Value.ToString());
                if (comboBox1.Text == "Exception")
                {
                    if (dataGridView1.Rows[DataBank.id].Cells[6].Value.ToString() == "Exclusive")
                    {
                        dataGridView1.Rows[DataBank.id].Cells[2].ReadOnly = true;
                        dataGridView1.Rows[DataBank.id].Cells[3].ReadOnly = true;
                        dataGridView1.Rows[DataBank.id].Cells[4].ReadOnly = true;//..фыв
                        dataGridView1.Rows[DataBank.id].Cells[5].ReadOnly = true;
                    }
                    else if (dataGridView1.Rows[DataBank.id].Cells[6].Value.ToString() == "Time")
                    {
                        dataGridView1.Rows[DataBank.id].Cells[2].ReadOnly = false;
                        dataGridView1.Rows[DataBank.id].Cells[3].ReadOnly = false;
                        dataGridView1.Rows[DataBank.id].Cells[4].ReadOnly = true;
                        dataGridView1.Rows[DataBank.id].Cells[5].ReadOnly = true;
                    }
                    else if (dataGridView1.Rows[DataBank.id].Cells[6].Value.ToString() == "Date")
                    {
                        dataGridView1.Rows[DataBank.id].Cells[2].ReadOnly = true;
                        dataGridView1.Rows[DataBank.id].Cells[3].ReadOnly = true;
                        dataGridView1.Rows[DataBank.id].Cells[4].ReadOnly = false;
                        dataGridView1.Rows[DataBank.id].Cells[5].ReadOnly = false;
                    }
                }
                if (comboBox1.Text == "Information")
                {
                    int x = Convert.ToInt32(dataGridView1.Rows[DataBank.id].Cells[5].Value);
                    int y = Convert.ToInt32(dataGridView1.Rows[DataBank.id].Cells[2].Value);
                    chart1.Series[0].Points.AddXY(x, y);
                    int q = Convert.ToInt32(dataGridView1.Rows[DataBank.id].Cells[5].Value);
                    int a = Convert.ToInt32(dataGridView1.Rows[DataBank.id].Cells[7].Value);
                    chart1.Series[1].Points.AddXY(q, a);
                    int w = Convert.ToInt32(dataGridView1.Rows[DataBank.id].Cells[5].Value);
                    int s = Convert.ToInt32(dataGridView1.Rows[DataBank.id].Cells[3].Value);
                    chart1.Series[2].Points.AddXY(w, s);
                }
            }
            catch
            { 
            }
            
        }

        /*button6_Click - изменение данных в таблице Exception.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        * Локальные переменные:
        *   connectionString - строка подключения;
        *   sql1 - строка запроса.
        */
        private void button6_Click(object sender, EventArgs e)
        {

            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=UTMP;Integrated Security=True";
            cann = new SqlConnection(connectionString);
            cann.Open();
            try
            {
                if (dataGridView1.Rows[DataBank.id].Cells[6].Value.ToString() == "Exclusive")
                {
                    string sql11 = "Update PRACTICE.EXCEPTION Set LOGIN_ID = " + dataGridView1.Rows[DataBank.id].Cells[1].Value + "," +
                        "TIME_FROM = null,TIME_TO = null,DATE_FROM = null," +
                        "DATE_TO = null, EXCEPTION_TYPE = '" + dataGridView1.Rows[DataBank.id].Cells[6].Value + "',ZHURNAL_ID = " + dataGridView1.Rows[DataBank.id].Cells[7].Value + "" +
                        ",PRIORITY1 = " + dataGridView1.Rows[DataBank.id].Cells[8].Value + " where LOGIN_ID = " + dataGridView1.Rows[DataBank.id].Cells[1].Value;
                    comand = new SqlCommand(sql11, cann);
                    comand.ExecuteNonQuery();
                }
                if (dataGridView1.Rows[DataBank.id].Cells[6].Value.ToString() == "Time")
                {
                    string sql11 = "Update PRACTICE.EXCEPTION Set LOGIN_ID = " + dataGridView1.Rows[DataBank.id].Cells[1].Value + "," +
                        "TIME_FROM = '" + dataGridView1.Rows[DataBank.id].Cells[2].Value + "',TIME_TO = '" + dataGridView1.Rows[DataBank.id].Cells[3].Value + "',DATE_FROM = null," +
                        "DATE_TO = null, EXCEPTION_TYPE = '" + dataGridView1.Rows[DataBank.id].Cells[6].Value + "',ZHURNAL_ID = " + dataGridView1.Rows[DataBank.id].Cells[7].Value + "" +
                        ",PRIORITY1 = " + dataGridView1.Rows[DataBank.id].Cells[8].Value + " where LOGIN_ID = " + dataGridView1.Rows[DataBank.id].Cells[1].Value;
                    comand = new SqlCommand(sql11, cann);
                    comand.ExecuteNonQuery();
                }
                if (dataGridView1.Rows[DataBank.id].Cells[6].Value.ToString() == "Date")
                {
                    string sql11 = "Update PRACTICE.EXCEPTION Set LOGIN_ID = " + dataGridView1.Rows[DataBank.id].Cells[1].Value + "," +
                        "TIME_FROM = null,TIME_TO = null,DATE_FROM ='" + dataGridView1.Rows[DataBank.id].Cells[4].Value + "'," +
                        "DATE_TO = '" + dataGridView1.Rows[DataBank.id].Cells[5].Value + "', EXCEPTION_TYPE = '" + dataGridView1.Rows[DataBank.id].Cells[6].Value + "',ZHURNAL_ID = " + dataGridView1.Rows[DataBank.id].Cells[7].Value + "" +
                        ",PRIORITY1 = " + dataGridView1.Rows[DataBank.id].Cells[8].Value + " where LOGIN_ID = " + dataGridView1.Rows[DataBank.id].Cells[1].Value;
                    comand = new SqlCommand(sql11, cann);
                    comand.ExecuteNonQuery();
                }
            }
            catch { }
            cann.Close();
        }

        /*button7_Click - удаление данных в таблице Exception.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        * Локальные переменные:
        *   connectionString - строка подключения;
        *   sql1 - строка запроса.
        */
        private void button7_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=UTMP;Integrated Security=True";
            cann = new SqlConnection(connectionString);
            cann.Open();
                string sql11 = "Delete From PRACTICE.EXCEPTION WHERE ID = "+ DataBank.id1;
                comand = new SqlCommand(sql11, cann);
                comand.ExecuteNonQuery();
            cann.Close();
        }

        /*pictureBox5_Click - свернуть программу.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /*pictureBox4_Click - закрытие программы.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}