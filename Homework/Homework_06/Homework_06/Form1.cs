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

namespace Homework_06
{
    public partial class Form1 : Form
    {
        private int halfWidth, halfHeight;
        private Graphics graphics;
        private DirectBitmap dbmp;
        private const int X_AXIS_LEN = 40; // Fake
        private const int X_INCREMENT = 22; // Screen
        private const int Y_AXIS_LEN = 4;  // Fake
        private const int Y_INCREMENT = 100; // Screen

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

        private void bgwDrawing_Done(object sender, RunWorkerCompletedEventArgs e)
        {
            pbxGraph.Invalidate();
        }

        private void DrawAxes()
        {
            Point[] arrow = new Point[3];
            Point[] axis = new Point[2];

            // x axis
            //---------------------------------------------
            // Left arrow
            arrow[0].X = -halfWidth + 10;
            arrow[0].Y = 10;
            arrow[1].X = -halfWidth;
            arrow[1].Y = 0;
            arrow[2].X = arrow[0].X;
            arrow[2].Y = -arrow[0].Y;

            graphics.DrawLines(Pens.Black, arrow);

            // horizontal line
            axis[0].X = -halfWidth;
            axis[0].Y = 0;
            axis[1].X = halfWidth;
            axis[1].Y = axis[0].Y;

            graphics.DrawLine(Pens.Black, axis[0], axis[1]);

            // Right arrow
            arrow[0].X = -arrow[0].X;
            arrow[1].X = -arrow[1].X;
            arrow[2].X = -arrow[2].X;

            graphics.DrawLines(Pens.Black, arrow);
            //-----------------------------------------------

            // y axis
            //---------------------------------------------
            // Top arrow
            arrow[0].Y = -halfHeight + 10;
            arrow[0].X = 10;
            arrow[1].Y = -halfHeight;
            arrow[1].X = 0;
            arrow[2].Y = arrow[0].Y;
            arrow[2].X = -arrow[0].X;

            graphics.DrawLines(Pens.Black, arrow);

            // Vertical line
            axis[0].Y = -halfHeight;
            axis[0].X = 0;
            axis[1].Y = halfHeight;
            axis[1].X = axis[0].X;

            graphics.DrawLine(Pens.Black, axis[0], axis[1]);

            // Bottom arrow
            arrow[0].Y = -arrow[0].Y;
            arrow[1].Y = -arrow[1].Y;
            arrow[2].Y = -arrow[2].Y;

            graphics.DrawLines(Pens.Black, arrow);
            //-----------------------------------------------
        }

        private void DrawTicks()
        {
            Font myFont = new Font(FontFamily.GenericSansSerif, 8);
          

            // x axis ticks
            for (int x = X_INCREMENT; x < halfWidth; x += X_INCREMENT)
            {
                graphics.DrawLine(Pens.Black, x, 10, x, -10);

                graphics.DrawString(((X_AXIS_LEN >> 1) * x / 220.0).ToString(), myFont, Brushes.Black, new PointF(x - 4, 15));
            }

            for (int x = -X_INCREMENT; x > -halfWidth; x -= X_INCREMENT)
            {
                graphics.DrawLine(Pens.Black, x, 10, x, -10);

                graphics.DrawString(((X_AXIS_LEN >> 1) * x / 220.0).ToString(), myFont, Brushes.Black, new PointF(x - 4, 15));
            }

            // y axis ticks
            for (int y = Y_INCREMENT; y < halfHeight; y += Y_INCREMENT)
            {
                graphics.DrawLine(Pens.Black, 10, y, -10, y);

                graphics.DrawString(((Y_AXIS_LEN >> 1) * y / 400.0).ToString(), myFont, Brushes.Black, new PointF(-35, -y - 8));
            }

            for (int y = -Y_INCREMENT; y > -halfHeight; y -= Y_INCREMENT)
            {
                graphics.DrawLine(Pens.Black, 10, y, -10, y);

                graphics.DrawString(((Y_AXIS_LEN >> 1) * y / 400.0).ToString(), myFont, Brushes.Black, new PointF(-35, -y - 8));
            }
        }

        private void DrawSine()
        {
            double y = 0.0;
            double rx = 0.0;
            PointF[] rys = new PointF[441];

            // From -220 to 220 (graphics).
            for (int x = -(10 * X_INCREMENT); x <= 10 * X_INCREMENT; x++)
            {
                rx = (double) x * (X_AXIS_LEN >> 1) / 220.0;

                if (rx == 0.0)
                    y = 1.0;
                else
                    y = Math.Sin(rx) / rx;

                rys[x + 220].X = x;
                rys[x + 220].Y = (float) (-y * 200.0);
            }

            graphics.DrawCurve(Pens.Red, rys);
        }

        private void bgwDrawing_DoWork(object sender, DoWorkEventArgs e)
        {
            DrawSine();
            DrawAxes();
            DrawTicks();
        }
    }
}
