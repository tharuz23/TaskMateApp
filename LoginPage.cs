using System;
using System.Windows.Forms;
using TaskMateApp.BLL;
using TaskMateApp.Classes;

namespace TaskMateApp
{
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUser.Text.Trim();
            string password = txtPass.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Enter username and password");
                return;
            }

            var loggedUser = UserBLL.Login(username, password);

            if (loggedUser == null)
            {
                MessageBox.Show("Invalid username or password");
                return;
            }

            if (loggedUser.RoleName == "OIC" || loggedUser.RoleName == "CO")
            {
                new WelcomeAdminPage(loggedUser).Show();
                this.Hide();
            }
            else
            {
                new WelcomeUserPage(loggedUser).Show();
                this.Hide();
            }
        }

        
        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
