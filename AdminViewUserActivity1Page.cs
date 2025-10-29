using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TaskMateApp.BLL;
using TaskMateApp.Classes;

namespace TaskMateApp
{
    public partial class AdminViewUserActivity1Page : Form
    {
        private readonly User _current;
        private Timer refreshTimer;

        public AdminViewUserActivity1Page(User current)
        {
            _current = current;
            InitializeComponent();

            dgvActivities.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvActivities.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvActivities.AllowUserToResizeRows = false;
            dgvActivities.RowHeadersVisible = false;

            dgvActivities.CellPainting += dgvActivities_CellPainting;

            LoadActivities();
            StartAutoRefresh();
        }

        private void StartAutoRefresh()
        {
            refreshTimer = new Timer();
            refreshTimer.Interval = 5000; // refresh every 5 seconds
            refreshTimer.Tick += (s, e) => LoadActivities();
            refreshTimer.Start();
        }

        private void LoadActivities()
        {
            try
            {
                dgvActivities.Rows.Clear();

                DataTable activities = ActivityBLL.GetAll();

                if (activities == null || activities.Rows.Count == 0)
                {
                    var allTasks = TaskBLL.GetAllTasks();
                    foreach (var task in allTasks)
                    {
                        string supervisor = task.Supervisor ?? "—";
                        string dueAt = task.DueAt.HasValue
                            ? task.DueAt.Value.ToString("yyyy-MM-dd HH:mm")
                            : "—";

                        int idx = dgvActivities.Rows.Add(
                            task.TaskID,
                            task.Title,
                            supervisor,
                            dueAt,
                            "View"
                        );

                        if (task.DueAt.HasValue && task.DueAt.Value < DateTime.Now)
                            dgvActivities.Rows[idx].Cells["colDueAt"].Style.ForeColor = Color.Red;
                    }
                    return;
                }

                var groupedTasks = activities.AsEnumerable()
                    .GroupBy(r => new
                    {
                        TaskID = r["TaskID"],
                        TaskTitle = r["TaskTitle"],
                        Supervisor = r["Supervisor"],
                        DueAt = r["DueAt"]
                    });

                foreach (var group in groupedTasks)
                {
                    string supervisor = group.Key.Supervisor?.ToString() ?? "—";
                    string dueAt = group.Key.DueAt == DBNull.Value
                        ? "—"
                        : Convert.ToDateTime(group.Key.DueAt).ToString("yyyy-MM-dd HH:mm");

                    int taskId = Convert.ToInt32(group.Key.TaskID);

                    
                    var statuses = group.Select(r => r["ActivityStatus"].ToString()).Distinct().ToList();
                    bool allDone = statuses.All(s => s == "Done");

                    int rowIndex = dgvActivities.Rows.Add(
                        taskId,
                        group.Key.TaskTitle,
                        supervisor,
                        dueAt,
                        "View"
                    );

                    
                    if (group.Key.DueAt != DBNull.Value &&
                        Convert.ToDateTime(group.Key.DueAt) < DateTime.Now)
                    {
                        dgvActivities.Rows[rowIndex].Cells["colDueAt"].Style.ForeColor = Color.Red;
                    }

                    dgvActivities.Rows[rowIndex].Tag = allDone;

                    dgvActivities.Rows[rowIndex].Height =
                        dgvActivities.Rows[rowIndex].GetPreferredHeight(rowIndex, DataGridViewAutoSizeRowMode.AllCells, true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load activities: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvActivities_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
           
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvActivities.Columns["colView"].Index)
            {
                e.PaintBackground(e.CellBounds, true);

                int buttonWidth = 70;
                int buttonHeight = 18;
                int x = e.CellBounds.Left + (e.CellBounds.Width - buttonWidth) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - buttonHeight) / 2;
                Rectangle buttonRect = new Rectangle(x, y, buttonWidth, buttonHeight);

                using (SolidBrush bg = new SolidBrush(Color.White))
                    e.Graphics.FillRectangle(bg, buttonRect);

                using (Pen pen = new Pen(Color.LimeGreen, 2))
                    e.Graphics.DrawRectangle(pen, buttonRect);

                TextRenderer.DrawText(
                    e.Graphics,
                    "View",
                    new Font("Segoe UI", 9F, FontStyle.Bold),
                    buttonRect,
                    Color.Black,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );

                e.Handled = true;
                return;
            }

            
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvActivities.Columns["colTaskNo"].Index)
            {
                e.PaintBackground(e.CellBounds, true);

                string taskNo = dgvActivities.Rows[e.RowIndex].Cells["colTaskNo"].Value?.ToString() ?? "";
                bool allDone = dgvActivities.Rows[e.RowIndex].Tag is bool flag && flag;

                
                using (Font numberFont = new Font("Segoe UI", 9.5f, FontStyle.Regular))
                {
                    TextRenderer.DrawText(
                        e.Graphics,
                        taskNo,
                        numberFont,
                        new Point(e.CellBounds.Left + 10, e.CellBounds.Top + 6),
                        Color.Black
                    );
                }

                
                if (allDone)
                {
                    using (Font tickFont = new Font("Segoe UI Emoji", 9.5f, FontStyle.Regular))
                    using (SolidBrush brush = new SolidBrush(Color.ForestGreen))
                    {
                        Size numberSize = TextRenderer.MeasureText(taskNo, new Font("Segoe UI", 9.5f));
                        int tickX = e.CellBounds.Left + 10 + numberSize.Width - 4;
                        int tickY = e.CellBounds.Top + 6;
                        e.Graphics.DrawString("✅", tickFont, brush, new PointF(tickX, tickY));
                    }
                }

                e.Handled = true;
            }
        }

        private void dgvActivities_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvActivities.Columns[e.ColumnIndex].Name == "colView")
            {
                int taskId = Convert.ToInt32(dgvActivities.Rows[e.RowIndex].Cells["colTaskNo"].Value);
                string title = dgvActivities.Rows[e.RowIndex].Cells["colTitle"].Value.ToString();

                new AdminUserActivityDetailsPage(_current, taskId, title).Show();
                this.Hide();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            refreshTimer?.Stop();
            new WelcomeAdminPage(_current).Show();
            this.Close();
        }
    }
}
