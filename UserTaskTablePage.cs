using System;
using System.Drawing;
using System.Windows.Forms;
using TaskMateApp.BLL;
using TaskMateApp.Classes;

namespace TaskMateApp
{
    public partial class UserTaskTablePage : Form
    {
        private readonly User _current;

        public UserTaskTablePage(User current)
        {
            InitializeComponent();
            _current = current;

            dgvTasks.BorderStyle = BorderStyle.FixedSingle;
            dgvTasks.GridColor = Color.FromArgb(147, 197, 253);
            dgvTasks.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvTasks.DefaultCellStyle.BackColor = Color.White;
            dgvTasks.DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 240, 255);
            dgvTasks.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvTasks.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvTasks.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvTasks.AllowUserToResizeRows = false;
            dgvTasks.AllowUserToResizeColumns = false;

            LoadTasks();
        }

        private void LoadTasks()
        {
            var tasks = TaskBLL.GetAllTasks();
            dgvTasks.Rows.Clear();

            foreach (var t in tasks)
            {
                int rowIndex = dgvTasks.Rows.Add(
                    t.TaskID,
                    t.Title,
                    t.Description,
                    t.DueAt?.ToString("yyyy-MM-dd HH:mm"),
                    "View"
                );

                var row = dgvTasks.Rows[rowIndex];
                row.Cells["colDescription"].Style.WrapMode = DataGridViewTriState.True;

                // 🔹 Reset default colors
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.ForeColor = Color.Black;

                // 🔹 Make Due Date text red if overdue
                if (t.DueAt.HasValue && DateTime.Now > t.DueAt.Value)
                {
                    row.Cells["colDueAt"].Style.ForeColor = Color.Red;
                }

                // 🔹 Fetch user status (from activity table)
                string status = ActivityBLL.GetUserActivityStatus(_current.Username, t.TaskID);

                if (!string.IsNullOrEmpty(status))
                {
                    if (status.Equals("To Do", StringComparison.OrdinalIgnoreCase))
                    {
                        row.Cells["colTaskID"].Style.BackColor = Color.FromArgb(255, 255, 204, 204); // light red
                    }
                    else if (status.Equals("In Progress", StringComparison.OrdinalIgnoreCase))
                    {
                        row.Cells["colTaskID"].Style.BackColor = Color.FromArgb(255, 255, 247, 180); // light yellow
                    }
                    else if (status.Equals("Done", StringComparison.OrdinalIgnoreCase))
                    {
                        row.Cells["colTaskID"].Style.BackColor = Color.FromArgb(255, 204, 255, 204); // light green
                    }
                }

                // keep same color when selected
                foreach (DataGridViewCell c in row.Cells)
                {
                    c.Style.SelectionBackColor = c.Style.BackColor;
                    c.Style.SelectionForeColor = c.Style.ForeColor;
                }
            }

            dgvTasks.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
        }

        private void dgvTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvTasks.Columns[e.ColumnIndex].Name == "manageColumn")
            {
                int taskId = Convert.ToInt32(dgvTasks.Rows[e.RowIndex].Cells["colTaskID"].Value);
                new UserManageActivityPage(_current, taskId).Show();
                this.Hide();
            }
        }

        // ✅ Custom green bordered "View" button (same as before)
        private void dgvTasks_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvTasks.Columns["manageColumn"].Index)
                return;

            e.PaintBackground(e.CellBounds, true);

            int buttonWidth = 70;
            int buttonHeight = Math.Min(25, e.CellBounds.Height - 6);
            int x = e.CellBounds.Left + (e.CellBounds.Width - buttonWidth) / 2;
            int y = e.CellBounds.Top + (e.CellBounds.Height - buttonHeight) / 2;
            Rectangle buttonRect = new Rectangle(x, y, buttonWidth, buttonHeight);

            using (SolidBrush bgBrush = new SolidBrush(Color.White))
                e.Graphics.FillRectangle(bgBrush, buttonRect);

            using (Pen borderPen = new Pen(Color.LimeGreen, 2))
                e.Graphics.DrawRectangle(borderPen, buttonRect);

            TextRenderer.DrawText(
                e.Graphics,
                "View",
                new Font("Segoe UI", 9F, FontStyle.Bold),
                buttonRect,
                Color.Black,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );

            e.Handled = true;
        }

        private void btnViewMyActivity_Click(object sender, EventArgs e)
        {
            new UserViewActivityTablePage(_current).Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new WelcomeUserPage(_current).Show();
            this.Close();
        }
    }
}
