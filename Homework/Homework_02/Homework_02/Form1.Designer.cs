namespace Homework_02
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pbxGraph = new System.Windows.Forms.PictureBox();
            this.bgwDrawing = new System.ComponentModel.BackgroundWorker();
            this.pgbDrawing = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxGraph
            // 
            this.pbxGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxGraph.Image = ((System.Drawing.Image)(resources.GetObject("pbxGraph.Image")));
            this.pbxGraph.Location = new System.Drawing.Point(12, 12);
            this.pbxGraph.Name = "pbxGraph";
            this.pbxGraph.Size = new System.Drawing.Size(800, 800);
            this.pbxGraph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxGraph.TabIndex = 5;
            this.pbxGraph.TabStop = false;
            // 
            // bgwDrawing
            // 
            this.bgwDrawing.WorkerReportsProgress = true;
            this.bgwDrawing.WorkerSupportsCancellation = false;
            this.bgwDrawing.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDrawing_DoWork);
            this.bgwDrawing.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwDrawing_ProgressChanged);
            this.bgwDrawing.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDrawing_Done);
            // 
            // pgbDrawing
            // 
            this.pgbDrawing.Location = new System.Drawing.Point(12, 818);
            this.pgbDrawing.Name = "pgbDrawing";
            this.pgbDrawing.Size = new System.Drawing.Size(800, 23);
            this.pgbDrawing.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 853);
            this.Controls.Add(this.pgbDrawing);
            this.Controls.Add(this.pbxGraph);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Mandelbrot Set";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbxGraph)).EndInit();
            this.ResumeLayout(false);

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
    }
}

