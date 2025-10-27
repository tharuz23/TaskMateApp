using System;
using System.Windows.Forms;

namespace TaskMateApp
{
    public partial class HomePage : Form
    {
        public HomePage() { InitializeComponent(); }

        private void btnGetStarted_Click(object sender, EventArgs e)
        {
            new LoginPage().Show();
            this.Hide();
        }
    }
}
