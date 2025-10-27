using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskMateApp
{
    partial class AdminAddTaskPage
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblTaskNo;
        private TextBox txtTaskNo;
        private Label lblTaskName;
        private TextBox txtTitle;
        private Label lblTaskDescription;
        private TextBox txtDescription;
        private Label lblSupervisor;
        private ComboBox cmbSupervisor;
        private Label lblDueAt;
        private DateTimePicker dtpDue;
        private CheckBox chkLock;
        private Button btnAddTask;
        private Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblTaskNo = new Label();
            this.txtTaskNo = new TextBox();
            this.lblTaskName = new Label();
            this.txtTitle = new TextBox();
            this.lblTaskDescription = new Label();
            this.txtDescription = new TextBox();
            this.lblSupervisor = new Label();
            this.cmbSupervisor = new ComboBox();
            this.lblDueAt = new Label();
            this.dtpDue = new DateTimePicker();
            this.chkLock = new CheckBox();
            this.btnAddTask = new Button();
            this.btnBack = new Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Black;
            this.lblTitle.Location = new Point(50, 20);
            this.lblTitle.Size = new Size(880, 40);
            this.lblTitle.Text = "Add New Task";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblTaskNo
            this.lblTaskNo.Font = new Font("Segoe UI", 10F);
            this.lblTaskNo.Location = new Point(180, 100);
            this.lblTaskNo.Text = "Task No:";

            // txtTaskNo
            this.txtTaskNo.Font = new Font("Segoe UI", 10F);
            this.txtTaskNo.Location = new Point(350, 100);
            this.txtTaskNo.ReadOnly = true;
            this.txtTaskNo.Size = new Size(150, 34);

            // lblTaskName
            this.lblTaskName.Font = new Font("Segoe UI", 10F);
            this.lblTaskName.Location = new Point(180, 150);
            this.lblTaskName.Text = "Title:";

            // txtTitle
            this.txtTitle.Font = new Font("Segoe UI", 10F);
            this.txtTitle.Location = new Point(350, 150);
            this.txtTitle.Size = new Size(450, 34);

            // lblTaskDescription
            this.lblTaskDescription.Font = new Font("Segoe UI", 10F);
            this.lblTaskDescription.Location = new Point(180, 210);
            this.lblTaskDescription.Text = "Description:";

            // txtDescription
            this.txtDescription.Font = new Font("Segoe UI", 10F);
            this.txtDescription.Location = new Point(350, 210);
            this.txtDescription.Multiline = true;
            this.txtDescription.Size = new Size(450, 100);

            // lblSupervisor
            this.lblSupervisor.Font = new Font("Segoe UI", 10F);
            this.lblSupervisor.Location = new Point(180, 340);
            this.lblSupervisor.Text = "Supervisor:";

            // cmbSupervisor
            this.cmbSupervisor.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbSupervisor.Font = new Font("Segoe UI", 10F);
            this.cmbSupervisor.Location = new Point(350, 340);
            this.cmbSupervisor.Size = new Size(250, 36);

            // lblDueAt
            this.lblDueAt.Font = new Font("Segoe UI", 10F);
            this.lblDueAt.Location = new Point(180, 390);
            this.lblDueAt.Text = "Due At:";

            // dtpDue
            this.dtpDue.CustomFormat = "yyyy-MM-dd hh:mm tt";
            this.dtpDue.Font = new Font("Segoe UI", 10F);
            this.dtpDue.Format = DateTimePickerFormat.Custom;
            this.dtpDue.Location = new Point(350, 390);
            this.dtpDue.Size = new Size(250, 34);

            // chkLock
            this.chkLock.Font = new Font("Segoe UI", 10F);
            this.chkLock.Location = new Point(350, 440);
            this.chkLock.Text = "Lock this task";
            this.chkLock.AutoSize = true;

            // btnAddTask
            this.btnAddTask.BackColor = Color.FromArgb(59, 130, 246);
            this.btnAddTask.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnAddTask.ForeColor = Color.Black;
            this.btnAddTask.Location = new Point(432, 474);
            this.btnAddTask.Size = new Size(150, 40);
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = false;
            this.btnAddTask.Click += new EventHandler(this.btnAddTask_Click);

            // btnBack
            this.btnBack.BackColor = Color.LimeGreen;
            this.btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnBack.ForeColor = Color.Black;
            this.btnBack.Location = new Point(790, 531);
            this.btnBack.Size = new Size(140, 40);
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new EventHandler(this.btnBack_Click);

            // Form
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            this.ClientSize = new Size(980, 600);
            this.Controls.AddRange(new Control[] {
                this.lblTitle, this.lblTaskNo, this.txtTaskNo, this.lblTaskName, this.txtTitle,
                this.lblTaskDescription, this.txtDescription, this.lblSupervisor, this.cmbSupervisor,
                this.lblDueAt, this.dtpDue, this.chkLock, this.btnAddTask, this.btnBack });
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "AdminAddTaskPage";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
