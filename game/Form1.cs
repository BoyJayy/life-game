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
        const int n = 1000, m = 1000; const int size = 30;
        public Rectangle[,] rectangle = new Rectangle[n, m];
        Pen blackPen = new Pen(Color.Black, 1);

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = ActiveForm.CreateGraphics();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)

                {
                    rectangle[i, j] = new Rectangle(i * size, j * size, size, size);
                    g.DrawRectangle(blackPen, rectangle[i, j]);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
