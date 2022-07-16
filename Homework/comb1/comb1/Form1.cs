using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace comb1
{
    public partial class Form1 : Form
    {
        public double t, p, m;
        public Form1()
        {
            InitializeComponent();
        }

        private void Design_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(comboBox1.Text);
            int naca, thick, camb, cambd, front;
            float mask;
            p = 0.0;
            t = 0.0;
            m = 0.0;
            naca = int.Parse(comboBox1.Text);

            mask = (float)naca;
            mask = (float)(mask / 100.0);
            front = naca / 100;
            mask = (float)((mask - front) * 100.0 + 0.001);
            thick = (int)mask;
            MT.Text = thick.ToString() + " %";
            mask = (float)front;
            camb = front / 10;
            MXC.Text = camb.ToString() + " %";
            mask = (float)(mask / 10.0);
            mask = (float)((mask - camb) * 10.0);
            cambd = (int)(mask + 0.01);
            t = (float)(thick / 100.0);
            DtMc.Text = cambd.ToString() + "0%";
            t = (float)(thick / 100.0);
            p = (double)(cambd) / 10;
            m = (double)(camb) / 100.0;
            pictureBox1.BackColor = Color.White;
            pictureBox1.Invalidate();


        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            listBox1.Items.Clear();
            Graphics g = e.Graphics;

            g.TranslateTransform(400, 200);

            // Draw a string on the PictureBox.
            //g.DrawString("Y", new Font("Arial", 10), System.Drawing.Brushes.Blue, new Point(0, 0));
            //g.DrawString("X", new Font("Arial", 10), System.Drawing.Brushes.Blue, new Point(800, 200));

            //g.DrawLine(System.Drawing.Pens.Red, 0, 200, 800, 200);
            //g.DrawLine(System.Drawing.Pens.Red, 0, 0, 0, 400);
            float x, c, yt, temp, ts, tt, tf, r, dycdx, theta;
            float xl1, yl1, xu1, yu1, yc1, xl2, yl2, xu2, yu2, yc2, xc1, xc2;
            int i;
            float[] xu, xl, yu, yl, yc;
            xl = new float[101];
            yl = new float[101];
            xu = new float[101];
            yu = new float[101];
            yc = new float[101];

            c = (float)1.0;
            xl1 = -400;
            yl1 = 0;
            xu1 = -400;
            yu1 = 0;

            yc1 = 200;
            xc1 = 0;        

            for (i = 0; i <= 100; i++)
            {

                x = i;
                x = x / (float)100.0;
                temp = x / c;
                ts = temp * temp;
                tt = ts * temp;
                tf = tt * temp;
                yt = (float)(5.0 * t * c * (0.2969 * Math.Sqrt(temp) - 0.1260 * (temp) - 0.3516 * ts + 0.2843 * tt - 0.1015 * tf));
                //cout << " x = " << x << "  yt= " << yt << "\n";
                if (p < 0.00001)
                {
                    yc[i] = (float)0.0;
                    dycdx = (float)0.0;
                    theta = (float)0.0;
                }
                else
                {
                    if (x <= p * c)
                    {
                        yc[i] = (float)(m * (x / (p * p)) * (2.0 * p - x / c));
                        dycdx = (float)((2.0 * m) / (p * p) * (p - x / c));
                    }
                    else
                    {
                        yc[i] = (float)(m * (c - x) / ((1 - p) * (1 - p)) * (1.0 + x / c - 2.0 * p));
                        dycdx = (float)((2.0 * m) / ((1 - p) * (1 - p)) * (p - x / c));
                    }
                    theta = (float)Math.Atan(dycdx);
                }

                xl[i] = (float)(x + yt * Math.Sin(theta));
                yl[i] = (float)(yc[i] - yt * Math.Cos(theta));
                xu[i] = (float)(x - yt * Math.Sin(theta));
                yu[i] = (float)(yc[i] + yt * Math.Cos(theta));


                xl2 =-400 + (800 * xl[i]);
                yl2 = -(800 * yl[i]);
                //g.DrawLine(System.Drawing.Pens.Red, xl1, yl1, xl2, yl2);
                xl1 = xl2;
                yl1 = yl2;

                xu2 = -400 + (800 * xu[i]);
                yu2 = -(800 * yu[i]);
                //g.DrawLine(System.Drawing.Pens.Red, xu1, yu1, xu2, yu2);
                xu1 = xu2;
                yu1 = yu2;

                xc2 = 8 * i;
                yc2 = 200 - (int)(800 * yc[i]);
                //g.DrawLine(System.Drawing.Pens.Blue, xc1, yc1, xc2, yc2);
                xc1 = xc2;
                yc1 = yc2;
                //  cout << " xl= " << xl << "  yl= " << yl << "  xu= " << xu << "  yu=" << yu << "\n";
                listBox1.Items.Add("XL[" + i + "]=   " + xl[i] + "    YL[" + i + "]=     " + yl[i] + "     XU[" + i + "]=" + xu[i] + "    YU[" + i + "]=  " + yu[i] + "  YC[" + i + "]= " + yc[i]);
            }

            r = (float)(1.1019 * t * t);
            //  cout << "The radius of the leading edge circle is:  " << r;

            CRALE.Text = r.ToString();
            
            float z = 0.25f;
            float viewpoint = -0.75f;
            z -= viewpoint; // watch from -1
            //float rotx = 0.0f;

            // TODO: Z does have to be > 1
            // Now rotate about X axis as done in CubicSpline
            // To show view from above and show that there are splines behind it

            while (z <= (1.0f - viewpoint))
            {
                xl1 = (-0.5f / z) * 800;
                yl1 = 0;
                xu1 = (-0.5f / z) * 800;
                yu1 = 0;

                for (i = 0; i <= 100; i++)
                {
                    xl2 = ((-0.5f + xl[i]) / z) * 800;
                    yl2 = -(yl[i] / z) * 800;
                    g.DrawLine(System.Drawing.Pens.Red, xl1, yl1, xl2, yl2);
                    xl1 = xl2;
                    yl1 = yl2;

                    xu2 = ((-0.5f + xu[i]) / z) * 800;
                    yu2 = -(yu[i] / z) * 800;
                    g.DrawLine(System.Drawing.Pens.Red, xu1, yu1, xu2, yu2);
                    xu1 = xu2;
                    yu1 = yu2;
                }

                z += 0.25f;
            }
        }
    }
}
