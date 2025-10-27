using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskMateApp
{
    partial class WelcomeAdminPage
    {
        private System.ComponentModel.IContainer components = null;
        private Panel sideMenu;
        private Button btnTaskMate;
        private Button btnManageTasks;
        private Button btnViewActivities;
        private Button btnAddUser;
        private Label lblWelcome;
        private PictureBox pictureLogo;
        private PictureBox pictureMain;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.sideMenu = new System.Windows.Forms.Panel();
            this.btnTaskMate = new System.Windows.Forms.Button();
            this.btnManageTasks = new System.Windows.Forms.Button();
            this.btnViewActivities = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.pictureMain = new System.Windows.Forms.PictureBox();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.sideMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMain)).BeginInit();
            this.SuspendLayout();
            // 
            // sideMenu
            // 
            this.sideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(219)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.sideMenu.Controls.Add(this.btnTaskMate);
            this.sideMenu.Controls.Add(this.btnManageTasks);
            this.sideMenu.Controls.Add(this.btnViewActivities);
            this.sideMenu.Controls.Add(this.btnAddUser);
            this.sideMenu.Location = new System.Drawing.Point(30, 54);
            this.sideMenu.Name = "sideMenu";
            this.sideMenu.Size = new System.Drawing.Size(180, 502);
            this.sideMenu.TabIndex = 0;
            // 
            // btnTaskMate
            // 
            this.btnTaskMate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(197)))), ((int)(((byte)(253)))));
            this.btnTaskMate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTaskMate.Location = new System.Drawing.Point(20, 40);
            this.btnTaskMate.Name = "btnTaskMate";
            this.btnTaskMate.Size = new System.Drawing.Size(140, 83);
            this.btnTaskMate.TabIndex = 0;
            this.btnTaskMate.Text = "TaskMate";
            this.btnTaskMate.UseVisualStyleBackColor = false;
            this.btnTaskMate.Click += new System.EventHandler(this.btnTaskMate_Click);
            // 
            // btnManageTasks
            // 
            this.btnManageTasks.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnManageTasks.Location = new System.Drawing.Point(20, 149);
            this.btnManageTasks.Name = "btnManageTasks";
            this.btnManageTasks.Size = new System.Drawing.Size(140, 84);
            this.btnManageTasks.TabIndex = 1;
            this.btnManageTasks.Text = "Manage Tasks";
            // 
            // btnViewActivities
            // 
            this.btnViewActivities.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnViewActivities.Location = new System.Drawing.Point(20, 258);
            this.btnViewActivities.Name = "btnViewActivities";
            this.btnViewActivities.Size = new System.Drawing.Size(140, 92);
            this.btnViewActivities.TabIndex = 2;
            this.btnViewActivities.Text = "View/Manage User Activities";
            // 
            // btnAddUser
            // 
            this.btnAddUser.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAddUser.Location = new System.Drawing.Point(20, 375);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(140, 92);
            this.btnAddUser.TabIndex = 3;
            this.btnAddUser.Text = "View / Add Users";
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Consolas", 24F);
            this.lblWelcome.Location = new System.Drawing.Point(265, 54);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(444, 76);
            this.lblWelcome.TabIndex = 1;
            this.lblWelcome.Text = "Welcome Admin to";
            // 
            // pictureLogo
            // 
            this.pictureLogo.Image = global::TaskMateApp.Properties.Resources.TaskMateLogo;
            this.pictureLogo.Location = new System.Drawing.Point(643, 133);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(255, 67);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLogo.TabIndex = 2;
            this.pictureLogo.TabStop = false;
            // 
            // pictureMain
            // 
            this.pictureMain.Image = global::TaskMateApp.Properties.Resources.WelcomePageImage;
            this.pictureMain.Location = new System.Drawing.Point(375, 225);
            this.pictureMain.Name = "pictureMain";
            this.pictureMain.Size = new System.Drawing.Size(366, 315);
            this.pictureMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureMain.TabIndex = 3;
            this.pictureMain.TabStop = false;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.OrangeRed;
            this.btnLogOut.Location = new System.Drawing.Point(884, 44);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(75, 38);
            this.btnLogOut.TabIndex = 4;
            this.btnLogOut.Text = "LogOut";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            this.btnTaskMate.Click += new System.EventHandler(this.btnTaskMate_Click);
            this.btnManageTasks.Click += new System.EventHandler(this.btnManageTasks_Click);
            this.btnViewActivities.Click += new System.EventHandler(this.btnViewActivities_Click);
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // WelcomeAdminPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(980, 600);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.sideMenu);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.pictureLogo);
            this.Controls.Add(this.pictureMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "WelcomeAdminPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WelcomeAdminPage";
            this.Load += new System.EventHandler(this.WelcomeAdminPage_Load);
            this.sideMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureMain)).EndInit();
            this.ResumeLayout(false);

        }

        private Button btnLogOut;
    }
}
