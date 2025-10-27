using System.Drawing;
using System.Windows.Forms;

namespace TaskMateApp
{
    partial class UserManageActivityPage
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblHeading;
        private Label lblTitleLabel;
        private Label lblDescriptionLabel;
        private Label lblDueAtLabel;
        private Label lblTitle;
        private Label lblDescription;
        private Label lblDueAt;
        private Label lblStatusLabel;
        private ComboBox cmbStatus;
        private Button btnSave;
        private Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblHeading = new Label();
            this.lblTitleLabel = new Label();
            this.lblDescriptionLabel = new Label();
            this.lblDueAtLabel = new Label();
            this.lblTitle = new Label();
            this.lblDescription = new Label();
            this.lblDueAt = new Label();
            this.lblStatusLabel = new Label();
            this.cmbStatus = new ComboBox();
            this.btnSave = new Button();
            this.btnBack = new Button();

            this.SuspendLayout();

            // lblHeading
            this.lblHeading.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblHeading.ForeColor = Color.Black;
            this.lblHeading.Location = new Point(50, 20);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new Size(880, 40);
            this.lblHeading.Text = "Manage My Activity";
            this.lblHeading.TextAlign = ContentAlignment.MiddleCenter;

            // lblTitleLabel
            this.lblTitleLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTitleLabel.Location = new Point(180, 100);
            this.lblTitleLabel.Size = new Size(120, 25);
            this.lblTitleLabel.Text = "Task Title:";

            // lblTitle
            this.lblTitle.Font = new Font("Segoe UI", 10F);
            this.lblTitle.Location = new Point(350, 100);
            this.lblTitle.Size = new Size(500, 25);

            // lblDescriptionLabel
            this.lblDescriptionLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDescriptionLabel.Location = new Point(180, 150);
            this.lblDescriptionLabel.Size = new Size(120, 25);
            this.lblDescriptionLabel.Text = "Description:";

            // lblDescription
            this.lblDescription.Font = new Font("Segoe UI", 10F);
            this.lblDescription.Location = new Point(350, 150);
            this.lblDescription.Size = new Size(500, 60);

            // lblDueAtLabel
            this.lblDueAtLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDueAtLabel.Location = new Point(180, 230);
            this.lblDueAtLabel.Size = new Size(120, 25);
            this.lblDueAtLabel.Text = "Due Date:";

            // lblDueAt
            this.lblDueAt.Font = new Font("Segoe UI", 10F);
            this.lblDueAt.Location = new Point(350, 230);
            this.lblDueAt.Size = new Size(300, 25);

            // lblStatusLabel
            this.lblStatusLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblStatusLabel.Location = new Point(180, 290);
            this.lblStatusLabel.Size = new Size(120, 25);
            this.lblStatusLabel.Text = "Status:";

            // cmbStatus
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new Font("Segoe UI", 10F);
            this.cmbStatus.Items.AddRange(new object[] { "To Do", "In Progress", "Done" });
            this.cmbStatus.Location = new Point(350, 285);
            this.cmbStatus.Size = new Size(250, 36);

            // btnSave
            this.btnSave.BackColor = Color.FromArgb(59, 130, 246);
            this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.Black;
            this.btnSave.Location = new Point(430, 370);
            this.btnSave.Size = new Size(150, 40);
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnBack
            this.btnBack.BackColor = Color.LimeGreen;
            this.btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnBack.ForeColor = Color.Black;
            this.btnBack.Location = new Point(790, 530);
            this.btnBack.Size = new Size(140, 40);
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);

            // UserManageActivityPage
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            this.ClientSize = new Size(980, 600);
            this.Controls.Add(this.lblHeading);
            this.Controls.Add(this.lblTitleLabel);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblDescriptionLabel);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblDueAtLabel);
            this.Controls.Add(this.lblDueAt);
            this.Controls.Add(this.lblStatusLabel);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnBack);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UserManageActivityPage";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "UserManageActivityPage";
            this.ResumeLayout(false);
        }
    }
}
