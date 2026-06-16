using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

// Added standard repository using statement to match your architecture
using Window_Forms.Repositories;

namespace Window_Forms
{
    public partial class ApplicationsForm : Form
    {
        // 1. Single repository instance for the form
        private readonly ApplicationRepository _appRepo = new ApplicationRepository();

        public ApplicationsForm(DataTable data)
        {
            InitializeComponent();

            // 2. DataGrid Safety Configuration
            dgvApplications.ReadOnly = true;
            dgvApplications.AllowUserToAddRows = false;
            dgvApplications.AllowUserToDeleteRows = false;
            dgvApplications.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvApplications.CellFormatting += DgvApplications_CellFormatting;

            dgvApplications.DataSource = PrepareDataTable(data);
            dgvApplications.SelectionChanged += (s, e) => UpdateActionButtons();
            UpdateActionButtons(); // set initial state
        }
        private void DgvApplications_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvApplications.Columns[e.ColumnIndex]?.Name == "Action" && e.Value?.ToString() == "No Action Required")
            {
                e.CellStyle.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);
                e.CellStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            }

            
            if (dgvApplications.Columns[e.ColumnIndex]?.Name == "NeedBasedDisplay")
            {
                e.CellStyle.ForeColor = e.Value?.ToString() == "✔"
                    ? System.Drawing.Color.FromArgb(16, 185, 129)
                    : System.Drawing.Color.FromArgb(156, 163, 175);
                e.CellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
                e.FormattingApplied = true;
            }
        }
        private DataTable PrepareDataTable(DataTable dt)
        {
            if (!dt.Columns.Contains("Action"))
                dt.Columns.Add("Action", typeof(string));

            // ← Convert bool NeedBased to a display string up front
            if (dt.Columns.Contains("NeedBased"))
            {
                dt.Columns.Add("NeedBasedDisplay", typeof(string));
                foreach (DataRow row in dt.Rows)
                {
                    bool nb = row["NeedBased"] != DBNull.Value && Convert.ToBoolean(row["NeedBased"]);
                    row["NeedBasedDisplay"] = nb ? "✔" : "✘";
                }
            }

            foreach (DataRow row in dt.Rows)
            {
                string status = row["Status"]?.ToString() ?? "";
                bool isNeedBased = dt.Columns.Contains("NeedBased")
                    && row["NeedBased"] != DBNull.Value
                    && Convert.ToBoolean(row["NeedBased"]);

                row["Action"] = (status == "Approved" && isNeedBased)
                    ? "Your application has been approved. Check your email and visit the scholarship office along with your PDF receipt for further proceedings."
                    : "No Action Required";
            }

            return dt;
        }


        private void ApplicationsForm_Load(object sender, EventArgs e)
        {
            FormatGrid();
        }

        // 3. Helper to ensure columns stay formatted even after a refresh
        private void FormatGrid()
        {
            if (dgvApplications.Columns["Id"] is DataGridViewColumn idCol)
                idCol.Visible = false;

            if (dgvApplications.Columns["ScholarshipId"] is DataGridViewColumn sidCol)
                sidCol.Visible = false;

            if (dgvApplications.Columns["ScholarshipTitle"] is DataGridViewColumn titleCol)
                titleCol.HeaderText = "Scholarship";

            if (dgvApplications.Columns["AppliedDate"] is DataGridViewColumn dateCol)
            {
                dateCol.HeaderText = "Date Applied";
                dateCol.DefaultCellStyle.Format = "dd MMM yyyy"; 
            }

            if (dgvApplications.Columns["ReviewDate"] is DataGridViewColumn reviewCol)
            {
                reviewCol.HeaderText = "Review Date";
                reviewCol.DefaultCellStyle.Format = "dd MMM yyyy"; 
            }

            if (dgvApplications.Columns["AdminComments"] is DataGridViewColumn adminCol)
                adminCol.HeaderText = "Admin Comments";

            if (dgvApplications.Columns["YourComments"] is DataGridViewColumn yourCol)
                yourCol.HeaderText = "Your Comments";

            if (dgvApplications.Columns["NeedBased"] is DataGridViewColumn nbHide)
                nbHide.Visible = false;     

            if (dgvApplications.Columns["NeedBasedDisplay"] is DataGridViewColumn nbCol)
            {
                nbCol.HeaderText = "Need Based";
                nbCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                nbCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                nbCol.FillWeight = 60;
            }

            if (dgvApplications.Columns["Action"] is DataGridViewColumn actionCol)
            {
                actionCol.HeaderText = "Action";
                actionCol.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                actionCol.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(6, 148, 80);
            }
        }

        private void BtnDownloadReceipt_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 0)
            {
                ToastForm.ShowInfo("Select an application first.");
                return;
            }

            int applicationId = Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["Id"].Value);

            // 4. MEMORY FIX: Wrap SaveFileDialog in a using declaration
            using SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = $"ApplicationReceipt_{applicationId}.pdf",
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
                MessageBox.Show(ex.ToString(), "Full Error");
            }
        }

        private void BtnWithdraw_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 0)
            {
                ToastForm.ShowInfo("Select an application first.");
                return;
            }

            string status = dgvApplications.SelectedRows[0].Cells["Status"].Value?.ToString() ?? "";

            // UI validation: Only pending apps can be withdrawn
            if (status != "Pending")
            {
                ToastForm.ShowWarning("Only pending applications can be withdrawn.");
                return;
            }

            int applicationId = Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["Id"].Value);

            DialogResult result = MessageBox.Show(
                "Are you sure you want to withdraw this application?",
                "Confirm Withdrawal",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result != DialogResult.Yes)
                return;

            try
            {
                // Concurrency-safe SQL query
                Database.ExecuteProc("sp_WithdrawApplication",
                    new SqlParameter("@Id", applicationId));

                ToastForm.ShowInfo("Application withdrawn.");
                RefreshData();
                UpdateActionButtons();
            }
            catch (Exception ex)
            {
                ToastForm.ShowError("Could not withdraw.\n\n" + ex.Message);
            }
        }

        private void BtnReapply_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 0)
            {
                ToastForm.ShowInfo("Select an application first.");
                return;
            }

            string status = dgvApplications.SelectedRows[0].Cells["Status"].Value?.ToString() ?? "";

            if (status != "Rejected" && status != "Withdrawn")
            {
                ToastForm.ShowWarning("Only rejected or withdrawn applications can be reapplied.");
                return;
            }

            int applicationId = Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["Id"].Value);
            int scholarshipId = Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["ScholarshipId"].Value);
            string title = dgvApplications.SelectedRows[0].Cells["ScholarshipTitle"].Value?.ToString() ?? "Scholarship";

            // Fetch required documents for this scholarship
            string requiredDocs = "";
            try
            {
                DataTable dt = Database.QueryProc("sp_GetRequiredDocuments",
                    new SqlParameter("@Id", scholarshipId));

                if (dt.Rows.Count > 0)
                    requiredDocs = dt.Rows[0]["RequiredDocuments"]?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                ToastForm.ShowError("Could not load scholarship details.\n\n" + ex.Message);
                return;
            }

            // Block reapply if Pending already exists
            DataTable existingPending = Database.QueryProc("sp_GetPendingApplicationId",
                new SqlParameter("@ScholarshipId", scholarshipId),
                new SqlParameter("@UserEmail", Session.UserEmail));

            if (existingPending.Rows.Count > 0)
            {
                ToastForm.ShowWarning("You have already reapplied for this scholarship.\nYour application is currently Pending.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Reapply for '{title}'?",
                "Confirm Reapply",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes)
                return;

            // Identity Verification is MANDATORY for reapply
            bool identityVerified = IsIdentityVerified(Session.UserEmail);
            if (!identityVerified)
            {
                ToastForm.ShowWarning(
                    "Identity Verification is required before reapplying.\n\n" +
                    "Go to My Profile and complete Identity Verification first.");
                return;
            }

            // Open ApplyForm in reapply mode, passing the existing application ID
            ApplyForm reapplyForm = new ApplyForm(scholarshipId, title, requiredDocs, applicationId);
            if (reapplyForm.ShowDialog() == DialogResult.OK)
                RefreshData();
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
        private void RefreshData()
        {
            // Use the class-level repository instance
            dgvApplications.DataSource = PrepareDataTable(_appRepo.GetMyApplications(Session.UserEmail));

            // FIX: Re-apply formatting after assigning a new DataSource!
            FormatGrid();
        }

        private void UpdateActionButtons()
        {
            if (dgvApplications.SelectedRows.Count == 0)
            {
                btnWithdraw.Enabled = false;
                btnReapply.Visible = false;
                btnReapply.Enabled = false;
                btnContinueDraft.Visible = false;
                btnContinueDraft.Enabled = false;
                return;
            }

            string status = dgvApplications.SelectedRows[0].Cells["Status"].Value?.ToString() ?? "";

            bool isPending = status == "Pending";
            bool isReapplyable = status == "Rejected" || status == "Withdrawn";
            bool isDraft = status == "Draft";

            btnWithdraw.Enabled = isPending;
            btnReapply.Visible = isReapplyable;
            btnReapply.Enabled = isReapplyable;
            btnContinueDraft.Visible = isDraft;
            btnContinueDraft.Enabled = isDraft;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnContinueDraft_Click(object sender, EventArgs e)
        {
            if (dgvApplications.SelectedRows.Count == 0) return;

            int applicationId = Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["Id"].Value);
            int scholarshipId = Convert.ToInt32(dgvApplications.SelectedRows[0].Cells["ScholarshipId"].Value);

            // Guard: verify this draft hasn't already been submitted (stale grid or double-click)
            DataTable statusCheck = Database.QueryProc("sp_CheckApplicationStatus",
                new SqlParameter("@Id", applicationId),
                new SqlParameter("@UserEmail", Session.UserEmail));

            if (statusCheck.Rows.Count == 0)
            {
                ToastForm.ShowWarning("This application no longer exists.");
                RefreshData();
                return;
            }

            string currentStatus = statusCheck.Rows[0]["Status"]?.ToString() ?? "";

            if (currentStatus != "Draft")
            {
                if (currentStatus == "Approved")
                {
                    ToastForm.ShowWarning(
                        "You have already been approved for this scholarship.\n\nNo further applications can be submitted.");
                }
                else
                {
                    ToastForm.ShowWarning(
                        $"This application has already been submitted (Status: {currentStatus}).\n\nYou cannot apply for the same scholarship again.");
                }
                RefreshData();
                return;
            }

            // Also block if a Pending application already exists for this scholarship
            DataTable approvedCheck = Database.QueryProc("sp_GetApprovedApplicationId",
                new SqlParameter("@ScholarshipId", scholarshipId),
                new SqlParameter("@UserEmail", Session.UserEmail));

            if (approvedCheck.Rows.Count > 0)
            {
                ToastForm.ShowWarning(
                    "You have already been approved for this scholarship.\n\nNo further applications can be submitted.");
                RefreshData();
                return;
            }

            DataTable pendingCheck = Database.QueryProc("sp_GetPendingApplicationId",
                new SqlParameter("@ScholarshipId", scholarshipId),
                new SqlParameter("@UserEmail", Session.UserEmail));

            if (pendingCheck.Rows.Count > 0)
            {
                ToastForm.ShowWarning("You already have an active application for this scholarship.");
                RefreshData();
                return;
            }

            string title = dgvApplications.SelectedRows[0].Cells["ScholarshipTitle"].Value?.ToString() ?? "Scholarship";
            string requiredDocs = "";

            try
            {
                DataTable dt = Database.QueryProc("sp_GetRequiredDocuments",
                    new SqlParameter("@Id", scholarshipId));

                if (dt.Rows.Count > 0)
                    requiredDocs = dt.Rows[0]["RequiredDocuments"]?.ToString() ?? "";
            }
            catch (Exception ex)
            {
                ToastForm.ShowError("Could not load scholarship details.\n\n" + ex.Message);
                return;
            }

            ApplyForm applyForm = new ApplyForm(scholarshipId, title, requiredDocs, applicationId);
            if (applyForm.ShowDialog() == DialogResult.OK)
                RefreshData();
        }
    }
}