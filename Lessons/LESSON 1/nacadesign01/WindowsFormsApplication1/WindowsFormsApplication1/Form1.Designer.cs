namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nacas = new System.Windows.Forms.TextBox();
            this.Start_Analysis = new System.Windows.Forms.Button();
            this.MaxCamber = new System.Windows.Forms.TextBox();
            this.DisttoMaxCamb = new System.Windows.Forms.TextBox();
            this.MaxThick = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.nacanum = new System.Windows.Forms.Label();
            this.MAXC = new System.Windows.Forms.Label();
            this.DisttoMaxC = new System.Windows.Forms.Label();
            this.MaxTh = new System.Windows.Forms.Label();
            this.LERadius = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtPoints = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // nacas
            // 
            this.nacas.Location = new System.Drawing.Point(101, 34);
            this.nacas.Name = "nacas";
            this.nacas.Size = new System.Drawing.Size(100, 20);
            this.nacas.TabIndex = 0;
            // 
            // Start_Analysis
            // 
            this.Start_Analysis.Location = new System.Drawing.Point(4, 5);
            this.Start_Analysis.Name = "Start_Analysis";
            this.Start_Analysis.Size = new System.Drawing.Size(100, 23);
            this.Start_Analysis.TabIndex = 1;
            this.Start_Analysis.Text = "Start_Analysis";
            this.Start_Analysis.UseVisualStyleBackColor = true;
            this.Start_Analysis.Click += new System.EventHandler(this.Start_Analysis_Click);
            // 
            // MaxCamber
            // 
            this.MaxCamber.Location = new System.Drawing.Point(101, 60);
            this.MaxCamber.Name = "MaxCamber";
            this.MaxCamber.Size = new System.Drawing.Size(100, 20);
            this.MaxCamber.TabIndex = 3;
            // 
            // DisttoMaxCamb
            // 
            this.DisttoMaxCamb.Location = new System.Drawing.Point(101, 83);
            this.DisttoMaxCamb.Name = "DisttoMaxCamb";
            this.DisttoMaxCamb.Size = new System.Drawing.Size(100, 20);
            this.DisttoMaxCamb.TabIndex = 4;
            // 
            // MaxThick
            // 
            this.MaxThick.Location = new System.Drawing.Point(101, 115);
            this.MaxThick.Name = "MaxThick";
            this.MaxThick.Size = new System.Drawing.Size(100, 20);
            this.MaxThick.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(101, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nacanum
            // 
            this.nacanum.AutoSize = true;
            this.nacanum.Location = new System.Drawing.Point(-2, 37);
            this.nacanum.Name = "nacanum";
            this.nacanum.Size = new System.Drawing.Size(86, 13);
            this.nacanum.TabIndex = 7;
            this.nacanum.Text = "NACA NUMBER";
            // 
            // MAXC
            // 
            this.MAXC.AutoSize = true;
            this.MAXC.Location = new System.Drawing.Point(1, 60);
            this.MAXC.Name = "MAXC";
            this.MAXC.Size = new System.Drawing.Size(78, 13);
            this.MAXC.TabIndex = 8;
            this.MAXC.Text = "MAX CAMBER";
            // 
            // DisttoMaxC
            // 
            this.DisttoMaxC.AutoSize = true;
            this.DisttoMaxC.Location = new System.Drawing.Point(-2, 86);
            this.DisttoMaxC.Name = "DisttoMaxC";
            this.DisttoMaxC.Size = new System.Drawing.Size(100, 13);
            this.DisttoMaxC.TabIndex = 9;
            this.DisttoMaxC.Text = "DISTTOMAXCAMB";
            // 
            // MaxTh
            // 
            this.MaxTh.AutoSize = true;
            this.MaxTh.Location = new System.Drawing.Point(4, 118);
            this.MaxTh.Name = "MaxTh";
            this.MaxTh.Size = new System.Drawing.Size(94, 13);
            this.MaxTh.TabIndex = 10;
            this.MaxTh.Text = "MAX THICKNESS";
            // 
            // LERadius
            // 
            this.LERadius.Location = new System.Drawing.Point(101, 154);
            this.LERadius.Name = "LERadius";
            this.LERadius.Size = new System.Drawing.Size(100, 20);
            this.LERadius.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "CIRCLE RADIUS AT";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(207, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(820, 406);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "LEADING EDGE";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(101, 198);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 16;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(101, 269);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 17;
            // 
            // txtPoints
            // 
            this.txtPoints.Location = new System.Drawing.Point(1033, 12);
            this.txtPoints.Multiline = true;
            this.txtPoints.Name = "txtPoints";
            this.txtPoints.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPoints.Size = new System.Drawing.Size(286, 389);
            this.txtPoints.TabIndex = 18;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1338, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 19;
            this.button2.Text = "go away";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1449, 413);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtPoints);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LERadius);
            this.Controls.Add(this.MaxTh);
            this.Controls.Add(this.DisttoMaxC);
            this.Controls.Add(this.MAXC);
            this.Controls.Add(this.nacanum);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MaxThick);
            this.Controls.Add(this.DisttoMaxCamb);
            this.Controls.Add(this.MaxCamber);
            this.Controls.Add(this.Start_Analysis);
            this.Controls.Add(this.nacas);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nacas;
        private System.Windows.Forms.Button Start_Analysis;
        private System.Windows.Forms.TextBox MaxCamber;
        private System.Windows.Forms.TextBox DisttoMaxCamb;
        private System.Windows.Forms.TextBox MaxThick;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label nacanum;
        private System.Windows.Forms.Label MAXC;
        private System.Windows.Forms.Label DisttoMaxC;
        private System.Windows.Forms.Label MaxTh;
        private System.Windows.Forms.TextBox LERadius;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtPoints;
        private System.Windows.Forms.Button button2;
    }
}

