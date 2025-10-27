using System;
using System.Drawing;
using System.Windows.Forms;
using TaskMateApp.Classes;

namespace TaskMateApp
{
    public partial class WelcomeUserPage : Form
    {
        private readonly User _current;

        public WelcomeUserPage(User current)
        {
            InitializeComponent();
            _current = current;

            if (lblWelcome != null)
                lblWelcome.Text = $"Welcome {_current.FullName}!";
        }

        private void WelcomeUserPage_Load(object sender, EventArgs e)
        {
            // Highlight TaskMate by default
            HighlightButton(btnTaskMate);
        }

        // ✅ Button highlight logic
        private void HighlightButton(Button active)
        {
            Color highlight = Color.FromArgb(147, 197, 253);
            Color normal = Color.White;

            btnTaskMate.BackColor = normal;
            btnViewTasks.BackColor = normal;
            btnViewActivities.BackColor = normal;

            active.BackColor = highlight;
        }

        private void btnTaskMate_Click(object sender, EventArgs e)
        {
            HighlightButton(btnTaskMate);
        }

        private void btnViewTasks_Click(object sender, EventArgs e)
        {
            HighlightButton(btnViewTasks);
            new UserTaskTablePage(_current).Show();
            this.Hide();
        }

        private void btnViewActivities_Click(object sender, EventArgs e)
        {
            HighlightButton(btnViewActivities);
            new UserViewActivityTablePage(_current).Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            new HomePage().Show();
            this.Close();
        }
    }
}
