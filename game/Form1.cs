using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graphics g;
        const int n = 100, m = 100; const int size = 30;
        //public Rectangle[,] rectangle = new Rectangle[n, m];
        public Rect[,] rectangle = new Rect[n, m];
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        Pen blackPen = new Pen(Color.Black,1);
        bool mouse = false;

        public struct Rect
        {
            public Rectangle rect;
            public Color color;
            public int counter;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = Application.OpenForms[0].CreateGraphics();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    rectangle[i, j].rect = new Rectangle(i * size, j * size + 30, size, size);
                    rectangle[i, j].counter = 0;
                    g.DrawRectangle(blackPen, rectangle[i, j].rect);
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouse = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            if (mouse)
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if ((e.Y >= rectangle[i, j].rect.Location.Y + 1) &&
                        (e.Y <= (rectangle[i, j].rect.Location.Y + size)) &&
                        (e.X >= rectangle[i, j].rect.Location.X + 1) &&
                        (e.X <= (rectangle[i, j].rect.Location.X + size)))
                        {
                            g.FillRectangle(blackBrush, rectangle[i, j].rect);
                            rectangle[i, j].color = Color.Black;
                        }

                    }
                }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (rectangle[i, j].color == Color.Black)
                    {
                        //MessageBox.Show(i + " " + j);
                        rectangle[i - 1, j - 1].counter++;
                        rectangle[i - 1, j].counter++;
                        rectangle[i - 1, j + 1].counter++;
                        rectangle[i, j - 1].counter++;
                        rectangle[i, j].counter++;
                        rectangle[i, j + 1].counter++;
                        rectangle[i + 1, j - 1].counter++;
                        rectangle[i + 1, j].counter++;
                        rectangle[i + 1, j + 1].counter++;
                    }
                }
            }
        }

        /// <summary>
        ///  кнопка старт/стоп
        /// </summary>
        /// <param name="sender">сендер</param>
        /// <param name="e">эвент мыши(обращение к ней)</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start")
            {
                button1.Text = "Stop";
                timer1.Enabled = true;
            }
            else
            {
                button1.Text = "Start";
                timer1.Enabled = false;
            }
        }

        /// <summary>
        /// timer по клику кнопки старт/стоп
        /// </summary>
        /// <param name="sender">сендер</param>
        /// <param name="e">эвент мыши(обращение к ней)</param>
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    //здесь сам агоритм появления и изменения
                }
            }
        }

        /// <summary>
        /// отжатие мыши
        /// </summary>
        /// <param name="sender">сендер</param>
        /// <param name="e">эвент мыши(обращение к ней)</param>
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

            mouse = true;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if ((e.Y >= rectangle[i, j].rect.Location.Y + 1) &&
                    (e.Y <= (rectangle[i, j].rect.Location.Y + size)) &&
                    (e.X >= rectangle[i, j].rect.Location.X + 1) &&
                    (e.X <= (rectangle[i, j].rect.Location.X + size)))
                    {
                        g.FillRectangle(blackBrush, rectangle[i, j].rect);
                        rectangle[i, j].color = Color.Black;
                    }

                }
            }
        }
    }
}
