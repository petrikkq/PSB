/* Форма Information.
* Язык: C#
* Краткое описание:
*   С помощью данной формы происходит авторизация.
* Переменные, используемые в форме:
*   TogMove - переменная для возможности перетаскиваня формы;
*   argX - переменная для возможности перетаскиваня формы;
*   argY - переменная для возможности перетаскиваня формы.
* Функции, используемые в форме:
*   Information_MouseDown - возможность перетаскивания формы;
*   Information_MouseUp - возможность перетаскивания формы;
*   Information_MouseMove - возможность перетаскивания формы;
*   pictureBox2_Click - закрытие программы;
*   pictureBox3_Click - закрытие программы;
*   pictureBox4_Click - закрытие программы.
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
using System.Diagnostics;

namespace PSB
{
    public partial class Information : Form
    {
        public Information()
        {
            InitializeComponent();
        }
        /*pictureBox3_Click - закрыть форму.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /*pictureBox3_Click - отыкрытие страницы ВКонтакте.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://vk.com/luke_skypetrik");
        }

        /*pictureBox3_Click - отыкрытие страницы Instagram.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.instagram.com/petrikkq/");
        }

        //Возможность перетаскивания формы 

        int TogMove;
        int argX;
        int argY;

        /*Information_MouseDown - возможность перетаскивания формы.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void Information_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = 1;
            argX = e.X;
            argY = e.Y;
        }

        /*Information_MouseDown - возможность перетаскивания формы.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void Information_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

        /*Information_MouseDown - возможность перетаскивания формы.
        * Формальные параметры:
        *   sender - элемент управления, вызывающий эту функцию;
        *   e - аргументы события.
        */
        private void Information_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove == 1)
            {
                this.SetDesktopLocation(MousePosition.X - argX, MousePosition.Y - argY);
            }
        }
    }
}
