using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskMateApp
{
    partial class LoginPage
    {
        private System.ComponentModel.IContainer components = null;
        private Panel card;
        private Label lblLogin;
        private Label lblUser;
        private Label lblPass;
        private Panel pnlUser;
        private TextBox txtUser;
        private Panel pnlPass;
        private TextBox txtPass;
        private Button btnLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.card = new System.Windows.Forms.Panel();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.pnlUser = new System.Windows.Forms.Panel();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.pnlPass = new System.Windows.Forms.Panel();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.card.SuspendLayout();
            this.pnlUser.SuspendLayout();
            this.pnlPass.SuspendLayout();
            this.SuspendLayout();
            // 
            // card
            // 
            this.card.BackColor = System.Drawing.Color.White;
            this.card.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.card.Controls.Add(this.lblLogin);
            this.card.Controls.Add(this.lblUser);
            this.card.Controls.Add(this.pnlUser);
            this.card.Controls.Add(this.lblPass);
            this.card.Controls.Add(this.pnlPass);
            this.card.Controls.Add(this.btnLogin);
            this.card.Location = new System.Drawing.Point(290, 80);
            this.card.Name = "card";
            this.card.Size = new System.Drawing.Size(400, 440);
            this.card.TabIndex = 0;
            this.card.Resize += new System.EventHandler(this.RoundCardOnResize);
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Consolas", 24F);
            this.lblLogin.ForeColor = System.Drawing.Color.Black;
            this.lblLogin.Location = new System.Drawing.Point(160, 30);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(154, 56);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Login";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUser.Location = new System.Drawing.Point(55, 104);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(99, 28);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "Username";
            // 
            // pnlUser
            // 
            this.pnlUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.pnlUser.Controls.Add(this.txtUser);
            this.pnlUser.Location = new System.Drawing.Point(50, 135);
            this.pnlUser.Name = "pnlUser";
            this.pnlUser.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.pnlUser.Size = new System.Drawing.Size(300, 36);
            this.pnlUser.TabIndex = 2;
            this.pnlUser.Resize += new System.EventHandler(this.RoundFieldOnResize);
            // 
            // txtUser
            // 
            this.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtUser.Location = new System.Drawing.Point(10, 7);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(280, 27);
            this.txtUser.TabIndex = 0;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPass.Location = new System.Drawing.Point(55, 189);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(93, 28);
            this.lblPass.TabIndex = 3;
            this.lblPass.Text = "Password";
            // 
            // pnlPass
            // 
            this.pnlPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.pnlPass.Controls.Add(this.txtPass);
            this.pnlPass.Location = new System.Drawing.Point(50, 220);
            this.pnlPass.Name = "pnlPass";
            this.pnlPass.Padding = new System.Windows.Forms.Padding(10, 7, 10, 7);
            this.pnlPass.Size = new System.Drawing.Size(300, 36);
            this.pnlPass.TabIndex = 4;
            this.pnlPass.Resize += new System.EventHandler(this.RoundFieldOnResize);
            // 
            // txtPass
            // 
            this.txtPass.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtPass.Location = new System.Drawing.Point(10, 7);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(280, 27);
            this.txtPass.TabIndex = 1;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            // btnLogin
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(110, 300);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(180, 44);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Resize += new System.EventHandler(this.RoundButtonOnResize);
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // LoginPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(980, 600);
            this.Controls.Add(this.card);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginPage";
            this.Load += new System.EventHandler(this.LoginPage_Load);
            this.card.ResumeLayout(false);
            this.card.PerformLayout();
            this.pnlUser.ResumeLayout(false);
            this.pnlUser.PerformLayout();
            this.pnlPass.ResumeLayout(false);
            this.pnlPass.PerformLayout();
            this.ResumeLayout(false);

        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            ApplyRoundedCorners(card, 12);
            ApplyRoundedCorners(pnlUser, 16);
            ApplyRoundedCorners(pnlPass, 16);
            ApplyRoundedCorners(btnLogin, 18);
        }

        private void RoundCardOnResize(object sender, EventArgs e)
        {
            ApplyRoundedCorners(card, 12);
        }

        private void RoundFieldOnResize(object sender, EventArgs e)
        {
            var p = sender as Panel;
            if (p != null) ApplyRoundedCorners(p, 16);
        }

        private void RoundButtonOnResize(object sender, EventArgs e)
        {
            var c = sender as Control;
            if (c != null) ApplyRoundedCorners(c, 18);
        }

        private void ApplyRoundedCorners(Control c, int radius)
        {
            var r = new Rectangle(0, 0, c.Width, c.Height);
            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                int d = radius * 2;
                path.AddArc(r.X, r.Y, d, d, 180, 90);
                path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
                path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
                path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
                path.CloseFigure();
                c.Region = new Region(path);
            }
        }
    }
}
