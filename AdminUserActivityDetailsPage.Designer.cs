using System;
using System.Drawing;
using System.Windows.Forms;

namespace TaskMateApp
{
    partial class AdminUserActivityDetailsPage
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblTaskTitle;
        private ListBox lstToDo;
        private ListBox lstProgress;
        private ListBox lstDone;
        private Label lblToDo;
        private Label lblProgress;
        private Label lblDone;
        private Button btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.lblTaskTitle = new Label();
            this.lstToDo = new ListBox();
            this.lstProgress = new ListBox();
            this.lstDone = new ListBox();
            this.lblToDo = new Label();
            this.lblProgress = new Label();
            this.lblDone = new Label();
            this.btnBack = new Button();

            // ===== Page Title =====
            this.lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.Black;
            this.lblTitle.Text = "User Activity Details";
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Location = new Point(50, 20);
            this.lblTitle.Size = new Size(880, 40);

            this.lblTaskTitle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.lblTaskTitle.ForeColor = Color.Black;
            this.lblTaskTitle.Location = new Point(60, 65);
            this.lblTaskTitle.Size = new Size(800, 30);

            // ===== Section Titles =====
            this.lblToDo.Text = "To Do";
            this.lblProgress.Text = "In Progress";
            this.lblDone.Text = "Done";
            this.lblToDo.Font = this.lblProgress.Font = this.lblDone.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblToDo.Location = new Point(90, 100);
            this.lblProgress.Location = new Point(390, 100);
            this.lblDone.Location = new Point(690, 100);

            // ===== ListBoxes (colored) =====
            this.lstToDo.Location = new Point(60, 130);
            this.lstToDo.Size = new Size(250, 300);
            this.lstToDo.Font = new Font("Segoe UI", 9.5F);
            this.lstToDo.BackColor = Color.FromArgb(255, 230, 230); // soft red
            this.lstToDo.BorderStyle = BorderStyle.FixedSingle;
            this.lstToDo.DrawMode = DrawMode.OwnerDrawFixed;
            this.lstToDo.ItemHeight = 28;
            this.lstToDo.DrawItem += (s, e) => DrawStyledItem(s, e, Color.FromArgb(255, 215, 215));

            this.lstProgress.Location = new Point(360, 130);
            this.lstProgress.Size = new Size(250, 300);
            this.lstProgress.Font = new Font("Segoe UI", 9.5F);
            this.lstProgress.BackColor = Color.FromArgb(255, 250, 200); // soft yellow
            this.lstProgress.BorderStyle = BorderStyle.FixedSingle;
            this.lstProgress.DrawMode = DrawMode.OwnerDrawFixed;
            this.lstProgress.ItemHeight = 28;
            this.lstProgress.DrawItem += (s, e) => DrawStyledItem(s, e, Color.FromArgb(255, 240, 180));

            this.lstDone.Location = new Point(660, 130);
            this.lstDone.Size = new Size(250, 300);
            this.lstDone.Font = new Font("Segoe UI", 9.5F);
            this.lstDone.BackColor = Color.FromArgb(220, 255, 220); // soft green
            this.lstDone.BorderStyle = BorderStyle.FixedSingle;
            this.lstDone.DrawMode = DrawMode.OwnerDrawFixed;
            this.lstDone.ItemHeight = 28;
            this.lstDone.DrawItem += (s, e) => DrawStyledItem(s, e, Color.FromArgb(200, 245, 200));

            // ===== Back Button =====
            this.btnBack.BackColor = Color.LimeGreen;
            this.btnBack.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnBack.ForeColor = Color.Black;
            this.btnBack.Text = "Back";
            this.btnBack.Location = new Point(790, 510);
            this.btnBack.Size = new Size(140, 40);
            this.btnBack.Click += new EventHandler(this.btnBack_Click);

            // ===== Form Layout =====
            this.AutoScaleMode = AutoScaleMode.None;
            this.BackColor = Color.White;
            this.ClientSize = new Size(980, 600);
            this.Controls.AddRange(new Control[] {
                this.lblTitle, this.lblTaskTitle,
                this.lblToDo, this.lblProgress, this.lblDone,
                this.lstToDo, this.lstProgress, this.lstDone,
                this.btnBack
            });
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "AdminUserActivityDetailsPage";
        }

        // 🎨 Custom styled item drawing (username | submitted time)
        private void DrawStyledItem(object sender, DrawItemEventArgs e, Color hoverColor)
        {
            if (e.Index < 0) return;

            var listBox = sender as ListBox;
            if (listBox == null || e.Index >= listBox.Items.Count) return;

            e.DrawBackground();

            string text = listBox.Items[e.Index].ToString();
            string[] parts = text.Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
            string user = parts.Length > 0 ? parts[0].Trim() : "";
            string time = parts.Length > 1 ? parts[1].Trim() : "";

            Color backColor = (e.State & DrawItemState.Selected) == DrawItemState.Selected
                ? hoverColor
                : listBox.BackColor;

            using (SolidBrush bg = new SolidBrush(backColor))
                e.Graphics.FillRectangle(bg, e.Bounds);

            // vertical divider line (slightly adjusted)
            int midX = e.Bounds.Left + (int)(e.Bounds.Width * 0.45);
            using (Pen pen = new Pen(Color.Gray, 1))
                e.Graphics.DrawLine(pen, midX, e.Bounds.Top + 4, midX, e.Bounds.Bottom - 4);

            // username (left)
            TextRenderer.DrawText(
                e.Graphics, user, e.Font,
                new Rectangle(e.Bounds.Left + 8, e.Bounds.Top + 5, midX - e.Bounds.Left - 10, e.Bounds.Height),
                Color.Black, TextFormatFlags.Left | TextFormatFlags.VerticalCenter
            );

            // time (right, more visible)
            TextRenderer.DrawText(
                e.Graphics, time, e.Font,
                new Rectangle(midX + 5, e.Bounds.Top + 5, e.Bounds.Right - midX - 8, e.Bounds.Height),
                Color.FromArgb(70, 70, 70), TextFormatFlags.Left | TextFormatFlags.VerticalCenter
            );

            e.DrawFocusRectangle();
        }
    }
}
