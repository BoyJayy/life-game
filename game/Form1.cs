using System;
using System.Drawing;
using System.Windows.Forms;

namespace game
{
    public partial class lifegame : Form
    {
        public lifegame()
        {
            InitializeComponent();
        }

        private Graphics g;
        private const int n = 39, m = 23; private const int size = 30;

        //public Rectangle[,] rectangle = new Rectangle[n, m];
        public Rect[,] rectangle = new Rect[n, m];

        private SolidBrush blackBrush = new SolidBrush(Color.Black);
        private SolidBrush whiteBrush = new SolidBrush(Color.White);
        private SolidBrush redBrush = new SolidBrush(Color.Red);
        private Pen blackPen = new Pen(Color.Black, 1);
        private bool mouse = false;

        public struct Rect
        {
            public Rectangle rect;
            public Color color;
            public int counter;
            public static Rect operator ++(Rect r1) //peregruz
            {
                r1.counter++;
                return r1;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            g = Application.OpenForms[0].CreateGraphics();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    rectangle[i, j].rect = new Rectangle(i * size, j * size + 50, size, size);
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

        private void Form1_Load(object sender, EventArgs e)
        {
            //
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            // ZOMBIE
            // for (int i = 0; i < n; i++)
            //    for (int j = 0; j < m; j++)
            //    {
            //        if (i - 1 >= 0 && j - 1 >= 0) if (rectangle[i - 1, j - 1].color == Color.Black) rectangle[i, j]++; //i - 1 j - 1
            //        if (i - 1 >= 0) if (rectangle[i - 1, j].color == Color.Black) rectangle[i, j]++; //i - 1 j
            //        if (i - 1 >= 0 && j + 1 > m) if (rectangle[i - 1, j + 1].color == Color.Black) rectangle[i, j]++; //i - 1 j + 1
            //        if (j - 1 >= 0) if (rectangle[i, j - 1].color == Color.Black) rectangle[i, j]++; //j - 1
            //        if (j + 1 > m) if (rectangle[i, j - 1].color == Color.Black) rectangle[i, j]++; // j + 1
            //        if (i + 1 < n && j - 1 >= 0) if (rectangle[i + 1, j - 1].color == Color.Black) rectangle[i, j]++; //i + 1 j - 1
            //        if (i + 1 < n) if (rectangle[i + 1, j].color == Color.Black) rectangle[i, j]++; //i + 1 j
            //        if (i + 1 < n && j + 1 > m) if (rectangle[i + 1, j + 1].color == Color.Black) rectangle[i, j]++; //i + 1 j + 1
            //    } старая проверка для пастинга
            counter_forOnestep += 1;
            onestepButton.Text = "One step " + counter_forOnestep.ToString();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    if (rectangle[i, j].color == Color.Black && i > 0 && j > 0 && i < n - 1 && j < m - 1)
                    {
                        rectangle[i - 1, j - 1]++;
                        rectangle[i - 1, j]++;
                        rectangle[i - 1, j + 1]++;
                        rectangle[i, j - 1]++;
                        rectangle[i, j + 1]++;
                        rectangle[i + 1, j - 1]++;
                        rectangle[i + 1, j]++;
                        rectangle[i + 1, j + 1]++;
                    }
                }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    if (rectangle[i, j].counter == 3 && i >= 0 && j >= 0 && i < n && j < m)
                    {
                        //g.DrawString(rectangle[i, j].counter.ToString(), DefaultFont, Brushes.Green, rectangle[i, j].rect.X + 10, rectangle[i, j].rect.Y + 10);
                        //rectangle[i, j].counter = 0;
                        g.FillRectangle(blackBrush, rectangle[i, j].rect);
                        rectangle[i, j].color = Color.Black;
                    }
                    if (rectangle[i, j].counter < 2 || rectangle[i, j].counter > 3 && i >= 0 && j >= 0 && i < n && j < m)
                    {
                        //g.DrawString(rectangle[i, j].counter.ToString(), DefaultFont, Brushes.Green, rectangle[i, j].rect.X + 10, rectangle[i, j].rect.Y + 10);
                        //rectangle[i, j].counter = 0;
                        g.FillRectangle(whiteBrush, rectangle[i, j].rect);
                        rectangle[i, j].color = Color.White;
                    }
                }
        }

        private void start_Click(object sender, EventArgs e)
        {
            if (startButton.Text == "Start")
            {
                startButton.Text = "Stop";
                timer1.Enabled = true;
            }
            else
            {
                startButton.Text = "Start";
                timer1.Enabled = false;
            }
        }

        private int counter_forOnestep = 0;

        private void onestepButton_Click(object sender, EventArgs e)
        {
            counter_forOnestep += 1;
            onestepButton.Text = "One step " + counter_forOnestep.ToString();
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    if (rectangle[i, j].color == Color.Black && i > 0 && j > 0 && i < n - 1 && j < m - 1)
                    {
                        rectangle[i - 1, j - 1]++;
                        rectangle[i - 1, j]++;
                        rectangle[i - 1, j + 1]++;
                        rectangle[i, j - 1]++;
                        rectangle[i, j + 1]++;
                        rectangle[i + 1, j - 1]++;
                        rectangle[i + 1, j]++;
                        rectangle[i + 1, j + 1]++;
                    }
                }
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                {
                    if (rectangle[i, j].counter == 3 && i >= 0 && j >= 0 && i < n && j < m)
                    {
                        //g.DrawString(rectangle[i, j].counter.ToString(), DefaultFont, Brushes.Green, rectangle[i, j].rect.X + 10, rectangle[i, j].rect.Y + 10);
                        //rectangle[i, j].counter = 0;
                        g.FillRectangle(blackBrush, rectangle[i, j].rect);
                        rectangle[i, j].color = Color.Black;
                    }
                    if (rectangle[i, j].counter < 2 || rectangle[i, j].counter > 3 && i >= 0 && j >= 0 && i < n && j < m)
                    {
                        //g.DrawString(rectangle[i, j].counter.ToString(), DefaultFont, Brushes.Green, rectangle[i, j].rect.X + 10, rectangle[i, j].rect.Y + 10);
                        //rectangle[i, j].counter = 0;
                        g.FillRectangle(whiteBrush, rectangle[i, j].rect);
                        rectangle[i, j].color = Color.White;
                    }
                }
        }

        private void timerDelay_slider_Scroll(object sender, EventArgs e)
        {
            timerDelay_sliderValue.Text = timerDelay_slider.Value.ToString() + " ms";
            timer1.Interval = timerDelay_slider.Value + 1;
        }

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