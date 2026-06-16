using System.Data;
using Microsoft.Data.SqlClient;

namespace Window_Forms
{
    public partial class StudentProfilePopupForm : Form
    {
        private string _email;

        public StudentProfilePopupForm(string email)
        {
            InitializeComponent();
            _email = email;

            if (lblHeaderTitle != null)
            {
                lblHeaderTitle.Text = "Student Profile - " + email;
            }
        }

        private void StudentProfilePopupForm_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable profile = Database.QueryProc("sp_GetStudentProfile",
                    new SqlParameter("@Email", _email));

                if (profile.Rows.Count == 0)
                {
                    ToastForm.ShowInfo("Student profile not found.");
                    this.Close();
                    return;
                }

                DataTable display = new DataTable();
                display.Columns.Add("Field");
                display.Columns.Add("Value");

                foreach (DataColumn column in profile.Columns)
                {
                    if (column.ColumnName is "Id" or "UserId" or "CreatedAt" or "UpdatedAt"
                        or "DisabilityDetail")
                        continue;

                    object value = profile.Rows[0][column];
                    string displayValue;

                    if (column.ColumnName == "FingerprintTemplate")
                    {
                        byte[]? bytes = value == DBNull.Value ? null : value as byte[];
                        displayValue = bytes != null && bytes.Length > 0
                            ? "✔ Identity Verified"
                            : "✘ Not Verified";
                    }
                    else if (column.ColumnName == "DisabilityStatus")
                    {
                        string status = value == DBNull.Value ? "" : value.ToString()!.Trim();

                        if (string.IsNullOrWhiteSpace(status) || status.ToLower() == "no")
                        {
                            displayValue = "No";
                        }
                        else if (status.ToLower() == "yes")
                        {
                            string detail = profile.Columns.Contains("DisabilityDetail") &&
                                            profile.Rows[0]["DisabilityDetail"] != DBNull.Value
                                ? profile.Rows[0]["DisabilityDetail"].ToString()!.Trim()
                                : string.Empty;

                            displayValue = string.IsNullOrWhiteSpace(detail)
                                ? "Yes"
                                : $"Yes ({detail})";
                        }
                        else
                        {
                            // Handles "Yes - some detail" stored directly in DisabilityStatus
                            displayValue = status.StartsWith("Yes -", StringComparison.OrdinalIgnoreCase)
                                ? $"Yes ({status.Substring(5).Trim()})"
                                : status;
                        }
                    }
                    else
                    {
                        if (value == DBNull.Value)
                        {
                            displayValue = string.Empty;
                        }
                        else if (value is DateTime dt)
                        {
                            displayValue = dt.ToString("dd MMM yyyy"); 
                        }
                        else
                        {
                            displayValue = value.ToString()!;
                        }
                    }

                    display.Rows.Add(FriendlyName(column.ColumnName), displayValue);
                }

                dgvProfile.DataSource = display;

                if (dgvProfile.Columns["Field"] is DataGridViewColumn fieldColumn)
                    fieldColumn.Width = 220;

                if (dgvProfile.Columns["Value"] is DataGridViewColumn valueColumn)
                    valueColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                ToastForm.ShowError("Profile could not be loaded.\n\n" + ex.Message);
                this.Close();
            }
        }

        private static string FriendlyName(string columnName)
        {
            return columnName
                .Replace("UserEmail", "Email").Replace("FullName", "Full Name")
                .Replace("FatherName", "Father Name").Replace("MobileNumber", "Mobile Number")
                .Replace("DateOfAdmission", "Date of Admission").Replace("DisabilityStatus", "Disability Status")
                .Replace("FamilyIncome", "Family Income").Replace("SemesterYear", "Semester / Year")
                .Replace("RollNumber", "Roll Number").Replace("DegreeProgram", "Degree Program")
                .Replace("UniversityName", "University Name").Replace("RegistrationNumber", "Registration Number")
                .Replace("DateOfBirth", "Date of Birth").Replace("DomicileDistrict", "Domicile District")
                .Replace("TownVillage", "Town / Village").Replace("MailingAddress", "Mailing Address")
                .Replace("PermanentAddress", "Permanent Address").Replace("SSCBoard", "SSC Board")
                .Replace("SSCRollNo", "SSC Roll No").Replace("SSCYear", "SSC Year")
                .Replace("SSCMarks", "SSC Marks").Replace("SSCPercentage", "SSC Percentage")
                .Replace("SSCInstitute", "SSC Institute").Replace("HSSCBoard", "HSSC Board")
                .Replace("HSSCRollNo", "HSSC Roll No").Replace("HSSCYear", "HSSC Year")
                .Replace("HSSCMarks", "HSSC Marks").Replace("HSSCPercentage", "HSSC Percentage")
                .Replace("HSSCInstitute", "HSSC Institute")
                .Replace("FingerprintTemplate", "Identity Verification");
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
