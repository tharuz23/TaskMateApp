using System.Drawing;
using System.Windows.Forms;

namespace TaskMateApp
{
    partial class UserTaskTablePage
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private DataGridView dgvTasks;
        private Button btnViewMyActivity;
        private Button btnBack;
        private DataGridViewTextBoxColumn colTaskID;
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
            DataGridViewCellStyle headerStyle = new DataGridViewCellStyle();
            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle();

            this.lblTitle = new Label();
            this.dgvTasks = new DataGridView();
            this.colTaskID = new DataGridViewTextBoxColumn();
            this.colTitle = new DataGridViewTextBoxColumn();
            this.colDescription = new DataGridViewTextBoxColumn();
            this.colDueAt = new DataGridViewTextBoxColumn();
            this.manageColumn = new DataGridViewButtonColumn();
            this.btnViewMyActivity = new Button();
            this.btnBack = new Button();

            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            this.SuspendLayout();

            // ===== Label =====
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Black;
            this.lblTitle.Location = new Point(50, 20);
            this.lblTitle.Size = new Size(880, 40);
            this.lblTitle.Text = "Task List";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // ===== DataGridView =====
            this.dgvTasks.AllowUserToAddRows = false;
            this.dgvTasks.AllowUserToResizeRows = false;
            this.dgvTasks.BackgroundColor = Color.White;

            
            this.dgvTasks.BorderStyle = BorderStyle.None;
            this.dgvTasks.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvTasks.GridColor = Color.FromArgb(147, 197, 253);

            this.dgvTasks.Location = new Point(50, 80);
            this.dgvTasks.Size = new Size(880, 400);
            this.dgvTasks.RowHeadersVisible = false;
            this.dgvTasks.RowTemplate.Height = 35;
            this.dgvTasks.MultiSelect = false;
            this.dgvTasks.ReadOnly = true;
            this.dgvTasks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvTasks.CellContentClick += new DataGridViewCellEventHandler(this.dgvTasks_CellContentClick);
            this.dgvTasks.CellPainting += new DataGridViewCellPaintingEventHandler(this.dgvTasks_CellPainting);

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
            cellStyle.SelectionBackColor = Color.White;
            cellStyle.SelectionForeColor = Color.Black;
            this.dgvTasks.DefaultCellStyle = cellStyle;

            // ===== Columns =====
            this.colTaskID.HeaderText = "Task ID";
            this.colTaskID.Name = "colTaskID";
            this.colTaskID.Width = 90;
            this.colTaskID.ReadOnly = true;

            this.colTitle.HeaderText = "Title";
            this.colTitle.Name = "colTitle";
            this.colTitle.Width = 200;
            this.colTitle.ReadOnly = true;

            this.colDescription.HeaderText = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 300;
            this.colDescription.ReadOnly = true;
            this.colDescription.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            this.colDueAt.HeaderText = "Due Date";
            this.colDueAt.Name = "colDueAt";
            this.colDueAt.Width = 180;
            this.colDueAt.ReadOnly = true;

            this.manageColumn.HeaderText = "Manage";
            this.manageColumn.Name = "manageColumn";
            this.manageColumn.Text = "View";
            this.manageColumn.UseColumnTextForButtonValue = true;
            this.manageColumn.FlatStyle = FlatStyle.Flat;
            this.manageColumn.DefaultCellStyle.ForeColor = Color.Black;
            this.manageColumn.Width = 105;

            this.dgvTasks.Columns.AddRange(new DataGridViewColumn[]
            {
                this.colTaskID,
                this.colTitle,
                this.colDescription,
                this.colDueAt,
                this.manageColumn
            });

            // ===== View My Activity Button =====
            this.btnViewMyActivity.BackColor = Color.FromArgb(59, 130, 246);
            this.btnViewMyActivity.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnViewMyActivity.ForeColor = Color.Black;
            this.btnViewMyActivity.Location = new Point(50, 500);
            this.btnViewMyActivity.Size = new Size(220, 40);
            this.btnViewMyActivity.Text = "View My Activity";
            this.btnViewMyActivity.UseVisualStyleBackColor = false;
            this.btnViewMyActivity.Click += new System.EventHandler(this.btnViewMyActivity_Click);

            // ===== Back Button =====
            this.btnBack.BackColor = Color.LimeGreen;
            this.btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnBack.ForeColor = Color.Black;
            this.btnBack.Location = new Point(790, 500);
            this.btnBack.Size = new Size(140, 40);
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // ===== Form =====
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            this.ClientSize = new Size(980, 600);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.dgvTasks);
            this.Controls.Add(this.btnViewMyActivity);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "UserTaskTablePage";

            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
