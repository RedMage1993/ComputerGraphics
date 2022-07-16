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
using System.Collections.ObjectModel;
using System.Threading;

namespace Homework_07
{
    public struct Camera
    {
        public Point3D position; // viewpoint
        public double roll; // rotate about Z
        public double yaw; // rotate about Y
        public double pitch; // rotate about X

        public Camera(Point3D pos, double r, double y, double p)
        {
            position = pos;
            roll = r;
            yaw = y;
            pitch = p;
        }
    }

   public partial class Form1 : Form
    {
        private int halfWidth, halfHeight;
        private int halfDepth;
        private Camera camera;
        private Graphics graphics;
        private DirectBitmap dbmp;
        //private DirectBitmap dbmpBuffer;
        private double splineRotY = 0;
        //private Bitmap bmp, tbmp, obmp;

        public Form1()
        {
            InitializeComponent();

            // For faster access to pixels.
            dbmp = new DirectBitmap(pbxGraph.Width, pbxGraph.Height);
            //dbmpBuffer = new DirectBitmap(pbxGraph.Width, pbxGraph.Height);

            pbxGraph.Image = dbmp.Bitmap;

            halfWidth = pbxGraph.Width >> 1;
            halfHeight = pbxGraph.Height >> 1;
            halfDepth = halfWidth; // Since we tend to want to see the whole width when rotated

            camera = new Camera(new Point3D(0, 0, -1), 0, 0, 0); // viewpoint one step back

            // calculate degrees to rotate in opposite direction based on viewpoint x y

            
            //graphics = Graphics.FromImage(dbmpBuffer.Bitmap);
            graphics = Graphics.FromImage(dbmp.Bitmap);
            
            graphics.TranslateTransform(halfWidth, halfHeight);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Application.DoEvents(); // Let all messages in message queue be processed.

            bgwDrawing.RunWorkerAsync();
        }

        private void bgwDrawing_Done(object sender, RunWorkerCompletedEventArgs e)
        {
            /*if (tbmp != null)
            {
                obmp = tbmp;
            }

            bmp = new Bitmap(dbmpBuffer.Bitmap);
            tbmp = bmp;
            pbxGraph.Image = bmp;

            if (obmp != null)
            {
                obmp.Dispose();
            }

            
            deg += 0.5;
            Thread.Sleep(1);
            bgwDrawing.RunWorkerAsync();*/

            pbxGraph.Invalidate();
        }

        private Point3D FixAxis(Point3D ori)
        {
            double splineRotXrad, splineRotYrad;

            // x
            splineRotXrad = -camera.pitch;
            splineRotXrad = splineRotXrad * Math.PI / 180.0;

            // y
            splineRotYrad = -camera.yaw;
            splineRotYrad = splineRotYrad * Math.PI / 180.0;

            //rot bout y
            ori.X = ori.X * Math.Cos(splineRotYrad) - ori.Z * Math.Sin(splineRotYrad);
            ori.Z = ori.X * Math.Sin(splineRotYrad) + ori.Z * Math.Cos(splineRotYrad);

            // rot by x
            ori.Y = ori.Y * Math.Cos(splineRotXrad) + ori.Z * Math.Sin(splineRotXrad);
            ori.Z = -ori.Y * Math.Sin(splineRotXrad) + ori.Z * Math.Cos(splineRotXrad);

            // relativity
            ori.X = ori.X - camera.position.X;
            ori.Y = ori.Y - camera.position.Y;
            ori.Z = ori.Z - camera.position.Z;

            // 3d to 2d
            ori.X = (ori.X / ori.Z) * halfWidth;
            ori.Y = (ori.Y / ori.Z) * halfHeight;

            return ori;
        }

        private void DrawAxes()
        {
            Point3D yAxis1 = new Point3D(0, -1.75, 0);
            Point3D yAxis2 = new Point3D(0, 1.75, 0);

            Point3D xAxis1 = new Point3D(-1.25, 0, 0);
            Point3D xAxis2 = new Point3D(1.25, 0, 0);
            

            /*if (camera.yaw > 0 || camera.pitch > 0)
            {
                // Should be able to see Z axis
            }*/

            yAxis1 = FixAxis(yAxis1);
            yAxis2 = FixAxis(yAxis2);

            graphics.DrawLine(Pens.Black, new PointF((float)yAxis1.X, (float)yAxis1.Y), new PointF((float)yAxis2.X, (float)yAxis2.Y));
            //graphics.DrawString("Y", new Font("Arial", 10), Brushes.Black, new Point(2, -halfHeight));

            xAxis1 = FixAxis(xAxis1);
            xAxis2 = FixAxis(xAxis2);

            graphics.DrawLine(Pens.Black, new PointF((float)xAxis1.X, (float)xAxis1.Y), new PointF((float)xAxis2.X, (float)xAxis2.Y));
            //graphics.DrawString("X", new Font("Arial", 10), Brushes.Black, new Point(halfWidth - 12, 1));
        }

        private void drawSpline(CubicSpline spline, Point3D[] ctrlPts)
        {
            double t;
            PointD ptOnPiece1, ptOnPiece2;
            //float aspect = pbxGraph.Width / pbxGraph.Height;
            //const double factor = 0.25;

            if (!spline.setCtrlPts(ctrlPts.Length, ctrlPts))
                return;
            spline.Init();

            for (int i = 0; i < ctrlPts.Length - 1; i++)
            {
                t = 0.0;

                spline.SetCoeForPiece(i);

                ptOnPiece1 = spline.getScreenPts(t, i);

                while (t < 1.0)
                {
                    t = Math.Round(t + 0.1, 2);

                    ptOnPiece2 = spline.getScreenPts(t, i);

                    graphics.DrawLine(Pens.Red, (float)ptOnPiece1.X, (float)ptOnPiece1.Y, (float)ptOnPiece2.X, (float)ptOnPiece2.Y);

                    //graphics.DrawLine(Pens.Red, (float)(ptOnPiece1.X + factor * 1 * halfWidth), (float)ptOnPiece1.Y, (float)(ptOnPiece2.X + factor * 1 * halfWidth), (float)ptOnPiece2.Y);

                    //graphics.DrawLine(Pens.Red, (float)(ptOnPiece1.X + factor * 2 * halfWidth), (float)ptOnPiece1.Y, (float)(ptOnPiece2.X + factor * 2 * halfWidth), (float)ptOnPiece2.Y);

                    ptOnPiece1 = ptOnPiece2;
                }
            }
        }

        private void bgwDrawing_DoWork(object sender, DoWorkEventArgs e)
        {
            CubicSpline spline = new CubicSpline(splineRotY, camera, halfWidth, halfHeight, halfDepth);

            Point3D[] topCps =
            {
                new Point3D(-1, 0, 0),
                new Point3D(-0.9825, 0.07, 0),
                new Point3D(-0.895, 0.17, 0),
                new Point3D(-0.7375, 0.25, 0),
                new Point3D(-0.5575, 0.3, 0),
                new Point3D(-0.395, 0.315, 0),
                new Point3D(-0.1425, 0.305, 0),
                new Point3D(0.0725, 0.275, 0),
                new Point3D(0.25, 0.245, 0),
                new Point3D(0.44, 0.195, 0),
                new Point3D(0.6525, 0.13, 0),
                new Point3D(0.835, 0.07, 0),
                new Point3D(1, 0, 0)
            };

            Point3D[] botCps =
            {
                new Point3D(-1, 0, 0),
                new Point3D(-0.98, -0.055, 0),
                new Point3D(-0.935, -0.1, 0),
                new Point3D(-0.87, -0.13, 0),
                new Point3D(-0.7525, -0.155, 0),
                new Point3D(-0.6825, -0.16, 0),
                new Point3D(-0.405, -0.16, 0),
                new Point3D(-0.17, -0.15, 0),
                new Point3D(0.17, -0.115, 0),
                new Point3D(0.4425, -0.08, 0),
                new Point3D(0.645, -0.055, 0),
                new Point3D(0.86, -0.025, 0),
                new Point3D(1, 0, 0)
            };

            graphics.Clear(Color.White);

            DrawAxes();

            drawSpline(spline, topCps);
            drawSpline(spline, botCps);
        }

        private void trkSplineYRot_Scroll(object sender, EventArgs e)
        {
            splineRotY = trkSplineYRot.Value;
            lblSplineYRot.Text = splineRotY.ToString();
            
            if (!bgwDrawing.IsBusy)
                bgwDrawing.RunWorkerAsync();
        }

        /*private void trkRoll_Scroll(object sender, EventArgs e)
        {
            camera.roll = trkRoll.Value;
            lblRoll.Text = camera.roll.ToString();

            if (!bgwDrawing.IsBusy)
                bgwDrawing.RunWorkerAsync();
        }*/

        private void trkYaw_Scroll(object sender, EventArgs e)
        {
            camera.yaw = trkYaw.Value;
            lblYaw.Text = camera.yaw.ToString();

            if (!bgwDrawing.IsBusy)
                bgwDrawing.RunWorkerAsync();
        }

        private void trkPitch_Scroll(object sender, EventArgs e)
        {
            camera.pitch = trkPitch.Value;
            lblPitch.Text = camera.pitch.ToString();

            if (!bgwDrawing.IsBusy)
                bgwDrawing.RunWorkerAsync();
        }
    }
}
