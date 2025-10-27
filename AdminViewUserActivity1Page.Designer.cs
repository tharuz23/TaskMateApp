using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskMateApp
{
    partial class AdminViewUserActivity1Page
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private DataGridView dgvActivities;
        private Button btnBack;
        private DataGridViewTextBoxColumn colTaskNo;
        private DataGridViewTextBoxColumn colTitle;
        private DataGridViewTextBoxColumn colSupervisor;
        private DataGridViewTextBoxColumn colDueAt;
        private DataGridViewButtonColumn colView;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();

            this.lblTitle = new Label();
            this.dgvActivities = new DataGridView();
            this.colTaskNo = new DataGridViewTextBoxColumn();
            this.colTitle = new DataGridViewTextBoxColumn();
            this.colSupervisor = new DataGridViewTextBoxColumn();
            this.colDueAt = new DataGridViewTextBoxColumn();
            this.colView = new DataGridViewButtonColumn();
            this.btnBack = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvActivities)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Black;
            this.lblTitle.Location = new Point(50, 20);
            this.lblTitle.Size = new Size(880, 45);
            this.lblTitle.Text = "User Activity Table";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // dgvActivities
            this.dgvActivities.AllowUserToAddRows = false;
            this.dgvActivities.AllowUserToResizeRows = false;
            this.dgvActivities.BackgroundColor = Color.White;
            this.dgvActivities.BorderStyle = BorderStyle.FixedSingle;
            this.dgvActivities.GridColor = Color.FromArgb(147, 197, 253);
            this.dgvActivities.RowHeadersVisible = false;
            this.dgvActivities.RowTemplate.Height = 40;
            this.dgvActivities.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            this.dgvActivities.EnableHeadersVisualStyles = false;
            this.dgvActivities.CellContentClick += new DataGridViewCellEventHandler(this.dgvActivities_CellContentClick);

            // Header
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(147, 197, 253);
            headerStyle.ForeColor = Color.Black;
            headerStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.dgvActivities.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvActivities.ColumnHeadersHeight = 38;

            // Cells
            cellStyle.BackColor = Color.White;
            cellStyle.ForeColor = Color.Black;
            cellStyle.SelectionBackColor = Color.FromArgb(226, 239, 255);
            cellStyle.SelectionForeColor = Color.Black;
            this.dgvActivities.DefaultCellStyle = cellStyle;

            // Columns
            this.colTaskNo.HeaderText = "Task No";
            this.colTaskNo.Name = "colTaskNo";
            this.colTaskNo.Width = 80;

            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.Width = 250;

            this.colSupervisor.HeaderText = "Supervisor";
            this.colSupervisor.Name = "colSupervisor";
            this.colSupervisor.Width = 220;

            this.colDueAt.HeaderText = "Due At";
            this.colDueAt.Name = "colDueAt";
            this.colDueAt.Width = 190;

            this.colView.HeaderText = "Action";
            this.colView.Name = "colView";
            this.colView.Text = "View";
            this.colView.UseColumnTextForButtonValue = true;
            this.colView.FlatStyle = FlatStyle.Flat;
            this.colView.Width = 135;

            this.dgvActivities.Columns.AddRange(new DataGridViewColumn[] {
                this.colTaskNo, this.colTitle, this.colSupervisor, this.colDueAt, this.colView
            });

            this.dgvActivities.Location = new Point(50, 70);
            this.dgvActivities.Size = new Size(880, 420);

            // btnBack
            this.btnBack.BackColor = Color.LimeGreen;
            this.btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnBack.ForeColor = Color.Black;
            this.btnBack.Location = new Point(790, 510);
            this.btnBack.Size = new Size(140, 40);
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new EventHandler(this.btnBack_Click);

            // Form
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            this.ClientSize = new Size(980, 600);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvActivities);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "AdminViewUserActivity1Page";

            ((System.ComponentModel.ISupportInitialize)(this.dgvActivities)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
