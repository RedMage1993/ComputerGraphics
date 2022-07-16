namespace Homework_01
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
            this.lblC1Prompt = new System.Windows.Forms.Label();
            this.txtC1Input = new System.Windows.Forms.TextBox();
            this.pbxGraph = new System.Windows.Forms.PictureBox();
            this.btnGraph = new System.Windows.Forms.Button();
            this.txtC0Input = new System.Windows.Forms.TextBox();
            this.lblC0Prompt = new System.Windows.Forms.Label();
            this.pgbDrawing = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.bgwDrawing = new System.ComponentModel.BackgroundWorker();
            this.btnDendrite = new System.Windows.Forms.Button();
            this.btnRabbit = new System.Windows.Forms.Button();
            this.btnDragon = new System.Windows.Forms.Button();
            this.lblPresets = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // lblC1Prompt
            // 
            this.lblC1Prompt.AutoSize = true;
            this.lblC1Prompt.Location = new System.Drawing.Point(12, 48);
            this.lblC1Prompt.Name = "lblC1Prompt";
            this.lblC1Prompt.Size = new System.Drawing.Size(23, 13);
            this.lblC1Prompt.TabIndex = 4;
            this.lblC1Prompt.Text = "C1:";
            // 
            // txtC1Input
            // 
            this.txtC1Input.Location = new System.Drawing.Point(12, 64);
            this.txtC1Input.Name = "txtC1Input";
            this.txtC1Input.Size = new System.Drawing.Size(100, 20);
            this.txtC1Input.TabIndex = 3;
            this.txtC1Input.Text = "0.8";
            // 
            // pbxGraph
            // 
            this.pbxGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxGraph.Image = ((System.Drawing.Image)(resources.GetObject("pbxGraph.Image")));
            this.pbxGraph.Location = new System.Drawing.Point(118, 12);
            this.pbxGraph.Name = "pbxGraph";
            this.pbxGraph.Size = new System.Drawing.Size(800, 800);
            this.pbxGraph.TabIndex = 5;
            this.pbxGraph.TabStop = false;
            // 
            // btnGraph
            // 
            this.btnGraph.Location = new System.Drawing.Point(12, 90);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(100, 23);
            this.btnGraph.TabIndex = 6;
            this.btnGraph.Text = "Graph";
            this.btnGraph.UseVisualStyleBackColor = true;
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // txtC0Input
            // 
            this.txtC0Input.Location = new System.Drawing.Point(12, 25);
            this.txtC0Input.Name = "txtC0Input";
            this.txtC0Input.Size = new System.Drawing.Size(100, 20);
            this.txtC0Input.TabIndex = 0;
            this.txtC0Input.Text = "-0.1";
            // 
            // lblC0Prompt
            // 
            this.lblC0Prompt.AutoSize = true;
            this.lblC0Prompt.Location = new System.Drawing.Point(12, 9);
            this.lblC0Prompt.Name = "lblC0Prompt";
            this.lblC0Prompt.Size = new System.Drawing.Size(23, 13);
            this.lblC0Prompt.TabIndex = 1;
            this.lblC0Prompt.Text = "C0:";
            // 
            // pgbDrawing
            // 
            this.pgbDrawing.Location = new System.Drawing.Point(12, 119);
            this.pgbDrawing.Name = "pgbDrawing";
            this.pgbDrawing.Size = new System.Drawing.Size(100, 23);
            this.pgbDrawing.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pgbDrawing.TabIndex = 7;
            this.pgbDrawing.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 90);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // bgwDrawing
            // 
            this.bgwDrawing.WorkerReportsProgress = true;
            this.bgwDrawing.WorkerSupportsCancellation = true;
            this.bgwDrawing.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDrawing_DoWork);
            this.bgwDrawing.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwDrawing_ProgressChanged);
            this.bgwDrawing.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwDrawing_Done);
            // 
            // btnDendrite
            // 
            this.btnDendrite.Location = new System.Drawing.Point(12, 161);
            this.btnDendrite.Name = "btnDendrite";
            this.btnDendrite.Size = new System.Drawing.Size(100, 23);
            this.btnDendrite.TabIndex = 9;
            this.btnDendrite.Text = "the Dendrite";
            this.btnDendrite.UseVisualStyleBackColor = true;
            this.btnDendrite.Click += new System.EventHandler(this.btnDendrite_Click);
            // 
            // btnRabbit
            // 
            this.btnRabbit.Location = new System.Drawing.Point(12, 190);
            this.btnRabbit.Name = "btnRabbit";
            this.btnRabbit.Size = new System.Drawing.Size(100, 23);
            this.btnRabbit.TabIndex = 11;
            this.btnRabbit.Text = "the Rabbit";
            this.btnRabbit.UseVisualStyleBackColor = true;
            this.btnRabbit.Click += new System.EventHandler(this.btnRabbit_Click);
            // 
            // btnDragon
            // 
            this.btnDragon.Location = new System.Drawing.Point(12, 219);
            this.btnDragon.Name = "btnDragon";
            this.btnDragon.Size = new System.Drawing.Size(100, 23);
            this.btnDragon.TabIndex = 12;
            this.btnDragon.Text = "the Dragon";
            this.btnDragon.UseVisualStyleBackColor = true;
            this.btnDragon.Click += new System.EventHandler(this.btnDragon_Click);
            // 
            // lblPresets
            // 
            this.lblPresets.AutoSize = true;
            this.lblPresets.Location = new System.Drawing.Point(12, 145);
            this.lblPresets.Name = "lblPresets";
            this.lblPresets.Size = new System.Drawing.Size(45, 13);
            this.lblPresets.TabIndex = 13;
            this.lblPresets.Text = "Presets:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 824);
            this.Controls.Add(this.lblPresets);
            this.Controls.Add(this.btnDragon);
            this.Controls.Add(this.btnRabbit);
            this.Controls.Add(this.btnDendrite);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pgbDrawing);
            this.Controls.Add(this.btnGraph);
            this.Controls.Add(this.pbxGraph);
            this.Controls.Add(this.lblC1Prompt);
            this.Controls.Add(this.txtC1Input);
            this.Controls.Add(this.lblC0Prompt);
            this.Controls.Add(this.txtC0Input);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Julia Set";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pbxGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Label lblC1Prompt;
        private System.Windows.Forms.TextBox txtC1Input;
        private System.Windows.Forms.PictureBox pbxGraph;
        private System.Windows.Forms.Button btnGraph;
        private System.Windows.Forms.TextBox txtC0Input;
        private System.Windows.Forms.Label lblC0Prompt;
        private System.Windows.Forms.ProgressBar pgbDrawing;
        private System.Windows.Forms.Button btnCancel;
        private System.ComponentModel.BackgroundWorker bgwDrawing;
        private System.Windows.Forms.Button btnDendrite;
        private System.Windows.Forms.Button btnDragon;
        private System.Windows.Forms.Button btnRabbit;
        private System.Windows.Forms.Label lblPresets;
    }
}

