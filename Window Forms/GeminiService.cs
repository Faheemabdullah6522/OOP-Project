using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Window_Forms
{
   
    public static class GeminiService
    {
      
        public static string ApiKey { get; set; } = "AQ.Ab8RN6La8rSruu4bR_jBQ-GNvnfaJjIfE18ySi07uCSOLH8jNg";

        private static readonly HttpClient _http = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(60)
        };

        private const string BaseUrl = "https://generativelanguage.googleapis.com/v1beta/models/";
        private const string Model = "gemini-2.5-flash-lite";   

        public static async Task<Dictionary<string, string>> ExtractProfileDataAsync(string filePath)
        {
            byte[] fileBytes = await File.ReadAllBytesAsync(filePath);
            string base64Data = Convert.ToBase64String(fileBytes);

            string ext = Path.GetExtension(filePath).ToLower();
            string mimeType = ext switch
            {
                ".pdf"          => "application/pdf",
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png"          => "image/png",
                _               => throw new NotSupportedException($"Unsupported file type: {ext}")
            };

            
            const string extractionPrompt = @"
You are a document OCR assistant for a Pakistani scholarship management system.
Analyze this document from BISE (Board of Intermediate & Secondary Education) Pakistan.

=== DOCUMENT TYPE ===

SSC (Matric / 10th Class):
  Keywords: 'SECONDARY SCHOOL CERTIFICATE', 'SSC', '10th'
  → Populate SSC fields

HSSC (Intermediate / 11th+12th Class):
  Keywords: 'INTERMEDIATE', 'HSSC', 'FIRST YEAR', 'SECOND YEAR', 'PART 1', 'PART 2'
  → Populate HSSC fields
- On CNIC cards: the address printed is for CNIC purposes only — extract Province and District 
  from it ONLY if no other document in the scan provides these fields
- 'Permanent Address' on CNIC → PermanentAddress (do not split into Province/District)

=== KEY FIELD LOCATIONS ===

- 'Roll No.' → SSCRollNo or HSSCRollNo
- 'Reg. No.' or 'Registration No.' → RegistrationNumber
- 'Name of Candidate' or 'Certified that' → FullName
- 'Son of' or 'Daughter of' → FatherName
- 'School / District' or 'Institute' → SSCInstitute or HSSCInstitute
- 'Date of birth' → DateOfBirth
- Summary line 'The candidate secured X/Y marks' → X is obtained marks, Y is total

=== MARKS & PERCENTAGE ===

From 'The candidate secured [OBTAINED]/[TOTAL] marks':
- SSCMarks or HSSCMarks = OBTAINED only (e.g. '1030/1100' → '1030')
- If percentage not printed, calculate: round((OBTAINED / TOTAL) * 100, 2)
  Example: 1030/1100 → 93.64
  Example: 958/1200 → 79.83

=== OUTPUT ===

Return ONLY a valid JSON object using EXACTLY these keys (omit keys not found):

{
  ""FullName"":           """",
  ""FatherName"":         """",
  ""CNIC"":               """",
  ""DateOfBirth"":        """",
  ""Gender"":             """",
  ""MobileNumber"":       """",
  ""Religion"":           """",
  ""PermanentAddress"":   """",
  ""MailingAddress"":     """",
  ""Province"":           """",
  ""District"":           """",
  ""DomicileDistrict"":   """",
  ""TownVillage"":        """",
  ""UniversityName"":     """",
  ""Department"":         """",
  ""DegreeProgram"":      """",
  ""RegistrationNumber"": """",
  ""RollNumber"":         """",
  ""SemesterYear"":       """",
  ""CGPA"":               """",
  ""FamilyIncome"":       """",
  ""SSCBoard"":           """",
  ""SSCRollNo"":          """",
  ""SSCYear"":            """",
  ""SSCMarks"":           """",
  ""SSCPercentage"":      """",
  ""SSCInstitute"":       """",
  ""HSSCBoard"":          """",
  ""HSSCRollNo"":         """",
  ""HSSCYear"":           """",
  ""HSSCMarks"":          """",
  ""HSSCPercentage"":     """",
  ""HSSCInstitute"":      """"
}

Formatting rules:
- CNIC: may appear on document as 12345-1234567-1 (with dashes) — extract it but store WITHOUT dashes as 13 digits only (e.g. '1234512345671'). Registration numbers like '243272-FR-2021' are NOT CNICs.
- DateOfBirth: dd/MM/yyyy
- SSCMarks / HSSCMarks: obtained marks only as plain integer string (e.g. '1030')
- SSCPercentage / HSSCPercentage: decimal, no % symbol (e.g. '93.64')
- SSCYear / HSSCYear: 4-digit year only (e.g. '2023')
- SSCRollNo / HSSCRollNo: exactly as printed on document
- SSCBoard / HSSCBoard: short form (e.g. 'BISE Faisalabad', 'Federal Board')
- SSCInstitute / HSSCInstitute: school/college name only, no address
- Return ONLY the JSON object, no explanations, no markdown backticks
- Province: only populate if you are confident it is a Pakistani province name 
  (Punjab, Sindh, KPK, Balochistan, AJK, GB, Islamabad) — never extract from school/board names
- District: the main administrative district (e.g. Faisalabad, Lahore, Multan).
  NEVER use a tehsil, taluka, union council, or village name here.
  Only populate if you are confident it is a top-level Pakistani district name.
  Never extract from school names, board names, or college addresses.
- DomicileDistrict: ONLY populate this from a Domicile Certificate document.
  A domicile certificate will have the words 'DOMICILE' or 'Certificate of Domicile' printed on it.
  Extract the district name printed on that certificate ONLY.
  This must be a district name, NOT a tehsil, town, or village name.
  If the document is NOT a domicile certificate, leave DomicileDistrict empty.
- TownVillage: use this for tehsil, taluka, town, union council, or village names.
  Never put a tehsil or town name into District or DomicileDistrict.
";

            var requestBody = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new object[]
                        {
                            new { text = extractionPrompt },
                            new
                            {
                                inline_data = new
                                {
                                    mime_type = mimeType,
                                    data      = base64Data
                                }
                            }
                        }
                    }
                },
                generationConfig = new
                {
                    temperature    = 0.1,  
                    maxOutputTokens = 1024
                }
            };

            string rawJson   = JsonSerializer.Serialize(requestBody);
            var    content   = new StringContent(rawJson, Encoding.UTF8, "application/json");
            string url       = $"{BaseUrl}{Model}:generateContent?key={ApiKey}";

            HttpResponseMessage response = await _http.PostAsync(url, content);
            string responseBody = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException($"Gemini API error ({response.StatusCode}):\n{responseBody}");

            string? text = ParseGeminiText(responseBody);
            if (string.IsNullOrWhiteSpace(text))
                return new Dictionary<string, string>();

          
            text = StripCodeFences(text);

            try
            {
                var raw = JsonSerializer.Deserialize<Dictionary<string, string>>(text)
                          ?? new Dictionary<string, string>();

                // Return only non-empty values
                return raw
                    .Where(kv => !string.IsNullOrWhiteSpace(kv.Value))
                    .ToDictionary(kv => kv.Key, kv => kv.Value.Trim());
            }
            catch (JsonException)
            {
                // Model returned something non-JSON; return empty so caller can handle gracefully
                return new Dictionary<string, string>();
            }
        }

        public static async Task<string> ChatAsync(
            List<(string role, string text)> history,
            string systemPrompt)
        {
            var contents = history
                .Select(m => new
                {
                    role  = m.role,
                    parts = new[] { new { text = m.text } }
                })
                .ToArray();

            var requestBody = new
            {
                system_instruction = new
                {
                    parts = new[] { new { text = systemPrompt } }
                },
                contents,
                generationConfig = new
                {
                    temperature     = 0.5,
                    maxOutputTokens = 600
                }
            };

            string rawJson  = JsonSerializer.Serialize(requestBody);
            var    content  = new StringContent(rawJson, Encoding.UTF8, "application/json");
            string url      = $"{BaseUrl}{Model}:generateContent?key={ApiKey}";

            try
            {
                HttpResponseMessage response = await _http.PostAsync(url, content);
                string responseBody = await response.Content.ReadAsStringAsync();

                if ((int)response.StatusCode == 429)
                    return "⚠️ The AI service is temporarily busy. Please wait a moment and try again.";

                if (!response.IsSuccessStatusCode)
                    return $"API Error {response.StatusCode}: {responseBody}";

                return ParseGeminiText(responseBody)
                       ?? "I couldn't generate a response. Please try again.";
            }
            catch (Exception ex)
            {
                return $"Connection error: {ex.Message}";
            }
        }

        private static string? ParseGeminiText(string responseBody)
        {
            try
            {
                var doc = JsonNode.Parse(responseBody);
                return doc?["candidates"]?[0]?["content"]?["parts"]?[0]?["text"]?.GetValue<string>();
            }
            catch
            {
                return null;
            }
        }

        private static string StripCodeFences(string text)
        {
            text = text.Trim();
            if (!text.StartsWith("```")) return text;

            int firstNewline = text.IndexOf('\n');
            if (firstNewline >= 0) text = text[(firstNewline + 1)..];
            if (text.EndsWith("```")) text = text[..^3];
            return text.Trim();
        }
    }
}
