using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;

namespace Window_Forms
{
    public partial class ApproveRejectForm : Form
    {
        public ApproveRejectForm()
        {
            InitializeComponent();
        }

        private void ApproveRejectForm_Load(object sender, EventArgs e)
        {
            dgvApps.ReadOnly = true;
            dgvApps.AllowUserToAddRows = false;
            dgvApps.AllowUserToDeleteRows = false;
            dgvApps.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvApps.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvApps.CellFormatting += DgvApps_CellFormatting;
            LoadApplications();
        }
        private void DgvApps_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvApps.Columns[e.ColumnIndex]?.Name == "NeedBasedDisplay")
            {
                e.CellStyle.ForeColor = e.Value?.ToString() == "✔"
                    ? System.Drawing.Color.FromArgb(16, 185, 129)
                    : System.Drawing.Color.FromArgb(156, 163, 175);
                e.CellStyle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
                e.FormattingApplied = true;
            }
        }
        private void LoadApplications()
        {
            try
            {
                DataTable dt = Database.QueryProc("sp_GetPendingApplications");

                if (dt.Columns.Contains("NeedBased"))
                {
                    dt.Columns.Add("NeedBasedDisplay", typeof(string));
                    foreach (DataRow row in dt.Rows)
                    {
                        bool nb = row["NeedBased"] != DBNull.Value && Convert.ToBoolean(row["NeedBased"]);
                        row["NeedBasedDisplay"] = nb ? "✔" : "✘";
                    }
                }


                dgvApps.DataSource = dt;

                if (dgvApps.Columns["Id"] is DataGridViewColumn idCol)
                    idCol.Visible = false;

                if (dgvApps.Columns["StudentComments"] is DataGridViewColumn sc)
                    sc.HeaderText = "Student Comments";

                if (dgvApps.Columns["DegreeProgram"] is DataGridViewColumn dp)
                    dp.HeaderText = "Degree Program";

                if (dgvApps.Columns["FamilyIncome"] is DataGridViewColumn fi)
                    fi.HeaderText = "Family Income";

                if (dgvApps.Columns["AppliedDate"] is DataGridViewColumn ad)
                {
                    ad.HeaderText = "Applied Date";
                    ad.DefaultCellStyle.Format = "dd MMM yyyy";  
                }

                if (dgvApps.Columns["FullName"] is DataGridViewColumn fnCol)
                    fnCol.HeaderText = "Full Name";

                if (dgvApps.Columns["NeedBased"] is DataGridViewColumn nbHide)
                    nbHide.Visible = false;

                if (dgvApps.Columns["NeedBasedDisplay"] is DataGridViewColumn nbCol)
                {
                    nbCol.HeaderText = "Need Based";
                    nbCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    nbCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    nbCol.FillWeight = 60;
                }

                if (dgvApps.Columns["FPVerified"] is DataGridViewColumn fpCol)
                {
                    fpCol.HeaderText = "Fingerprint";
                    fpCol.Visible = false;
                    fpCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                // TEMP: replace the toast with this to see the full error
                MessageBox.Show(ex.Message, "Full Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e) => this.Close();

        private void BtnApprove_Click(object sender, EventArgs e) => UpdateStatus("Approved");
        private void BtnReject_Click(object sender, EventArgs e) => UpdateStatus("Rejected");

        private void UpdateStatus(string newStatus)
        {
            if (dgvApps.SelectedRows.Count == 0)
            {
                ToastForm.ShowWarning("Select an application.");
                return;
            }

            int appId = Convert.ToInt32(dgvApps.SelectedRows[0].Cells["Id"].Value);
            string scholarshipTitle = dgvApps.SelectedRows[0].Cells["Scholarship"].Value?.ToString() ?? "scholarship";
            string studentEmail = dgvApps.SelectedRows[0].Cells["Student"].Value?.ToString() ?? string.Empty;
            string studentName = dgvApps.SelectedRows[0].Cells["FullName"].Value?.ToString() ?? "Student";
            string comments = "";

            if (newStatus == "Rejected")
            {
                comments = Interaction.InputBox(
                    "Please enter the reason for rejection:",
                    "Rejection Reason", "", -1, -1);

                if (string.IsNullOrWhiteSpace(comments))
                {
                    var result = MessageBox.Show(
                        "Are you sure you want to reject without providing a reason?",
                        "Confirm Rejection", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.No) return;
                }
            }

            try
            {
                using SqlConnection conn = Database.GetConnection();
                conn.Open();
                using SqlTransaction trans = conn.BeginTransaction();

                // ── 1. Update application status ────────────────────────────
                using SqlCommand cmd = new SqlCommand("sp_UpdateApplicationStatus", conn, trans)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ApplicationId", appId);
                cmd.Parameters.AddWithValue("@Status", newStatus);
                cmd.Parameters.AddWithValue("@Comments", Database.ValueOrDbNull(comments));
                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    trans.Rollback();
                    ToastForm.ShowWarning("This application has already been processed by another administrator.");
                    LoadApplications();
                    return;
                }

                // ── 2. Insert notification ──────────────────────────────────
                string notifMsg = $"Hello {studentName}, your application for '{scholarshipTitle}' has been {newStatus}.";

                using SqlCommand cmdNotif = new SqlCommand("sp_InsertNotification", conn, trans)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmdNotif.Parameters.AddWithValue("@UserEmail", studentEmail);
                cmdNotif.Parameters.AddWithValue("@Message", notifMsg);
                cmdNotif.ExecuteNonQuery();

                trans.Commit();

                // ── 3. Send status email only (outside transaction) ────────
                bool statusEmailSent = false;

                try
                {
                    bool isNeedBased = dgvApps.SelectedRows[0].Cells["NeedBased"].Value != DBNull.Value
                        && Convert.ToBoolean(dgvApps.SelectedRows[0].Cells["NeedBased"].Value);

                    Utils.SendApplicationStatusEmail(
                        studentEmail, studentName, scholarshipTitle, newStatus, comments, isNeedBased);

                    statusEmailSent = true;
                }
                catch { /* log if needed */ }

                // ── 4. Show result toast ────────────────────────────────────
                if (newStatus == "Approved")
                {
                    if (statusEmailSent)
                        ToastForm.ShowInfo("Application Approved successfully.\n✅ Status email sent to student.");
                    else
                        ToastForm.ShowWarning("Application Approved successfully.\n⚠ Status email failed to send.");
                }
                else
                {
                    if (statusEmailSent)
                        ToastForm.ShowInfo("Application Rejected successfully.\n✅ Status email sent to student.");
                    else
                        ToastForm.ShowWarning("Application Rejected successfully,\n⚠ Status email failed to send.");
                }

                LoadApplications();
            }
            catch (Exception ex)
            {
                ToastForm.ShowError($"Failed to update application.\n\n{ex.Message}");
            }
        }

        private void BtnViewDocs_Click(object sender, EventArgs e)
        {
            string? studentEmail = GetSelectedStudentEmail();
            if (string.IsNullOrWhiteSpace(studentEmail)) return;
            try
            {
                using AllDocumentsForm frm = new AllDocumentsForm(studentEmail);
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                ToastForm.ShowError($"Documents could not be loaded.\n\n{ex.Message}");
            }
        }

        private void BtnViewProfile_Click(object? sender, EventArgs e)
        {
            string? studentEmail = GetSelectedStudentEmail();
            if (string.IsNullOrWhiteSpace(studentEmail)) return;
            using StudentProfilePopupForm frm = new StudentProfilePopupForm(studentEmail);
            frm.ShowDialog();
        }

        private void BtnDownloadReceipt_Click(object? sender, EventArgs e)
        {
            if (dgvApps.SelectedRows.Count == 0)
            {
                ToastForm.ShowInfo("Select an application.");
                return;
            }

            int applicationId = Convert.ToInt32(dgvApps.SelectedRows[0].Cells["Id"].Value);

            using SaveFileDialog dialog = new SaveFileDialog
            {
                Filter = "PDF files (*.pdf)|*.pdf",
                FileName = $"ApplicationReceipt_{applicationId}.pdf",
                Title = "Save Application Receipt"
            };

            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                ApplicationReceiptService.SaveReceipt(applicationId, dialog.FileName);
                ToastForm.ShowInfo("PDF receipt saved successfully.");
            }
            catch (Exception ex)
            {
                ToastForm.ShowError($"Receipt could not be saved.\n\n{ex.Message}");
            }
        }

        private string? GetSelectedStudentEmail()
        {
            if (dgvApps.SelectedRows.Count == 0)
            {
                ToastForm.ShowWarning("Select an application.");
                return null;
            }
            return dgvApps.SelectedRows[0].Cells["Student"].Value?.ToString();
        }
    }
}
