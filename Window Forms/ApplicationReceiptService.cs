using Microsoft.Data.SqlClient;
using QRCoder;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Data;
using System.Globalization;
using System.Text;

namespace Window_Forms
{
    public static class ApplicationReceiptService
    {
        public static void SaveReceipt(int applicationId, string filePath)
        {
            DataTable table = Database.QueryProc("sp_GetReceiptData",
                new SqlParameter("@ApplicationId", applicationId));

            if (table.Rows.Count == 0)
                throw new InvalidOperationException("Application was not found.");

            DataRow row = table.Rows[0];

            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(45);
                    page.MarginTop(10);
                    page.DefaultTextStyle(x => x.FontSize(10).FontFamily("Segoe UI"));

                    page.Header().Column(col =>
                    {
                        col.Item().AlignCenter().Column(inner =>
                        {
                            // logo
                            try
                            {
                                var resourceManager = new System.ComponentModel.ComponentResourceManager(typeof(Login));
                                var logoImage = resourceManager.GetObject("pictureBox3.Image") as System.Drawing.Image;
                                if (logoImage != null)
                                {
                                    using var ms = new MemoryStream();
                                    logoImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                                    byte[] logoBytes = ms.ToArray();
                                    inner.Item().PaddingTop(0).PaddingRight(3).Height(70).AlignCenter()
    .Image(logoBytes, ImageScaling.FitHeight);
                                    inner.Item().PaddingBottom(4);
                                }
                            }
                            catch { }

                            inner.Item().PaddingTop(-8).DefaultTextStyle(x => x.FontSize(18).Bold().FontColor(Colors.Blue.Darken3))
    .AlignCenter().Text("QuasarEdu");

                            inner.Item().PaddingTop(0).DefaultTextStyle(x => x.FontSize(13).Bold())
                                .AlignCenter().Text("OFFICIAL APPLICATION RECEIPT");
                        });

                        // Line is OUTSIDE the AlignCenter so it spans full width
                        col.Item().PaddingTop(4).LineHorizontal(1).LineColor(Colors.Black);
                    });

                    page.Content().PaddingVertical(12).Column(col =>
                    {
                        col.Item().Row(r =>
                        {
                            r.RelativeItem().Text(text =>
                            {
                                text.Span("Receipt No: ").SemiBold();
                                text.Span("APP-" + Read(row, "ApplicationId"));
                            });

                            r.RelativeItem().AlignRight().Text(text =>
                            {
                                text.Span("Date: ").SemiBold();
                                text.Span(DateTime.Now.ToString("dd MMMM yyyy hh:mm tt"));
                            });
                        });

                        col.Item().PaddingTop(4).Row(r =>
                        {
                            r.RelativeItem().Text(text =>
                            {
                                text.Span("Status: ").SemiBold();
                                text.Span(Read(row, "Status").ToUpper());
                            });
                        });

                        col.Item().PaddingTop(10).DefaultTextStyle(x => x.FontSize(11).Bold())
                            .Text("STUDENT INFORMATION").FontColor(Colors.Blue.Darken3);

                        col.Item().PaddingLeft(8).Table(tableDescriptor =>
                        {
                            tableDescriptor.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(140);
                                columns.RelativeColumn();
                            });

                            AddDetailRow(tableDescriptor, "Full Name", Read(row, "FullName"));
                            AddDetailRow(tableDescriptor, "Father Name", Read(row, "FatherName"));
                            AddDetailRow(tableDescriptor, "CNIC", Read(row, "CNIC"));
                            AddDetailRow(tableDescriptor, "Date of Birth", FormatDate(row, "DateOfBirth"));
                            AddDetailRow(tableDescriptor, "Mobile Number", Read(row, "MobileNumber"));
                            AddDetailRow(tableDescriptor, "Email", Read(row, "UserEmail"));
                            AddDetailRow(tableDescriptor, "Department", Read(row, "Department"));
                            AddDetailRow(tableDescriptor, "Degree Program", Read(row, "DegreeProgram"));
                            AddDetailRow(tableDescriptor, "Semester / Year", Read(row, "SemesterYear"));
                            AddDetailRow(tableDescriptor, "CGPA", Read(row, "CGPA"));
                            AddDetailRow(tableDescriptor, "Family Income", Read(row, "FamilyIncome"));
                            AddDetailRow(tableDescriptor, "Province", Read(row, "Province"));
                            AddDetailRow(tableDescriptor, "District", Read(row, "District"));
                            string disability = Read(row, "DisabilityStatus");
                            if (!string.IsNullOrWhiteSpace(disability))
                                AddDetailRow(tableDescriptor, "Disability Status", disability);
                            if (!string.IsNullOrWhiteSpace(Read(row, "MailingAddress")))
                                AddDetailRow(tableDescriptor, "Mailing Address", Read(row, "MailingAddress"));
                            if (!string.IsNullOrWhiteSpace(Read(row, "PermanentAddress")))
                                AddDetailRow(tableDescriptor, "Permanent Address", Read(row, "PermanentAddress"));
                        });

                        col.Item().PaddingTop(10).DefaultTextStyle(x => x.FontSize(11).Bold())
                            .Text("SCHOLARSHIP DETAILS").FontColor(Colors.Blue.Darken3);

                        col.Item().PaddingLeft(8).Table(tableDescriptor =>
                        {
                            tableDescriptor.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(140);
                                columns.RelativeColumn();
                            });

                            AddDetailRow(tableDescriptor, "Scholarship", Read(row, "Title"));
                            AddDetailRow(tableDescriptor, "Amount", FormatCurrency(row, "Amount"));
                            AddDetailRow(tableDescriptor, "Deadline", FormatDate(row, "Deadline"));
                            AddDetailRow(tableDescriptor, "Minimum CGPA", Read(row, "MinimumCGPA"));
                            AddDetailRow(tableDescriptor, "Max Family Income", Read(row, "MaxFamilyIncome"));
                            AddDetailRow(tableDescriptor, "Need Based", FormatBool(row, "NeedBased"));
                        });

                        col.Item().PaddingTop(10).DefaultTextStyle(x => x.FontSize(11).Bold())
                            .Text("APPLICATION STATUS").FontColor(Colors.Blue.Darken3);

                        col.Item().PaddingLeft(8).Table(tableDescriptor =>
                        {
                            tableDescriptor.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(140);
                                columns.RelativeColumn();
                            });

                            AddDetailRow(tableDescriptor, "Applied Date", FormatDateTime(row, "AppliedDate"));
                            AddDetailRow(tableDescriptor, "Review Date", FormatDateTime(row, "ReviewDate"));

                            string statusColor = Read(row, "Status").ToLower() == "approved"
                                ? Colors.Green.Darken2 : Colors.Red.Darken2;

                            tableDescriptor.Cell().Padding(2).Text("Final Status").SemiBold();
                            tableDescriptor.Cell().Padding(2).DefaultTextStyle(x => x.FontColor(statusColor).SemiBold())
                                .Text(Read(row, "Status").ToUpper());
                        });

                        col.Item().PaddingTop(10).DefaultTextStyle(x => x.FontSize(11).Bold())
                            .Text("ADMIN REMARKS").FontColor(Colors.Blue.Darken3);

                        col.Item().PaddingLeft(8).Text(string.IsNullOrWhiteSpace(Read(row, "Comments"))
                            ? "No remarks provided."
                            : Read(row, "Comments"));
                        // ── IDENTITY VERIFICATION SECTION ─────────────────────
                        col.Item().PaddingTop(10).DefaultTextStyle(x => x.FontSize(11).Bold())
                            .Text("IDENTITY VERIFICATION").FontColor(Colors.Blue.Darken3);

                        string studentEmail = Read(row, "UserEmail");

                        DataTable idDocs = new DataTable();
                        try
                        {
                            idDocs = Database.QueryProc("sp_GetVerificationDocuments",
                                new SqlParameter("@UserEmail", studentEmail));
                        }
                        catch { }

                        if (idDocs.Rows.Count > 0)
                        {
                            col.Item().PaddingLeft(8)
                                .DefaultTextStyle(x => x.FontColor(Colors.Green.Darken2).SemiBold())
                                .Text("✔ Identity Verified — " + idDocs.Rows.Count + " document(s) on file.");

                            foreach (DataRow docRow in idDocs.Rows)
                            {
                                string docType = docRow["DocumentType"]?.ToString() ?? "";
                                string fileName = docRow["FileName"]?.ToString() ?? "";
                                string filePath = docRow["FilePath"]?.ToString() ?? "";
                                string ext = System.IO.Path.GetExtension(filePath).ToLower();

                                // ── Document label ──
                                col.Item()
                                    .PaddingTop(8).PaddingLeft(8)
                                    .DefaultTextStyle(x => x.FontSize(10).SemiBold().FontColor(Colors.Blue.Darken2))
                                    .Text(docType);

                                col.Item()
                                    .PaddingLeft(8)
                                    .DefaultTextStyle(x => x.FontSize(9).FontColor(Colors.Grey.Darken2))
                                    .Text("File: " + fileName);

                                // ── Embed photo if image ──
                                if (System.IO.File.Exists(filePath) &&
                                    (ext == ".jpg" || ext == ".jpeg" || ext == ".png"))
                                {
                                    try
                                    {
                                        byte[] imgBytes = System.IO.File.ReadAllBytes(filePath);
                                        col.Item()
                                            .PaddingTop(4).PaddingLeft(8)
                                            .Width(160).Height(160)
                                            .Image(imgBytes, ImageScaling.FitArea);
                                    }
                                    catch
                                    {
                                        col.Item().PaddingLeft(8)
                                            .DefaultTextStyle(x => x.FontSize(9).Italic().FontColor(Colors.Grey.Darken1))
                                            .Text("(Image could not be embedded.)");
                                    }
                                }
                                else if (System.IO.File.Exists(filePath) && ext == ".pdf")
                                {
                                    col.Item().PaddingLeft(8)
                                        .DefaultTextStyle(x => x.FontSize(9).Italic().FontColor(Colors.Grey.Darken1))
                                        .Text("PDF document — see Documents section for full view.");
                                }
                                else if (ext == ".bin")
                                {
                                    // Biometric / PIN credential — no photo to show
                                    col.Item().PaddingLeft(8)
                                        .DefaultTextStyle(x => x.FontSize(9).Italic().FontColor(Colors.Grey.Darken1))
                                        .Text("Verified via device credential (no photo).");
                                }
                                else
                                {
                                    col.Item().PaddingLeft(8)
                                        .DefaultTextStyle(x => x.FontSize(9).Italic().FontColor(Colors.Orange.Medium))
                                        .Text("⚠ File could not be located on disk.");
                                }
                            }
                        }
                        else
                        {
                            col.Item().PaddingLeft(8)
                                .DefaultTextStyle(x => x.FontColor(Colors.Red.Darken2).SemiBold())
                                .Text("⚠ Identity not verified. This application is likely to be rejected.");
                        }
                        // ── END IDENTITY VERIFICATION SECTION ─────────────────

                    });

                    page.Footer().Column(col =>
                    {
                        col.Item().LineHorizontal(1).LineColor(Colors.Grey.Medium);
                        col.Item().PaddingTop(6).Row(r =>
                        {
                            r.ConstantItem(80).Column(qrCol =>
                            {
                                byte[] qrBytes = GenerateQrCode(row);
                                qrCol.Item().Width(72).Height(72).Image(qrBytes, ImageScaling.FitArea);
                                qrCol.Item().DefaultTextStyle(x => x.FontSize(7).Italic().FontColor(Colors.Grey.Darken1))
                                    .AlignCenter().Text("Scan to verify");
                            });
                            r.RelativeItem().PaddingLeft(10).PaddingTop(12).Column(txtCol =>
                            {
                                txtCol.Item().DefaultTextStyle(x => x.FontSize(8).Italic().FontColor(Colors.Grey.Darken1))
                                    .Text("This is a computerized generated receipt. No signature required.");
                                txtCol.Item().PaddingTop(4).DefaultTextStyle(x => x.FontSize(8).Italic().FontColor(Colors.Grey.Darken1))
                                    .Text("QuasarEdu By Project QuasarX");
                            });
                        });
                    });
                });
            }).GeneratePdf(filePath);
        }

        private static void AddDetailRow(TableDescriptor table, string label, string value)
        {
            table.Cell().Padding(2).Text(label).SemiBold();
            table.Cell().Padding(2).Text(value);
        }

        private static string Read(DataRow row, string column)
        {
            return row.Table.Columns.Contains(column) && row[column] != DBNull.Value
                ? row[column]?.ToString() ?? string.Empty
                : string.Empty;
        }

        private static string FormatDate(DataRow row, string column)
        {
            return row.Table.Columns.Contains(column) && row[column] != DBNull.Value
                ? Convert.ToDateTime(row[column]).ToString("dd MMM yyyy", CultureInfo.CurrentCulture)
                : string.Empty;
        }

        private static string FormatDateTime(DataRow row, string column)
        {
            return row.Table.Columns.Contains(column) && row[column] != DBNull.Value
                ? Convert.ToDateTime(row[column]).ToString("dd MMM yyyy hh:mm tt", CultureInfo.CurrentCulture)
                : string.Empty;
        }

        private static string FormatBool(DataRow row, string column)
        {
            return row.Table.Columns.Contains(column) && row[column] != DBNull.Value && Convert.ToBoolean(row[column])
                ? "YES"
                : "No";
        }

        private static string FormatCurrency(DataRow row, string column)
        {
            if (row.Table.Columns.Contains(column) == false || row[column] == DBNull.Value)
            {
                return string.Empty;
            }

            decimal value = Convert.ToDecimal(row[column]);

            return value.ToString("C", CultureInfo.CurrentCulture);
        }

        private static byte[] GenerateQrCode(DataRow row)
        {
            // Encode a URL — phone camera opens it directly in the browser
            string appId = Read(row, "ApplicationId");
            string content = $"{Utils.FingerprintServerBaseUrl}/receipt?id=APP-{appId}";

            using var generator = new QRCodeGenerator();
            using var data = generator.CreateQrCode(content, QRCodeGenerator.ECCLevel.M);
            using var code = new PngByteQRCode(data);
            return code.GetGraphic(6);
        }
    }
}