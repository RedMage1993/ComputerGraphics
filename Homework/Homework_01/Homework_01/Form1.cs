using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace Homework_01
{
    public partial class Form1 : Form
    {
        private const double MAX_MAGNITUDE = 1.5; // Blowup number.
        private const int MAX_ITERATIONS = 512; // For pen color.
        private Graphics graphics;
        private Complex c;
        private object clicker = null;

        public Form1()
        {
            InitializeComponent();

            graphics = Graphics.FromImage(pbxGraph.Image);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Application.DoEvents(); // Let all messages in message queue be processed.

            btnCancel.BringToFront();

            ToggleProgress(true);
            c = new Complex(double.Parse(txtC0Input.Text), double.Parse(txtC1Input.Text));
            bgwDrawing.RunWorkerAsync();
        }

        private void ToggleProgress(bool toggle)
        {
            pgbDrawing.Visible = toggle;

            // Only ever true once. It's cause I'm trying to be fancy with how I handle the Cancel button.
            if (clicker != null)
                btnCancel.Location = ((Button) clicker).Location;
            btnCancel.Visible = toggle;

            btnGraph.Enabled = !toggle;
            btnDendrite.Enabled = !toggle;
            btnRabbit.Enabled = !toggle;
            btnDragon.Enabled = !toggle;
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

        private void bgwDrawing_Done(object sender, RunWorkerCompletedEventArgs e)
        {
            ToggleProgress(false);

            if (e.Cancelled)
                graphics.Clear(BackColor);

            pbxGraph.Invalidate();
        }

        private void bgwDrawing_DoWork(object sender, DoWorkEventArgs e)
        {
            Complex z;
            int it;
            bool explode;
            Brush magicBrush;
            double modifier = (c.Imaginary > 0) ? 1.0 / c.Imaginary : 1;

            for (int row = 0; row < pbxGraph.Height;)
            {
                for (int col = 0; col < pbxGraph.Width; col++)
                {
                    // Fake x and y axis used for calculation.
                    // -1.495 is used to offset/center the image.
                    // Using 1:1 ratio and distance of 3 to center image and avoid being skewed.
                    z = new Complex(-1.495 + (col / (double)pbxGraph.Width) * 3.0, -(-1.495 + (row / (double)pbxGraph.Height) * 3.0)); // Maximum red alert. Memory usage of peace!
                    explode = false;

                    // Main color determination code (escapees and prisoners).
                    for (it = 0; it < MAX_ITERATIONS * z.Magnitude * z.Magnitude * modifier && !explode; it++)
                    {
                        z = (z * z) + c;
                        if (z.Magnitude > MAX_MAGNITUDE)
                            explode = true;
                    }

                    if (explode)
                    {
                        magicBrush = Brushes.White;
                    }
                    else
                    {
                        magicBrush = new SolidBrush(Color.FromArgb(255, 0, 0, (it * 100) % 255)); // Also part of the color determination.
                    }

                    graphics.FillRectangle(magicBrush, col, row, 1, 1); // Fill back buffer as much as you can before invalidate.
                }

                if (bgwDrawing.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }

                bgwDrawing.ReportProgress((int)(((++row * pbxGraph.Width) / (double)(pbxGraph.Width * pbxGraph.Height)) * 100.0));
            }
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            clicker = sender;
            ToggleProgress(true);
            c = new Complex(double.Parse(txtC0Input.Text), double.Parse(txtC1Input.Text));
            bgwDrawing.RunWorkerAsync();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bgwDrawing.CancelAsync();
        }

        private void btnDendrite_Click(object sender, EventArgs e)
        {
            clicker = sender;
            ToggleProgress(true);
            c = new Complex(0.0, -1.0);

            // Let them see preset input.
            txtC0Input.Text = "0.0";
            txtC1Input.Text = "-1.0";

            bgwDrawing.RunWorkerAsync();
        }

        private void btnRabbit_Click(object sender, EventArgs e)
        {
            clicker = sender;
            ToggleProgress(true);
            c = new Complex(-0.1, 0.8);

            // Let them see preset input.
            txtC0Input.Text = "-0.1";
            txtC1Input.Text = "0.8";

            bgwDrawing.RunWorkerAsync();
        }

        private void btnDragon_Click(object sender, EventArgs e)
        {
            clicker = sender;
            ToggleProgress(true);
            c = new Complex(0.36, 0.1);

            // Let them see preset input.
            txtC0Input.Text = "0.36";
            txtC1Input.Text = "0.1";

            bgwDrawing.RunWorkerAsync();
        }
    }
}
