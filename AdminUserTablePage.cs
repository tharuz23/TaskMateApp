using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TaskMateApp.BLL;
using TaskMateApp.Classes;

namespace TaskMateApp
{
    public partial class AdminUserTablePage : Form
    {
        private readonly User _current;

        public AdminUserTablePage(User current)
        {
            _current = current;
            InitializeComponent();
            dgvUsers.CellPainting += dgvUsers_CellPainting;
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                DataTable users = UserBLL.GetAllUsers();
                dgvUsers.Rows.Clear();

                foreach (DataRow row in users.Rows)
                {
                    dgvUsers.Rows.Add(
                        row["UserID"],
                        row["FullName"],
                        row["Username"],
                        row["RoleName"],
                        "Delete"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load users: " + ex.Message);
            }
        }

        
        private void dgvUsers_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvUsers.Columns["manageColumn"].Index)
                return;

            e.PaintBackground(e.CellBounds, true);

            int buttonWidth = 70;
            int buttonHeight = 18; 
            int x = e.CellBounds.Left + (e.CellBounds.Width - buttonWidth) / 2;
            int y = e.CellBounds.Top + (e.CellBounds.Height - buttonHeight) / 2;
            Rectangle buttonRect = new Rectangle(x, y, buttonWidth, buttonHeight);

            using (SolidBrush brush = new SolidBrush(Color.White))
                e.Graphics.FillRectangle(brush, buttonRect);

            using (Pen pen = new Pen(Color.Red, 1.6f))
                e.Graphics.DrawRectangle(pen, buttonRect);

            TextRenderer.DrawText(
                e.Graphics,
                "Delete",
                new Font("Segoe UI", 9F, FontStyle.Bold),
                buttonRect,
                Color.Red,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
            );

            e.Handled = true;
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvUsers.Columns[e.ColumnIndex].Name == "manageColumn")
            {
                int userId = Convert.ToInt32(dgvUsers.Rows[e.RowIndex].Cells["colUserID"].Value);
                DialogResult confirm = MessageBox.Show(
                    "Are you sure you want to delete this user?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    bool success = UserBLL.DeleteUser(userId);
                    if (success)
                    {
                        MessageBox.Show("User deleted successfully!");
                        LoadUsers();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete user.");
                    }
                }
            }
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            new AdminAddNewUserPage(_current).Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new WelcomeAdminPage(_current).Show();
            this.Close();
        }
    }
}
