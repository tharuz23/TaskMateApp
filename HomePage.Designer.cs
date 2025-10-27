using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskMateApp
{
    partial class HomePage
    {
        private System.ComponentModel.IContainer components = null;
        private PictureBox pictureLeft;
        private PictureBox pictureLogo;
        private Button btnGetStarted;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnGetStarted = new System.Windows.Forms.Button();
            this.pictureLeft = new System.Windows.Forms.PictureBox();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetStarted
            // 
            this.btnGetStarted.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnGetStarted.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGetStarted.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnGetStarted.ForeColor = System.Drawing.Color.White;
            this.btnGetStarted.Location = new System.Drawing.Point(598, 374);
            this.btnGetStarted.Name = "btnGetStarted";
            this.btnGetStarted.Size = new System.Drawing.Size(300, 48);
            this.btnGetStarted.TabIndex = 3;
            this.btnGetStarted.Text = "Get Started";
            this.btnGetStarted.UseVisualStyleBackColor = false;
            this.btnGetStarted.Click += new System.EventHandler(this.btnGetStarted_Click);
            // 
            // pictureLeft
            // 
            this.pictureLeft.Image = global::TaskMateApp.Properties.Resources.HomePageImage;
            this.pictureLeft.Location = new System.Drawing.Point(80, 90);
            this.pictureLeft.Name = "pictureLeft";
            this.pictureLeft.Size = new System.Drawing.Size(420, 420);
            this.pictureLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLeft.TabIndex = 0;
            this.pictureLeft.TabStop = false;
            // 
            // pictureLogo
            // 
            this.pictureLogo.Image = global::TaskMateApp.Properties.Resources.TaskMateLogo;
            this.pictureLogo.Location = new System.Drawing.Point(506, 90);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(444, 233);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLogo.TabIndex = 1;
            this.pictureLogo.TabStop = false;
            // 
            // HomePage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(980, 600);
            this.Controls.Add(this.pictureLeft);
            this.Controls.Add(this.pictureLogo);
            this.Controls.Add(this.btnGetStarted);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "HomePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HomePage";
            ((System.ComponentModel.ISupportInitialize)(this.pictureLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
