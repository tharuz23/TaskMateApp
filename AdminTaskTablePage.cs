using System;
using System.Drawing;
using System.Windows.Forms;
using TaskMateApp.BLL;
using TaskMateApp.Classes;

namespace TaskMateApp
{
    public partial class AdminTaskTablePage : Form
    {
        private readonly User _current;

        public AdminTaskTablePage(User current)
        {
            _current = current;
            InitializeComponent();

            dgvTasks.BorderStyle = BorderStyle.FixedSingle;
            dgvTasks.GridColor = Color.FromArgb(147, 197, 253);
            dgvTasks.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgvTasks.DefaultCellStyle.BackColor = Color.White;
            dgvTasks.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvTasks.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvTasks.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvTasks.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvTasks.AllowUserToResizeRows = false;
            dgvTasks.AllowUserToResizeColumns = false;

            dgvTasks.CellPainting += dgvTasks_CellPainting;
            LoadTasks();

            button1.Click += BtnMyTasks_Click;
        }

        private void LoadTasks()
        {
            var tasks = TaskBLL.GetAllTasks();
            dgvTasks.Rows.Clear();

            foreach (var t in tasks)
            {
                
                string displayId = t.IsLocked ? $"{t.TaskID} 🔒" : t.TaskID.ToString();

                int rowIndex = dgvTasks.Rows.Add(
                    displayId,
                    t.Title,
                    t.Description,
                    t.Supervisor,
                    t.DueAt?.ToString("yyyy-MM-dd HH:mm"),
                    "View"
                );

                var row = dgvTasks.Rows[rowIndex];
                row.Cells["colDescription"].Style.WrapMode = DataGridViewTriState.True;

                if (t.DueAt.HasValue && t.DueAt.Value < DateTime.Now)
                {
                    row.Cells["colDueAt"].Style.ForeColor = Color.Red;
                    row.Cells["colDueAt"].Style.SelectionForeColor = Color.Red;
                }
                else
                {
                    row.Cells["colDueAt"].Style.ForeColor = Color.Black;
                    row.Cells["colDueAt"].Style.SelectionForeColor = Color.Black;
                }

                if (t.IsLocked && t.CreatedBy != _current.Username)
                {
                    row.Cells["manageColumn"].Style.ForeColor = Color.Gray;
                    row.Cells["manageColumn"].Style.SelectionForeColor = Color.Gray;
                    row.Cells["manageColumn"].ReadOnly = true;
                    row.Cells["manageColumn"].Value = "🔒 Locked";
                }
            }

            dgvTasks.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
        }

        private void btnAddNewTask_Click(object sender, EventArgs e)
        {
            new AdminAddTaskPage(_current).Show();
            this.Hide();
        }

        private void BtnMyTasks_Click(object sender, EventArgs e)
        {
            new AdminMyTasksPage(_current).Show();
            this.Hide();
        }

        private void dgvTasks_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string colName = dgvTasks.Columns[e.ColumnIndex].Name;
            if (colName == "manageColumn")
            {
               
                var idValue = dgvTasks.Rows[e.RowIndex].Cells["colTaskNo"].Value.ToString().Replace("🔒", "").Trim();
                int taskId = Convert.ToInt32(idValue);

                var selected = TaskBLL.GetAllTasks().Find(t => t.TaskID == taskId);
                if (selected == null) return;

                if (selected.IsLocked && selected.CreatedBy != _current.Username)
                {
                    MessageBox.Show("You cannot edit this task. It is locked by another admin.", "Access Denied",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                new AdminEditTaskPage(_current, taskId).Show();
                this.Hide();
            }
        }

        private void dgvTasks_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == dgvTasks.Columns["manageColumn"].Index)
            {
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

                string text = e.FormattedValue?.ToString() ?? "";
                Color textColor = (text == "🔒 Locked") ? Color.Gray : Color.Black;

                TextRenderer.DrawText(
                    e.Graphics,
                    text,
                    new Font("Segoe UI", 9F, FontStyle.Bold),
                    buttonRect,
                    textColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );

                e.Handled = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new WelcomeAdminPage(_current).Show();
            this.Close();
        }
    }
}
