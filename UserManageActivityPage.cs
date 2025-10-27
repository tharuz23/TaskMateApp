using System;
using System.Windows.Forms;
using TaskMateApp.BLL;
using TaskMateApp.Classes;

namespace TaskMateApp
{
    public partial class UserManageActivityPage : Form
    {
        private readonly User _current;
        private readonly int _taskId;

        public UserManageActivityPage(User current, int taskId)
        {
            InitializeComponent();
            _current = current;
            _taskId = taskId;
            LoadTaskDetails();
            LoadExistingStatus(); 
        }

        private void LoadTaskDetails()
        {
            var task = TaskBLL.GetTaskById(_taskId);
            if (task != null)
            {
                lblTitle.Text = task.Title;
                lblDescription.Text = task.Description;
                lblDueAt.Text = task.DueAt?.ToString("yyyy-MM-dd HH:mm") ?? "No Due Date";
            }
        }

        
        private void LoadExistingStatus()
        {
            string existingStatus = ActivityBLL.GetUserActivityStatus(_current.Username, _taskId);
            if (!string.IsNullOrEmpty(existingStatus))
            {
                cmbStatus.SelectedItem = existingStatus;
            }
            else
            {
                cmbStatus.SelectedIndex = -1; 
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string selectedStatus = cmbStatus.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedStatus))
            {
                MessageBox.Show("Please select a status before saving.");
                return;
            }

            bool success = ActivityBLL.Upsert(_current.Username, _taskId, selectedStatus);

            if (success)
            {
                MessageBox.Show("Activity status updated successfully!");
                new UserViewActivityTablePage(_current).Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to update activity.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new UserTaskTablePage(_current).Show();
            this.Close();
        }
    }
}
