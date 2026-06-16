using System;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace Window_Forms
{
    public partial class AllDocumentsForm : Form
    {
        // Made readonly since it shouldn't change after the form opens
        private readonly string? _email;

        public AllDocumentsForm(string? email = null)
        {
            InitializeComponent();
            _email = email;

            if (!string.IsNullOrWhiteSpace(_email))
            {
                lblHeaderTitle.Text = $"Documents - {_email}";
            }
        }

        private void AllDocumentsForm_Load(object sender, EventArgs e)
        {
            try
            {
                // UI SAFETY: Lock down the data grid
                dgvDocuments.ReadOnly = true;
                dgvDocuments.AllowUserToAddRows = false;
                dgvDocuments.AllowUserToDeleteRows = false;
                dgvDocuments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvDocuments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                DataTable dt;

                if (string.IsNullOrWhiteSpace(_email))
                {
                    dt = Database.QueryProc("sp_GetAllDocuments");
                }
                else
                {
                    dt = Database.QueryProc("sp_GetAllDocuments",
                        new SqlParameter("@UserEmail", _email));
                }

                dgvDocuments.DataSource = dt;

                // Hide system columns
                if (dgvDocuments.Columns["FilePath"] is DataGridViewColumn filePathColumn)
                    filePathColumn.Visible = false;

                if (dgvDocuments.Columns["Id"] is DataGridViewColumn idColumn)
                    idColumn.Visible = false;

                // Optionally, hide the "Student" column if they are viewing their own documents
                if (!string.IsNullOrWhiteSpace(_email) && dgvDocuments.Columns["Student"] is DataGridViewColumn studentCol)
                    studentCol.Visible = false;

                if (dgvDocuments.Columns["UploadDate"] is DataGridViewColumn uploadDateColumn)
                {
                    uploadDateColumn.HeaderText = "Upload Date";
                    uploadDateColumn.DefaultCellStyle.Format = "dd MMM yyyy";   // ← add
                }

                // Format headers for better readability
                FormatColumnHeader("DocumentType", "Document Type");
                FormatColumnHeader("FileName", "File Name");
                FormatColumnHeader("UploadDate", "Upload Date");
            }
            catch (Exception ex)
            {
                ToastForm.ShowError("Documents could not be loaded.\n\n" + ex.Message);
                this.Close();
            }
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            string? filePath = GetSelectedFilePath();

            if (!string.IsNullOrWhiteSpace(filePath))
            {
                // FIX: Check if file actually exists on the disk
                if (!File.Exists(filePath))
                {
                    ToastForm.ShowError("File not found. It may have been moved or deleted.");
                    return;
                }

                DocumentPrintService.OpenDocument(filePath);
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            string? filePath = GetSelectedFilePath();

            if (!string.IsNullOrWhiteSpace(filePath))
            {
                // FIX: Check if file actually exists on the disk
                if (!File.Exists(filePath))
                {
                    ToastForm.ShowError("File not found. It may have been moved or deleted.");
                    return;
                }

                DocumentPrintService.PrintDocument(filePath);
            }
        }

        // FIX: Signature updated to string? to accurately reflect it can return null
        private string? GetSelectedFilePath()
        {
            if (dgvDocuments.SelectedRows.Count == 0)
            {
                ToastForm.ShowInfo("Select a document first.");
                return null;
            }

            return dgvDocuments.SelectedRows[0].Cells["FilePath"].Value?.ToString();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Helper method to make column headers look professional
        private void FormatColumnHeader(string columnName, string headerText)
        {
            if (dgvDocuments.Columns[columnName] is DataGridViewColumn col)
            {
                col.HeaderText = headerText;
            }
        }
    }
}