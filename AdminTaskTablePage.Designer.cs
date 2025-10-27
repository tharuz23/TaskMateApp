using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskMateApp
{
    partial class AdminTaskTablePage
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Panel panelBox;
        private DataGridView dgvTasks;
        private Button btnAddNewTask;
        private Button btnBack;
        private Button button1;
        private DataGridViewTextBoxColumn colTaskNo;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colDescription;
        private DataGridViewTextBoxColumn colSupervisor;
        private DataGridViewTextBoxColumn colDueAt;
        private DataGridViewButtonColumn manageColumn;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panelBox = new System.Windows.Forms.Panel();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.colTaskNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSupervisor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDueAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manageColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnAddNewTask = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(50, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(880, 40);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Tasks Table";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelBox
            // 
            this.panelBox.BackColor = System.Drawing.Color.White;
            this.panelBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBox.Controls.Add(this.dgvTasks);
            this.panelBox.Location = new System.Drawing.Point(50, 70);
            this.panelBox.Name = "panelBox";
            this.panelBox.Size = new System.Drawing.Size(880, 420);
            this.panelBox.TabIndex = 1;
            // 
            // dgvTasks
            // 
            this.dgvTasks.AllowUserToAddRows = false;
            this.dgvTasks.AllowUserToResizeRows = false;
            this.dgvTasks.BackgroundColor = System.Drawing.Color.White;
            this.dgvTasks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(197)))), ((int)(((byte)(253)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTasks.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTasks.ColumnHeadersHeight = 38;
            this.dgvTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTaskNo,
            this.colTitle,
            this.colDescription,
            this.colSupervisor,
            this.colDueAt,
            this.manageColumn});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTasks.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTasks.EnableHeadersVisualStyles = false;
            this.dgvTasks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(147)))), ((int)(((byte)(197)))), ((int)(((byte)(253)))));
            this.dgvTasks.Location = new System.Drawing.Point(0, 0);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.RowHeadersVisible = false;
            this.dgvTasks.RowHeadersWidth = 62;
            this.dgvTasks.RowTemplate.Height = 28;
            this.dgvTasks.Size = new System.Drawing.Size(878, 418);
            this.dgvTasks.TabIndex = 0;
            this.dgvTasks.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTasks_CellContentClick);
            // 
            // colTaskNo
            // 
            this.colTaskNo.HeaderText = "Task ID";
            this.colTaskNo.MinimumWidth = 8;
            this.colTaskNo.Name = "colTaskNo";
            // 
            // colTitle
            // 
            this.colTitle.HeaderText = "Title";
            this.colTitle.MinimumWidth = 8;
            this.colTitle.Name = "colTitle";
            this.colTitle.Width = 150;
            // 
            // colDescription
            // 
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDescription.HeaderText = "Description";
            this.colDescription.MinimumWidth = 8;
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 260;
            // 
            // colSupervisor
            // 
            this.colSupervisor.HeaderText = "Supervisor";
            this.colSupervisor.MinimumWidth = 8;
            this.colSupervisor.Name = "colSupervisor";
            this.colSupervisor.Width = 130;
            // 
            // colDueAt
            // 
            this.colDueAt.HeaderText = "Due At";
            this.colDueAt.MinimumWidth = 8;
            this.colDueAt.Name = "colDueAt";
            this.colDueAt.Width = 130;
            // 
            // manageColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            this.manageColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.manageColumn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.manageColumn.HeaderText = "Manage";
            this.manageColumn.MinimumWidth = 8;
            this.manageColumn.Name = "manageColumn";
            this.manageColumn.Text = "View";
            this.manageColumn.UseColumnTextForButtonValue = true;
            this.manageColumn.Width = 105;
            // 
            // btnAddNewTask
            // 
            this.btnAddNewTask.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnAddNewTask.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddNewTask.ForeColor = System.Drawing.Color.Black;
            this.btnAddNewTask.Location = new System.Drawing.Point(50, 510);
            this.btnAddNewTask.Name = "btnAddNewTask";
            this.btnAddNewTask.Size = new System.Drawing.Size(220, 40);
            this.btnAddNewTask.TabIndex = 2;
            this.btnAddNewTask.Text = "Add New Task";
            this.btnAddNewTask.UseVisualStyleBackColor = false;
            this.btnAddNewTask.Click += new System.EventHandler(this.btnAddNewTask_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.LimeGreen;
            this.btnBack.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.Black;
            this.btnBack.Location = new System.Drawing.Point(790, 510);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(140, 40);
            this.btnBack.TabIndex = 3;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // button1 (My Tasks)
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(825, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 27);
            this.button1.TabIndex = 4;
            this.button1.Text = "My Tasks";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // AdminTaskTablePage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(980, 600);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panelBox);
            this.Controls.Add(this.btnAddNewTask);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AdminTaskTablePage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminTaskTablePage";
            this.panelBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
