using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drawpoints
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
            

        }

        private void Paint_Event(object sender, PaintEventArgs e)
        {
            Brush aBrush = (Brush)Brushes.Green;
            Brush bBrush = (Brush)Brushes.Blue;
            Brush cBrush = (Brush)Brushes.Red;
            Graphics g = this.CreateGraphics();

        
            int x = 0, y = 0;
            
            int ax = 410, ay = 10, bx = 10, by = 710, cx = 800, cy = 710;
            Random random = new Random();
            int rn = random.Next(0, 3);
            for (int i = 0; i < 40000; i++)
            {
              if (rn == 0)
              {
                  x = (x + ax) / 2;
                  y = (y + ay) / 2;
                  g.FillRectangle(aBrush, x, y, 1, 1);
              }

              else if (rn == 1)
              {
                  x = (x + bx) / 2;
                  y = (y + by) / 2;
                  g.FillRectangle(bBrush, x, y, 1, 1);
              }
              else if (rn == 2)
              {
                  x = (x + cx) / 2;
                  y = (y + cy) / 2;
                  g.FillRectangle(cBrush, x, y, 1, 1);
              }
              rn = random.Next(0, 3);
            }

        }
    }
}
