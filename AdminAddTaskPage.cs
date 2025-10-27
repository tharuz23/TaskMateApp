using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TaskMateApp.BLL;
using TaskMateApp.Classes;

namespace TaskMateApp
{
    public partial class AdminAddTaskPage : Form
    {
        private readonly User _current;

        public AdminAddTaskPage(User current)
        {
            InitializeComponent();
            _current = current;
            LoadSupervisors();
            GenerateNextTaskNumber();
        }

        private void LoadSupervisors()
        {
            var allUsers = UserBLL.GetAllUsers();
            cmbSupervisor.Items.Clear();

            foreach (DataRow row in allUsers.Rows)
            {
                string role = row["RoleName"].ToString();
                if (role == "OIC" || role == "CO")
                    cmbSupervisor.Items.Add($"{row["FullName"]} ({role})");
            }

            if (cmbSupervisor.Items.Count > 0)
                cmbSupervisor.SelectedIndex = 0;
        }

        private void GenerateNextTaskNumber()
        {
            int nextId = TaskBLL.GetNextTaskId();
            txtTaskNo.Text = nextId.ToString("00");
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            string supervisorText = cmbSupervisor.SelectedItem?.ToString();
            DateTime? dueAt = dtpDue.Value;
            bool isLocked = chkLock.Checked;

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(supervisorText))
            {
                MessageBox.Show("Please fill all fields including a valid supervisor.");
                return;
            }

            var allUsers = UserBLL.GetAllUsers();
            DataRow supervisorRow = allUsers.AsEnumerable()
                .FirstOrDefault(r => supervisorText.Contains(r["FullName"].ToString()));

            if (supervisorRow == null)
            {
                MessageBox.Show("Supervisor username not found or invalid. Please select a valid supervisor.");
                return;
            }

            int supervisorUserId = Convert.ToInt32(supervisorRow["UserID"]);
            int newTaskId = TaskBLL.AddTaskWithLock(title, description, supervisorUserId, dueAt, _current.Username, isLocked);

            if (newTaskId > 0)
            {
                MessageBox.Show("Task added successfully!");
                new AdminTaskTablePage(_current).Show();
                Close();
            }
            else
            {
                MessageBox.Show("Failed to add task.");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new AdminTaskTablePage(_current).Show();
            Close();
        }
    }
}
