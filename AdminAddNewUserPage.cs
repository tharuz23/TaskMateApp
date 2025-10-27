using System;
using System.Data;
using System.Windows.Forms;
using TaskMateApp.BLL;
using TaskMateApp.Classes;

namespace TaskMateApp
{
    public partial class AdminAddNewUserPage : Form
    {
        private readonly User _current;

        public AdminAddNewUserPage(User current)
        {
            _current = current;
            InitializeComponent();
            LoadRoles();
        }

        
        private void LoadRoles()
        {
            try
            {
                DataTable roles = UserBLL.GetRoles();

                if (roles == null || roles.Rows.Count == 0)
                {
                    MessageBox.Show("No roles found in the system.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                cmbRole.DataSource = roles;
                cmbRole.DisplayMember = "RoleName";
                cmbRole.ValueMember = "RoleID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load roles: " + ex.Message);
            }
        }

       
        private void btnAddUserMain_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text.Trim();
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(fullName) ||
                string.IsNullOrWhiteSpace(username) ||
                string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill all fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbRole.SelectedValue == null)
            {
                MessageBox.Show("Please select a valid role.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int roleId = Convert.ToInt32(cmbRole.SelectedValue);
            bool success = UserBLL.AddUser(fullName, username, password, roleId);

            if (success)
            {
                MessageBox.Show("✅ User added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new AdminUserTablePage(_current).Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to add user. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void btnBack_Click(object sender, EventArgs e)
        {
            new AdminUserTablePage(_current).Show();
            this.Close();
        }
    }
}
