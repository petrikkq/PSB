/*
* Выпускная квалификационная работа
* Тема: "Администрирование и мониторинг ресурсов базы данных"
* Разработал: Петров Даниил Дмитриевич, группа ТМП-81.
* Дата и номер версии: 14.05.2020 v2.0.
* Язык: C#.
* Класс используемый в программе:
*   petrikkq - модуль работы с базой данных.
* Формы используемые в программе:
*   Autorization - основная форма программы;
*   AdminForm - форма администратора;
*   Delete_sessions - форма удаления сессий;
*   Information - форма информации о разработчике;
*   Insert_Exception - форма добавления ограничений на пользователей;
*   Message - форма уведомлений пользователя;
*   Personal_data - форма регистрации нового пользователя;
*   Top_usage - форма просмотра топа пользователей по использованию ресурсов;
*   UserForm - форма обычного пользователя.
*/

/* Форма Autorization.
* Краткое описание:
*   С помощью данной формы происходит авторизация.
* Переменные, используемые в форме:
*   cann - переменная, для соединения с базой данных;
*   d2 - переменная для чтения базы данных;
*   command - SQL – запрос;
*   TogMove - переменная для возможности перетаскиваня формы;
*   argX - переменная для возможности перетаскиваня формы;
*   argY - переменная для возможности перетаскиваня формы.
* Функции, используемые в форме:
*   button1_click – авторизация по логину и паролю;
*   button3_click - закрытие программы;
*   textBox1_Click - Изменения дизайна поля для логина;
*   textBox1_Leave - Изменения дизайна поля для логина;
*   textBox2_Enter - Изменения дизайна поля для пароля;
*   textBox2_Leave - Изменения дизайна поля для пароля;
*   Autorization_MouseDown - Возможность перетаскивания формы;
*   Autorization_MouseUp - Возможность перетаскивания формы;
*   Autorization_MouseMove - Возможность перетаскивания формы;
*   pictureBox4_Click - Закрытие программы;
*   pictureBox5_Click - Свернуть программу;
*   pictureBox6_Click - Открытие формы Personal_data и открытие Microsoft Management Studio;
*   pictureBox7_Click - Открытие формы Information.
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
    public partial class Autorization : Form
    {
        SqlConnection cann;
        SqlDataReader d2;
        SqlCommand comand;
        int TogMove;
        int argX;
        int argY;
        public Autorization()
        {
            InitializeComponent();
            ToolTip t = new ToolTip();
            ToolTip t1 = new ToolTip();
            t.SetToolTip(pictureBox6, "Открыть Microsoft SQL Server Management Studio 18");
            t1.SetToolTip(pictureBox7, "Информация о разработчике");
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=UTMP;Integrated Security=True";
            cann = new SqlConnection(connectionString);
            cann.Open();
            string sql3 = "select * from PRACTICE.DIC_LOGINS";
            comand = new SqlCommand(sql3,cann);
            DataTable t2 = new DataTable();
            d2 = comand.ExecuteReader();
            t2.Load(d2);
            if (t2.Rows.Count == 0)
            {
                MessageBox.Show("Ваш Логин: sa. Пароль : 12345.","Информация",MessageBoxButtons.OK,MessageBoxIcon.Information);
                sql3 = "ALTER LOGIN sa WITH PASSWORD = '12345'; use UTMP; Insert into PRACTICE.DIC_LOGINS Select 'sa', '12345'";
                comand = new SqlCommand(sql3,cann);
                comand.ExecuteNonQuery();
            }
            cann.Close();
        }
        /*button1_Click - открытие формы Department.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        * Локальные переменные:
        *   connectionString - строка подключения;
        *   id1 - переменная для нахождения id;
        *   table – переменная для загрузки таблицы;
        *   f – переменная для открытия формы "UserForm";
        *   adminform - переменная для открытия формы "AdminForm".
        */
        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=UTMP;Integrated Security=True";
            cann = new SqlConnection(connectionString);
            petrikkq pl = new petrikkq();
            cann.Open();
            string sql1 = "select * from PRACTICE.DIC_LOGINS where LOGIN_NAME collate Cyrillic_General_CS_AS like '" + textBox1.Text + "' and "+
            "PASS collate Cyrillic_General_CS_AS like '" + textBox2.Text + "'";
            comand = new SqlCommand(sql1, cann);
            int id1 = pl.sqlcb("Select ID From PRACTICE.DIC_LOGINS Where LOGIN_NAME = '" + textBox1.Text + "' and PASS = '" + textBox2.Text + "'", connectionString) + 1;
            DataTable table = new DataTable();
            d2 = comand.ExecuteReader();
            table.Load(d2);
            if (textBox1.Text == "Имя пользователя" || textBox2.Text == "Пароль")
            {
                MessageBox.Show("Не все поля заполнены!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (table.Rows.Count == 0)
                {
                    MessageBox.Show("Пользователя с таким логином и паролем не существует!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (table.Rows[0]["LOGIN_NAME"].ToString() == textBox1.Text && table.Rows[0]["PASS"].ToString() == textBox2.Text && id1 == 1)
                    {
                        AdminForm adminForm = new AdminForm();
                        adminForm.Show();
                    }
                    else
                    {
                        DataBank.id = id1;
                        UserForm f = new UserForm();
                        f.Show();
                    }
                    this.Hide();
                }
            }
            cann.Close();
        }

        /*button3_Click - закрытие программы.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /*textBox1_Click - дизайн поля для логина.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Имя пользователя")
            {
                textBox1.Clear();
            }
            panel1.BackColor = Color.FromArgb(63,169,221);
            textBox1.ForeColor = Color.FromArgb(63, 169, 221);
        }

        /*textBox1_Leave - дизайн поля для логина.
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
                textBox1.Text = "Имя пользователя";
            }
        }

        /*textBox2_Enter - дизайн поля для пароля.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Пароль")
            {
                textBox2.Clear();
                textBox2.UseSystemPasswordChar = true;
            }
            panel3.BackColor = Color.FromArgb(63, 169, 221);
            textBox2.ForeColor = Color.FromArgb(63, 169, 221);
        }

        /*textBox2_Leave - дизайн поля для пароля.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
            textBox2.ForeColor = Color.WhiteSmoke;
            panel3.BackColor = Color.WhiteSmoke;
            if (textBox2.Text == "")
            {
                textBox2.Text = "Пароль";
                textBox2.UseSystemPasswordChar = false;
            }
        }

        /*Autorization_MouseDown - возможность перетаскивания формы.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void Autorization_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = 1;
            argX = e.X;
            argY = e.Y;
        }

        /*Autorization_MouseDown - возможность перетаскивания формы.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void Autorization_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

        /*Autorization_MouseDown - возможность перетаскивания формы.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void Autorization_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - argX,MousePosition.Y - argY);
            }
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

        /*pictureBox5_Click - свернуть программу.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        /*pictureBox6_Click - открытие формы Personal_data.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        * Локальная переменная:
        *   data - переменная для открытия формы "Personal_data".
        */
        private void pictureBox6_Click(object sender, EventArgs e)
        {
                Personal_data data = new Personal_data();
                data.Show();
        }

        /*pictureBox7_Click - открытие формы Information.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        * Локальная переменная:
        *   info - переменная для открытия формы "Information".
        */
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Information info = new Information();
            info.Show();
        }
    }
}