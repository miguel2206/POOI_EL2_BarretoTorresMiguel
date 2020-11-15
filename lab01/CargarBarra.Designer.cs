namespace lab01
{
    partial class CargarBarra
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
            this.pgbBarra = new System.Windows.Forms.ProgressBar();
            this.lblProgreso = new System.Windows.Forms.Label();
            this.bwSerie = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // pgbBarra
            // 
            this.pgbBarra.Location = new System.Drawing.Point(12, 75);
            this.pgbBarra.Name = "pgbBarra";
            this.pgbBarra.Size = new System.Drawing.Size(614, 35);
            this.pgbBarra.TabIndex = 1;
            this.pgbBarra.Click += new System.EventHandler(this.pgbBarra_Click);
            // 
            // lblProgreso
            // 
            this.lblProgreso.AutoSize = true;
            this.lblProgreso.Location = new System.Drawing.Point(12, 135);
            this.lblProgreso.Name = "lblProgreso";
            this.lblProgreso.Size = new System.Drawing.Size(83, 13);
            this.lblProgreso.TabIndex = 2;
            this.lblProgreso.Text = "Completado: 0%";
            // 
            // bwSerie
            // 
            this.bwSerie.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSerie_RunWorkerCompleted);
            // 
            // CargarBarra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 186);
            this.Controls.Add(this.lblProgreso);
            this.Controls.Add(this.pgbBarra);
            this.Name = "CargarBarra";
            this.Text = "CargarBarra";
            this.Load += new System.EventHandler(this.CargarBarra_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar pgbBarra;
        private System.Windows.Forms.Label lblProgreso;
        public System.ComponentModel.BackgroundWorker bwSerie;
    }
}