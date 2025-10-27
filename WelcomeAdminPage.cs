using System;
using System.Drawing;
using System.Windows.Forms;
using TaskMateApp.Classes;

namespace TaskMateApp
{
    public partial class WelcomeAdminPage : Form
    {
        private readonly User _current;

        public WelcomeAdminPage(User current)
        {
            InitializeComponent();
            _current = current;

            if (lblWelcome != null)
                lblWelcome.Text = $"Welcome {_current.FullName}!";
        }

        private void WelcomeAdminPage_Load(object sender, EventArgs e)
        {
            
            HighlightButton(btnTaskMate);
        }

   
        private void HighlightButton(Button activeButton)
        {
            Color highlight = Color.FromArgb(147, 197, 253);
            Color normal = Color.White;

            
            btnTaskMate.BackColor = normal;
            btnManageTasks.BackColor = normal;
            btnViewActivities.BackColor = normal;
            btnAddUser.BackColor = normal;
            activeButton.BackColor = highlight;
        }

        private void btnTaskMate_Click(object sender, EventArgs e)
        {
            HighlightButton(btnTaskMate);
        }

        private void btnManageTasks_Click(object sender, EventArgs e)
        {
            HighlightButton(btnManageTasks);
            new AdminTaskTablePage(_current).Show();
            this.Hide();
        }

        private void btnViewActivities_Click(object sender, EventArgs e)
        {
            HighlightButton(btnViewActivities);
            new AdminViewUserActivity1Page(_current).Show();
            this.Hide();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            HighlightButton(btnAddUser);
            new AdminUserTablePage(_current).Show();
            this.Hide();
        }


        private void btnLogOut_Click(object sender, EventArgs e)
        {
            new HomePage().Show();
            this.Close();
        }
    }
}
