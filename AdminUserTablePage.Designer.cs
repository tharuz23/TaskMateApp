using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskMateApp
{
    partial class AdminUserTablePage
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Panel panelBox;
        private DataGridView dgvUsers;
        private Button btnAddNewUser;
        private Button btnBack;
        private DataGridViewTextBoxColumn colUserID;
        private DataGridViewTextBoxColumn colFullName;
        private DataGridViewTextBoxColumn colUsername;
        private DataGridViewTextBoxColumn colRole;
        private DataGridViewButtonColumn manageColumn;

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
            this.panelBox = new Panel();
            this.dgvUsers = new DataGridView();
            this.colUserID = new DataGridViewTextBoxColumn();
            this.colFullName = new DataGridViewTextBoxColumn();
            this.colUsername = new DataGridViewTextBoxColumn();
            this.colRole = new DataGridViewTextBoxColumn();
            this.manageColumn = new DataGridViewButtonColumn();
            this.btnAddNewUser = new Button();
            this.btnBack = new Button();
            this.panelBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Black;
            this.lblTitle.Location = new Point(50, 20);
            this.lblTitle.Size = new Size(880, 40);
            this.lblTitle.Text = "Users Table";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // panelBox
            this.panelBox.BackColor = Color.White;
            this.panelBox.BorderStyle = BorderStyle.FixedSingle;
            this.panelBox.Controls.Add(this.dgvUsers);
            this.panelBox.Location = new Point(50, 70);
            this.panelBox.Size = new Size(880, 420);

            // dgvUsers
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.BackgroundColor = Color.White;
            this.dgvUsers.BorderStyle = BorderStyle.FixedSingle;
            this.dgvUsers.GridColor = Color.FromArgb(147, 197, 253);
            this.dgvUsers.Dock = DockStyle.Fill;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.RowTemplate.Height = 28;
            this.dgvUsers.CellContentClick += new DataGridViewCellEventHandler(this.dgvUsers_CellContentClick);

            // Header style
            headerStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = Color.FromArgb(147, 197, 253);
            headerStyle.ForeColor = Color.Black;
            headerStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            headerStyle.WrapMode = DataGridViewTriState.True;
            this.dgvUsers.EnableHeadersVisualStyles = false;
            this.dgvUsers.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.dgvUsers.ColumnHeadersHeight = 38;

            //  Cell style
            cellStyle.BackColor = Color.White;
            cellStyle.ForeColor = Color.Black;
            cellStyle.SelectionBackColor = Color.FromArgb(226, 239, 255);
            cellStyle.SelectionForeColor = Color.Black;
            this.dgvUsers.DefaultCellStyle = cellStyle;

            // Columns
            this.colUserID.HeaderText = "User ID";
            this.colUserID.Name = "colUserID";
            this.colUserID.Width = 125;

            this.colFullName.HeaderText = "Full Name";
            this.colFullName.Name = "colFullName";
            this.colFullName.Width = 250;

            this.colUsername.HeaderText = "Username";
            this.colUsername.Name = "colUsername";
            this.colUsername.Width = 220;

            this.colRole.HeaderText = "Role";
            this.colRole.Name = "colRole";
            this.colRole.Width = 180;

            this.manageColumn.HeaderText = "Manage";
            this.manageColumn.Name = "manageColumn";
            this.manageColumn.Text = "Delete";
            this.manageColumn.UseColumnTextForButtonValue = true;
            this.manageColumn.FlatStyle = FlatStyle.Flat;
            this.manageColumn.Width = 100;

            // Add all columns
            this.dgvUsers.Columns.AddRange(new DataGridViewColumn[]
            {
                this.colUserID, this.colFullName, this.colUsername, this.colRole, this.manageColumn
            });

            // btnAddNewUser
            this.btnAddNewUser.BackColor = Color.FromArgb(59, 130, 246);
            this.btnAddNewUser.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnAddNewUser.ForeColor = Color.Black;
            this.btnAddNewUser.Location = new Point(50, 510);
            this.btnAddNewUser.Size = new Size(220, 40);
            this.btnAddNewUser.Text = "Add New User";
            this.btnAddNewUser.UseVisualStyleBackColor = false;
            this.btnAddNewUser.Click += new EventHandler(this.btnAddNewUser_Click);

            // btnBack
            this.btnBack.BackColor = Color.LimeGreen;
            this.btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnBack.ForeColor = Color.Black;
            this.btnBack.Location = new Point(790, 510);
            this.btnBack.Size = new Size(140, 40);
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new EventHandler(this.btnBack_Click);

            // AdminUserTablePage
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            this.ClientSize = new Size(980, 600);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panelBox);
            this.Controls.Add(this.btnAddNewUser);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "AdminUserTablePage";

            this.panelBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
