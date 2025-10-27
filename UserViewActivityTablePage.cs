using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TaskMateApp.BLL;
using TaskMateApp.Classes;

namespace TaskMateApp
{
    public partial class UserViewActivityTablePage : Form
    {
        private readonly User _current;

        public UserViewActivityTablePage(User current)
        {
            InitializeComponent();
            _current = current;
            ConfigureGrid();
            LoadMyActivities();
        }

        private void ConfigureGrid()
        {
            dgvActivities.AutoGenerateColumns = false;

            colTaskNo.DataPropertyName = "TaskID";
            colTitle.DataPropertyName = "TaskTitle";
            colStatus.DataPropertyName = "ActivityStatus";
            colDueAt.DataPropertyName = "DueAt";
            colSubmittedAt.DataPropertyName = "SubmittedAt";

            dgvActivities.AllowUserToAddRows = false;
            dgvActivities.AllowUserToResizeColumns = false;
            dgvActivities.AllowUserToResizeRows = false;
            dgvActivities.ReadOnly = true;
            dgvActivities.MultiSelect = false;
            dgvActivities.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvActivities.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvActivities.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            
            dgvActivities.RowsDefaultCellStyle.SelectionBackColor = Color.Transparent;
            dgvActivities.RowsDefaultCellStyle.SelectionForeColor = Color.Black;
            dgvActivities.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dgvActivities.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvActivities.EnableHeadersVisualStyles = false;

            
            dgvActivities.CellFormatting += (s, e) =>
            {
                if (e.RowIndex >= 0 && e.Value != null)
                {
                    if (dgvActivities.Columns[e.ColumnIndex].Name == colDueAt.Name ||
                        dgvActivities.Columns[e.ColumnIndex].Name == colSubmittedAt.Name)
                    {
                        if (DateTime.TryParse(e.Value.ToString(), out var dt))
                            e.Value = dt.ToString("yyyy-MM-dd HH:mm");
                    }
                }
            };

            dgvActivities.DataBindingComplete += DgvActivities_DataBindingComplete;
        }

        private void LoadMyActivities()
        {
            DataTable dt = ActivityBLL.GetByUsername(_current.Username);
            dgvActivities.DataSource = dt;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            new WelcomeUserPage(_current).Show();
            Close();
        }

        private void DgvActivities_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvActivities.Rows)
            {
                if (row.Cells[colStatus.Index].Value == null) continue;

                string status = row.Cells[colStatus.Index].Value.ToString().Trim();
                row.DefaultCellStyle.ForeColor = Color.Black;

                
                if (status.Equals("To Do", StringComparison.OrdinalIgnoreCase))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 204, 204); 
                }
                else if (status.Equals("In Progress", StringComparison.OrdinalIgnoreCase))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 247, 180); 
                }
                else if (status.Equals("Done", StringComparison.OrdinalIgnoreCase))
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 204, 255, 204); 
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }

                
                row.DefaultCellStyle.SelectionBackColor = row.DefaultCellStyle.BackColor;
                row.DefaultCellStyle.SelectionForeColor = row.DefaultCellStyle.ForeColor;
            }
        }
    }
}
