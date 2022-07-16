using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_03
{
    public struct complex
    {
        public double re;
        public double im;
    }

    public struct pointd
    {
        public double X;
        public double Y;

        public pointd(double _x, double _y)
        {
            X = _x;
            Y = _y;
        }
    }

    public partial class Form1 : Form
    {
        private const double MAX_MAGNITUDE = 1.5; // Blowup number (a radius).
        private const int MAX_ITERATIONS = 4096; // For pen color.
        private const double X_AXIS_LENGTH = 3.0;
        private const double Y_AXIS_LENGTH = 3.0;
        private int halfWidth, halfHeight;
        private Graphics graphics;
        private int[,] backup; // Better to save int argb?
        private int[,] init; // Initial Mandelbrot set.
        private bool isInit = false;
        private double pbToSqRatio = 1.0; // Picture Box to square ratio.
        private double prevPbToSqRatio = 1.0;
        // Out of 400 because origin is center of Picture Box, so we would be able to MOVE left (and right) only 400 pixels.
        // So 400 = pbxGraph.Width / 2. 200 would be our offset on the x-axis from origin.
        // 
        private pointd move = new pointd(0, 0); // x,y position of cursor on PictureBox click.
        private Point pos = new Point(400, 400);
        private DirectBitmap dbmp;
        private enum Action { ZOOM, NONE }; // Actions that need to run the worker.

        private Action lastAction = Action.NONE;

        private double totDistX = 0.0;
        private double totDistY = 0.0;
        private double prevDistX = 0.0;
        private double prevDistY = 0.0;

        public Form1()
        {
            InitializeComponent();

            // For faster access to pixels.
            dbmp = new DirectBitmap(pbxGraph.Width, pbxGraph.Height);

            halfWidth = pbxGraph.Width >> 1;
            halfHeight = pbxGraph.Height >> 1;

            pbxGraph.Image = dbmp.Bitmap;

            graphics = Graphics.FromImage(pbxGraph.Image);

            backup = new int[pbxGraph.Image.Height, pbxGraph.Image.Width];
            init = new int[pbxGraph.Image.Height, pbxGraph.Image.Width];
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Application.DoEvents(); // Let all messages in message queue be processed.

            bgwDrawing.RunWorkerAsync();
        }

        private void bgwDrawing_Done(object sender, RunWorkerCompletedEventArgs e)
        {
            pbxGraph.Invalidate();

            if (!isInit)
                isInit = true;

            if (lastAction == Action.ZOOM)
            {
                btnUndo.Enabled = true;
                btnRestart.Enabled = true;
            }
        }

        private void bgwDrawing_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Hotfix for progress bar not updating along with value immediately.
            if (e.ProgressPercentage < pgbDrawing.Maximum)
            {
                pgbDrawing.Value = e.ProgressPercentage + 1;
                pgbDrawing.Value = e.ProgressPercentage;
            }
            else
            {
                pgbDrawing.Maximum++;
                pgbDrawing.Value = e.ProgressPercentage + 1;
                pgbDrawing.Value = e.ProgressPercentage;
                pgbDrawing.Maximum--;
            }
        }

        private void bgwDrawing_DoWork(object sender, DoWorkEventArgs e)
        {
            complex c, z, prevZ;
            int it;
            double magnitude = 0.0;

            for (int row = 0; row < pbxGraph.Height;)
            {
                for (int col = 0; col < pbxGraph.Width; col++)
                {
                    z.re = z.im = 0.0;

                    // -1.5 to start image from top left corner.
                    // Not 100% sure why move doesn't require being multiplied by ratio.
                    // My best visualization is that we move to where we want to go, and then apply the zoom.
                    // What's strange is that also includes specifying where the top left corner is, during the zoom.
                    c.re = move.X + pbToSqRatio * (-1.5 + (col / (double)pbxGraph.Width) * X_AXIS_LENGTH);
                    c.im = move.Y + pbToSqRatio * (-1.5 + (row / (double)pbxGraph.Height) * Y_AXIS_LENGTH);

                    for (it = 0; it < MAX_ITERATIONS; it++)
                    {
                        prevZ.re = z.re;
                        prevZ.im = z.im;

                        z.re = prevZ.re * prevZ.re - prevZ.im * prevZ.im + c.re;
                        z.im = 2.0 * prevZ.re * prevZ.im + c.im;

                        magnitude = z.re * z.re + z.im * z.im;
                        if (magnitude > MAX_MAGNITUDE * MAX_MAGNITUDE)
                            break;
                    }

                    if (isInit)
                        backup[row, col] = dbmp.Bits[row * pbxGraph.Width + col];

                    dbmp.BitsBackup[row * pbxGraph.Width + col] = dbmp.Bits[row * pbxGraph.Width + col] = Color.FromArgb(255, (int)(magnitude * 10) % 256, (it * 7) % 256, (it * 13) % 256).ToArgb();

                    if (!isInit)
                        backup[row,col] = init[row, col] = dbmp.Bits[row * pbxGraph.Width + col];
                }

                bgwDrawing.ReportProgress((int)(((++row * pbxGraph.Width) / (double)(pbxGraph.Width * pbxGraph.Height)) * 100.0));
            }
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            int rectSideLen = int.Parse(txtLength.Text);

            btnZoom.Enabled = false;

            // Took me a while to get this part.
            // Needed to have a way to translate zoomed coordinates to original (scale = 1) coordinates.
            // Move values needed to end up being the same when clicking on the same part of the image.
            // I knew the scale (pbToSqRatio) started out at 1, and well, it is 1, so the coordinate distance from the origin
            // will be correct for the first zoom (you will zoom into what you click).
            prevDistX = (-halfWidth + pos.X) * pbToSqRatio;
            prevDistY = (-halfHeight + pos.Y) * pbToSqRatio;

            totDistX += prevDistX;
            totDistY += prevDistY;

            move.X = totDistX / halfWidth * X_AXIS_LENGTH / 2.0;
            move.Y = totDistY / halfHeight * Y_AXIS_LENGTH / 2.0;

            // Handle zooming ratio.
            prevPbToSqRatio = pbToSqRatio;
            pbToSqRatio *= (rectSideLen / (double)pbxGraph.Width);

            lastAction = Action.ZOOM;

            restoreBits(); // Remove the rectangle to leave but don't need to invalidate.
            bgwDrawing.RunWorkerAsync();
        }

        private void restoreBits()
        {
            for (int row = 0; row < pbxGraph.Height; row++)
            {
                for (int col = 0; col < pbxGraph.Width; col++)
                {
                    dbmp.Bits[row * pbxGraph.Width + col] = dbmp.BitsBackup[row * pbxGraph.Width + col];
                }
            }
        }

        private void restoreBackup()
        {
            for (int row = 0; row < pbxGraph.Height; row++)
            {
                for (int col = 0; col < pbxGraph.Width; col++)
                {
                    dbmp.BitsBackup[row * pbxGraph.Width + col] = dbmp.Bits[row * pbxGraph.Width + col] = backup[row, col];
                }
            }
        }

        private void restoreInit()
        {
            for (int row = 0; row < pbxGraph.Height; row++)
            {
                for (int col = 0; col < pbxGraph.Width; col++)
                {
                    dbmp.BitsBackup[row * pbxGraph.Width + col] = dbmp.Bits[row * pbxGraph.Width + col] = init[row, col];
                }
            }
        }

        private void pbxGraph_MouseClick(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            int rectSideLen = int.Parse(txtLength.Text);

            switch (me.Button)
            {
                case MouseButtons.Left:
                    pos = me.Location;

                    // Redraw backup, then draw box.
                    restoreBits();
                    graphics.DrawRectangle(Pens.White, me.Location.X - (rectSideLen >> 1), me.Location.Y - (rectSideLen >> 1), rectSideLen, rectSideLen);
                    pbxGraph.Invalidate();                   

                    btnZoom.Enabled = true;
                    break;

                case MouseButtons.Right:
                    restoreBits();
                    pbxGraph.Invalidate();
                    btnZoom.Enabled = false;
                    break;
                default:
                    // Nothing.
                    break;
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            btnUndo.Enabled = false;

            pbToSqRatio = prevPbToSqRatio;
            totDistX -= prevDistX;
            totDistY -= prevDistY;

            restoreBackup();
            pbxGraph.Invalidate();
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            btnRestart.Enabled = false;
            btnUndo.Enabled = false;
            btnZoom.Enabled = false;

            prevPbToSqRatio = pbToSqRatio = 1.0;
            totDistX = totDistY = 0.0;

            lastAction = Action.NONE;

            restoreInit();
            pbxGraph.Invalidate();
        }
    }
}
