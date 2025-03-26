namespace WorkRestTimer
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblWork = new System.Windows.Forms.Label();
            this.lblRest = new System.Windows.Forms.Label();
            this.lblCycles = new System.Windows.Forms.Label();
            this.txtWork = new System.Windows.Forms.TextBox();
            this.txtRest = new System.Windows.Forms.TextBox();
            this.txtCycles = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblTimer = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWork
            // 
            this.lblWork.Location = new System.Drawing.Point(20, 20);
            this.lblWork.Name = "lblWork";
            this.lblWork.Size = new System.Drawing.Size(100, 23);
            this.lblWork.Text = "Work (min):";
            // 
            // lblRest
            // 
            this.lblRest.Location = new System.Drawing.Point(20, 60);
            this.lblRest.Name = "lblRest";
            this.lblRest.Size = new System.Drawing.Size(100, 23);
            this.lblRest.Text = "Rest (min):";
            // 
            // lblCycles
            // 
            this.lblCycles.Location = new System.Drawing.Point(20, 100);
            this.lblCycles.Name = "lblCycles";
            this.lblCycles.Size = new System.Drawing.Size(100, 23);
            this.lblCycles.Text = "Total Cycles:";
            // 
            // txtWork
            // 
            this.txtWork.Location = new System.Drawing.Point(130, 20);
            this.txtWork.Size = new System.Drawing.Size(100, 23);
            this.txtWork.Text = "25";
            // 
            // txtRest
            // 
            this.txtRest.Location = new System.Drawing.Point(130, 60);
            this.txtRest.Size = new System.Drawing.Size(100, 23);
            this.txtRest.Text = "5";
            // 
            // txtCycles
            // 
            this.txtCycles.Location = new System.Drawing.Point(130, 100);
            this.txtCycles.Size = new System.Drawing.Size(100, 23);
            this.txtCycles.Text = "4";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Location = new System.Drawing.Point(20, 140);
            this.btnStart.Size = new System.Drawing.Size(210, 35);
            this.btnStart.Text = "Start Timer";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblTimer
            // 
            this.lblTimer.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Bold);
            this.lblTimer.Location = new System.Drawing.Point(20, 190);
            this.lblTimer.Size = new System.Drawing.Size(210, 60);
            this.lblTimer.Text = "00:00";
            this.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblStatus.Location = new System.Drawing.Point(20, 260);
            this.lblStatus.Size = new System.Drawing.Size(210, 30);
            this.lblStatus.Text = "Waiting...";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.ClientSize = new System.Drawing.Size(254, 310);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblTimer);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtCycles);
            this.Controls.Add(this.txtRest);
            this.Controls.Add(this.txtWork);
            this.Controls.Add(this.lblCycles);
            this.Controls.Add(this.lblRest);
            this.Controls.Add(this.lblWork);
            this.Name = "Form1";
            this.Text = "Work-Rest Timer";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblWork, lblRest, lblCycles, lblTimer, lblStatus;
        private TextBox txtWork, txtRest, txtCycles;
        private Button btnStart;
    }
}
