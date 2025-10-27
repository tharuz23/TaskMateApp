using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskMateApp
{
    partial class AdminMyTasksPage
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Panel panelBox;
        private DataGridView dgvTasks;
        private Button btnBack;
        private DataGridViewTextBoxColumn colTaskNo;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colDescription;
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
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle cellStyle = new System.Windows.Forms.DataGridViewCellStyle();

            this.lblTitle = new System.Windows.Forms.Label();
            this.panelBox = new System.Windows.Forms.Panel();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.colTaskNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDueAt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manageColumn = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnBack = new System.Windows.Forms.Button();

            this.panelBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.SuspendLayout();

            // ===== Label =====
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Black;
            this.lblTitle.Location = new Point(50, 20);
            this.lblTitle.Size = new Size(880, 40);
            this.lblTitle.Text = "My Tasks";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // ===== Panel =====
            this.panelBox.BackColor = Color.White;
            this.panelBox.BorderStyle = BorderStyle.FixedSingle;
            this.panelBox.Controls.Add(this.dgvTasks);
            this.panelBox.Location = new Point(50, 70);
            this.panelBox.Size = new Size(880, 420);

            // ===== DataGridView =====
            this.dgvTasks.AllowUserToAddRows = false;
            this.dgvTasks.AllowUserToResizeRows = false;
            this.dgvTasks.BackgroundColor = Color.White;
            this.dgvTasks.BorderStyle = BorderStyle.None;
            this.dgvTasks.Dock = DockStyle.Fill;
            this.dgvTasks.GridColor = Color.FromArgb(147, 197, 253);
            this.dgvTasks.RowHeadersVisible = false;
            this.dgvTasks.RowTemplate.Height = 28;
            this.dgvTasks.CellContentClick += new DataGridViewCellEventHandler(this.dgvTasks_CellContentClick);

            // ===== Header Style =====
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(147, 197, 253);
            headerStyle.ForeColor = Color.Black;
            headerStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            headerStyle.WrapMode = DataGridViewTriState.True;
            this.dgvTasks.EnableHeadersVisualStyles = false;
            this.dgvTasks.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvTasks.ColumnHeadersHeight = 38;

            // ===== Cell Style =====
            cellStyle.BackColor = Color.White;
            cellStyle.ForeColor = Color.Black;
            cellStyle.SelectionBackColor = Color.FromArgb(226, 239, 255);
            cellStyle.SelectionForeColor = Color.Black;
            cellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvTasks.DefaultCellStyle = cellStyle;

            // ===== Columns =====
            this.colTaskNo.HeaderText = "Task ID";
            this.colTaskNo.Name = "colTaskNo";
            this.colTaskNo.Width = 90;

            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.Width = 150;

            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 365;

            this.colDueAt.HeaderText = "Due At";
            this.colDueAt.Name = "colDueAt";
            this.colDueAt.Width = 160;

            this.manageColumn.HeaderText = "Manage";
            this.manageColumn.Name = "manageColumn";
            this.manageColumn.Text = "View";
            this.manageColumn.UseColumnTextForButtonValue = true;
            this.manageColumn.FlatStyle = FlatStyle.Flat;
            this.manageColumn.DefaultCellStyle.ForeColor = Color.Black;
            this.manageColumn.Width = 110;

            this.dgvTasks.Columns.AddRange(new DataGridViewColumn[]
            {
                this.colTaskNo,
                this.colTitle,
                this.colDescription,
                this.colDueAt,
                this.manageColumn
            });

            // ===== Back Button =====
            this.btnBack.BackColor = Color.LimeGreen;
            this.btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnBack.ForeColor = Color.Black;
            this.btnBack.Location = new Point(790, 510);
            this.btnBack.Size = new Size(140, 40);
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new EventHandler(this.btnBack_Click);

            // ===== Form =====
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            this.ClientSize = new Size(980, 600);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panelBox);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "AdminMyTasksPage";

            this.panelBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
