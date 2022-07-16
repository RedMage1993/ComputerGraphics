namespace CS480Final
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Button();
            this.MAXC = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MXC = new System.Windows.Forms.TextBox();
            this.DtMc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MT = new System.Windows.Forms.TextBox();
            this.CRALE = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lblAttackPrompt = new System.Windows.Forms.Label();
            this.trkAttack = new System.Windows.Forms.TrackBar();
            this.lblAttack = new System.Windows.Forms.Label();
            this.lblLength = new System.Windows.Forms.Label();
            this.trkLength = new System.Windows.Forms.TrackBar();
            this.lblLengthPrompt = new System.Windows.Forms.Label();
            this.lblScale = new System.Windows.Forms.Label();
            this.trkScale = new System.Windows.Forms.TrackBar();
            this.lblScalePrompt = new System.Windows.Forms.Label();
            this.Button1 = new System.Windows.Forms.Button();
            this.lblXRot = new System.Windows.Forms.Label();
            this.trkXRot = new System.Windows.Forms.TrackBar();
            this.lblXRotPrompt = new System.Windows.Forms.Label();
            this.grpAlign = new System.Windows.Forms.GroupBox();
            this.radCenter = new System.Windows.Forms.RadioButton();
            this.radBack = new System.Windows.Forms.RadioButton();
            this.radFront = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkAttack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkXRot)).BeginInit();
            this.grpAlign.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.AllowDrop = true;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "0006",
            "0008",
            "0009",
            "0010",
            "0012",
            "0015",
            "0018",
            "0021",
            "0024",
            "1408",
            "1410",
            "1412",
            " 2408",
            " 2410",
            " 2411",
            " 2412",
            " 2414",
            "2415",
            " 2418",
            "2421",
            "2424",
            " 4412",
            "4415",
            "4418",
            "4421",
            "4424",
            "6409",
            "6412"});
            this.comboBox1.Location = new System.Drawing.Point(101, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(64, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "2421";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "NACA NUMBER";
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(90, -1);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(75, 23);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // MAXC
            // 
            this.MAXC.AutoSize = true;
            this.MAXC.Location = new System.Drawing.Point(2, 57);
            this.MAXC.Name = "MAXC";
            this.MAXC.Size = new System.Drawing.Size(66, 13);
            this.MAXC.TabIndex = 4;
            this.MAXC.Text = "Max Camber";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Dist. to Max Cam.";
            // 
            // MXC
            // 
            this.MXC.Location = new System.Drawing.Point(101, 55);
            this.MXC.Name = "MXC";
            this.MXC.Size = new System.Drawing.Size(64, 20);
            this.MXC.TabIndex = 6;
            // 
            // DtMc
            // 
            this.DtMc.Location = new System.Drawing.Point(101, 80);
            this.DtMc.Name = "DtMc";
            this.DtMc.Size = new System.Drawing.Size(64, 20);
            this.DtMc.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Max Thickness";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Circle Radius At";
            // 
            // MT
            // 
            this.MT.Location = new System.Drawing.Point(101, 102);
            this.MT.Name = "MT";
            this.MT.Size = new System.Drawing.Size(64, 20);
            this.MT.TabIndex = 10;
            // 
            // CRALE
            // 
            this.CRALE.Location = new System.Drawing.Point(101, 138);
            this.CRALE.Name = "CRALE";
            this.CRALE.Size = new System.Drawing.Size(64, 20);
            this.CRALE.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Leading Edge";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(171, 44);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 400);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(977, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(251, 400);
            this.textBox1.TabIndex = 14;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1234, 12);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(251, 400);
            this.textBox2.TabIndex = 15;
            // 
            // lblAttackPrompt
            // 
            this.lblAttackPrompt.AutoSize = true;
            this.lblAttackPrompt.Location = new System.Drawing.Point(5, 266);
            this.lblAttackPrompt.Name = "lblAttackPrompt";
            this.lblAttackPrompt.Size = new System.Drawing.Size(80, 13);
            this.lblAttackPrompt.TabIndex = 16;
            this.lblAttackPrompt.Text = "Angle of Attack";
            // 
            // trkAttack
            // 
            this.trkAttack.Location = new System.Drawing.Point(12, 282);
            this.trkAttack.Maximum = 90;
            this.trkAttack.Name = "trkAttack";
            this.trkAttack.Size = new System.Drawing.Size(106, 45);
            this.trkAttack.TabIndex = 17;
            this.trkAttack.TickFrequency = 10;
            this.trkAttack.Scroll += new System.EventHandler(this.trkAttack_Scroll);
            // 
            // lblAttack
            // 
            this.lblAttack.AutoSize = true;
            this.lblAttack.Location = new System.Drawing.Point(125, 282);
            this.lblAttack.Name = "lblAttack";
            this.lblAttack.Size = new System.Drawing.Size(13, 13);
            this.lblAttack.TabIndex = 18;
            this.lblAttack.Text = "0";
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(125, 333);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(25, 13);
            this.lblLength.TabIndex = 21;
            this.lblLength.Text = "800";
            // 
            // trkLength
            // 
            this.trkLength.Location = new System.Drawing.Point(12, 333);
            this.trkLength.Maximum = 800;
            this.trkLength.Minimum = 400;
            this.trkLength.Name = "trkLength";
            this.trkLength.Size = new System.Drawing.Size(106, 45);
            this.trkLength.TabIndex = 20;
            this.trkLength.TickFrequency = 36;
            this.trkLength.Value = 800;
            this.trkLength.Scroll += new System.EventHandler(this.trkLength_Scroll);
            // 
            // lblLengthPrompt
            // 
            this.lblLengthPrompt.AutoSize = true;
            this.lblLengthPrompt.Location = new System.Drawing.Point(5, 317);
            this.lblLengthPrompt.Name = "lblLengthPrompt";
            this.lblLengthPrompt.Size = new System.Drawing.Size(40, 13);
            this.lblLengthPrompt.TabIndex = 19;
            this.lblLengthPrompt.Text = "Length";
            // 
            // lblScale
            // 
            this.lblScale.AutoSize = true;
            this.lblScale.Location = new System.Drawing.Point(125, 384);
            this.lblScale.Name = "lblScale";
            this.lblScale.Size = new System.Drawing.Size(18, 13);
            this.lblScale.TabIndex = 24;
            this.lblScale.Text = "1x";
            // 
            // trkScale
            // 
            this.trkScale.Location = new System.Drawing.Point(12, 384);
            this.trkScale.Maximum = 4;
            this.trkScale.Minimum = 1;
            this.trkScale.Name = "trkScale";
            this.trkScale.Size = new System.Drawing.Size(106, 45);
            this.trkScale.TabIndex = 23;
            this.trkScale.Value = 1;
            this.trkScale.Scroll += new System.EventHandler(this.trkScale_Scroll);
            // 
            // lblScalePrompt
            // 
            this.lblScalePrompt.AutoSize = true;
            this.lblScalePrompt.Location = new System.Drawing.Point(5, 368);
            this.lblScalePrompt.Name = "lblScalePrompt";
            this.lblScalePrompt.Size = new System.Drawing.Size(34, 13);
            this.lblScalePrompt.TabIndex = 22;
            this.lblScalePrompt.Text = "Scale";
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(1, -1);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(88, 23);
            this.Button1.TabIndex = 1;
            this.Button1.Text = "Start Analysis";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Design_Click);
            // 
            // lblXRot
            // 
            this.lblXRot.AutoSize = true;
            this.lblXRot.Location = new System.Drawing.Point(125, 458);
            this.lblXRot.Name = "lblXRot";
            this.lblXRot.Size = new System.Drawing.Size(19, 13);
            this.lblXRot.TabIndex = 27;
            this.lblXRot.Text = "15";
            // 
            // trkXRot
            // 
            this.trkXRot.Location = new System.Drawing.Point(12, 458);
            this.trkXRot.Maximum = 90;
            this.trkXRot.Name = "trkXRot";
            this.trkXRot.Size = new System.Drawing.Size(106, 45);
            this.trkXRot.TabIndex = 26;
            this.trkXRot.TickFrequency = 10;
            this.trkXRot.Value = 15;
            this.trkXRot.Scroll += new System.EventHandler(this.trkXRot_Scroll);
            // 
            // lblXRotPrompt
            // 
            this.lblXRotPrompt.AutoSize = true;
            this.lblXRotPrompt.Location = new System.Drawing.Point(5, 442);
            this.lblXRotPrompt.Name = "lblXRotPrompt";
            this.lblXRotPrompt.Size = new System.Drawing.Size(34, 13);
            this.lblXRotPrompt.TabIndex = 25;
            this.lblXRotPrompt.Text = "X Rot";
            // 
            // grpAlign
            // 
            this.grpAlign.Controls.Add(this.radCenter);
            this.grpAlign.Controls.Add(this.radBack);
            this.grpAlign.Controls.Add(this.radFront);
            this.grpAlign.Location = new System.Drawing.Point(12, 164);
            this.grpAlign.Name = "grpAlign";
            this.grpAlign.Size = new System.Drawing.Size(153, 96);
            this.grpAlign.TabIndex = 28;
            this.grpAlign.TabStop = false;
            this.grpAlign.Text = "Z Alignment";
            // 
            // radCenter
            // 
            this.radCenter.AutoSize = true;
            this.radCenter.Checked = true;
            this.radCenter.Location = new System.Drawing.Point(6, 66);
            this.radCenter.Name = "radCenter";
            this.radCenter.Size = new System.Drawing.Size(56, 17);
            this.radCenter.TabIndex = 2;
            this.radCenter.TabStop = true;
            this.radCenter.Text = "Center";
            this.radCenter.UseVisualStyleBackColor = true;
            this.radCenter.CheckedChanged += new System.EventHandler(this.radAlign_CheckedChanged);
            // 
            // radBack
            // 
            this.radBack.AutoSize = true;
            this.radBack.Location = new System.Drawing.Point(7, 43);
            this.radBack.Name = "radBack";
            this.radBack.Size = new System.Drawing.Size(50, 17);
            this.radBack.TabIndex = 1;
            this.radBack.TabStop = true;
            this.radBack.Text = "Back";
            this.radBack.UseVisualStyleBackColor = true;
            this.radBack.CheckedChanged += new System.EventHandler(this.radAlign_CheckedChanged);
            // 
            // radFront
            // 
            this.radFront.AutoSize = true;
            this.radFront.Location = new System.Drawing.Point(7, 20);
            this.radFront.Name = "radFront";
            this.radFront.Size = new System.Drawing.Size(49, 17);
            this.radFront.TabIndex = 0;
            this.radFront.TabStop = true;
            this.radFront.Text = "Front";
            this.radFront.UseVisualStyleBackColor = true;
            this.radFront.CheckedChanged += new System.EventHandler(this.radAlign_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 503);
            this.Controls.Add(this.grpAlign);
            this.Controls.Add(this.lblXRot);
            this.Controls.Add(this.trkXRot);
            this.Controls.Add(this.lblXRotPrompt);
            this.Controls.Add(this.lblScale);
            this.Controls.Add(this.trkScale);
            this.Controls.Add(this.lblScalePrompt);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.trkLength);
            this.Controls.Add(this.lblLengthPrompt);
            this.Controls.Add(this.lblAttack);
            this.Controls.Add(this.trkAttack);
            this.Controls.Add(this.lblAttackPrompt);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CRALE);
            this.Controls.Add(this.MT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DtMc);
            this.Controls.Add(this.MXC);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.MAXC);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Button1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkAttack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkXRot)).EndInit();
            this.grpAlign.ResumeLayout(false);
            this.grpAlign.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.Label MAXC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox MXC;
        private System.Windows.Forms.TextBox DtMc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox MT;
        private System.Windows.Forms.TextBox CRALE;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label lblAttackPrompt;
        private System.Windows.Forms.TrackBar trkAttack;
        private System.Windows.Forms.Label lblAttack;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.TrackBar trkLength;
        private System.Windows.Forms.Label lblLengthPrompt;
        private System.Windows.Forms.Label lblScale;
        private System.Windows.Forms.TrackBar trkScale;
        private System.Windows.Forms.Label lblScalePrompt;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Label lblXRot;
        private System.Windows.Forms.Label lblXRotPrompt;
        private System.Windows.Forms.TrackBar trkXRot;
        private System.Windows.Forms.GroupBox grpAlign;
        private System.Windows.Forms.RadioButton radCenter;
        private System.Windows.Forms.RadioButton radBack;
        private System.Windows.Forms.RadioButton radFront;
    }
}

