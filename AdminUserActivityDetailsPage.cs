using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TaskMateApp.BLL;
using TaskMateApp.Classes;

namespace TaskMateApp
{
    public partial class AdminUserActivityDetailsPage : Form
    {
        private readonly User _current;
        private readonly int _taskId;
        private readonly string _title;

        private Label lblAllDone;

        private string originalToDoText;
        private string originalProgressText;
        private string originalDoneText;

        public AdminUserActivityDetailsPage(User current, int taskId, string title)
        {
            _current = current;
            _taskId = taskId;
            _title = title;

            InitializeComponent();
            lblTaskTitle.Text = $"Task: {_title}";

           
            originalToDoText = lblToDo.Text;
            originalProgressText = lblProgress.Text;
            originalDoneText = lblDone.Text;

            
            lblAllDone = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Green,
                Visible = false
            };
            this.Controls.Add(lblAllDone);

            LoadActivityDetails();
        }

        private void LoadActivityDetails()
        {
            DataTable all = ActivityBLL.GetActivitiesFiltered(_taskId, null);

            var todo = all.AsEnumerable().Where(r => r["ActivityStatus"].ToString() == "To Do");
            var inprogress = all.AsEnumerable().Where(r => r["ActivityStatus"].ToString() == "In Progress");
            var done = all.AsEnumerable().Where(r => r["ActivityStatus"].ToString() == "Done");

            int countTodo = todo.Count();
            int countProgress = inprogress.Count();
            int countDone = done.Count();
            int totalUsers = all.Rows.Count;

            lblToDo.Text = $"{originalToDoText} ({countTodo})";
            lblProgress.Text = $"{originalProgressText} ({countProgress})";
            lblDone.Text = $"{originalDoneText} ({countDone})";

            FillList(lstToDo, todo, false);
            FillList(lstProgress, inprogress, true);
            FillList(lstDone, done, true);

            
            if (countDone > 0 && countDone == totalUsers)
            {
                lblAllDone.Text = "✅ All users have completed this task!";
                lblAllDone.Visible = true;
                int centerX = (this.ClientSize.Width - lblAllDone.PreferredWidth) / 2;
                lblAllDone.Location = new Point(centerX, lstDone.Bottom + 30);
                lblAllDone.BringToFront();
            }
            else
            {
                lblAllDone.Visible = false;
            }
        }

        private void FillList(ListBox box, IEnumerable<DataRow> data, bool allowRemove)
        {
            box.Items.Clear();
            foreach (var r in data)
            {
                string name = r["UserFullName"].ToString();
                string time = r["SubmittedAt"] == DBNull.Value ? "—" :
                    Convert.ToDateTime(r["SubmittedAt"]).ToString("yyyy-MM-dd HH:mm");
                box.Items.Add($"{name} | {time}");
            }

            box.DrawMode = DrawMode.OwnerDrawFixed;
            box.ItemHeight = 30;

            if (allowRemove)
            {
                box.DrawItem += (s, e) => DrawStyledItemWithRemove(s, e);
                box.MouseClick += (s, e) => HandleRemoveClick(s, e);
            }
            else
            {
                box.DrawItem += (s, e) => DrawStyledItemSimple(s, e);
            }
        }

        private void DrawStyledItemSimple(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var box = sender as ListBox;
            string text = box.Items[e.Index].ToString();
            string[] parts = text.Split('|');
            string user = parts[0].Trim();
            string time = parts.Length > 1 ? parts[1].Trim() : "";

            e.DrawBackground();
            Rectangle rect = e.Bounds;

            using (SolidBrush bg = new SolidBrush(box.BackColor))
                e.Graphics.FillRectangle(bg, rect);

            int midX = rect.Left + 110;
            using (Pen pen = new Pen(Color.Gray, 1))
                e.Graphics.DrawLine(pen, midX, rect.Top + 5, midX, rect.Bottom - 5);

            TextRenderer.DrawText(e.Graphics, user, e.Font,
                new Rectangle(rect.Left + 8, rect.Top + 6, 95, rect.Height),
                Color.Black, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            TextRenderer.DrawText(e.Graphics, time, e.Font,
                new Rectangle(midX + 8, rect.Top + 6, 115, rect.Height),
                Color.Gray, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

            e.DrawFocusRectangle();
        }

        private void DrawStyledItemWithRemove(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            var box = sender as ListBox;
            string text = box.Items[e.Index].ToString();
            string[] parts = text.Split('|');
            string user = parts[0].Trim();
            string time = parts.Length > 1 ? parts[1].Trim() : "";

            e.DrawBackground();
            Rectangle rect = e.Bounds;

            using (SolidBrush bg = new SolidBrush(box.BackColor))
                e.Graphics.FillRectangle(bg, rect);

            int midX = rect.Left + 110;
            using (Pen pen = new Pen(Color.Gray, 1))
                e.Graphics.DrawLine(pen, midX, rect.Top + 5, midX, rect.Bottom - 5);

            TextRenderer.DrawText(e.Graphics, user, e.Font,
                new Rectangle(rect.Left + 8, rect.Top + 6, 95, rect.Height),
                Color.Black, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            TextRenderer.DrawText(e.Graphics, time, e.Font,
                new Rectangle(midX + 8, rect.Top + 6, 115, rect.Height),
                Color.Gray, TextFormatFlags.Left | TextFormatFlags.VerticalCenter);

            Rectangle closeRect = new Rectangle(rect.Right - 18, rect.Top + 7, 10, 10);
            using (Pen pen = new Pen(Color.Red, 1.8f))
            {
                e.Graphics.DrawLine(pen, closeRect.Left, closeRect.Top, closeRect.Right, closeRect.Bottom);
                e.Graphics.DrawLine(pen, closeRect.Left, closeRect.Bottom, closeRect.Right, closeRect.Top);
            }

            e.DrawFocusRectangle();
        }

        private void HandleRemoveClick(object sender, MouseEventArgs e)
        {
            var box = sender as ListBox;
            int index = box.IndexFromPoint(e.Location);
            if (index < 0) return;

            Rectangle itemRect = box.GetItemRectangle(index);
            Rectangle closeRect = new Rectangle(itemRect.Right - 18, itemRect.Top + 7, 10, 10);

            if (closeRect.Contains(e.Location))
            {
                string item = box.Items[index].ToString();
                string fullName = item.Split('|')[0].Trim();

                DialogResult confirm = MessageBox.Show(
                    $"Reset activity for {fullName} to 'To Do'?",
                    "Confirm Reset",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirm == DialogResult.Yes)
                {
                    bool success = ActivityBLL.ResetUserToDo(_taskId, fullName);
                    if (success)
                    {
                        MessageBox.Show(
                            $"User {fullName}'s activity was reset to 'To Do' at {DateTime.Now:yyyy-MM-dd HH:mm}",
                            "Reset Successful",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );
                        LoadActivityDetails();
                    }
                    else
                    {
                        MessageBox.Show("Failed to reset activity.");
                    }
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new AdminViewUserActivity1Page(_current).Show();
            this.Close();
        }
    }
}
