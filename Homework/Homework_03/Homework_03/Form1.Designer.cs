namespace Homework_03
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
            this.pgbDrawing = new System.Windows.Forms.ProgressBar();
            this.btnZoom = new System.Windows.Forms.Button();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.lblLengthPrompt = new System.Windows.Forms.Label();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnRestart = new System.Windows.Forms.Button();
            this.lblProgress = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxGraph
            // 
            this.pbxGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxGraph.Location = new System.Drawing.Point(118, 12);
            this.pbxGraph.Name = "pbxGraph";
            this.pbxGraph.Size = new System.Drawing.Size(800, 800);
            this.pbxGraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxGraph.TabIndex = 5;
            this.pbxGraph.TabStop = false;
            this.pbxGraph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbxGraph_MouseClick);
            // 
            // bgwDrawing
            // 
            this.bgwDrawing.WorkerReportsProgress = true;
            this.bgwDrawing.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDrawing_DoWork);
            this.bgwDrawing.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwDrawing_ProgressChanged);
            this.bgwDrawing.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDrawing_Done);
            // 
            // pgbDrawing
            // 
            this.pgbDrawing.Location = new System.Drawing.Point(12, 83);
            this.pgbDrawing.Name = "pgbDrawing";
            this.pgbDrawing.Size = new System.Drawing.Size(100, 23);
            this.pgbDrawing.TabIndex = 6;
            // 
            // btnZoom
            // 
            this.btnZoom.Enabled = false;
            this.btnZoom.Location = new System.Drawing.Point(12, 54);
            this.btnZoom.Name = "btnZoom";
            this.btnZoom.Size = new System.Drawing.Size(100, 23);
            this.btnZoom.TabIndex = 8;
            this.btnZoom.Text = "Zoom";
            this.btnZoom.UseVisualStyleBackColor = true;
            this.btnZoom.Click += new System.EventHandler(this.btnZoom_Click);
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(12, 28);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(100, 20);
            this.txtLength.TabIndex = 9;
            this.txtLength.Text = "400";
            // 
            // lblLengthPrompt
            // 
            this.lblLengthPrompt.AutoSize = true;
            this.lblLengthPrompt.Location = new System.Drawing.Point(12, 12);
            this.lblLengthPrompt.Name = "lblLengthPrompt";
            this.lblLengthPrompt.Size = new System.Drawing.Size(85, 13);
            this.lblLengthPrompt.TabIndex = 10;
            this.lblLengthPrompt.Text = "Box Side Length";
            this.lblLengthPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnUndo
            // 
            this.btnUndo.Enabled = false;
            this.btnUndo.Location = new System.Drawing.Point(12, 134);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(100, 23);
            this.btnUndo.TabIndex = 11;
            this.btnUndo.Text = "Undo Last Zoom";
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // btnRestart
            // 
            this.btnRestart.Enabled = false;
            this.btnRestart.Location = new System.Drawing.Point(12, 163);
            this.btnRestart.Name = "btnRestart";
            this.btnRestart.Size = new System.Drawing.Size(100, 23);
            this.btnRestart.TabIndex = 12;
            this.btnRestart.Text = "Restart";
            this.btnRestart.UseVisualStyleBackColor = true;
            this.btnRestart.Click += new System.EventHandler(this.btnRestart_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(12, 118);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(48, 13);
            this.lblProgress.TabIndex = 13;
            this.lblProgress.Text = "Progress";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 824);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btnRestart);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.lblLengthPrompt);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.btnZoom);
            this.Controls.Add(this.pgbDrawing);
            this.Controls.Add(this.pbxGraph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Mandelbrot Set Zoom - Left click to add square / Right click to remove square";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbxGraph)).EndInit();
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
        private System.Windows.Forms.ProgressBar pgbDrawing;
        private System.Windows.Forms.Button btnZoom;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label lblLengthPrompt;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnRestart;
        private System.Windows.Forms.Label lblProgress;
    }
}

