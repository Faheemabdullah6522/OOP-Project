namespace Window_Forms
{
  
    public class DocumentExtractorService
    {
        private readonly Dictionary<string, Control> _fields;
        private readonly Action<string>? _onStatus;  

    
        public DocumentExtractorService(
            Dictionary<string, Control> profileFields,
            Action<string>? statusCallback = null)
        {
            _fields   = profileFields;
            _onStatus = statusCallback;
        }

        public async Task<int> ScanAndFillAsync(string filePath, string documentType)
        {
            _onStatus?.Invoke("🔍 Scanning document with AI...");

            Dictionary<string, string> extracted;

            try
            {
                extracted = await GeminiService.ExtractProfileDataAsync(filePath);
            }
            catch (Exception ex)
            {
                _onStatus?.Invoke("⚠️ Scan failed.");
                throw new Exception($"Document scan failed: {ex.Message}", ex);
            }

            if (extracted.Count == 0)
            {
                _onStatus?.Invoke("ℹ️ No data could be extracted.");
                return 0;
            }

            // Fields to prioritise based on document type
            var priorityFields = GetPriorityFields(documentType);

            int filled = 0;

            // Fill on the UI thread
            if (_fields.Values.FirstOrDefault()?.InvokeRequired == true)
            {
                _fields.Values.First().Invoke(() => filled = FillFields(extracted, priorityFields));
            }
            else
            {
                filled = FillFields(extracted, priorityFields);
            }

            _onStatus?.Invoke(filled > 0
                ? $"✅ {filled} field(s) auto-filled from document."
                : "ℹ️ Document scanned — no matching fields found.");

            return filled;
        }

      
        private int FillFields(
            Dictionary<string, string> extracted,
            HashSet<string>? priorityFields)
        {
            int count = 0;

            // Build the ordered set: priority fields first, then the rest
            IEnumerable<string> orderedKeys = priorityFields != null
                ? priorityFields.Concat(extracted.Keys.Except(priorityFields))
                : extracted.Keys;

            foreach (string key in orderedKeys)
            {
                if (!extracted.TryGetValue(key, out string? value)) continue;
                if (!_fields.TryGetValue(key, out Control? control))  continue;

                string cleaned = value.Trim();
                if (string.IsNullOrEmpty(cleaned)) continue;

                switch (control)
                {
                    case TextBox tb:
                        // Only fill if empty
                        if (string.IsNullOrWhiteSpace(tb.Text))
                        {
                            tb.Text = cleaned;
                            HighlightControl(tb);
                            count++;
                        }
                        break;

                    case ComboBox cb:
                        if (string.IsNullOrWhiteSpace(cb.Text))
                        {
                            // Try exact match first
                            int idx = cb.FindStringExact(cleaned);
                            if (idx >= 0)
                            {
                                cb.SelectedIndex = idx;
                                HighlightControl(cb);
                                count++;
                            }
                            else
                            {
                                // Case-insensitive partial match
                                for (int i = 0; i < cb.Items.Count; i++)
                                {
                                    if (cb.Items[i]?.ToString()?.Equals(cleaned,
                                        StringComparison.OrdinalIgnoreCase) == true)
                                    {
                                        cb.SelectedIndex = i;
                                        HighlightControl(cb);
                                        count++;
                                        break;
                                    }
                                }
                            }
                        }
                        break;

                    case DateTimePicker dtp:
                        // Only fill if at default/min value
                        if (dtp.Value == dtp.MinDate || dtp.Value.Date == DateTime.Today)
                        {
                            if (DateTime.TryParseExact(cleaned, "dd/MM/yyyy",
                                System.Globalization.CultureInfo.InvariantCulture,
                                System.Globalization.DateTimeStyles.None, out DateTime dt))
                            {
                                dtp.Value = dt;
                                count++;
                            }
                            else if (DateTime.TryParse(cleaned, out DateTime dt2))
                            {
                                dtp.Value = dt2;
                                count++;
                            }
                        }
                        break;

                
                }
            }

            return count;
        }

     
        private static void HighlightControl(Control control)
        {
            Color originalColor = control.BackColor;
            control.BackColor = Color.FromArgb(220, 252, 231);  // soft green

            var timer = new System.Windows.Forms.Timer { Interval = 2500 };
            timer.Tick += (_, _) =>
            {
                control.BackColor = originalColor;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private static HashSet<string>? GetPriorityFields(string documentType)
        {
            return documentType.ToLower() switch
            {
                var d when d.Contains("cnic") || d.Contains("national") => new HashSet<string>
                {
                    "FullName", "FatherName", "CNIC", "DateOfBirth",
                    "Gender", "PermanentAddress", "District", "Province"
                },

                var d when d.Contains("transcript") || d.Contains("result") || d.Contains("mark") => new HashSet<string>
                {
                    "UniversityName", "Department", "DegreeProgram",
                    "RegistrationNumber", "RollNumber", "CGPA", "SemesterYear",
                    "SSCBoard", "SSCRollNo", "SSCYear", "SSCMarks", "SSCPercentage", "SSCInstitute",
                    "HSSCBoard", "HSSCRollNo", "HSSCYear", "HSSCMarks", "HSSCPercentage", "HSSCInstitute"
                },

                var d when d.Contains("domicile") => new HashSet<string>
                {
                    "FullName", "FatherName", "Province", "District",
                    "DomicileDistrict", "TownVillage", "PermanentAddress"
                },

                var d when d.Contains("income") || d.Contains("salary") => new HashSet<string>
                {
                    "FullName", "FatherName", "FamilyIncome"
                },

                var d when d.Contains("degree") || d.Contains("certificate") => new HashSet<string>
                {
                    "FullName", "FatherName", "UniversityName", "Department",
                    "DegreeProgram", "RegistrationNumber"
                },

                _ => null 
            };
        }
    }
}
