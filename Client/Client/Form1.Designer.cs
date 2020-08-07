namespace Client
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.batCharge = new System.Windows.Forms.Label();
            this.charger = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // batCharge
            // 
            this.batCharge.AutoSize = true;
            this.batCharge.Location = new System.Drawing.Point(65, 110);
            this.batCharge.Name = "batCharge";
            this.batCharge.Size = new System.Drawing.Size(118, 13);
            this.batCharge.TabIndex = 0;
            this.batCharge.Text = "Battery Percentage: ?%";
            // 
            // charger
            // 
            this.charger.AutoSize = true;
            this.charger.Location = new System.Drawing.Point(65, 74);
            this.charger.Name = "charger";
            this.charger.Size = new System.Drawing.Size(109, 13);
            this.charger.TabIndex = 1;
            this.charger.Text = "Charger Plugged in: ?";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(58, 126);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(125, 37);
            this.progressBar1.TabIndex = 2;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 320);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.charger);
            this.Controls.Add(this.batCharge);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Neuroware Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label batCharge;
        private System.Windows.Forms.Label charger;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

