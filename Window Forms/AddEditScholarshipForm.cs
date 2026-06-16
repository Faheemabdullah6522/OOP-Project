using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Window_Forms
{
    public partial class AddEditScholarshipForm : Form
    {
        private readonly int? editId;

        public AddEditScholarshipForm(int? id = null)
        {
            InitializeComponent();

            // 1. Max-Length Constraints (Adjust values to match your exact DB schema)
            txtTitle.MaxLength = 100;
            txtDesc.MaxLength = 1000;
            txtEligibility.MaxLength = 1000;
            txtRequiredDocs.MaxLength = 500;
            txtDegreeProgram.MaxLength = 100;
            txtSemesterYear.MaxLength = 50;

            editId = id;

            if (id.HasValue)
                LoadScholarshipData(id.Value);
            chkNeedBased.CheckedChanged += ChkNeedBased_CheckedChanged;
        }

        private void LoadScholarshipData(int id)
        {
            try
            {
                DataTable dt = Database.QueryProc("sp_GetScholarshipById", new SqlParameter("@Id", id));
                if (dt.Rows.Count == 0)
                    return;
                DataRow row = dt.Rows[0];

                txtTitle.Text = row["Title"].ToString();
                txtDesc.Text = row["Description"].ToString();
                txtEligibility.Text = row["Eligibility"].ToString();
                txtAmount.Text = row["Amount"].ToString();

                if (row["Deadline"] != DBNull.Value)
                    dtpDeadline.Value = Convert.ToDateTime(row["Deadline"]);

                chkActive.Checked = row["IsActive"] != DBNull.Value && Convert.ToBoolean(row["IsActive"]);
                txtRequiredDocs.Text = row["RequiredDocuments"].ToString();
                txtMinCgpa.Text = row["MinimumCGPA"] == DBNull.Value ? string.Empty : row["MinimumCGPA"].ToString();
                txtMaxIncome.Text = row["MaxFamilyIncome"] == DBNull.Value ? string.Empty : row["MaxFamilyIncome"].ToString();
                txtDegreeProgram.Text = row["DegreeProgram"].ToString();
                txtSemesterYear.Text = row["SemesterYear"].ToString();
                chkNeedBased.Checked = row["NeedBased"] != DBNull.Value && Convert.ToBoolean(row["NeedBased"]);
            }
            catch (Exception ex)
            {
                ToastForm.ShowError("Scholarship could not be loaded.\n\n" + ex.Message);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // --- VALIDATIONS ---

            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                ToastForm.ShowWarning("Title is required.");
                return;
            }

            if (!TryReadDecimal(txtAmount.Text, "Amount", out decimal amount)) return;

            // Range check: Amount
            if (amount <= 0)
            {
                ToastForm.ShowWarning("Amount must be greater than zero.");
                return;
            }

            if (!TryReadNullableDecimal(txtMinCgpa.Text, "Minimum CGPA", out decimal? minCgpa)) return;

            // Range check: CGPA
            if (minCgpa.HasValue && (minCgpa.Value < 0m || minCgpa.Value > 4.0m))
            {
                ToastForm.ShowWarning("CGPA must be between 0.0 and 4.0.");
                return;
            }

            if (!TryReadNullableDecimal(txtMaxIncome.Text, "Max family income", out decimal? maxIncome)) return;

            // Range check: Income
            if (maxIncome.HasValue && maxIncome.Value < 0)
            {
                ToastForm.ShowWarning("Family Income cannot be negative.");
                return;
            }

            // Date validation for NEW scholarships
            if (!editId.HasValue && dtpDeadline.Value.Date < DateTime.Today)
            {
                ToastForm.ShowWarning("New scholarships cannot have a deadline in the past.");
                return;
            }

            // --- DATABASE SAVE ---

            try
            {
                string query;
                if (editId.HasValue)
                {
                    query = @"
                        UPDATE Scholarships
                        SET Title = @title,
                            Description = @desc,
                            Eligibility = @elig,
                            Amount = @amount,
                            Deadline = @deadline,
                            IsActive = @active,
                            RequiredDocuments = @reqDocs,
                            MinimumCGPA = @minCgpa,
                            MaxFamilyIncome = @maxIncome,
                            DegreeProgram = @degreeProgram,
                            SemesterYear = @semesterYear,
                            NeedBased = @needBased
                        WHERE Id = @id";
                }
                else
                {
                    query = @"
                        INSERT INTO Scholarships
                            (Title, Description, Eligibility, Amount, Deadline, IsActive, RequiredDocuments, MinimumCGPA, MaxFamilyIncome, DegreeProgram, SemesterYear, NeedBased)
                        VALUES
                            (@title, @desc, @elig, @amount, @deadline, @active, @reqDocs, @minCgpa, @maxIncome, @degreeProgram, @semesterYear, @needBased)";
                }

                using SqlConnection conn = Database.GetConnection();
                conn.Open();
                using SqlCommand cmd = new SqlCommand(query, conn);

                if (editId.HasValue)
                    cmd.Parameters.AddWithValue("@id", editId.Value);

                cmd.Parameters.AddWithValue("@title", txtTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@desc", Database.ValueOrDbNull(txtDesc.Text.Trim()));
                cmd.Parameters.AddWithValue("@elig", Database.ValueOrDbNull(txtEligibility.Text.Trim()));
                cmd.Parameters.AddWithValue("@amount", amount);
                cmd.Parameters.AddWithValue("@deadline", dtpDeadline.Value.Date);
                cmd.Parameters.AddWithValue("@active", chkActive.Checked);
                cmd.Parameters.AddWithValue("@reqDocs", Database.ValueOrDbNull(txtRequiredDocs.Text.Trim()));

                // Safely apply nullable decimals to SQL parameters
                cmd.Parameters.AddWithValue("@minCgpa", minCgpa.HasValue ? (object)minCgpa.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@maxIncome", maxIncome.HasValue ? (object)maxIncome.Value : DBNull.Value);

                cmd.Parameters.AddWithValue("@degreeProgram", Database.ValueOrDbNull(txtDegreeProgram.Text.Trim()));
                cmd.Parameters.AddWithValue("@semesterYear", Database.ValueOrDbNull(txtSemesterYear.Text.Trim()));
                cmd.Parameters.AddWithValue("@needBased", chkNeedBased.Checked);

                cmd.ExecuteNonQuery();

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                ToastForm.ShowError("Scholarship could not be saved.\n\n" + ex.Message);
            }
        }

        private static bool TryReadDecimal(string text, string label, out decimal value)
        {
            if (decimal.TryParse(text, out value))
                return true;

            ToastForm.ShowWarning(label + " must be a number.");
            return false;
        }

        // Refactored to return C# native Nullable type (decimal?) instead of object
        private static bool TryReadNullableDecimal(string text, string label, out decimal? value)
        {
            value = null;
            if (string.IsNullOrWhiteSpace(text))
            {
                return true;
            }

            if (decimal.TryParse(text, out decimal parsed))
            {
                value = parsed;
                return true;
            }

            ToastForm.ShowWarning(label + " must be a number.");
            return false;
        }

        private void BtnCancel_Click(object? sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void ChkNeedBased_CheckedChanged(object? sender, EventArgs e)
        {
            const string slipDoc = "Income/Salary Proof";
            var docs = txtRequiredDocs.Text
                .Split(',')
                .Select(d => d.Trim())
                .Where(d => !string.IsNullOrEmpty(d))
                .ToList();

            if (chkNeedBased.Checked)
            {
                if (!docs.Any(d => d.Equals(slipDoc, StringComparison.OrdinalIgnoreCase)))
                {
                    docs.Add(slipDoc);
                    txtRequiredDocs.Text = string.Join(",", docs);
                }
            }
            else
            {
                docs.RemoveAll(d => d.Equals(slipDoc, StringComparison.OrdinalIgnoreCase));
                txtRequiredDocs.Text = string.Join(",", docs);
            }
        }
    }
}