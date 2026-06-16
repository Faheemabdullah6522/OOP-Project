using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using Window_Forms.Models;
using Window_Forms.Repositories;
using Microsoft.Data.SqlClient;

namespace Window_Forms
{
    public partial class StudentDashboard : Form
    {
        private Student _currentStudent;
        private ScholarshipRepository _scholarshipRepo;
        private ApplicationRepository _applicationRepo;
        private StudentRepository _studentRepo;

      
        private const decimal NEED_BASED_INCOME_THRESHOLD = 50000m;

        public StudentDashboard()
        {
            InitializeComponent();

            _scholarshipRepo = new ScholarshipRepository();
            _applicationRepo = new ApplicationRepository();
            _studentRepo = new StudentRepository();
        }

        private void StudentDashboard_Load(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(Session.UserEmail))
            {
                MessageBox.Show("Session expired or invalid. Please login again.", "Session Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                BtnLogout_Click(null, null); 
            }

            try
            {
                EnsureStudentRecord();
                LoadCurrentStudent();

                if (!string.IsNullOrWhiteSpace(Session.FullName))
                {
                    lblWelcome.Text = "Welcome, " + Session.FullName;
                }
                else
                {
                    lblWelcome.Text = "Welcome, " + Session.UserEmail;
                }

                LoadScholarships();
                CleanupExpiredDrafts();
            }
            catch (Exception ex)
            {
                ToastForm.ShowError("Dashboard could not be loaded.\n\n" + ex.Message);
            }
        }

        private void EnsureStudentRecord()
        {
            Student existing = _studentRepo.GetByEmail(Session.UserEmail);

            if (existing == null)
            {
                Database.ExecuteProc("sp_CreateStudentFromUser", new SqlParameter("@Email", Session.UserEmail));
            }
        }

        private void LoadCurrentStudent()
        {
            _currentStudent = _studentRepo.GetByEmail(Session.UserEmail);

            if (_currentStudent == null)
            {
                return;
            }

           
            Session.FullName = _currentStudent.FullName;
            Session.Phone = _currentStudent.MobileNumber;

            if (_currentStudent.PermanentAddress != null)
            {
                Session.Address = _currentStudent.PermanentAddress;
            }
            else
            {
                Session.Address = _currentStudent.MailingAddress;
            }

            Session.DateOfBirth = _currentStudent.DateOfBirth;
            Session.Department = _currentStudent.Department;
            Session.DegreeProgram = _currentStudent.DegreeProgram;
            Session.SemesterYear = _currentStudent.SemesterYear;
            Session.FamilyIncome = _currentStudent.FamilyIncome;
            Session.CGPA = _currentStudent.CGPA;
        }

        private void LoadScholarships()
        {
            try
            {
                List<Scholarship> scholarships = _scholarshipRepo.GetAllActive();

                DataTable dt = new DataTable();

                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Title", typeof(string));
                dt.Columns.Add("Description", typeof(string));
                dt.Columns.Add("Eligibility", typeof(string));
                dt.Columns.Add("Amount", typeof(decimal));
                dt.Columns.Add("Deadline", typeof(DateTime));
                dt.Columns.Add("MinimumCGPA", typeof(decimal));
                dt.Columns.Add("MaxFamilyIncome", typeof(decimal));
                dt.Columns.Add("DegreeProgram", typeof(string));
                dt.Columns.Add("SemesterYear", typeof(string));
                dt.Columns.Add("NeedBased", typeof(bool));
                dt.Columns.Add("RequiredDocuments", typeof(string));
                dt.Columns.Add("Recommendation", typeof(string));
                dt.Columns.Add("Reason", typeof(string));
                dt.Columns.Add("RecommendationRank", typeof(int));

              
                for (int i = 0; i < scholarships.Count; i++)
                {
                    Scholarship s = scholarships[i];
                    DataRow row = dt.NewRow();

                    row["ID"] = s.Id;
                    row["Title"] = s.Title;
                    row["Description"] = Database.ValueOrDbNull(s.Description);
                    row["Eligibility"] = Database.ValueOrDbNull(s.Eligibility);
                    row["Amount"] = s.Amount;
                    row["Deadline"] = Database.ValueOrDbNull(s.Deadline);
                    row["MinimumCGPA"] = Database.ValueOrDbNull(s.MinimumCGPA);
                    row["MaxFamilyIncome"] = Database.ValueOrDbNull(s.MaxFamilyIncome);
                    row["DegreeProgram"] = Database.ValueOrDbNull(s.DegreeProgram);
                    row["SemesterYear"] = Database.ValueOrDbNull(s.SemesterYear);
                    row["NeedBased"] = s.NeedBased;
                    row["RequiredDocuments"] = Database.ValueOrDbNull(s.RequiredDocuments);

                    ScholarshipMatch match = EvaluateScholarship(row);
                    row["Recommendation"] = match.Label;
                    row["Reason"] = match.Reason;
                    row["RecommendationRank"] = match.Rank;

                    dt.Rows.Add(row);
                }

                if (dt.Columns.Contains("NeedBased"))
                {
                    dt.Columns.Add("NeedBasedDisplay", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        bool nb = row["NeedBased"] != DBNull.Value && Convert.ToBoolean(row["NeedBased"]);
                        row["NeedBasedDisplay"] = nb ? "✔" : "✘";
                    }
                }

                DataView view = dt.DefaultView;
                view.Sort = "RecommendationRank ASC, Deadline ASC";

                dgvScholarships.DataSource = view;
                dgvScholarships.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

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
                SetColumnHeader("Eligibility", "Criteria");
                SetColumnHeader("Recommendation", "Eligibility");

                if (dgvScholarships.Columns["RecommendationRank"] is DataGridViewColumn rankColumn)
                {
                    rankColumn.Visible = false;
                }

                if (dgvScholarships.Columns["RequiredDocuments"] is DataGridViewColumn docsColumn)
                {
                    docsColumn.Visible = false;
                }

                if (dgvScholarships.Columns["Deadline"] is DataGridViewColumn deadlineColumn)
                {
                    deadlineColumn.DefaultCellStyle.Format = "dd MMM yyyy";
                }

            }
            catch (Exception ex)
            {
                ToastForm.ShowError("Scholarships could not be loaded.\n\n" + ex.Message);
            }
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
            {
                gridColumn.HeaderText = header;
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            LoadScholarships();
        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {
            ProfileForm profile = new ProfileForm();
            profile.ShowDialog();

            LoadCurrentStudent();

            if (!string.IsNullOrWhiteSpace(Session.FullName))
            {
                lblWelcome.Text = "Welcome, " + Session.FullName;
            }
            else
            {
                lblWelcome.Text = "Welcome, " + Session.UserEmail;
            }

            LoadScholarships();
        }

        private void BtnApply_Click(object sender, EventArgs e)
        {
            DataRow row = GetSelectedScholarship();

            if (row == null)
            {
                ToastForm.ShowWarning("Select a scholarship to apply.");
                return;
       
            int matchRank = Convert.ToInt32(row["RecommendationRank"]);
            if (matchRank == 2)
            {
                ToastForm.ShowInfo(
                    "You are not eligible for this scholarship yet.\n\n" +
                    row["Reason"].ToString() +
                    "\n\nUpdate your profile if any information is missing.");
                return;
            }

            int scholarshipId = Convert.ToInt32(row["Id"]);
            string title = row["Title"]?.ToString() ?? "Scholarship";
            string requiredDocs = row["RequiredDocuments"]?.ToString() ?? "";

       
            Student profile = _studentRepo.GetByEmail(Session.UserEmail);
            var missingFields = new List<string>();

            if (string.IsNullOrWhiteSpace(profile?.FullName)) missingFields.Add("Full Name");
            if (string.IsNullOrWhiteSpace(profile?.FatherName)) missingFields.Add("Father Name");
            if (string.IsNullOrWhiteSpace(profile?.CNIC)) missingFields.Add("CNIC");
            if (string.IsNullOrWhiteSpace(profile?.MobileNumber)) missingFields.Add("Mobile Number");
            if (string.IsNullOrWhiteSpace(profile?.Gender)) missingFields.Add("Gender");
            if (string.IsNullOrWhiteSpace(profile?.Department)) missingFields.Add("Department");
            if (string.IsNullOrWhiteSpace(profile?.DegreeProgram)) missingFields.Add("Degree Program");
            if (string.IsNullOrWhiteSpace(profile?.RollNumber)) missingFields.Add("Roll Number");
            if (string.IsNullOrWhiteSpace(profile?.UniversityName)) missingFields.Add("University Name");
            if (profile?.CGPA == null) missingFields.Add("CGPA");
            if (profile?.FamilyIncome == null) missingFields.Add("Family Income");
            if (string.IsNullOrWhiteSpace(profile?.Province)) missingFields.Add("Province");
            bool identityVerified = IsIdentityVerified(Session.UserEmail);

            if (missingFields.Count > 0)
            {
                ToastForm.ShowWarning(
                    "Your profile is incomplete. Please fill in the following fields before applying:\n\n• " +
                    string.Join("\n• ", missingFields) +
                    "\n\nGo to My Profile to complete your information.");
                return;
            }

            if (!identityVerified)
            {
                ToastForm.ShowWarning(
                    "Identity Verification is required for applying.\n\n" +
                    "Go back to My Profile and perform Identity Verification.");
                return;
            }

            try
            {
               
                bool hasActive = Convert.ToInt32(Database.ScalarProc("sp_CheckExistingApplication",
                    new SqlParameter("@ScholarshipId", scholarshipId),
                    new SqlParameter("@UserEmail", Session.UserEmail),
                    new SqlParameter("@StatusFilter", "Active")) ?? 0) > 0;
                if (hasActive)
                {
                    ToastForm.ShowWarning("You have already applied for this scholarship.\nYour application is currently pending.");
                    return;
                }

                DataTable draftApp = Database.QueryProc("sp_GetDraftApplicationId",
                    new SqlParameter("@ScholarshipId", scholarshipId),
                    new SqlParameter("@UserEmail", Session.UserEmail));

                if (draftApp.Rows.Count > 0)
                {
                    int draftId = Convert.ToInt32(draftApp.Rows[0]["Id"]);
                    ApplyForm draftApplyForm = new ApplyForm(scholarshipId, title, requiredDocs, draftId); 
                    if (draftApplyForm.ShowDialog() == DialogResult.OK)
                        LoadScholarships();
                    return;
                }

                DataTable priorApp = Database.QueryProc("sp_GetRejectedApplicationsForResubmit",
                    new SqlParameter("@ScholarshipId", scholarshipId),
                    new SqlParameter("@UserEmail", Session.UserEmail));

                if (priorApp.Rows.Count > 0)
                {
                    string priorStatus = priorApp.Rows[0]["Status"].ToString();

                    DialogResult confirm = MessageBox.Show(
                        $"Your previous application was '{priorStatus}'.\n\nWould you like to reapply?",
                        "Reapply?",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (confirm != DialogResult.Yes)
                        return;

                    int existingAppId = Convert.ToInt32(priorApp.Rows[0]["Id"]);
                    ApplyForm reapplyForm = new ApplyForm(scholarshipId, title, requiredDocs, existingAppId);
                    if (reapplyForm.ShowDialog() == DialogResult.OK)
                        LoadScholarships();

                    return;
                }

              
                ApplyForm applyForm = new ApplyForm(scholarshipId, title, requiredDocs);
                if (applyForm.ShowDialog() == DialogResult.OK)
                    LoadScholarships();
            }
            catch (Exception ex)
            {
                ToastForm.ShowError("Application could not be started.\n\n" + ex.Message);
            }
        }

        private bool IsIdentityVerified(string userEmail)
        {
            try
            {
                object result = Database.ScalarProc("sp_CountIdentityDocuments",
                    new SqlParameter("@UserEmail", userEmail));

                int count = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;
                return count > 0;
            }
            catch
            {
                return false;
            }
        }

        private DataRow GetSelectedScholarship()
        {
            if (dgvScholarships.SelectedRows.Count == 0)
            {
                return null;
            }

            DataGridViewRow selectedRow = dgvScholarships.SelectedRows[0];

            if (selectedRow.DataBoundItem is DataRowView view)
            {
                return view.Row;
            }

            return null;
        }

        private void BtnSaveForLater_Click(object sender, EventArgs e)
        {
            DataRow row = GetSelectedScholarship();
            if (row == null)
            {
                ToastForm.ShowWarning("Select a scholarship to save.");
                return;
            }

            DateTime deadline = row["Deadline"] != DBNull.Value
                ? Convert.ToDateTime(row["Deadline"]) : DateTime.MaxValue;

            if (deadline < DateTime.Today)
            {
                ToastForm.ShowWarning("This scholarship's deadline has passed. It cannot be saved.");
                return;
            }

            int scholarshipId = Convert.ToInt32(row["ID"]);

            try
            {
                bool hasActive = Convert.ToInt32(Database.ScalarProc("sp_CheckExistingApplication",
                    new SqlParameter("@ScholarshipId", scholarshipId),
                    new SqlParameter("@UserEmail", Session.UserEmail),
                    new SqlParameter("@StatusFilter", "Active")) ?? 0) > 0;
                if (hasActive)
                {
                    ToastForm.ShowWarning("You have already applied for this scholarship.\nYour application is currently pending.");
                    return;
                }

                if (_applicationRepo.HasDraft(scholarshipId, Session.UserEmail))
                {
                    ToastForm.ShowInfo("Already saved as Draft in My Applications.");
                    return;
                }

                Database.ExecuteProc("sp_SubmitDraftApplication",
                    new SqlParameter("@UserEmail", Session.UserEmail),
                    new SqlParameter("@ScholarshipId", scholarshipId));

                ToastForm.ShowInfo("Saved as Draft. Open My Applications and click 'Continue Draft' to apply.");
            }
            catch (Exception ex)
            {
                ToastForm.ShowError("Could not save as draft.\n\n" + ex.Message);
            }
        }
        private void CleanupExpiredDrafts()
        {
            try
            {
                Database.ExecuteProc("sp_DeleteExpiredDrafts");
            }
            catch { }
        }

        private void BtnMyApplications_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = _applicationRepo.GetMyApplications(Session.UserEmail);
                ApplicationsForm frm = new ApplicationsForm(dt);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                ToastForm.ShowError("Applications could not be loaded.\n\n" + ex.Message);
            }
        }

        private void BtnDownloadReceipt_Click(object sender, EventArgs e)
        {
            DataRow selected = GetSelectedScholarship();

            if (selected == null)
            {
                ToastForm.ShowInfo("Select a scholarship first, or open My Applications.");
                return;
            }

            int scholarshipId = Convert.ToInt32(selected["Id"]);

            object appId = Database.ScalarProc("sp_GetLatestApplicationId",
                new SqlParameter("@ScholarshipId", scholarshipId),
                new SqlParameter("@UserEmail", Session.UserEmail));

           
            if (appId == null || appId == DBNull.Value)
            {
                ToastForm.ShowInfo("You have not applied for the selected scholarship yet.");
                return;
            }

            SaveReceipt(Convert.ToInt32(appId));
        }

        private void BtnNotifications_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Database.QueryProc("sp_GetNotificationsByEmail",
                    new SqlParameter("@UserEmail", Session.UserEmail));

                NotificationsForm frm = new NotificationsForm(dt);
                frm.ShowDialog();

                Database.ExecuteProc("sp_MarkNotificationsRead",
                    new SqlParameter("@UserEmail", Session.UserEmail));
            }
            catch (Exception ex)
            {
                ToastForm.ShowError("Notifications could not be loaded.\n\n" + ex.Message);
            }
        }

        private void SaveReceipt(int applicationId)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = "ApplicationReceipt_" + applicationId + ".pdf",
                Title = "Save Application Receipt"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            try
            {
                ApplicationReceiptService.SaveReceipt(applicationId, dialog.FileName);
                ToastForm.ShowInfo("PDF receipt saved successfully.");
            }
            catch (Exception ex)
            {
                ToastForm.ShowError("Receipt could not be saved.\n\n" + ex.Message);
            }
        }

        private ScholarshipMatch EvaluateScholarship(DataRow scholarship)
        {
            List<string> matches = new List<string>();
            List<string> blockers = new List<string>();

            decimal studentCgpa = _currentStudent?.CGPA ?? 0;
            decimal studentIncome = _currentStudent?.FamilyIncome ?? 0;
            string studentDegree = _currentStudent?.DegreeProgram ?? "";
            string studentDepartment = _currentStudent?.Department ?? "";
            string studentSemester = _currentStudent?.SemesterYear ?? "";

            bool hasMinCgpa = scholarship.Table.Columns.Contains("MinimumCGPA") && scholarship["MinimumCGPA"] != DBNull.Value;
            if (hasMinCgpa)
            {
                decimal minCgpa = Convert.ToDecimal(scholarship["MinimumCGPA"]);
                if (_currentStudent?.CGPA == null)
                {
                    blockers.Add("CGPA is missing from your profile");
                }
                else if (studentCgpa < minCgpa)
                {
                    blockers.Add("CGPA must be at least " + minCgpa.ToString("0.00"));
                }
                else
                {
                    matches.Add("CGPA " + studentCgpa.ToString("0.00") + " meets the requirement");
                }
            }

            bool hasMaxIncome = scholarship.Table.Columns.Contains("MaxFamilyIncome") && scholarship["MaxFamilyIncome"] != DBNull.Value;
            if (hasMaxIncome)
            {
                decimal maxIncome = Convert.ToDecimal(scholarship["MaxFamilyIncome"]);
                if (_currentStudent?.FamilyIncome == null)
                {
                    blockers.Add("Family Income is missing from your profile");
                }
                else if (studentIncome > maxIncome)
                {
                    blockers.Add("Family Income must be at most " + maxIncome.ToString("0"));
                }
                else
                {
                    matches.Add("Family Income is within the required limit");
                }
            }

            string requiredProgram = "";
            if (scholarship.Table.Columns.Contains("DegreeProgram") && scholarship["DegreeProgram"] != DBNull.Value)
            {
                requiredProgram = scholarship["DegreeProgram"].ToString() ?? "";
            }

            if (!string.IsNullOrWhiteSpace(requiredProgram))
            {
                if (ProgramMatches(requiredProgram, studentDegree, studentDepartment))
                {
                    matches.Add("Degree/Dept matches");
                }
                else
                {
                    blockers.Add("Degree/Dept should match " + requiredProgram);
                }
            }

            string requiredSemester = "";
            if (scholarship.Table.Columns.Contains("SemesterYear") && scholarship["SemesterYear"] != DBNull.Value)
            {
                requiredSemester = scholarship["SemesterYear"].ToString() ?? "";
            }

            if (!string.IsNullOrWhiteSpace(requiredSemester))
            {
                if (TextMatches(requiredSemester, studentSemester))
                {
                    matches.Add("Semester/Year matches");
                }
                else
                {
                    blockers.Add("Semester/Year should match " + requiredSemester);
                }
            }

            bool needBased = scholarship.Table.Columns.Contains("NeedBased") && scholarship["NeedBased"] != DBNull.Value && Convert.ToBoolean(scholarship["NeedBased"]);

            if (needBased && !hasMaxIncome)
            {
                if (_currentStudent?.FamilyIncome == null)
                {
                    blockers.Add("Family income is required for need-based scholarships");
                }
                else if (studentIncome <= NEED_BASED_INCOME_THRESHOLD)
                {
                    matches.Add("need-based income condition matches");
                }
                else
                {
                    blockers.Add("Family income is above the need-based limit");
                }
            }

            if (blockers.Count > 0)
            {
                return new ScholarshipMatch(false, "Not Eligible", string.Join("; ", blockers), 2);
            }

            if (matches.Count > 0)
            {
                return new ScholarshipMatch(true, "Eligible", string.Join("; ", matches), 0);
            }

            return new ScholarshipMatch(true, "Eligible", "No special restrictions found.", 1);
        }

        // After — strict match only: student's degree or department must contain the required program (or vice versa)
        private bool ProgramMatches(string requiredProgram, string degree, string department)
        {
            return TextMatches(requiredProgram, degree) || TextMatches(requiredProgram, department);
        }

        private bool TextMatches(string required, string actual)
        {
            if (string.IsNullOrWhiteSpace(required)) return true;
            if (string.IsNullOrWhiteSpace(actual)) return false;

            // Optimization: StringComparison.OrdinalIgnoreCase eliminates string copying memory allocation
            string req = required.Trim();
            string act = actual.Trim();

            if (act.IndexOf(req, StringComparison.OrdinalIgnoreCase) >= 0) return true;
            if (req.IndexOf(act, StringComparison.OrdinalIgnoreCase) >= 0) return true;

            return false;
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
          
            if (sender != null && MessageBox.Show("Are you sure you want to logout?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            Session.Logout();

            Login login = new Login();
            login.Show();

            this.Close();
        }

        private sealed class ScholarshipMatch
        {
            public bool IsEligible { get; private set; }
            public string Label { get; private set; }
            public string Reason { get; private set; }
            public int Rank { get; private set; }

            public ScholarshipMatch(bool isEligible, string label, string reason, int rank)
            {
                IsEligible = isEligible;
                Label = label;
                Reason = reason;
                Rank = rank;
            }
        }
    }
}