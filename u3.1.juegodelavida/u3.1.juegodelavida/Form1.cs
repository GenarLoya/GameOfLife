using System;
using GlobalKeyboardHooker;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace u3._1.juegodelavida
{
    public partial class Form1 : Form
    {

        int lenght = 40;
        int lenghtpixel = 10;
        int[,] golife;
        int[,] golifecopy;
        int[,] neighbor;
        int keyx = 0, keyy = 0;
        int mode = 0, fill = 0;
        GlobalKeyboardHook gkh = new GlobalKeyboardHook();

        public Form1()
        {
            InitializeComponent();
            golife = new int[lenght, lenght];
            golifecopy = new int[lenght, lenght];
            neighbor = new int[3, 3];
            neighbor[1, 1] = -2;
            golife[2, 2] = 1;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < lenght; j++)
                {
                    golife[i, j] = 0;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Golife();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            mode = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            mode = 1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Printgolife()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < lenght; j++)
                {
                    if (golife[i, j] == 0) Printpixel(bmp, i, j, Color.White);
                    else if (golife[i, j] == 1) Printpixel(bmp, i, j, Color.Black);

                    if (keyx == i && keyy == j)
                    {
                        Printpixel(bmp, i, j, Color.Red);
                    }
                }
            }

            pictureBox1.Image = bmp;
        }

        private void Printpixel(Bitmap bmp, int x, int y, Color color)
        {
            for (int i = 0; i < lenghtpixel; i++)
            {
                for (int j = 0; j < lenghtpixel; j++)
                {
                    bmp.SetPixel(i + (x * lenghtpixel), j + (y * lenghtpixel), color);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (mode == 0)
            {
                if (checkBox1.Checked == true) fill = 0;
                else fill = 1;

                golife[keyx, keyy] = fill; ;

                keyy--;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (mode == 0)
            {
                if (checkBox1.Checked == true) fill = 0;
                else fill = 1;

                golife[keyx, keyy] = fill; ;

                keyy++;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (mode == 0)
            {
                if (checkBox1.Checked == true) fill = 0;
                else fill = 1;

                golife[keyx, keyy] = fill; ;

                keyx--;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (mode == 0)
            {
                if (checkBox1.Checked == true) fill = 0;
                else fill = 1;

                golife[keyx, keyy] = fill; ;

                keyx++;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            Printgolife();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (mode == 0)
            {
                if (golife[keyx, keyy] == 1) fill = 0;
                else fill = 1;

                golife[keyx, keyy] = fill;
            }
        }

        private void Golife()
        {
            int negbhorcount = 0, g = 1;

            for (; ; )
            {

                if (mode == 0) Console.WriteLine("MODO: Pausa");
                else if (mode == 1) Console.WriteLine("MODO: Play");

                switch (mode)
                {
                    case 0:

                        break;

                    case 1:

                        for (int i = 0; i < lenght; i++)
                        {
                            for (int j = 0; j < lenght; j++)
                            {
                                //Console.WriteLine(Convert.ToString(i) +", " + (Convert.ToString(j)));

                                if (i - 1 >= 0 && (j - 1) >= 0)
                                {
                                    neighbor[0, 0] = golife[i - 1, j - 1];
                                }
                                else
                                {
                                    neighbor[0, 0] = -1;
                                }

                                if (i + 1 < lenght && (j + 1) < lenght)
                                {
                                    neighbor[2, 2] = golife[i + 1, j + 1];
                                }
                                else
                                {
                                    neighbor[2, 2] = -1;
                                }

                                if (i - 1 >= 0 && (j + 1) < lenght)
                                {
                                    neighbor[0, 2] = golife[i - 1, j + 1];
                                }
                                else
                                {
                                    neighbor[0, 2] = -1;
                                }

                                if (i + 1 < lenght && (j - 1) >= 0)
                                {
                                    neighbor[2, 0] = golife[i + 1, j - 1];
                                }
                                else
                                {
                                    neighbor[2, 0] = -1;
                                }

                                if (i - 1 >= 0 && (j >= 0 && j < lenght))
                                {
                                    neighbor[0, 1] = golife[i - 1, j];
                                }
                                else
                                {
                                    neighbor[0, 1] = -1;
                                }

                                if (i + 1 < lenght && (j >= 0 && j < lenght))
                                {
                                    neighbor[2, 1] = golife[i + 1, j];
                                }
                                else
                                {
                                    neighbor[2, 1] = -1;
                                }

                                if (j - 1 >= 0 && (i >= 0 && i < lenght))
                                {
                                    neighbor[1, 0] = golife[i, j - 1];
                                }
                                else
                                {
                                    neighbor[1, 0] = -1;
                                }

                                if (j + 1 < lenght && (i >= 0 && i < lenght))
                                {
                                    neighbor[1, 2] = golife[i, j + 1];
                                }
                                else
                                {
                                    neighbor[1, 2] = -1;
                                }

                                for (int k = 0; k < 3; k++)
                                {
                                    for (int l = 0; l < 3; l++)
                                    {
                                        if (neighbor[k, l] == 1)
                                        {
                                            negbhorcount++;
                                        }
                                    }
                                }

                                if (golife[i, j] == 0)
                                {
                                    if (negbhorcount == 3) golifecopy[i, j] = 1;
                                    else if (negbhorcount < 3 || negbhorcount > 3) golifecopy[i, j] = 0;
                                }
                                else if (golife[i, j] == 1)
                                {
                                    if (negbhorcount == 3 || negbhorcount == 2) golifecopy[i, j] = 1;
                                    if (negbhorcount > 3) golifecopy[i, j] = 0;
                                    else if (negbhorcount < 2) golifecopy[i, j] = 0;
                                }

                                negbhorcount = 0;
                            }
                        }

                        golife = golifecopy;

                        int[,] golifereinit = new int[lenght, lenght];

                        golifecopy = golifereinit;

                        Printgolife();

                        break;
                }

                if (g == 1) break;

            }
        }

        private void Keydetect()
        {
            
        }
    }
}
