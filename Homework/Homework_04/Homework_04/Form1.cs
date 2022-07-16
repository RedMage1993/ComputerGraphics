using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_04
{
    public partial class Form1 : Form
    {
        private int halfWidth, halfHeight;
        private Graphics graphics;
        private DirectBitmap dbmp;

        public Form1()
        {
            InitializeComponent();

            // For faster access to pixels.
            dbmp = new DirectBitmap(pbxGraph.Width, pbxGraph.Height);

            halfWidth = pbxGraph.Width >> 1;
            halfHeight = pbxGraph.Height >> 1;

            pbxGraph.Image = dbmp.Bitmap;

            graphics = Graphics.FromImage(pbxGraph.Image);
            graphics.TranslateTransform(halfWidth, halfHeight);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Application.DoEvents(); // Let all messages in message queue be processed.

            bgwDrawing.RunWorkerAsync();
        }

        private PointF[] getTrianglePoints(PointF pin)//, int sideLen)
        {
            PointF[] points = new PointF[5];

            points[0] = pin;

            points[1].X = pin.X + 120;
            points[1].Y = pin.Y;

            points[2].X = pin.X + 20;
            points[2].Y = pin.Y + 10;

            points[3].X = pin.X + 10;
            points[3].Y = pin.Y + 5;

            points[4].X = pin.X;
            points[4].Y = pin.Y + 5;

            return points;
        }

        private PointF[] getBasePoints(PointF pin)
        {
            PointF[] points = new PointF[4];

            points[0] = pin;
            points[0].X += 5;

            points[1].X = pin.X - 10;
            points[1].Y = pin.Y + 240;

            points[2].X = pin.X + 30;
            points[2].Y = pin.Y + 240;

            points[3].X = pin.X + 15;
            points[3].Y = pin.Y;

            return points;
        }

        private void bgwDrawing_DoWork(object sender, DoWorkEventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            System.Drawing.Drawing2D.Matrix matrix = new System.Drawing.Drawing2D.Matrix();
            double t = 0.0; // Theta
            int circleWidth = 20;
            int circleHeight = 20;
            //int triSideLen = 75;
            PointF trifecta = new PointF(circleWidth >> 1, 0); // Lol. Origin.
            PointF[] triangle = getTrianglePoints(trifecta);//, triSideLen);
            PointF[] backup = new PointF[5];
            PointF[] windmillBase = getBasePoints(new PointF(-(circleWidth >> 1), circleHeight >> 1));

            triangle.CopyTo(backup, 0);

            // Main routine
            // Invalidate for each frame
            while (true)
            {
                sw.Start();

                // Calculate x,y using sin/cos/t.
                // Get triangle points at x,y.
                // Translate points to triangle center (-center).
                // Rotate using rotation matrix and t.
                // Translate back to x,y (+center).
                // Draw polygon.
                graphics.Clear(Color.White);

                graphics.FillEllipse(Brushes.Black, -(circleWidth >> 1), -(circleHeight >> 1), circleWidth, circleHeight);
                //graphics.FillRectangle(Brushes.Blue, -10, (circleHeight >> 1), 20, 150);
                graphics.FillPolygon(Brushes.Blue, windmillBase);
                for (int tri = 0; tri < 3; tri++)
                {
                    // Was originally (circleWidth >> 1) for the correct position on the circle without rotation. Rotation throws positioning off. 
                    // By guessing, I saw that if I pretended the circle was bigger and then shifted it to the left a bit here that it would center correctly.
                    // Honestly not sure what the correct logical reasoning is here for why the positioning is thrown off and then what kind of action to take for that.
                    // Edit: After changing the triangle side length, i noticed that it's actually the triangle side length that needs to be subtracted.
                    // I think it makes more sense but I'm still not entirely sure why it must be done. I think it's because as you rotate, the right side of the triangle (at 75) is turned 180 degrees (to the left),
                    // and if you want that to be on the left side of the circle, then you need to shift to the left by the width of the triangle.
                    //trifecta = new PointF((float)(Math.Cos((t + tri * 120) * Math.PI / 180) * (circleWidth * 0.8)) - triSideLen, (float)(-Math.Sin((t + tri * 120) * Math.PI / 180) * (circleHeight * 0.8)));
                    // Edit2: Turns out it was rotating at the circle origin (0, 0) when RotateAt is not used, so therefore the moving around with cos/sin was totally unnecessary.
                    // But now it seems harder to bring the triangles inward/outward. Jk, you can specify where the triangles begin with trifecta.

                    // + 50 because I'm interpreting equilateral triangle center to be halfway down x axis.
                    // Can translate and rotate or just use rotateAt.
                    matrix.Rotate((float)-(t + tri * 120), System.Drawing.Drawing2D.MatrixOrder.Append);
                    matrix.TransformPoints(triangle);
                    matrix.Reset();

                    graphics.FillPolygon(Brushes.Red, triangle);

                    backup.CopyTo(triangle, 0);
                }

                pbxGraph.Invalidate();

                t += 2;
                if (t >= 360.0)
                    t = 0.0;

                // Wait time if not enough time has passed
                while (sw.ElapsedMilliseconds < 30)
                    System.Threading.Thread.Sleep(1);

                sw.Stop();
                sw.Reset();
            }
        }
    }
}
