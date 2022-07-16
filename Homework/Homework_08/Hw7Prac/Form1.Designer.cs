namespace Homework_07
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
            this.pbxGraph = new System.Windows.Forms.PictureBox();
            this.bgwDrawing = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.trkSplineYRot = new System.Windows.Forms.TrackBar();
            this.lblSplineYRot = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblYaw = new System.Windows.Forms.Label();
            this.lblPitch = new System.Windows.Forms.Label();
            this.trkYaw = new System.Windows.Forms.TrackBar();
            this.trkPitch = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkSplineYRot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkYaw)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkPitch)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxGraph
            // 
            this.pbxGraph.BackColor = System.Drawing.Color.White;
            this.pbxGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxGraph.Location = new System.Drawing.Point(159, 12);
            this.pbxGraph.Name = "pbxGraph";
            this.pbxGraph.Size = new System.Drawing.Size(800, 400);
            this.pbxGraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxGraph.TabIndex = 5;
            this.pbxGraph.TabStop = false;
            // 
            // bgwDrawing
            // 
            this.bgwDrawing.WorkerReportsProgress = true;
            this.bgwDrawing.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDrawing_DoWork);
            this.bgwDrawing.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDrawing_Done);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Spline Rotation Y";
            // 
            // trkSplineYRot
            // 
            this.trkSplineYRot.LargeChange = 10;
            this.trkSplineYRot.Location = new System.Drawing.Point(12, 28);
            this.trkSplineYRot.Maximum = 360;
            this.trkSplineYRot.Name = "trkSplineYRot";
            this.trkSplineYRot.Size = new System.Drawing.Size(104, 45);
            this.trkSplineYRot.TabIndex = 7;
            this.trkSplineYRot.TickFrequency = 36;
            this.trkSplineYRot.Scroll += new System.EventHandler(this.trkSplineYRot_Scroll);
            // 
            // lblSplineYRot
            // 
            this.lblSplineYRot.AutoSize = true;
            this.lblSplineYRot.Location = new System.Drawing.Point(122, 28);
            this.lblSplineYRot.Name = "lblSplineYRot";
            this.lblSplineYRot.Size = new System.Drawing.Size(13, 13);
            this.lblSplineYRot.TabIndex = 8;
            this.lblSplineYRot.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Camera Rotation X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 206);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Camera Rotation Y";
            // 
            // lblYaw
            // 
            this.lblYaw.AutoSize = true;
            this.lblYaw.Location = new System.Drawing.Point(122, 158);
            this.lblYaw.Name = "lblYaw";
            this.lblYaw.Size = new System.Drawing.Size(13, 13);
            this.lblYaw.TabIndex = 16;
            this.lblYaw.Text = "0";
            // 
            // lblPitch
            // 
            this.lblPitch.AutoSize = true;
            this.lblPitch.Location = new System.Drawing.Point(122, 232);
            this.lblPitch.Name = "lblPitch";
            this.lblPitch.Size = new System.Drawing.Size(13, 13);
            this.lblPitch.TabIndex = 17;
            this.lblPitch.Text = "0";
            // 
            // trkYaw
            // 
            this.trkYaw.LargeChange = 10;
            this.trkYaw.Location = new System.Drawing.Point(12, 158);
            this.trkYaw.Maximum = 360;
            this.trkYaw.Name = "trkYaw";
            this.trkYaw.Size = new System.Drawing.Size(104, 45);
            this.trkYaw.TabIndex = 19;
            this.trkYaw.TickFrequency = 36;
            this.trkYaw.Scroll += new System.EventHandler(this.trkYaw_Scroll);
            // 
            // trkPitch
            // 
            this.trkPitch.LargeChange = 10;
            this.trkPitch.Location = new System.Drawing.Point(12, 222);
            this.trkPitch.Maximum = 360;
            this.trkPitch.Name = "trkPitch";
            this.trkPitch.Size = new System.Drawing.Size(104, 45);
            this.trkPitch.TabIndex = 20;
            this.trkPitch.TickFrequency = 36;
            this.trkPitch.Scroll += new System.EventHandler(this.trkPitch_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 423);
            this.Controls.Add(this.trkPitch);
            this.Controls.Add(this.trkYaw);
            this.Controls.Add(this.lblPitch);
            this.Controls.Add(this.lblYaw);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSplineYRot);
            this.Controls.Add(this.trkSplineYRot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbxGraph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Cubic Spline NACA 2412";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbxGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkSplineYRot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkYaw)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkPitch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void PbxGraph_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void BgwDrawing_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void BgwDrawing_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion
        private System.Windows.Forms.PictureBox pbxGraph;
        private System.ComponentModel.BackgroundWorker bgwDrawing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trkSplineYRot;
        private System.Windows.Forms.Label lblSplineYRot;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblYaw;
        private System.Windows.Forms.Label lblPitch;
        private System.Windows.Forms.TrackBar trkYaw;
        private System.Windows.Forms.TrackBar trkPitch;
    }
}

