using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS480Final
{
    public partial class Form1 : Form
    {
        public double t, p, m;
        public DirectBitmap dbmp;
        public Graphics g;
        private float[] xu, xl, yu, yl, yc;
        private int halfWidth, halfHeight;

        public Form1()
        {
            InitializeComponent();

            dbmp = new DirectBitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = dbmp.Bitmap;

            g = Graphics.FromImage(pictureBox1.Image);

            halfWidth = pictureBox1.Width >> 1;
            halfHeight = pictureBox1.Height >> 1;

            //g.TranslateTransform(halfWidth, halfHeight);

            xl = new float[102];
            yl = new float[102];
            yl[0] = 0.0f;
            xu = new float[102];
            yu = new float[102];
            yu[0] = 0.0f;
            yc = new float[102];
            yc[0] = 0.0f;
        }

        private void analyze()
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

            if (radCenter.Checked)
            {
                xl[0] = xu[0] = -0.5f;
            }
            else if (radFront.Checked)
            {
                xl[0] = xu[0] = 0.0f;
            }
            else if (radBack.Checked)
            {
                xl[0] = xu[0] = -1f;
            }

            getnacapoints();

            // Draw a string on the PictureBox.
            //g.DrawString("Y", new Font("Arial", 10), System.Drawing.Brushes.Blue, new Point(0, 0));
            //g.DrawString("X", new Font("Arial", 10), System.Drawing.Brushes.Blue, new Point(800, 200));

            //g.DrawLine(System.Drawing.Pens.Red, 0, 200, 800, 200);
            //g.DrawLine(System.Drawing.Pens.Red, 0, 0, 0, 400);

            pictureBox1.Invalidate();
        }

        public void Form1_Shown(object sender, EventArgs e)
        {
            Application.DoEvents();

            analyze();
        }

        private void Design_Click(object sender, EventArgs e)
        {
            analyze();
        }

        private void trkXRot_Scroll(object sender, EventArgs e)
        {
            lblXRot.Text = trkXRot.Value.ToString();
            analyze();
        }

        private void radAlign_CheckedChanged(object sender, EventArgs e)
        {

            analyze();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void drawairfoils(float sz, float ez)
        {
            float airfoilWidth = trkLength.Value;
            float angleAtkZRot = trkAttack.Value;
            float rotx = trkXRot.Value * (float)Math.PI / 180.0f;
            float scale = trkScale.Value;
            float xl1, yl1, xu1, yu1, xl2, yl2, xu2, yu2;

            float viewpoint = -2.75f;
            float z = sz; // TODO: Make repeat for 0.0 to -0.5f, draw lines from 0.0 out to both sides
            float rz = 0.0f;
            //float rotx = 22.5f * (float)Math.PI / 180.0f;

            PointF[] prevSplineTop = new PointF[15];
            PointF[] prevSplineBot = new PointF[15];
            bool prevDone = false;
            int spline = 0;

            g.ResetTransform();

            if (radCenter.Checked)
                g.TranslateTransform(halfWidth, halfHeight);
            else if (radFront.Checked)
                g.TranslateTransform(0, halfHeight);
            else if (radBack.Checked)
                g.TranslateTransform(0, halfHeight);

            g.RotateTransform(angleAtkZRot);

            while (z < ez)
            {
                for (int i = 0; i < 101; i++)
                {
                    //bottom
                    xl1 = xl[i];
                    yl1 = yl[i];
                    xl2 = xl[i + 1];
                    yl2 = yl[i + 1];

                    //rotz
                    //xl1 = xl1 * (float)Math.Cos(angleAtkZRot) + yl1 * (float)Math.Sin(angleAtkZRot);
                    //yl1 = -xl1 * (float)Math.Sin(angleAtkZRot) + yl1 * (float)Math.Cos(angleAtkZRot);

                    // rotx
                    yl1 = yl1 * (float)Math.Cos(rotx) + z * (float)Math.Sin(rotx);
                    rz = -yl1 * (float)Math.Sin(rotx) + z * (float)Math.Cos(rotx);
                    rz = rz - viewpoint;
                    //2d to 3d
                    xl1 = xl1 / rz;// / rz;
                    yl1 /= rz;

                    //xl2 = xl2 * (float)Math.Cos(angleAtkZRot) + yl2 * (float)Math.Sin(angleAtkZRot);
                    //yl2 = -xl2 * (float)Math.Sin(angleAtkZRot) + yl2 * (float)Math.Cos(angleAtkZRot);
                    yl2 = yl2 * (float)Math.Cos(rotx) + z * (float)Math.Sin(rotx);
                    rz = -yl2 * (float)Math.Sin(rotx) + z * (float)Math.Cos(rotx);
                    rz = rz - viewpoint;
                    xl2 = xl2 / rz;// / rz;
                    yl2 /= rz;

                    xl1 = ((radBack.Checked) ? -xl1 : xl1) * airfoilWidth * scale;
                    if (radBack.Checked)
                        xl1 = pictureBox1.Width - xl1;
                    yl1 = -yl1 * pictureBox1.Height * scale;
                    xl2 = ((radBack.Checked) ? -xl2 : xl2)  * airfoilWidth * scale;
                    if (radBack.Checked)
                        xl2 = pictureBox1.Width - xl2;
                    yl2 = -yl2 * pictureBox1.Height * scale;
                    g.DrawLine(System.Drawing.Pens.Red, xl1, yl1, xl2, yl2);

                    //top
                    xu1 = xu[i];
                    yu1 = yu[i];
                    xu2 = xu[i + 1];
                    yu2 = yu[i + 1];

                    //rotz
                    //xu1 = xu1 * (float)Math.Cos(angleAtkZRot) + yu1 * (float)Math.Sin(angleAtkZRot);
                    //yu1 = -xu1 * (float)Math.Sin(angleAtkZRot) + yu1 * (float)Math.Cos(angleAtkZRot);

                    // rotx
                    yu1 = yu1 * (float)Math.Cos(rotx) + z * (float)Math.Sin(rotx);
                    rz = -yu1 * (float)Math.Sin(rotx) + z * (float)Math.Cos(rotx);
                    rz = rz - viewpoint;
                    //2d to 3d
                    xu1 = xu1 / rz;// / rz;
                    yu1 /= rz;

                    //xu2 = xu2 * (float)Math.Cos(angleAtkZRot) + yu2 * (float)Math.Sin(angleAtkZRot);
                    //yu2 = -xu2 * (float)Math.Sin(angleAtkZRot) + yu2 * (float)Math.Cos(angleAtkZRot);
                    yu2 = yu2 * (float)Math.Cos(rotx) + z * (float)Math.Sin(rotx);
                    rz = -yu2 * (float)Math.Sin(rotx) + z * (float)Math.Cos(rotx);
                    rz = rz - viewpoint;
                    xu2 = xu2 / rz;// / rz;
                    yu2 /= rz;

                    xu1 = ((radBack.Checked) ? -xu1 : xu1) * airfoilWidth * scale;
                    if (radBack.Checked)
                        xu1 = pictureBox1.Width - xu1;
                    yu1 = -yu1 * pictureBox1.Height * scale;
                    xu2 = ((radBack.Checked) ? -xu2 : xu2) * airfoilWidth * scale;
                    if (radBack.Checked)
                        xu2 = pictureBox1.Width - xu2;
                    yu2 = -yu2 * pictureBox1.Height * scale;
                    g.DrawLine(System.Drawing.Pens.Red, xu1, yu1, xu2, yu2);

                    if (i % 10 == 0)
                    {
                        if (prevDone)
                        {
                            g.DrawLine(System.Drawing.Pens.Green, prevSplineBot[spline], new PointF(xl1, yl1));
                            g.DrawLine(System.Drawing.Pens.Green, prevSplineTop[spline], new PointF(xu1, yu1));
                        }

                        prevSplineBot[spline].X = xl1;
                        prevSplineBot[spline].Y = yl1;

                        prevSplineTop[spline].X = xu1;
                        prevSplineTop[spline].Y = yu1;

                        spline++;
                    }
                }

                prevDone = true;
                spline = 0;
                z += 0.1f;
            }
        }

        private void getnacapoints()
        {
            //textBox1.Text = "";
            //textBox2.Text = "";

            float x, c, yt, temp, ts, tt, tf, r, dycdx, theta;
            float xl1, yl1, xu1, yu1, xl2, yl2, xu2, yu2;
            int i;

            c = (float)1.0;
            xl1 = xl[0] * pictureBox1.Width;
            yl1 = yl[0] * pictureBox1.Height;
            xu1 = xl[0] * pictureBox1.Width;
            yu1 = yu[0] * pictureBox1.Height;

            /*textBox1.Text = textBox1.Text + "new Point3D(" + xl[0] + ", " + yl[0] + ", " + 0 + "),";
            textBox1.Text = textBox1.Text + Environment.NewLine;

            textBox2.Text = textBox2.Text + "new Point3D(" + xu[0] + ", " + yu[0] + ", " + 0 + "),";
            textBox2.Text = textBox2.Text + Environment.NewLine;*/

            for (i = 1; i <= 101; i++)
            {

                x = i;
                x = x / (float)100.0;
                temp = x / c;
                ts = temp * temp;
                tt = ts * temp;
                tf = tt * temp; 
                yt = (float)(5.0 * t * c * (0.2969 * Math.Sqrt(temp) - 0.1260 * (temp) - 0.3516 * ts + 0.2843 * tt - 0.1015 * tf));

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

                float buffer = 0.0f;
                if (radCenter.Checked)
                    buffer = -0.5f;
                else if (radFront.Checked)
                    buffer = 0.0f;
                else if (radBack.Checked)
                    buffer = -1f;

                xl[i] = (float)(buffer + x + yt * Math.Sin(theta));
                yl[i] = (float)(2 * (yc[i] - yt * Math.Cos(theta)));
                xu[i] = (float)(buffer + x - yt * Math.Sin(theta));
                yu[i] = (float)(2 * (yc[i] + yt * Math.Cos(theta)));

                xl2 = pictureBox1.Width * xl[i];
                yl2 = -(pictureBox1.Height * yl[i]);
                //g.DrawLine(System.Drawing.Pens.Red, xl1, yl1, xl2, yl2);
                xl1 = xl2;
                yl1 = yl2;

                xu2 = pictureBox1.Width * xu[i];
                yu2 = -(pictureBox1.Height * yu[i]);
                //g.DrawLine(System.Drawing.Pens.Red, xu1, yu1, xu2, yu2);
                xu1 = xu2;
                yu1 = yu2;

                /*textBox1.Text = textBox1.Text + "new Point3D(" + xl[i] + ", " + yl[i] + ", " + 0 + "),";
                textBox1.Text = textBox1.Text + Environment.NewLine;

                textBox2.Text = textBox2.Text + "new Point3D(" + xu[i] + ", " + yu[i] + ", " + 0 + "),";
                textBox2.Text = textBox2.Text + Environment.NewLine;*/
            }

            r = (float)(1.1019 * t * t);

            CRALE.Text = r.ToString();

            g.Clear(Color.White);
            drawairfoils(-1.5f, 1.25f);
            //drawairfoils(-2f, -0.25f);
        }

        private void trkAttack_Scroll(object sender, EventArgs e)
        {
            lblAttack.Text = trkAttack.Value.ToString();
            analyze();
        }

        private void trkLength_Scroll(object sender, EventArgs e)
        {
            lblLength.Text = trkLength.Value.ToString();
            analyze();
        }

        private void trkScale_Scroll(object sender, EventArgs e)
        {
            lblScale.Text = trkScale.Value.ToString() + "x";
            analyze();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            analyze();
        }
    }
}
