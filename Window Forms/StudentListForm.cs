using System.Data;
using Microsoft.Data.SqlClient;

namespace Window_Forms
{
    public partial class StudentListForm : Form
    {
        public StudentListForm()
        {
            InitializeComponent();
        }

        private void StudentListForm_Load(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void LoadStudents()
        {
            try
            {
                SqlParameter deptParam = new SqlParameter("@Department", DBNull.Value);
                SqlParameter progParam = new SqlParameter("@DegreeProgram", DBNull.Value);
                SqlParameter searchParam = new SqlParameter("@SearchText",
                    string.IsNullOrWhiteSpace(txtSearch.Text) ? DBNull.Value : (object)txtSearch.Text.Trim());

                dgvStudents.DataSource = Database.QueryProc("sp_SearchStudents", deptParam, progParam, searchParam);
                if (dgvStudents.Columns["FullName"] != null)
                    dgvStudents.Columns["FullName"].HeaderText = "Full Name";
                if (dgvStudents.Columns["MobileNumber"] != null)
                    dgvStudents.Columns["MobileNumber"].HeaderText = "Mobile Number";
                if (dgvStudents.Columns["DegreeProgram"] != null)
                    dgvStudents.Columns["DegreeProgram"].HeaderText = "Degree Program";
                if (dgvStudents.Columns["SemesterYear"] != null)
                    dgvStudents.Columns["SemesterYear"].HeaderText = "Semester / Year";
                if (dgvStudents.Columns["DateOfBirth"] is DataGridViewColumn dobCol)
                {
                    dobCol.HeaderText = "Date of Birth";
                    dobCol.DefaultCellStyle.Format = "dd MMM yyyy";
                }
                if (dgvStudents.Columns["FamilyIncome"] != null)
                    dgvStudents.Columns["FamilyIncome"].HeaderText = "Family Income";
            }
            catch (Exception ex)
            {
                ToastForm.ShowError("Students could not be loaded.\n\n" + ex.Message);
            }
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            LoadStudents();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            txtMaxIncome.Text = string.Empty;
            txtMinCgpa.Text = string.Empty;
            LoadStudents();
        }

        private void DgvStudents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            string email = dgvStudents.Rows[e.RowIndex].Cells["Email"].Value?.ToString();

            if (string.IsNullOrWhiteSpace(email) == false)
            {
                StudentProfilePopupForm profileForm = new StudentProfilePopupForm(email);
                profileForm.ShowDialog();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
