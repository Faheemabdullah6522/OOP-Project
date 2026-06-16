using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Guna.Charts.WinForms;
using Window_Forms.Repositories;

namespace Window_Forms
{
    public partial class AdminDashboard : Form
    {
        private readonly ScholarshipRepository _scholarshipRepo = new();

        public AdminDashboard()
        {
            InitializeComponent();
        }

        private void AdminDashboard_Load(object sender, EventArgs e)
        {
            try
            {
                // Grid Safety Configuration
                dgvScholarships.ReadOnly = true;
                dgvScholarships.AllowUserToAddRows = false;
                dgvScholarships.AllowUserToDeleteRows = false;
                dgvScholarships.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                lblWelcome.Text = $"Admin: {Session.UserEmail}";
                LoadStats();
                LoadScholarships();
            }
            catch (Exception ex)
            {
                ToastForm.ShowError($"Admin dashboard could not be loaded.\n\n{ex.Message}");
            }
        }

        private void LoadStats()
        {
            try
            {
                DataTable dt = Database.QueryProc("sp_GetDashboardStats");

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    lblStatValue1.Text = row["TotalScholarships"].ToString();
                    lblStatValue2.Text = row["TotalApplications"].ToString();
                    lblStatValue3.Text = row["PendingReviews"].ToString();

                    int reviewed = Convert.ToInt32(row["ReviewedCount"]);
                    int approvedCount = Convert.ToInt32(row["ApprovedCount"]);

                    // Safe calculation preventing divide-by-zero
                    lblStatValue4.Text = reviewed > 0 ? $"{approvedCount * 100 / reviewed}%" : "0%";
                }
            }
            catch
            {
                lblStatValue1.Text = "!";
                lblStatValue2.Text = "!";
                lblStatValue3.Text = "!";
                lblStatValue4.Text = "!";
            }
        }

        private void LoadScholarships()
        {
            try
            {
                DataTable dt = Database.Query(@"
                    SELECT
                        Id, Title, Amount, Deadline, MinimumCGPA, MaxFamilyIncome,
                        DegreeProgram, SemesterYear, NeedBased, IsActive, Description, Eligibility
                    FROM Scholarships
                    ORDER BY IsActive DESC, Deadline, Title");

                if (dt.Columns.Contains("NeedBased"))
                {
                    dt.Columns.Add("NeedBasedDisplay", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        bool nb = row["NeedBased"] != DBNull.Value && Convert.ToBoolean(row["NeedBased"]);
                        row["NeedBasedDisplay"] = nb ? "✔" : "✘";
                    }
                }

                dgvScholarships.DataSource = dt;

                dgvScholarships.DataSource = dt;
                dgvScholarships.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                SetColumnHeader("Id", "ID");
                SetColumnHeader("MinimumCGPA", "Minimum CGPA");
                SetColumnHeader("MaxFamilyIncome", "Max Income");
                SetColumnHeader("DegreeProgram", "Degree / Dept");
                SetColumnHeader("SemesterYear", "Semester / Year");
                if (dgvScholarships.Columns["NeedBased"] is DataGridViewColumn nbHide)
                    nbHide.Visible = false;

                if (dgvScholarships.Columns["NeedBasedDisplay"] is DataGridViewColumn nbCol)
                {
                    nbCol.HeaderText = "Need Based";
                    nbCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    nbCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    nbCol.FillWeight = 60;
                }
                SetColumnHeader("IsActive", "Active");
                SetColumnHeader("Eligibility", "Criteria");

                if (dgvScholarships.Columns["Deadline"] is DataGridViewColumn deadlineColumn)
                {
                    deadlineColumn.DefaultCellStyle.Format = "dd MMM yyyy";
                }
            }
            catch (Exception ex)
            {
                ToastForm.ShowError($"Scholarships could not be loaded.\n\n{ex.Message}");
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadStats();

            if (pnlChart.Visible)
                LoadChart();
            else
                LoadScholarships();
        }

        private void DgvScholarships_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvScholarships.Columns[e.ColumnIndex]?.Name == "NeedBasedDisplay")
            {
                e.CellStyle.ForeColor = e.Value?.ToString() == "✔"
                    ? System.Drawing.Color.FromArgb(16, 185, 129)
                    : System.Drawing.Color.FromArgb(156, 163, 175);
                e.CellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
                e.FormattingApplied = true;
            }
        }

        private void SetColumnHeader(string column, string header)
        {
            if (dgvScholarships.Columns[column] is DataGridViewColumn gridColumn)
                gridColumn.HeaderText = header;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            // MEMORY FIX: using declaration
            using AddEditScholarshipForm addForm = new AddEditScholarshipForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadScholarships();
                LoadStats(); // Refresh stats in case counts changed
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvScholarships.SelectedRows.Count == 0)
            {
                ToastForm.ShowWarning("Select a scholarship to edit.");
                return;
            }

            int id = Convert.ToInt32(dgvScholarships.SelectedRows[0].Cells["Id"].Value);

            // MEMORY FIX: using declaration
            using AddEditScholarshipForm editForm = new AddEditScholarshipForm(id);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                LoadScholarships();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dgvScholarships.SelectedRows.Count == 0) return;

            int id = Convert.ToInt32(dgvScholarships.SelectedRows[0].Cells["Id"].Value);
            if (MessageBox.Show("Delete this scholarship?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                _scholarshipRepo.Delete(id);
                LoadScholarships();
                LoadStats(); // Refresh stats in case counts changed
            }
            catch (Exception ex)
            {
                ToastForm.ShowError($"Scholarship could not be deleted.\n\n{ex.Message}");
            }
        }

        private void BtnViewApplications_Click(object sender, EventArgs e)
        {
            // MEMORY FIX: using declaration
            using ApproveRejectForm approveForm = new ApproveRejectForm();
            approveForm.ShowDialog();

            // Refresh stats because they likely changed an application status
            LoadStats();
        }

        private void BtnViewStudents_Click(object sender, EventArgs e)
        {
            // MEMORY FIX: using declaration
            using StudentListForm frm = new StudentListForm();
            frm.ShowDialog();
        }

        private void BtnViewDocuments_Click(object sender, EventArgs e)
        {
            try
            {
                // MEMORY FIX: using declaration
                using AllDocumentsForm frm = new AllDocumentsForm();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                ToastForm.ShowError($"Documents could not be loaded.\n\n{ex.Message}");
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            Session.Logout();

            // Do not use 'using' here since the Login form needs to stay open
            Login login = new Login();
            login.Show();
            Close();
        }

        private void BtnCharts_Click(object sender, EventArgs e)
        {
            if (pnlChart.Visible)
            {
                pnlChart.Visible = false;
                pnlGrid.Visible = true;
                btnCharts.Text = "Charts";
            }
            else
            {
                pnlGrid.Visible = false;
                pnlChart.Visible = true;
                btnCharts.Text = "Grid";
                LoadChart();
            }
        }

        private void LoadChart()
        {
            try
            {
                chartStatus.Datasets.Clear();

                DataTable dt = Database.QueryProc("sp_GetApplicationStatusCounts");

                GunaPieDataset dataset = new GunaPieDataset
                {
                    Label = "Applications",
                    BorderWidth = 1
                };

                // Defined base colors
                Color[] chartColors =
                {
                    Color.FromArgb(255, 193, 7),   // Yellow (Pending)
                    Color.FromArgb(16, 185, 129),  // Green (Approved)
                    Color.FromArgb(239, 68, 68),   // Red (Rejected)
                    Color.FromArgb(107, 114, 128), // Gray
                    Color.FromArgb(59, 130, 246),  // Blue
                    Color.FromArgb(139, 92, 246)   // Purple
                };

                int colorIndex = 0;

                foreach (DataRow row in dt.Rows)
                {
                    string status = row["Status"].ToString();
                    int count = Convert.ToInt32(row["Count"]);
                    dataset.DataPoints.Add(status, count);

                    // CHART SAFETY: Safely loop colors if statuses exceed available hardcoded colors
                    dataset.FillColors.Add(chartColors[colorIndex % chartColors.Length]);
                    colorIndex++;
                }

                chartStatus.Datasets.Add(dataset);
            }
            catch (Exception ex)
            {
                ToastForm.ShowError($"Chart could not be loaded.\n\n{ex.Message}");
            }
        }
    }
}