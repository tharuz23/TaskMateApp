using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskMateApp
{
    partial class UserViewActivityTablePage
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private DataGridView dgvActivities;
        private Button btnBack;
        private DataGridViewTextBoxColumn colTaskNo;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colStatus;
        private DataGridViewTextBoxColumn colDueAt;
        private DataGridViewTextBoxColumn colSubmittedAt;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();

            this.lblTitle = new Label();
            this.dgvActivities = new DataGridView();
            this.colTaskNo = new DataGridViewTextBoxColumn();
            this.colTitle = new DataGridViewTextBoxColumn();
            this.colStatus = new DataGridViewTextBoxColumn();
            this.colDueAt = new DataGridViewTextBoxColumn();
            this.colSubmittedAt = new DataGridViewTextBoxColumn();
            this.btnBack = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvActivities)).BeginInit();
            this.SuspendLayout();

            // ===== Label =====
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Black;
            this.lblTitle.Location = new Point(50, 20);
            this.lblTitle.Size = new Size(880, 40);
            this.lblTitle.Text = "My Activity";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // ===== Header Style =====
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(147, 197, 253);
            headerStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            headerStyle.ForeColor = Color.Black;
            headerStyle.WrapMode = DataGridViewTriState.True;

            // ===== Grid =====
            this.dgvActivities.AllowUserToAddRows = false;
            this.dgvActivities.AllowUserToResizeRows = false;
            this.dgvActivities.BackgroundColor = Color.White;
            this.dgvActivities.BorderStyle = BorderStyle.None;
            this.dgvActivities.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            this.dgvActivities.GridColor = Color.FromArgb(147, 197, 253);
            this.dgvActivities.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvActivities.ColumnHeadersHeight = 38; // ✅ match task table
            this.dgvActivities.EnableHeadersVisualStyles = false;
            this.dgvActivities.Location = new Point(50, 80);
            this.dgvActivities.RowHeadersVisible = false;
            this.dgvActivities.RowTemplate.Height = 35; // ✅ match task table
            this.dgvActivities.Size = new Size(880, 400);
            this.dgvActivities.MultiSelect = false;
            this.dgvActivities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvActivities.ReadOnly = true;
            this.dgvActivities.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            this.dgvActivities.DefaultCellStyle.SelectionForeColor = Color.Black;

            // ===== Columns =====
            this.colTaskNo.HeaderText = "Task ID";
            this.colTaskNo.Width = 90;
            this.colTaskNo.ReadOnly = true;
            this.colTaskNo.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.colTitle.HeaderText = "Title";
            this.colTitle.Width = 200;
            this.colTitle.ReadOnly = true;
            this.colTitle.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.colStatus.HeaderText = "Status";
            this.colStatus.Width = 150;
            this.colStatus.ReadOnly = true;
            this.colStatus.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.colDueAt.HeaderText = "Due At";
            this.colDueAt.Width = 200;
            this.colDueAt.ReadOnly = true;
            this.colDueAt.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.colSubmittedAt.HeaderText = "Submitted At";
            this.colSubmittedAt.Width = 200;
            this.colSubmittedAt.ReadOnly = true;
            this.colSubmittedAt.SortMode = DataGridViewColumnSortMode.NotSortable;

            this.dgvActivities.Columns.AddRange(new DataGridViewColumn[] {
                this.colTaskNo, this.colTitle, this.colStatus, this.colDueAt, this.colSubmittedAt
            });

            // ===== Back Button =====
            this.btnBack.BackColor = Color.LimeGreen;
            this.btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnBack.ForeColor = Color.Black; // ✅ black text
            this.btnBack.Location = new Point(790, 500);
            this.btnBack.Size = new Size(140, 40);
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new EventHandler(this.btnBack_Click);

            // ===== Form =====
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            this.ClientSize = new Size(980, 600);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvActivities);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "UserViewActivityTablePage";

            ((System.ComponentModel.ISupportInitialize)(this.dgvActivities)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
