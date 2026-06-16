using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using Guna.UI2.WinForms;
using Microsoft.Data.SqlClient;
using Window_Forms.Repositories;

namespace Window_Forms
{
    public partial class ProfileForm : Form
    {
        private readonly string documentsFolder = Path.Combine(Application.StartupPath, "Uploads");
        private readonly Dictionary<string, Control> fields = new Dictionary<string, Control>();
        private readonly Dictionary<string, string> labels = new Dictionary<string, string>();
        private DataGridView? documentsGrid;
        private ComboBox? documentTypeBox;

      
        private static readonly string[] AllowedExtensions = { ".pdf", ".jpg", ".jpeg", ".png" };

        private static readonly string[] ProfileColumns =
        {
            "FullName", "FatherName", "CNIC", "MobileNumber", "Email", "Gender", "Religion",
            "DateOfAdmission", "DisabilityStatus", "FamilyIncome", "SemesterYear",
            "RollNumber", "Department", "DegreeProgram", "UniversityName", "RegistrationNumber", "CGPA",
            "DateOfBirth", "DomicileDistrict", "Province", "District", "TownVillage", "MailingAddress", "PermanentAddress",
            "SSCBoard", "SSCRollNo", "SSCYear", "SSCMarks", "SSCPercentage", "SSCInstitute",
            "HSSCBoard", "HSSCRollNo", "HSSCYear", "HSSCMarks", "HSSCPercentage", "HSSCInstitute"
        };

        private static readonly HashSet<string> DecimalColumns = new HashSet<string>
        {
            "FamilyIncome", "CGPA", "SSCMarks", "SSCPercentage", "HSSCMarks", "HSSCPercentage"
        };

        private static readonly HashSet<string> IntegerColumns = new HashSet<string>
        {
            "SSCRollNo", "SSCYear",
            "HSSCRollNo", "HSSCYear"
        };

        private static readonly HashSet<string> DateColumns = new HashSet<string>
        {
            "DateOfAdmission", "DateOfBirth"
        };

        public ProfileForm()
        {
            InitializeComponent();
            Directory.CreateDirectory(documentsFolder);
            RegisterDesignerFields();
        }

        private void RegisterDesignerFields()
        {
            fields.Clear();
            labels.Clear();

            RegisterField("FullName", "Full Name", txtFullName);
            RegisterField("FatherName", "Father Name", txtFatherName);
            RegisterField("CNIC", "CNIC", txtCNIC);
            RegisterField("MobileNumber", "Mobile Number", txtMobileNumber);
            RegisterField("Email", "Email", txtEmail);
            RegisterField("Gender", "Gender", cmbGender);
            RegisterField("Religion", "Religion", cmbReligion);
            RegisterField("DateOfAdmission", "Date of Admission", dtpDateOfAdmission);
            RegisterField("DisabilityStatus", "Disability Status", cmbDisabilityStatus);
            RegisterField("FamilyIncome", "Family Income", txtFamilyIncome);
            RegisterField("SemesterYear", "Semester / Year", txtSemesterYear);
            RegisterField("RollNumber", "Roll Number", txtRollNumber);
            RegisterField("Department", "Department", txtDepartment);
            RegisterField("DegreeProgram", "Degree Program", txtDegreeProgram);
            RegisterField("UniversityName", "University Name", txtUniversityName);
            RegisterField("RegistrationNumber", "Registration Number", txtRegistrationNumber);
            RegisterField("CGPA", "CGPA", txtCGPA);
            RegisterField("DateOfBirth", "Date of Birth", dtpDateOfBirth);
            RegisterField("DomicileDistrict", "Domicile District", txtDomicileDistrict);
            RegisterField("Province", "Province", txtProvince);
            RegisterField("District", "District", txtDistrict);
            RegisterField("TownVillage", "Town / Village", txtTownVillage);
            RegisterField("MailingAddress", "Mailing Address", txtMailingAddress);
            RegisterField("PermanentAddress", "Permanent Address", txtPermanentAddress);
            RegisterField("SSCBoard", "SSC Board", txtSSCBoard);
            RegisterField("SSCRollNo", "SSC Roll No", txtSSCRollNo);
            RegisterField("SSCYear", "SSC Year", txtSSCYear);
            RegisterField("SSCMarks", "SSC Marks", txtSSCMarks);
            RegisterField("SSCPercentage", "SSC Percentage", txtSSCPercentage);
            RegisterField("SSCInstitute", "SSC Institute", txtSSCInstitute);
            RegisterField("HSSCBoard", "HSSC Board", txtHSSCBoard);
            RegisterField("HSSCRollNo", "HSSC Roll No", txtHSSCRollNo);
            RegisterField("HSSCYear", "HSSC Year", txtHSSCYear);
            RegisterField("HSSCMarks", "HSSC Marks", txtHSSCMarks);
            RegisterField("HSSCPercentage", "HSSC Percentage", txtHSSCPercentage);
            RegisterField("HSSCInstitute", "HSSC Institute", txtHSSCInstitute);

            documentsGrid = dgvDocuments;
            documentTypeBox = cmbDocType;
            cmbDocType.SelectedIndex = 0;
            Label lblIncomeHint = new Label
            {
                Text = "📋 For Need-Based Scholarships",
                Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic),
                ForeColor = System.Drawing.Color.FromArgb(14, 116, 144),
                AutoSize = true,
                Visible = false,
                Location = new System.Drawing.Point(cmbDocType.Left, cmbDocType.Bottom + 4)
            };
            cmbDocType.Parent.Controls.Add(lblIncomeHint);

            cmbDocType.SelectedIndexChanged += (s, e) =>
            {
                lblIncomeHint.Visible = cmbDocType.SelectedItem?.ToString() == "Income/Salary Proof";
            };
        }

        private void RegisterField(string column, string label, Control editor)
        {
            fields[column] = editor;
            labels[column] = label;
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Session.UserEmail))
            {
                ToastForm.ShowWarning("Please login again.");
                Close();
                return;
            }

            try
            {
                EnsureStudentRecord();
                LoadProfile();
                LoadDocuments();
                cmbDisabilityStatus.SelectedIndexChanged += CmbDisabilityStatus_SelectedIndexChanged;
                if (cmbDisabilityStatus.Text == "Yes")
                    txtDisabilityDetail.Visible = true;
            }
            catch (Exception ex)
            {
                ToastForm.ShowError($"Profile could not be loaded.\n\n{ex.Message}");
            }
        }

        private void BtnChatbot_Click(object? sender, EventArgs e)
        {
            ChatbotForm.ShowChatbot(this);
        }

        private void EnsureStudentRecord()
        {
            Database.ExecuteProc("sp_CreateStudentFromUser", new SqlParameter("@Email", Session.UserEmail));
        }

        private void LoadProfile()
        {
            DataTable table = Database.QueryProc("sp_GetStudentProfile", new SqlParameter("@Email", Session.UserEmail));

            if (table.Rows.Count == 0)
            {
                SetText("Email", Session.UserEmail);
                return;
            }

            DataRow row = table.Rows[0];
            foreach (string column in ProfileColumns)
            {
                if (!fields.TryGetValue(column, out Control? control))
                    continue;

                object value = row.Table.Columns.Contains(column) ? row[column] : DBNull.Value;
                if (value == DBNull.Value)
                {
                    if (column == "Email")
                        SetText(column, Session.UserEmail);
                    continue;
                }

                if (control is Guna2DateTimePicker picker)
                    picker.Value = Convert.ToDateTime(value);
                else if (control is Guna2ComboBox combo)
                    combo.Text = value.ToString();
                else if (control is Guna2TextBox textBox)
                    textBox.Text = value.ToString();
            }

            SyncSessionFromRow(row);
            // Load disability detail
            if (row.Table.Columns.Contains("DisabilityStatus") && row["DisabilityStatus"]?.ToString() == "Yes")
            {
                txtDisabilityDetail.Visible = true;
                if (row.Table.Columns.Contains("DisabilityDetail") && row["DisabilityDetail"] != DBNull.Value)
                    txtDisabilityDetail.Text = row["DisabilityDetail"].ToString();
            }

            // Load same address checkbox
            string mailing = row.Table.Columns.Contains("MailingAddress") && row["MailingAddress"] != DBNull.Value
                ? row["MailingAddress"].ToString() ?? "" : "";
            string permanent = row.Table.Columns.Contains("PermanentAddress") && row["PermanentAddress"] != DBNull.Value
                ? row["PermanentAddress"].ToString() ?? "" : "";
            if (!string.IsNullOrWhiteSpace(mailing) && mailing == permanent)
            {
                chkSameAddress.Checked = true;
                txtPermanentAddress.Enabled = false;
            }
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            // CHECK 6: Prevent double-clicks
            Control? btn = sender as Control;
            if (btn != null) btn.Enabled = false;

            try
            {
                if (string.IsNullOrWhiteSpace(Session.UserEmail))
                    return;

                // Validate all required fields before saving
                string? missingField = GetFirstMissingRequiredField();
                if (missingField != null)
                {
                    ToastForm.ShowWarning($"{missingField} is required.");
                    return;
                }

                // If disability is Yes, detail must be specified
                if (cmbDisabilityStatus.Text == "Yes" && string.IsNullOrWhiteSpace(txtDisabilityDetail.Text))
                {
                    ToastForm.ShowWarning("Please specify the disability.");
                    return;
                }

                // CHECK 5: String Format Validations (CNIC and Mobile Number)
                string cnic = GetText("CNIC");
                if (!string.IsNullOrWhiteSpace(cnic) && !Regex.IsMatch(cnic, @"^\d{13}$"))
                {
                    ToastForm.ShowWarning("CNIC must be exactly 13 digits.");
                    return;
                }

                string mobile = GetText("MobileNumber");
                if (!string.IsNullOrWhiteSpace(mobile) && !Regex.IsMatch(mobile, @"^(03\d{9}|\+923\d{9})$"))
                {
                    ToastForm.ShowWarning("Mobile number must be a valid format (e.g., 03001234567).");
                    return;
                }

                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@UserEmail", Session.UserEmail),
                    new SqlParameter("@UserId", Database.ValueOrDbNull(Session.UserId))
                };

                // Getting field values will now automatically throw a FormatException if bounds are violated
                foreach (string column in ProfileColumns)
                    parameters.Add(new SqlParameter("@" + column, GetFieldValue(column)));

                Database.ExecuteProc("sp_UpsertStudentProfile", parameters.ToArray());
                Database.ExecuteProc("sp_UpdateUserProfile",
                    new SqlParameter("@Email", Session.UserEmail),
                    new SqlParameter("@FullName", Database.ValueOrDbNull(GetText("FullName"))),
                    new SqlParameter("@Phone", Database.ValueOrDbNull(GetText("MobileNumber"))),
                    new SqlParameter("@Address", Database.ValueOrDbNull(GetText("PermanentAddress") ?? GetText("MailingAddress"))),
                    new SqlParameter("@DateOfBirth", GetFieldValue("DateOfBirth")));
                // Save disability detail if Yes
                if (cmbDisabilityStatus.Text == "Yes" && !string.IsNullOrWhiteSpace(txtDisabilityDetail.Text))
                {
                    Database.ExecuteProc("sp_UpdateDisabilityStatus",
                        new SqlParameter("@Value", "Yes - " + txtDisabilityDetail.Text.Trim()),
                        new SqlParameter("@Email", Session.UserEmail));
                }
                UpdateSessionFromFields();

                ToastForm.ShowInfo("Profile updated.");
            }
            // Now catches our Custom bounds logic
            catch (FormatException ex)
            {
                ToastForm.ShowWarning(ex.Message);
            }
            catch (Exception ex)
            {
                ToastForm.ShowError($"Profile could not be saved.\n\n{ex.Message}");
            }
            finally
            {
                if (btn != null) btn.Enabled = true;
            }
        }

        private string? GetFirstMissingRequiredField()
        {
            foreach (string column in ProfileColumns)
            {
                if (!fields.TryGetValue(column, out Control? control))
                    continue;

                // DateTimePickers always carry a value — skip them
                if (DateColumns.Contains(column))
                    continue;

                string text = control is Guna2ComboBox combo ? combo.Text.Trim() : control.Text.Trim();
                if (string.IsNullOrWhiteSpace(text))
                    return labels.TryGetValue(column, out string? lbl) ? lbl : column;
            }

            return null;
        }

        private object GetFieldValue(string column)
        {
            if (!fields.TryGetValue(column, out Control? control))
                return DBNull.Value;

            if (DateColumns.Contains(column) && control is Guna2DateTimePicker picker)
                return picker.Value.Date;

            string text = control is Guna2ComboBox combo ? combo.Text.Trim() : control.Text.Trim();
            if (string.IsNullOrWhiteSpace(text))
                return DBNull.Value;

            if (DecimalColumns.Contains(column))
            {
                if (decimal.TryParse(text, out decimal value))
                {
                    // CHECK 4: Range Validation for Academic Data
                    if (column == "CGPA" && (value < 0.0m || value > 4.0m))
                        throw new FormatException("CGPA must be between 0.0 and 4.0.");

                    if ((column == "SSCPercentage" || column == "HSSCPercentage") && (value < 0.0m || value > 100.0m))
                        throw new FormatException($"{labels[column]} must be between 0 and 100.");

                    if (column == "FamilyIncome" && value < 0)
                        throw new FormatException("Family Income cannot be negative.");

                    return value;
                }

                throw new FormatException($"{labels[column]} must be a number.");
            }

            if (IntegerColumns.Contains(column))
            {
                if (int.TryParse(text, out int value))
                {
                    // Basic sanity check for years
                    if ((column == "SSCYear" || column == "HSSCYear") && (value < 1950 || value > DateTime.Now.Year))
                        throw new FormatException($"{labels[column]} must be a valid year.");

                    // Roll numbers must be positive
                    if ((column == "SSCRollNo" || column == "HSSCRollNo") && value <= 0)
                        throw new FormatException($"{labels[column]} must be a positive number.");

                    return value;
                }

                throw new FormatException($"{labels[column]} must be a whole number.");
            }

            return text;
        }

        private void BtnUploadDoc_Click(object sender, EventArgs e)
        {
            if (cmbDocType.SelectedIndex <= 0)
            {
                ToastForm.ShowWarning("Please select a document type before uploading.");
                return;
            }

            string selectedType = cmbDocType.SelectedItem?.ToString() ?? "";

            // Check if a document of this type already exists for this student
            try
            {
                object existing = Database.ScalarProc("sp_CountDocumentsByType",
                    new SqlParameter("@UserEmail", Session.UserEmail),
                    new SqlParameter("@DocumentType", selectedType));

                int count = (existing != null && existing != DBNull.Value) ? Convert.ToInt32(existing) : 0;

                if (count > 0)
                {
                    ToastForm.ShowWarning(
                        $"A '{selectedType}' document is already uploaded.\n\nDelete the existing one first, then re-upload.");
                    return;
                }
            }
            catch (Exception ex)
            {
                ToastForm.ShowError("Could not verify existing documents.\n\n" + ex.Message);
                return;
            }

            // Proceed with file selection
            using OpenFileDialog dlg = new OpenFileDialog
            {
                Title = $"Select {selectedType}",
                Filter = "PDF files (*.pdf)|*.pdf|Image files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*",
                Multiselect = false
            };

            if (dlg.ShowDialog() != DialogResult.OK)
                return;

            string srcPath = dlg.FileName;
            string fileName = Path.GetFileName(srcPath);
            string uploadsFolder = Path.Combine(Application.StartupPath, "Uploads");
            Directory.CreateDirectory(uploadsFolder);

            string safePart = Utils.MakeSafeFilePart(Session.UserEmail) ?? "student";
            string destPath = Path.Combine(uploadsFolder, $"{safePart}_{DateTime.Now.Ticks}_{fileName}");

            try
            {
                File.Copy(srcPath, destPath);

                Database.ExecuteProc("sp_InsertDocument",
                    new SqlParameter("@UserEmail", Session.UserEmail),
                    new SqlParameter("@DocumentType", selectedType),
                    new SqlParameter("@FileName", fileName),
                    new SqlParameter("@FilePath", destPath));

                ToastForm.ShowSuccess($"'{selectedType}' uploaded successfully.");
                LoadDocuments(); // refresh the grid
            }
            catch (Exception ex)
            {
                // Clean up the copied file if the DB insert failed
                if (File.Exists(destPath))
                    try { File.Delete(destPath); } catch { }

                ToastForm.ShowError("Upload failed.\n\n" + ex.Message);
            }
        }

        private void BtnViewDocs_Click(object sender, EventArgs e)
        {
            LoadDocuments();
        }

        private void BtnFingerprint_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Session.UserEmail))
                return;

            Control? btn = sender as Control;
            if (btn != null) btn.Enabled = false;

            try
            {
                // Check if already verified
                object existing = Database.ScalarProc("sp_CountIdentityDocuments",
                    new SqlParameter("@UserEmail", Session.UserEmail));
                int count = (existing != null && existing != DBNull.Value) ? Convert.ToInt32(existing) : 0;

                if (count > 0)
                {
                    DialogResult reVerify = MessageBox.Show(
                        "You have already completed Identity Verification.\n\nSend a new link to re-verify?",
                        "Already Verified", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (reVerify != DialogResult.Yes) return;
                }

                // Clean up old identity documents
                Database.ExecuteProc("sp_DeleteIdentityDocuments",
                    new SqlParameter("@UserEmail", Session.UserEmail));

                // Reset fingerprint marker
                new StudentRepository().UpdateFingerprintByEmail(Session.UserEmail, null);

                string token = Utils.GenerateFingerprintVerificationToken();
                string studentName = Session.FullName ?? Session.UserEmail;

                // ✅ INSERT TOKEN INTO DB BEFORE SENDING EMAIL
                Database.ExecuteProc("sp_InsertIdentityVerificationToken",
                    new SqlParameter("@UserEmail", Session.UserEmail),
                    new SqlParameter("@Token", token),
                    new SqlParameter("@StudentName", studentName),
                    new SqlParameter("@ExpiresAt", DateTime.Now.AddHours(1)));

                // Now send the email
                Utils.SendIdentityVerificationLinkEmail(Session.UserEmail, studentName, token);

                btnFingerprint.Text = "Resend Verification Link";
                ToastForm.ShowSuccess(
                    "Verification link sent to your email!\n\n" +
                    "Open it on your mobile device to complete identity verification.");
            }
            catch (Exception ex)
            {
                ToastForm.ShowError("Could not send verification link.\n\n" + ex.Message);
            }
            finally
            {
                if (btn != null) btn.Enabled = true;
            }
        }

        private void BtnClose_Click(object? sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close?", "Confirm Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            Close();
        }

        private void LoadDocuments()
        {
            if (string.IsNullOrWhiteSpace(Session.UserEmail) || documentsGrid == null)
                return;

            DataTable table = Database.QueryProc("sp_GetDocumentsByEmail",
                new SqlParameter("@UserEmail", Session.UserEmail));
            documentsGrid.DataSource = table;

            if (documentsGrid.Columns["FilePath"] is DataGridViewColumn filePathColumn)
                filePathColumn.Visible = false;

            if (documentsGrid.Columns["DocumentType"] is DataGridViewColumn docTypeColumn)
                docTypeColumn.HeaderText = "Document Type";

            if (documentsGrid.Columns["FileName"] is DataGridViewColumn fileNameColumn)
                fileNameColumn.HeaderText = "File Name";

            if (dgvDocuments.Columns["UploadDate"] is DataGridViewColumn uploadDateColumn)
            {
                uploadDateColumn.HeaderText = "Upload Date";
                uploadDateColumn.DefaultCellStyle.Format = "dd MMM yyyy";   // ← add
            }
        }


        private void DocumentsGrid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (documentsGrid == null || e.RowIndex < 0)
                return;

            string? path = documentsGrid.Rows[e.RowIndex].Cells["FilePath"].Value?.ToString();

            if (string.IsNullOrWhiteSpace(path) || !File.Exists(path))
            {
                ToastForm.ShowWarning("File was not found on disk.");
                return;
            }

            // CHECK 3: Process Execution Safe-Guards (Prevent opening arbitrary .exe/.bat files)
            string extension = Path.GetExtension(path).ToLower();
            if (!AllowedExtensions.Contains(extension))
            {
                ToastForm.ShowWarning("Security Block: This file type is not allowed to be opened.");
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                ToastForm.ShowError($"Could not open file.\n\n{ex.Message}");
            }
        }

        private void SyncSessionFromRow(DataRow row)
        {
            Session.FullName = ReadString(row, "FullName");
            Session.Phone = ReadString(row, "MobileNumber");
            Session.Address = ReadString(row, "PermanentAddress") ?? ReadString(row, "MailingAddress");
            Session.DateOfBirth = ReadDate(row, "DateOfBirth");
            Session.Department = ReadString(row, "Department");
            Session.DegreeProgram = ReadString(row, "DegreeProgram");
            Session.SemesterYear = ReadString(row, "SemesterYear");
            Session.FamilyIncome = ReadDecimal(row, "FamilyIncome");
            Session.CGPA = ReadDecimal(row, "CGPA");
        }

        private void UpdateSessionFromFields()
        {
            Session.FullName = GetText("FullName");
            Session.Phone = GetText("MobileNumber");
            Session.Address = GetText("PermanentAddress");
            if (string.IsNullOrWhiteSpace(Session.Address))
                Session.Address = GetText("MailingAddress");
            Session.DateOfBirth = fields.TryGetValue("DateOfBirth", out Control? dob) && dob is Guna2DateTimePicker picker ? picker.Value.Date : null;
            Session.Department = GetText("Department");
            Session.DegreeProgram = GetText("DegreeProgram");
            Session.SemesterYear = GetText("SemesterYear");
            Session.FamilyIncome = TryGetDecimal("FamilyIncome");
            Session.CGPA = TryGetDecimal("CGPA");
        }

        private string GetText(string column)
        {
            if (!fields.TryGetValue(column, out Control? control))
                return string.Empty;

            return control is Guna2ComboBox combo ? combo.Text.Trim() : control.Text.Trim();
        }

        private void SetText(string column, string? value)
        {
            if (fields.TryGetValue(column, out Control? control))
                control.Text = value ?? string.Empty;
        }

        private decimal? TryGetDecimal(string column)
        {
            string text = GetText(column);
            return decimal.TryParse(text, out decimal value) ? value : null;
        }

        private static string? ReadString(DataRow row, string column)
        {
            return row.Table.Columns.Contains(column) && row[column] != DBNull.Value ? row[column].ToString() : null;
        }

        private static DateTime? ReadDate(DataRow row, string column)
        {
            return row.Table.Columns.Contains(column) && row[column] != DBNull.Value ? Convert.ToDateTime(row[column]) : null;
        }

        private static decimal? ReadDecimal(DataRow row, string column)
        {
            return row.Table.Columns.Contains(column) && row[column] != DBNull.Value ? Convert.ToDecimal(row[column]) : null;
        }
        private void ChkSameAddress_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSameAddress.Checked)
            {
                txtPermanentAddress.Text = txtMailingAddress.Text;
                txtPermanentAddress.Enabled = false;
            }
            else
            {
                txtPermanentAddress.Enabled = true;
            }
        }

        private void CmbDisabilityStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isDisabled = cmbDisabilityStatus.Text == "Yes";
            txtDisabilityDetail.Visible = isDisabled;
            if (!isDisabled)
                txtDisabilityDetail.Text = "";
        }

        private void TxtCNIC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                return;
            }
            if (txtCNIC.Text.Length >= 13 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void TxtMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            string current = txtMobileNumber.Text;
            if (current.Length == 0 && char.IsDigit(e.KeyChar))
            {
                txtMobileNumber.Text = "+923";
                txtMobileNumber.SelectionStart = txtMobileNumber.Text.Length;
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '+')
            {
                e.Handled = true;
                return;
            }
            if (current.Length >= 13 && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }
        private void BtnDeleteDoc_Click(object sender, EventArgs e)
        {
            if (dgvDocuments.SelectedRows.Count == 0)
            {
                ToastForm.ShowInfo("Select a document to delete.");
                return;
            }

            string docType = dgvDocuments.SelectedRows[0].Cells["DocumentType"].Value?.ToString() ?? "";
            string filePath = dgvDocuments.SelectedRows[0].Cells["FilePath"].Value?.ToString() ?? "";
            int docId = Convert.ToInt32(dgvDocuments.SelectedRows[0].Cells["ID"].Value);

            DialogResult confirm = MessageBox.Show(
                $"Delete '{docType}'?\n\nYou will need to re-upload it if required.",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
                return;

            try
            {
                Database.ExecuteProc("sp_DeleteDocument",
                    new SqlParameter("@Id", docId),
                    new SqlParameter("@UserEmail", Session.UserEmail));

                // Delete the physical file too
                if (!string.IsNullOrWhiteSpace(filePath) && File.Exists(filePath))
                {
                    try { File.Delete(filePath); } catch { /* fail silently if file is locked */ }
                }

                ToastForm.ShowInfo($"'{docType}' deleted. You can now upload a new one.");
                LoadDocuments();
            }
            catch (Exception ex)
            {
                ToastForm.ShowError("Could not delete document.\n\n" + ex.Message);
            }
        }
        private async void BtnAutoFill_Click(object? sender, EventArgs e)
        {
            // ── 1. Pick a document ────────────────────────────────────────────────
            using var dlg = new OpenFileDialog
            {
                Title  = "Select a document to scan (CNIC, Transcript, Domicile, etc.)",
                Filter = "Supported files (*.pdf;*.jpg;*.jpeg;*.png)|*.pdf;*.jpg;*.jpeg;*.png",
                Multiselect = false
            };
 
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
 
            string filePath = dlg.FileName;
 
            // ── 2. Loading state ──────────────────────────────────────────────────
            btnAutoFill.Enabled = false;
            btnAutoFill.Text    = "⏳ Scanning...";
 
            try
            {
                // ── 3. Call Gemini ─────────────────────────────────────────────────
                var extracted = await GeminiService.ExtractProfileDataAsync(filePath);
 
                if (extracted.Count == 0)
                {
                    ToastForm.ShowWarning(
                        "The AI couldn't read any fields from that document.\n\n" +
                        "Make sure the file is a clear, readable PDF or image.");
                    return;
                }
 
                // ── 4. Fill form fields (only empty ones) ──────────────────────────
                int filled = 0;
 
                foreach (var kv in extracted)
                {
                    if (!fields.TryGetValue(kv.Key, out Control? ctrl)) continue;
 
                    string value = kv.Value.Trim();
                    if (string.IsNullOrEmpty(value)) continue;
 
                    switch (ctrl)
                    {
                        case Guna.UI2.WinForms.Guna2TextBox tb when string.IsNullOrWhiteSpace(tb.Text):
                            tb.Text = value;
                            FlashGreen(tb);
                            filled++;
                            break;
 
                        case TextBox tb when string.IsNullOrWhiteSpace(tb.Text):
                            tb.Text = value;
                            FlashGreen(tb);
                            filled++;
                            break;
 
                        case Guna.UI2.WinForms.Guna2ComboBox cb when cb.SelectedIndex <= 0:
                        {
                            int idx = cb.FindStringExact(value);
                            if (idx < 0)
                                for (int i = 0; i < cb.Items.Count; i++)
                                    if (cb.Items[i]?.ToString()
                                        ?.Equals(value, StringComparison.OrdinalIgnoreCase) == true)
                                    { idx = i; break; }
 
                            if (idx >= 0) { cb.SelectedIndex = idx; filled++; }
                            break;
                        }
 
                        case Guna.UI2.WinForms.Guna2DateTimePicker dtp
                            when dtp.Value.Date == DateTime.Today || dtp.Value == dtp.MinDate:
                        {
                            if (DateTime.TryParseExact(value, "dd/MM/yyyy",
                                    System.Globalization.CultureInfo.InvariantCulture,
                                    System.Globalization.DateTimeStyles.None, out var dt)
                                || DateTime.TryParse(value, out dt))
                            {
                                dtp.Value = dt;
                                filled++;
                            }
                            break;
                        }
                    }
                }
 
                // ── 5. Result toast ────────────────────────────────────────────────
                if (filled > 0)
                    ToastForm.ShowSuccess(
                        $"✅ {filled} field(s) auto-filled!\n" +
                        "Review the highlighted fields, then click Save Profile.");
                else
                    ToastForm.ShowWarning(
                        "Document scanned — all matching fields were already filled.\n" +
                        "Auto Fill only fills in empty fields.");
            }
            catch (Exception ex)
            {
                ToastForm.ShowError("Auto Fill failed.\n\n" + ex.Message);
            }
            finally
            {
                // ── 6. Restore button ─────────────────────────────────────────────
                btnAutoFill.Enabled = true;
                btnAutoFill.Text    = "✨ Auto Fill";
            }
        }
 
        /// <summary>
        /// Briefly highlights a control with a soft green to show it was auto-filled.
        /// </summary>
        private static void FlashGreen(Control control)
        {
            var original = control.BackColor;
            control.BackColor = Color.FromArgb(220, 252, 231);  // soft green
 
            var t = new System.Windows.Forms.Timer { Interval = 2500 };
            t.Tick += (_, _) =>
            {
                control.BackColor = original;
                t.Stop();
                t.Dispose();
            };
            t.Start();
        }
    }
}