using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

        public  double t, p, m;
     //   public  bool bl=false;   
        public Form1()
        {
            InitializeComponent();
        }
            
        private void Start_Analysis_Click(object sender, EventArgs e)
        {

           int naca, thick, camb, cambd, front;
            float mask;
            p = 0.0;
            t = 0.0;
            m = 0.0;
            naca = int.Parse(nacas.Text);

            mask = (float)naca;
            mask = (float)(mask / 100.0);
            front = naca / 100;
            mask = (float)((mask - front) * 100.0);
            thick = (int)mask;
            MaxThick.Text = thick.ToString()+" %";
            mask = (float)front;
            camb = front / 10;
            MaxCamber.Text = camb.ToString()+ " %";
            mask = (float)(mask / 10.0);
            mask = (float)((mask - camb) * 10.0);
            cambd = (int)(mask + 0.01); 
            t = (double)(thick) / 100.0;
            DisttoMaxCamb.Text = cambd.ToString()+"0%";
            t = (double)(thick) / 100.0;
            
            p = (double)(cambd) / 10;
            m = (double)(camb) / 100.0;
            //bl = true;
            
            textBox1.Text = p.ToString();
            textBox2.Text = m.ToString();
            // thick is the maximum thickness in per cent (%)
            // Camb is the maximum Camber in per cent
            // cambd is the distance of the maximum camber from the leading edge.
            pictureBox1.BackColor = Color.White;

            pictureBox1.Invalidate();
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;

            if (me.Button == MouseButtons.Right)
            {
                txtPoints.Text += ("new Point3D(" + ((-400 + me.X) / 400.0) + ", " + ((200 + -me.Y) / 200.0) + ", " + "0),");
                txtPoints.Text += Environment.NewLine;
            }
                //listBox1.Items.Add("X: " + me.X / 800.0f + ", Y: " + (200 - me.Y) / 200.0f);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtPoints.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

           // if (bl)
          //  {
                //listBox1.Items.Clear();
                Graphics g = e.Graphics;

                // Draw a string on the PictureBox.
                g.DrawString("Y", new Font("Arial", 10), System.Drawing.Brushes.Blue, new Point(0, 0));
                g.DrawString("X", new Font("Arial", 10), System.Drawing.Brushes.Blue, new Point(800, 200));

                g.DrawLine(System.Drawing.Pens.Red, 0, 200, 800, 200);
                g.DrawLine(System.Drawing.Pens.Red, 0, 0, 0, 400);
                /*  int naca, thick, camb, cambd, front;
                  float mask;

                  naca = int.Parse(nacas.Text);

                  mask = (float)naca;
                  mask = (float)(mask / 100.0);
                  front = naca / 100;
                  mask = (float)((mask - front) * 100.0);
                  thick = (int)mask;
                  MaxThick.Text = thick.ToString();
                  mask = (float)front;
                  camb = front / 10;
                  MaxCamber.Text = camb.ToString();
                  mask = (float)(mask / 10.0);
                  mask = (float)((mask - camb) * 10.0);
                  cambd = (int)(mask + 0.01);
                  DisttoMaxCamb.Text = cambd.ToString(); */

                // thick is the maximum thickness in per cent (%)
                // Camb is the maximum Camber in per cent
                // cambd is the distance of the maximum camber from the leading edge.
                float x, c, yt, temp, ts, tt, tf, r, dycdx, theta;
                int i, xl1, yl1, xu1, yu1, yc1, xl2, yl2, xu2, yu2, yc2, xc1, xc2;
                float[] xu, xl, yu, yl, yc;
                xl = new float[101];
                yl = new float[101];
                xu = new float[101];
                yu = new float[101];
                yc = new float[101];
                c = (float)1.0;
                // t = (double)(thick) / 100.0;

                //  p = (double)(cambd) / 10;
                //   m = (double)(camb) / 100.0;
              //  t = 0.12;
             //   p = 0.40;
             //   m = 0.02;
                xl1 = 0;
                yl1 = 200;
                xu1 = 0;
                yu1 = 200;
                yc1 = 200;
                xc1 = 0;

                for (i = 0; i <= 100; i++)
                {

                    x = i;
                    x = x / (float) 100.0;
                    temp = x / c;
                    ts = temp * temp;
                    tt = ts * temp;
                    tf = tt * temp;
                    yt = (float)( 5.0 * t * c * (0.2969 * Math.Sqrt(temp) - 0.1260 * (temp) - 0.3516 * ts + 0.2843 * tt - 0.1015 * tf));
                    //cout << " x = " << x << "  yt= " << yt << "\n";
                    if (p < 0.00001)
                    {
                        yc[i] =(float) 0.0;
                        dycdx = (float)0.0;
                        theta = (float) 0.0;
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
                            yc[i] = (float) ( m * (c - x) / ((1 - p) * (1 - p)) * (1.0 + x / c - 2.0 * p));
                            dycdx = (float)((2.0 * m) / ((1 - p) * (1 - p)) * (p - x / c));
                        }
                        theta = (float)Math.Atan(dycdx);
                    }
                    xl[i] = (float)(x + yt * Math.Sin(theta));
                    yl[i] = (float)(yc[i] - yt * Math.Cos(theta));
                    xu[i] = (float)(x - yt * Math.Sin(theta));
                    yu[i] = (float)(yc[i] + yt * Math.Cos(theta));
                    xl2 = (int)(800 * xl[i]);
                    yl2 = 200 - (int)(800 * yl[i]);
                    g.DrawLine(System.Drawing.Pens.Red, xl1, yl1, xl2, yl2);
                    xl1 = xl2;
                    yl1 = yl2;

                    xu2 = (int)(800 * xu[i]);
                    yu2 = 200 - (int)(800 * yu[i]);
                    g.DrawLine(System.Drawing.Pens.Red, xu1, yu1, xu2, yu2);
                    xu1 = xu2;
                    yu1 = yu2;

                    xc2 = 8 * i;
                    yc2 = 200 - (int)(800 * yc[i]);
                    g.DrawLine(System.Drawing.Pens.Blue, xc1, yc1, xc2, yc2);
                    xc1 = xc2;
                    yc1 = yc2;

                /*if (i % 5 == 0)
                {
                    txtPoints.Text += ("new PointD(" + xl[i] + ", " + yl[i] + "),");
                    txtPoints.Text += Environment.NewLine;
                }*/
                
                //  cout << " xl= " << xl << "  yl= " << yl << "  xu= " << xu << "  yu=" << yu << "\n";
                //listBox1.Items.Add("XL[" + i + "]=   " + xl[i] + "    YL[" + i + "]=     " + yl[i] + "     XU[" + i + "]=" + xu[i] + "    YU[" + i + "]=  " + yu[i] + "  YC[" + i + "]= " + yc[i]);
                //listBox1.Items.Add("XL[" + i + "]=   " + xl1 + "    YL[" + i + "]=     " + yl1 + "     XU[" + i + "]=" + xu1 + "    YU[" + i + "]=  " + yu1 + "  YC[" + i + "]= " + yc[i]);
            }
                r = (float)(1.1019 * t * t);
                //  cout << "The radius of the leading edge circle is:  " << r;

                LERadius.Text = r.ToString();
               
          //  }
           

        }
    }
}
