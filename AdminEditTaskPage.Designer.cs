using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskMateApp
{
    partial class AdminEditTaskPage
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTaskNo;
        private Label lblTitle;
        private Label lblDescription;
        private Label lblSupervisor;
        private Label lblDueAt;
        private TextBox txtTitle;
        private TextBox txtDescription;
        private TextBox txtSupervisor;
        private TextBox txtDueAt;
        private CheckBox chkLock;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTaskNo = new Label();
            this.lblTitle = new Label();
            this.lblDescription = new Label();
            this.lblSupervisor = new Label();
            this.lblDueAt = new Label();
            this.txtTitle = new TextBox();
            this.txtDescription = new TextBox();
            this.txtSupervisor = new TextBox();
            this.txtDueAt = new TextBox();
            this.chkLock = new CheckBox();
            this.btnDelete = new Button();
            this.btnUpdate = new Button();
            this.btnBack = new Button();
            this.SuspendLayout();

            // lblTaskNo
            this.lblTaskNo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblTaskNo.Location = new Point(370, 40);
            this.lblTaskNo.Size = new Size(200, 30);
            this.lblTaskNo.Text = "Task No 01";
            this.lblTaskNo.TextAlign = ContentAlignment.MiddleCenter;

            // Title / Description / etc.
            this.lblTitle.Font = new Font("Segoe UI", 10F);
            this.lblTitle.Location = new Point(120, 100);
            this.lblTitle.Text = "Title:";

            this.lblDescription.Font = new Font("Segoe UI", 10F);
            this.lblDescription.Location = new Point(120, 160);
            this.lblDescription.Text = "Description:";

            this.lblSupervisor.Font = new Font("Segoe UI", 10F);
            this.lblSupervisor.Location = new Point(120, 330);
            this.lblSupervisor.Text = "Supervisor:";

            this.lblDueAt.Font = new Font("Segoe UI", 10F);
            this.lblDueAt.Location = new Point(120, 390);
            this.lblDueAt.Text = "DueAt:";

            this.txtTitle.Location = new Point(257, 100);
            this.txtTitle.Size = new Size(500, 26);

            this.txtDescription.Location = new Point(257, 164);
            this.txtDescription.Multiline = true;
            this.txtDescription.Size = new Size(500, 140);

            this.txtSupervisor.Location = new Point(257, 329);
            this.txtSupervisor.Size = new Size(500, 26);

            this.txtDueAt.Location = new Point(257, 389);
            this.txtDueAt.Size = new Size(500, 26);

            // chkLock
            this.chkLock.Font = new Font("Segoe UI", 10F);
            this.chkLock.Location = new Point(257, 425);
            this.chkLock.Text = "Lock this task";
            this.chkLock.AutoSize = true;

            // Buttons
            this.btnDelete.BackColor = Color.Red;
            this.btnDelete.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnDelete.ForeColor = Color.Black;
            this.btnDelete.Location = new Point(300, 480);
            this.btnDelete.Size = new Size(120, 40);
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);

            this.btnUpdate.BackColor = Color.RoyalBlue;
            this.btnUpdate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnUpdate.ForeColor = Color.Black;
            this.btnUpdate.Location = new Point(460, 480);
            this.btnUpdate.Size = new Size(120, 40);
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);

            this.btnBack.BackColor = Color.LimeGreen;
            this.btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnBack.Location = new Point(831, 534);
            this.btnBack.Size = new Size(120, 40);
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new EventHandler(this.btnBack_Click);

            // Form
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            this.ClientSize = new Size(980, 600);
            this.Controls.AddRange(new Control[] {
                this.lblTaskNo,this.lblTitle,this.lblDescription,this.lblSupervisor,this.lblDueAt,
                this.txtTitle,this.txtDescription,this.txtSupervisor,this.txtDueAt,this.chkLock,
                this.btnDelete,this.btnUpdate,this.btnBack });
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "AdminEditTaskPage";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
