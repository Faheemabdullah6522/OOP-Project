using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace Window_Forms
{
    public partial class ApplyForm : Form
    {
        private readonly int _scholarshipId;
        private readonly string _scholarshipTitle;
        private readonly string _documentsFolder;

        // Refactored to store both the local file path AND the mapped document type selected by the user
        // At the top of the class, add this field:
        private readonly HashSet<string> _alreadyUploadedTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
        private readonly List<(string FilePath, string DocType)> _uploadedFiles = new List<(string, string)>();
        private Button? _deleteDocBtn;
        private readonly int? _existingApplicationId;

        public ApplyForm(int scholarshipId, string title, string requiredDocs, int? existingApplicationId = null)
        {
            InitializeComponent();

            _scholarshipId = scholarshipId;
            _scholarshipTitle = title;
            _documentsFolder = Path.Combine(Application.StartupPath, "Uploads");


            Directory.CreateDirectory(_documentsFolder);
            _existingApplicationId = existingApplicationId;

            // Pre-fill comments if reapplying
            if (_existingApplicationId.HasValue)
            {
                DataTable prev = Database.QueryProc("sp_GetApplicationComments",
                    new SqlParameter("@Id", _existingApplicationId.Value));

                if (prev.Rows.Count > 0)
                {
                    string adminComments = prev.Rows[0]["Comments"]?.ToString() ?? "";

                    // Always show the admin comments section when reapplying,
                    // even if empty — so the student knows there was/wasn't feedback
                    Label lblAdminComments = new Label
                    {
                        Text = "⚠ Admin Feedback",
                        Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold),
                        ForeColor = System.Drawing.Color.FromArgb(220, 38, 38),
                        Location = new System.Drawing.Point(63, 570),
                        Size = new System.Drawing.Size(568, 40),
                        AutoSize = false
                    };

                    Guna.UI2.WinForms.Guna2TextBox txtAdminComments = new Guna.UI2.WinForms.Guna2TextBox
                    {
                        ReadOnly = true,
                        Multiline = true,
                        ScrollBars = System.Windows.Forms.ScrollBars.Vertical,
                        Font = new System.Drawing.Font("Segoe UI", 10F),
                        ForeColor = System.Drawing.Color.FromArgb(107, 114, 128),
                        FillColor = System.Drawing.Color.FromArgb(254, 242, 242),
                        BorderColor = System.Drawing.Color.FromArgb(220, 38, 38),
                        BorderRadius = 10,
                        BorderThickness = 1,
                        Location = new System.Drawing.Point(63, 612),
                        Size = new System.Drawing.Size(580, 80),
                        DefaultText = "",
                        SelectedText = ""
                    };

                    // ✅ FIX: Add controls to form FIRST, then set Text
                    // Guna2 controls require a parent before Text renders correctly
                    this.Controls.Add(lblAdminComments);
                    this.Controls.Add(txtAdminComments);

                    // Set text AFTER adding to the form
                    txtAdminComments.Text = string.IsNullOrWhiteSpace(adminComments)
                        ? "No feedback provided by admin."
                        : adminComments;

                    lblAdminComments.BringToFront();
                    txtAdminComments.BringToFront();

                    // Expand form height to fit the new section
                    this.ClientSize = new System.Drawing.Size(this.ClientSize.Width, this.ClientSize.Height + 108);
                    this.MinimumSize = new System.Drawing.Size(640, this.ClientSize.Height);
                }

                txtComments.Text = "";
            }   // ← closes if (_existingApplicationId.HasValue)

            lblTitle.Text = $"Applying for: {title}";

            lblTitle.Text = $"Applying for: {title}";

            // Build the small bin button and position it to the right of the listbox
            _deleteDocBtn = new Button
            {
                Text = "🗑",
                Font = new System.Drawing.Font("Segoe UI", 11F),
                Size = new System.Drawing.Size(36, 36),
                Location = new System.Drawing.Point(
                    listBoxDocs.Right + 6,
                    listBoxDocs.Top),
                FlatStyle = FlatStyle.Flat,
                BackColor = System.Drawing.Color.FromArgb(254, 226, 226),
                ForeColor = System.Drawing.Color.FromArgb(220, 38, 38),
                Cursor = Cursors.Hand,
                Visible = true,
                Enabled = false   // disabled until a ticked item is selected
            };
            _deleteDocBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(220, 38, 38);
            _deleteDocBtn.FlatAppearance.BorderSize = 1;
            _deleteDocBtn.Click += DeleteDocBtn_Click;
            this.Controls.Add(_deleteDocBtn);
            _deleteDocBtn.BringToFront();

            // Enable/disable the bin whenever the selection changes
            listBoxDocs.SelectedIndexChanged += (s, e) =>
            {
                string? sel = listBoxDocs.SelectedItem?.ToString();
                _deleteDocBtn.Enabled = sel != null && sel.StartsWith("✔");
            };

            if (!string.IsNullOrWhiteSpace(requiredDocs))
            {
                DataTable uploaded = Database.QueryProc("sp_GetStudentDocumentTypes",
                    new SqlParameter("@UserEmail", Session.UserEmail));

                foreach (DataRow r in uploaded.Rows)
                    _alreadyUploadedTypes.Add(r["DocumentType"].ToString() ?? "");

                string[] docs = requiredDocs.Split(',');
                foreach (string doc in docs)
                {
                    string trimmedDoc = doc.Trim();
                    if (!string.IsNullOrEmpty(trimmedDoc))
                    {
                        string displayText = _alreadyUploadedTypes.Contains(trimmedDoc)
                            ? $"✔ {trimmedDoc}  (already uploaded)"
                            : trimmedDoc;
                        listBoxDocs.Items.Add(displayText);
                    }
                }

                if (listBoxDocs.Items.Count > 0)
                    listBoxDocs.SelectedIndex = 0;
            }
            else
            {
                lblRequiredDocs.Text = "No specific documents required.";
                btnUpload.Enabled = false;
            }
        }

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            if (listBoxDocs.SelectedItem == null)
            {
                ToastForm.ShowWarning("Select the matching document type from the list before uploading.");
                return;
            }

            string raw = listBoxDocs.SelectedItem?.ToString() ?? "";
            string selectedDocType = raw.StartsWith("✔")
                ? raw.Replace("✔", "").Replace("(already uploaded)", "").Replace("(uploaded)", "").Trim()
                : raw.Trim();

            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter = "PDF files (*.pdf)|*.pdf|Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";

            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            // Check for duplicate doc type in this session
            bool alreadyInSession = _uploadedFiles.Any(f =>
                string.Equals(f.DocType, selectedDocType, StringComparison.OrdinalIgnoreCase));

            if (alreadyInSession || _alreadyUploadedTypes.Contains(selectedDocType))
            {
                ToastForm.ShowWarning(
                    $"'{selectedDocType}' is already uploaded.\n\nDelete the existing one first, then re-upload.");
                return;
            }
            string[] selectedFiles = openFileDialog1.FileNames;

            for (int i = 0; i < selectedFiles.Length; i++)
            {
                string file = selectedFiles[i];
                string fileName = Path.GetFileName(file);

                string safePart = Utils.MakeSafeFilePart(Session.UserEmail) ?? "student";
                string destPath = Path.Combine(_documentsFolder, $"{safePart}_{DateTime.Now.Ticks}_{fileName}");

                File.Copy(file, destPath);
                _uploadedFiles.Add((destPath, selectedDocType));
            }

            // Update the list item to show a tick after successful upload
            int selectedIndex = listBoxDocs.SelectedIndex;
            listBoxDocs.Items[selectedIndex] = $"✔ {selectedDocType}  (uploaded)";
            listBoxDocs.SelectedIndex = selectedIndex;

            ToastForm.ShowInfo($"{selectedFiles.Length} file(s) attached as '{selectedDocType}'.");
        }

        private void DeleteDocBtn_Click(object sender, EventArgs e)
        {
            if (listBoxDocs.SelectedItem == null)
                return;

            string raw = listBoxDocs.SelectedItem.ToString() ?? "";
            if (!raw.StartsWith("✔"))
                return;

            // Determine the clean doc type name
            string docType = raw
                .Replace("✔", "")
                .Replace("(already uploaded)", "")
                .Replace("(uploaded)", "")
                .Trim();

            bool wasAlreadyUploaded = _alreadyUploadedTypes.Contains(docType);

            if (wasAlreadyUploaded)
            {
                // Confirm before removing a profile-level document
                if (MessageBox.Show(
                        $"Remove '{docType}' from your profile documents?\nYou will need to re-upload it.",
                        "Confirm Remove",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) != DialogResult.Yes)
                    return;

                _alreadyUploadedTypes.Remove(docType);
            }
            else
            {
                // Remove any in-session uploaded files that match this doc type
                var toDelete = _uploadedFiles
                    .Where(f => string.Equals(f.DocType, docType, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                foreach (var file in toDelete)
                {
                    try
                    {
                        if (File.Exists(file.FilePath))
                            File.Delete(file.FilePath);
                    }
                    catch { /* fail silently */ }

                    _uploadedFiles.Remove(file);
                }
            }

            // Restore the list item back to un-ticked so the user can re-upload
            int idx = listBoxDocs.SelectedIndex;
            listBoxDocs.Items[idx] = docType;
            listBoxDocs.SelectedIndex = idx;

            // Bin becomes disabled again since item no longer has a tick
            if (_deleteDocBtn != null)
                _deleteDocBtn.Enabled = false;

            ToastForm.ShowInfo($"'{docType}' removed. You can now upload a new file for it.");
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Session.UserEmail))
            {
                ToastForm.ShowWarning("Session expired. Please login again.");
                return;
            }

            // DOCUMENT VALIDATION: Check all required docs are uploaded
            if (listBoxDocs.Items.Count > 0)
            {
                var uploadedTypes = _uploadedFiles.Select(f => f.DocType).ToHashSet(StringComparer.OrdinalIgnoreCase);
                var missingDocs = new List<string>();

                foreach (string item in listBoxDocs.Items)
                {
                    // Strip tick prefix to get the real doc type name
                    string requiredDoc = item.StartsWith("✔")
                        ? item.Replace("✔", "").Replace("(already uploaded)", "").Replace("(uploaded)", "").Trim()
                        : item.Trim();

                    // Already uploaded from profile — skip
                    if (_alreadyUploadedTypes.Contains(requiredDoc))
                        continue;

                    if (!uploadedTypes.Contains(requiredDoc))
                        missingDocs.Add(requiredDoc);
                }

                if (missingDocs.Count > 0)
                {
                    ToastForm.ShowWarning(
                        $"Please upload all required documents before submitting.\n\nMissing:\n• " +
                        string.Join("\n• ", missingDocs));
                    return;
                }
            }

            // UI PROTECTION: Disable controls to prevent double clicks/submissions
            btnSubmit.Enabled = false;

            // UI PROTECTION: Disable controls to prevent double clicks/submissions
            btnSubmit.Enabled = false;
            btnCancel.Enabled = false;
            btnUpload.Enabled = false;

            // FIX: Connections, Transactions, and Commands wrapped in 'using' statements to guarantee cleanup
            using SqlConnection conn = Database.GetConnection();
            conn.Open();
            using SqlTransaction transaction = conn.BeginTransaction();

            try
            {
                if (_existingApplicationId.HasValue)
                {
                    // ✅ INSERT new row — old rejected entry stays in history
                    using SqlCommand cmdApp = new SqlCommand("sp_SubmitApplicationWithComments", conn, transaction);
                    cmdApp.CommandType = CommandType.StoredProcedure;
                    cmdApp.Parameters.AddWithValue("@ScholarshipId", _scholarshipId);
                    cmdApp.Parameters.AddWithValue("@UserEmail", Session.UserEmail);
                    cmdApp.Parameters.AddWithValue("@StudentComments", Database.ValueOrDbNull(txtComments.Text.Trim()));
                    cmdApp.ExecuteNonQuery();
                }
                else
                {
                // Fresh application
                using SqlCommand cmdApp = new SqlCommand("sp_SubmitApplicationWithComments", conn, transaction);
                cmdApp.CommandType = CommandType.StoredProcedure;
                    cmdApp.Parameters.AddWithValue("@ScholarshipId", _scholarshipId);
                    cmdApp.Parameters.AddWithValue("@UserEmail", Session.UserEmail);
                    cmdApp.Parameters.AddWithValue("@StudentComments", Database.ValueOrDbNull(txtComments.Text.Trim()));
                    cmdApp.ExecuteNonQuery();
                }

                // Process track file array
                for (int i = 0; i < _uploadedFiles.Count; i++)
                {
                    var uploadedFile = _uploadedFiles[i];
                    string fileName = Path.GetFileName(uploadedFile.FilePath);

                    using SqlCommand cmdDoc = new SqlCommand("sp_InsertDocument", conn, transaction);
                    cmdDoc.CommandType = CommandType.StoredProcedure;
                    cmdDoc.Parameters.AddWithValue("@UserEmail", Session.UserEmail);
                    // FIX: Passes the true document category (e.g. "Transcript") instead of static string
                    cmdDoc.Parameters.AddWithValue("@DocumentType", uploadedFile.DocType);
                    cmdDoc.Parameters.AddWithValue("@FileName", fileName);
                    cmdDoc.Parameters.AddWithValue("@FilePath", uploadedFile.FilePath);
                    cmdDoc.ExecuteNonQuery();
                }

                transaction.Commit();

                ToastForm.ShowSuccess($"Application sent for '{_scholarshipTitle}'.");
                DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Explicit transaction rollback on failures
                transaction.Rollback();

                ToastForm.ShowError($"Error saving application: {ex.Message}");

                // Re-enable UI components on error so the user can fix information and retry
                btnSubmit.Enabled = true;
                btnCancel.Enabled = true;
                btnUpload.Enabled = true;
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // FIX: Handles user cancellation or closing the form layout via X button 
        // to prevent stray unreferenced files from piling up in the disk directory
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            // If the transaction didn't finish successfully, delete all uploaded copies
            if (DialogResult != DialogResult.OK && _uploadedFiles.Count > 0)
            {
                foreach (var file in _uploadedFiles)
                {
                    try
                    {
                        if (File.Exists(file.FilePath))
                        {
                            File.Delete(file.FilePath);
                        }
                    }
                    catch
                    {
                        // Fail silently during cleanup loop if files are temporarily locked
                    }
                }
            }
        }
    }
}