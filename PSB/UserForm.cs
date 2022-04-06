/* Форма UserForm.
* Язык: C#
* Краткое описание:
*   С помощью данной формы обычный пользователь может посмотреть даннные о своих сессиях.
* Переменные, используемые в форме:
*   cann - переменная, для соединения с базой данных;
*   d2 - переменная для чтения базы данных;
*   command - SQL – запрос;
*   TogMove - переменная для возможности перетаскиваня формы;
*   argX - переменная для возможности перетаскиваня формы;
*   argY - переменная для возможности перетаскиваня формы.
* Функции, используемые в форме:
*   dataGridView1_CellClick – построение графика использования ресурсов;
*   UserForm_MouseDown - Возможность перетаскивания формы;
*   UserForm_MouseUp - возможность перетаскивания формы;
*   UserForm_MouseMove - возможность перетаскивания формы;
*   pictureBox4_Click - закрытие программы;
*   pictureBox5_Click - свернуть программу;
*   pictureBox1_Click - открытие формы Message.
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
    public partial class UserForm : Form
    {
        SqlConnection cann;
        SqlDataReader d2;
        SqlCommand comand;
        DataTable dt;
        int TogMove;
        int argX;
        int argY;
        public UserForm()
        {
            InitializeComponent();
            ToolTip t = new ToolTip();
            t.SetToolTip(pictureBox1, "Уведомления");
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=UTMP;Integrated Security=True";
            cann = new SqlConnection(connectionString);
            cann.Open();
            string sql = "select SESSION_ID AS 'ID СЕССИИ',LOGICAL_READS AS 'КОЛ-ВО ЛОГИЧЕСИХ ЧТЕНИЙ', CPU_USAGE AS 'ИСПОЛЬЗОВАНИЕ ЦП', LOGIN_ID AS 'ID ПОЛЬЗОВАТЕЛЯ', TIME_IN_OPERATION_IN_MINUTES AS 'ВРЕМЯ В РАБОТЕ(МИН)', ZHURNAL_ID AS 'ID ЖУРНАЛА', RAM_USAGE AS 'ИСПОЛЬЗОВАНИЕ ОП' from PRACTICE.INFORMATION where LOGIN_ID = " + DataBank.id;
            comand = new SqlCommand(sql,cann);
            d2 = comand.ExecuteReader();
            dt = new DataTable();
            dt.Load(d2);
            bindingSource1.DataSource = dt;
            dataGridView1.DataSource = bindingSource1;
            string sql1 = "Select LOGIN_NAME From PRACTICE.DIC_LOGINS Where ID = " + DataBank.id;
            comand = new SqlCommand(sql1,cann);
            d2 = comand.ExecuteReader();
            d2.Read();
            object Login = d2.GetValue(0);
            label1.Text = Login.ToString();
            d2.Close();
            cann.Close();
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

        /*dataGridView1_CellClick - построение графика использования ресурсов.
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
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            DataBank.id1 = e.RowIndex;
            try
            {
                int x = Convert.ToInt32(dataGridView1.Rows[DataBank.id1].Cells["ВРЕМЯ В РАБОТЕ(МИН)"].Value);
                int y = Convert.ToInt32(dataGridView1.Rows[DataBank.id1].Cells["КОЛ-ВО ЛОГИЧЕСИХ ЧТЕНИЙ"].Value);
                chart1.Series[0].Points.AddXY(x, y);
                int q = Convert.ToInt32(dataGridView1.Rows[DataBank.id1].Cells["ВРЕМЯ В РАБОТЕ(МИН)"].Value);
                int a = Convert.ToInt32(dataGridView1.Rows[DataBank.id1].Cells["ИСПОЛЬЗОВАНИЕ ОП"].Value);
                chart1.Series[1].Points.AddXY(q, a);
                int w = Convert.ToInt32(dataGridView1.Rows[DataBank.id1].Cells["ВРЕМЯ В РАБОТЕ(МИН)"].Value);
                int s = Convert.ToInt32(dataGridView1.Rows[DataBank.id1].Cells["ИСПОЛЬЗОВАНИЕ ЦП"].Value);
                chart1.Series[2].Points.AddXY(w, s);
            }
            catch
            {
            }
        }

        /*UserForm_MouseUp - возможность перетаскивания формы.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void UserForm_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

        /*UserForm_MouseDown - возможность перетаскивания формы.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void UserForm_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = 1;
            argX = e.X;
            argY = e.Y;
        }

        /*UserForm_MouseMove - возможность перетаскивания формы.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void UserForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - argX, MousePosition.Y - argY);
            }
        }

        /*pictureBox1_Click - открытие формы Message.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        * Локальная переменная:
        *   message - переменная для открытия формы "Message".
        */
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Message message = new Message();
            message.ShowDialog();
        }
    }
}
