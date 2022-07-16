using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework_02
{
    public struct complex
    {
        public double re;
        public double im;
    }

    public partial class Form1 : Form
    {
        private const double MAX_MAGNITUDE = 1.5; // Blowup number (a radius).
        private const int MAX_ITERATIONS = 512; // For pen color.
        private Graphics graphics;

        public Form1()
        {
            InitializeComponent();

            graphics = Graphics.FromImage(pbxGraph.Image);
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
            Brush magicBrush;
            double magnitude = 0.0;

            for (int row = 0; row < pbxGraph.Height;)
            {
                for (int col = 0; col < pbxGraph.Width; col++)
                {
                    z.re = z.im = 0.0;

                    c.re = -2.0 + (col / (double)pbxGraph.Width) * 3.0;
                    c.im = -(-1.5 + (row / (double)pbxGraph.Height) * 3.0);

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

                    magicBrush = new SolidBrush(Color.FromArgb(255, (int) (magnitude * 10) % 256, (it * 7) % 256, (it * 13) % 256)); // Also part of the color determination.

                    graphics.FillRectangle(magicBrush, col, row, 1, 1); // Fill back buffer as much as you can before invalidate.
                }

                bgwDrawing.ReportProgress((int)(((++row * pbxGraph.Width) / (double)(pbxGraph.Width * pbxGraph.Height)) * 100.0));
            }
        }
    }
}
