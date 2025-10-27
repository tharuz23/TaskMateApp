using System;
using System.Windows.Forms;
using TaskMateApp.BLL;
using TaskMateApp.Classes;

namespace TaskMateApp
{
    public partial class AdminEditTaskPage : Form
    {
        private readonly User _current;
        private readonly int _taskId;

        public AdminEditTaskPage(User current, int taskId)
        {
            _current = current;
            _taskId = taskId;
            InitializeComponent();
            LoadTask();
        }

        private void LoadTask()
        {
            var t = TaskBLL.GetTaskById(_taskId);
            if (t == null)
            {
                MessageBox.Show("Task not found");
                new AdminTaskTablePage(_current).Show();
                Close();
                return;
            }

            lblTaskNo.Text = $"Task No {_taskId:D2}";
            txtTitle.Text = t.Title;
            txtDescription.Text = t.Description;
            txtSupervisor.Text = t.Supervisor;
            txtDueAt.Text = t.DueAt?.ToString("yyyy-MM-dd HH:mm") ?? "";
            chkLock.Checked = t.IsLocked;

            
            if (t.IsLocked && t.CreatedBy != _current.Username)
            {
                txtTitle.ReadOnly = true;
                txtDescription.ReadOnly = true;
                txtSupervisor.ReadOnly = true;
                txtDueAt.ReadOnly = true;
                chkLock.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;

                MessageBox.Show("This task is locked by another admin and cannot be edited.",
                    "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                
                if (t.CreatedBy != _current.Username)
                {
                    chkLock.Enabled = false;
                    chkLock.ForeColor = System.Drawing.Color.Gray;
                    ToolTip tip = new ToolTip();
                    tip.SetToolTip(chkLock, "Only the creator of this task can lock or unlock it.");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string desc = txtDescription.Text.Trim();
            DateTime? due = null;
            if (DateTime.TryParse(txtDueAt.Text, out var parsed)) due = parsed;

            var currentTask = TaskBLL.GetTaskById(_taskId);
            if (currentTask == null) return;

            if (TaskBLL.UpdateTask(_taskId, title, desc, currentTask.SupervisorUserID, due))
                MessageBox.Show("Updated successfully!");
            else
                MessageBox.Show("No changes were made.");

            
            if (currentTask.CreatedBy == _current.Username)
                TaskBLL.LockTask(_taskId, chkLock.Checked);

            new AdminTaskTablePage(_current).Show();
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete this task?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (TaskBLL.DeleteTask(_taskId))
                    MessageBox.Show("Task deleted successfully.");
                else
                    MessageBox.Show("Delete failed.");

                new AdminTaskTablePage(_current).Show();
                Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new AdminTaskTablePage(_current).Show();
            Close();
        }

        private void lblDescription_Click(object sender, EventArgs e)
        {
        }
    }
}
