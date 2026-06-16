using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;

namespace Window_Forms
{
    public static class Utils
    {
        public static string FingerprintServerBaseUrl { get; set; } = "https://milwaukee-waiting-sphere-studying.trycloudflare.com";

        public static string? MakeSafeFilePart(string? value)
        {
            if (value == null) return null;

            char[] invalidChars = Path.GetInvalidFileNameChars();
            char[] result = new char[value.Length];

            for (int i = 0; i < value.Length; i++)
            {
                char ch = value[i];
                bool isInvalid = false;
                for (int j = 0; j < invalidChars.Length; j++)
                    if (ch == invalidChars[j]) { isInvalid = true; break; }
                result[i] = isInvalid ? '_' : ch;
            }
            return new string(result);
        }

        public static string GenerateOtp()
        {
            var bytes = new byte[4];
            RandomNumberGenerator.Fill(bytes);
            int value = BitConverter.ToInt32(bytes, 0) & 0x7FFFFFFF;
            return (value % 900000 + 100000).ToString();
        }

        public static string GenerateFingerprintVerificationToken()
        {
            // 32 random bytes → 64-char hex string (URL-safe, no padding issues)
            var bytes = new byte[32];
            RandomNumberGenerator.Fill(bytes);
            return Convert.ToHexString(bytes).ToLowerInvariant();
        }

        public static void SendApplicationStatusEmail(
    string studentEmail, string studentName, string scholarshipTitle,
    string status, string comments = "", bool isNeedBased = false)
        {
            string statusColor = status.ToLower() == "approved" ? "#28a745" : "#dc3545";
            string statusEmoji = status.ToLower() == "approved" ? "✅" : "❌";

            var message = new MailMessage();
            message.From = new MailAddress("noreplyquasaredu@gmail.com");
            message.To.Add(studentEmail);
            message.Subject = $"Application {status} - {scholarshipTitle}";

            string body = $@"
<html>
<head>
    <style>
        body {{ font-family: 'Segoe UI', Arial, sans-serif; background-color: #f8f9fa; margin: 0; padding: 20px; }}
        .container {{ max-width: 600px; margin: 0 auto; background: white; border-radius: 12px; overflow: hidden; box-shadow: 0 4px 15px rgba(0,0,0,0.1); }}
        .header {{ background: linear-gradient(135deg, #06a494, #00f0ff); color: white; padding: 30px 20px; text-align: center; }}
        .content {{ padding: 30px 25px; line-height: 1.6; color: #333; }}
        .status {{ font-size: 28px; font-weight: bold; color: {statusColor}; margin: 15px 0; }}
        .details {{ background: #f8f9fa; padding: 15px; border-radius: 8px; margin: 20px 0; }}
        .footer {{ background: #f1f3f5; padding: 20px; text-align: center; font-size: 14px; color: #666; }}
        hr {{ border: none; border-top: 1px solid #eee; margin: 25px 0; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>QuasarEdu By Project QuasarX</h1>
            <p style='margin: 10px 0 0 0; opacity: 0.9;'>Application Status Update</p>
        </div>
        <div class='content'>
            <h2>Dear {studentName},</h2>
            <p>Your Scholarship Application has been reviewed.</p>
            <div style='text-align: center;'>
                <div class='status'>{statusEmoji} {status}</div>
            </div>
            <div class='details'>
                <strong>Scholarship:</strong> {scholarshipTitle}<br><br>
                <strong>Status:</strong> <span style='color:{statusColor}; font-weight:bold;'>{status}</span>
            </div>
            {(string.IsNullOrWhiteSpace(comments) ? "" : $@"
            <div class='details'>
                <strong>Admin Comments / Reason:</strong><br>
                <p style='margin: 10px 0; color: #444;'>{comments}</p>
            </div>")}
            <hr>
            {(status.ToLower() == "approved"
                        ? (isNeedBased
                            ? @"<p>Congratulations! Your application has been approved.</p>
                        <p>Please visit the scholarship office along with your PDF receipt for further proceedings.</p>"
                            : "<p>Congratulations! Your application has been approved. You can download your updated PDF receipt from the portal.</p>")
                        : "<p>We encourage you to reapply or apply for other scholarships that match your profile.</p>")}
            <tr>
    <td style='background:#f0f0f0; border-left: 4px solid #06a494; padding: 14px 16px; color: #333; font-size: 11px;'>
        <strong>Office Address:</strong><br>
        52448-54298 Boca Chica Blvd, Brownsville, TX 78521, United States
    </td>
</tr>
            <p>If you have any questions, contact <a href='mailto:AskQuasarEdu@gmail.com'>AskQuasarEdu@gmail.com</a>.</p>
        </div>
        <div class='footer'>
            <p>© 2026 QuasarEdu | Powered By Project QuasarX<br>All Rights Reserved</p>
            <p>This is an automated email. Please do not reply.</p>
</div>
    </div>
</body>
</html>";

            message.Body = body;
            message.IsBodyHtml = true;

            var smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("noreplyquasaredu@gmail.com", "ubtx xfpw mhfr uktd"),
                EnableSsl = true,
            };

            try { smtp.Send(message); }
            catch (Exception ex) { Console.WriteLine($"Email sending failed: {ex.Message}"); }
        }

       
        public static void SendOtpEmail(string email, string otp)
        {
            var message = new MailMessage();
            message.From = new MailAddress("noreplyquasaredu@gmail.com");
            message.To.Add(email);
            message.Subject = "OTP Code - QuasarEdu By Project QuasarX";

            string body = $@"
<html>
<head>
    <style>
        body {{ font-family: 'Segoe UI', Arial, sans-serif; background-color: #f8f9fa; margin: 0; padding: 20px; }}
        .container {{ max-width: 600px; margin: 0 auto; background: white; border-radius: 12px; overflow: hidden; box-shadow: 0 4px 15px rgba(0,0,0,0.1); }}
        .header {{ background: linear-gradient(135deg, #06a494, #00f0ff); color: white; padding: 30px 20px; text-align: center; }}
        .content {{ padding: 35px 30px; line-height: 1.7; color: #333; }}
        .otp-box {{ background: #f8f9fa; border: 2px dashed #06a494; border-radius: 10px; padding: 20px; text-align: center; margin: 25px 0; font-size: 32px; font-weight: bold; letter-spacing: 8px; color: #06a494; }}
        .footer {{ background: #f1f3f5; padding: 20px; text-align: center; font-size: 14px; color: #666; }}
        hr {{ border: none; border-top: 1px solid #eee; margin: 25px 0; }}
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1>QuasarEdu By Project QuasarX</h1>
            <p style='margin: 8px 0 0 0; opacity: 0.95;'>Email Verification</p>
        </div>
        <div class='content'>
            <h2>Hello,</h2>
            <p>Thank you for registering with QuasarEdu.</p>
            <p>Your One-Time Password (OTP) for Account Verification is:</p>
            <div class='otp-box'>{otp}</div>
            <p><strong>This OTP is valid for the next 10 minutes.</strong></p>
            <p>If you did not request this code, please ignore this email or contact AskQuasarEdu@gmail.com.</p>
            <tr>
    <td style='background:#f0f0f0; border-left: 4px solid #06a494; padding: 14px 16px; color: #333; font-size: 11px;'>
        <strong>Office Address:</strong><br>
        52448-54298 Boca Chica Blvd, Brownsville, TX 78521, United States
    </td>
</tr>
            <hr>
            <p style='font-size: 15px;'>For security reasons, never share your OTP with anyone.</p>
        </div>
        <div class='footer'>
            <p>© 2026 QuasarEdu | Powered By Project QuasarX<br>All Rights Reserved</p>
            <p>This is an automated email. Please do not reply.</p>
        </div>
    </div>
</body>
</html>";

            message.Body = body;
            message.IsBodyHtml = true;

            var smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("noreplyquasaredu@gmail.com", "ubtx xfpw mhfr uktd"),
                EnableSsl = true,
            };

            try { smtp.Send(message); }
            catch (Exception ex) { Console.WriteLine($"Failed to send OTP email: {ex.Message}"); }
        }
        public static void SendIdentityVerificationConfirmationEmail(
     string toEmail, string studentName, string verificationMethod = "unknown")
        {
            string body = """
<html>
<head>
    <style>
        body { font-family: 'Segoe UI', Arial, sans-serif; background-color: #f8f9fa; margin: 0; padding: 20px; }
        .container { max-width: 600px; margin: 0 auto; background: white; border-radius: 12px; overflow: hidden; box-shadow: 0 4px 15px rgba(0,0,0,0.1); }
        .header { background: linear-gradient(135deg, #06a494, #00f0ff); color: white; padding: 30px 20px; text-align: center; }
        .content { padding: 30px 25px; line-height: 1.6; color: #333; }
        .badge { display: inline-block; background: #28a745; color: white; border-radius: 20px; padding: 6px 18px; font-size: 14px; font-weight: bold; margin-bottom: 20px; }
        .footer { background: #f1f3f5; padding: 20px; text-align: center; font-size: 14px; color: #666; }
        hr { border: none; border-top: 1px solid #eee; margin: 25px 0; }
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1 style='margin:0 0 8px 0;'>QuasarEdu</h1>
            <p style='margin:0; opacity:0.9;'>By Project QuasarX</p>
        </div>
        <div class='content'>
            <div style='text-align:center;'>
                <div class='badge'>&#x2705; Identity Verified</div>
            </div>
            <h2>Dear STUDENT_NAME,</h2>
            <p>Your <strong>Identity Verification</strong> has been completed successfully on QuasarEdu.</p>
            <p>Verification completed via: <strong>Face Verification</strong> and <strong>VERIFY_METHOD</strong></p>
            <p>You are now eligible to submit scholarship applications. Please log in and apply for any scholarships before their deadlines.</p>
            <hr>
            <table width='100%' cellpadding='0' cellspacing='0' style='margin: 16px 0;'>
                <tr>
    <td style='background:#f0f0f0; border-left: 4px solid #06a494; padding: 14px 16px; color: #333; font-size: 11px;'>
        <strong>Office Address:</strong><br>
        52448-54298 Boca Chica Blvd, Brownsville, TX 78521, United States
    </td>
</tr>
            </table>
            <hr>
            <p>If you did not perform this verification, please contact us immediately at <a href='mailto:AskQuasarEdu@gmail.com'>AskQuasarEdu@gmail.com</a>.</p>
        </div>
        <div class='footer'>
            <p>&#169; 2026 QuasarEdu | Powered By Project QuasarX<br>All Rights Reserved</p>
            <p>This is an automated email. Please do not reply.</p>
        </div>
    </div>
</body>
</html>
"""
            .Replace("STUDENT_NAME", studentName)
            .Replace("VERIFY_METHOD", verificationMethod);

            var message = new MailMessage();
            message.From = new MailAddress("noreplyquasaredu@gmail.com");
            message.To.Add(toEmail);
            message.Subject = "Identity Verification Confirmed — QuasarEdu";
            message.Body = body;
            message.IsBodyHtml = true;

            using var smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("noreplyquasaredu@gmail.com", "ubtx xfpw mhfr uktd"),
                EnableSsl = true,
            };

            try { smtp.Send(message); }
            catch (Exception ex) { Console.WriteLine($"Identity verification email failed: {ex.Message}"); }
        }
        public static void SendIdentityVerificationLinkEmail(
     string studentEmail,
     string studentName,
     string token)
        {
            string verificationLink = $"{FingerprintServerBaseUrl}/identity-verify?token={token}";

            string body = """
<html>
<head>
    <meta name='viewport' content='width=device-width, initial-scale=1'>
    <style>
        body { font-family: 'Segoe UI', Arial, sans-serif; background-color: #f8f9fa; margin: 0; padding: 20px; }
        .container { max-width: 600px; margin: 0 auto; background: white; border-radius: 12px; overflow: hidden; box-shadow: 0 4px 15px rgba(0,0,0,0.1); }
        .header { background: linear-gradient(135deg, #06a494, #00f0ff); color: white; padding: 30px 20px; text-align: center; }
        .content { padding: 30px 25px; line-height: 1.6; color: #333; }
        .btn-verify { display: block; background: linear-gradient(135deg, #06a494, #00f0ff); color: white; text-decoration: none; text-align: center; padding: 18px 30px; border-radius: 10px; font-size: 18px; font-weight: bold; margin: 25px auto; max-width: 320px; box-shadow: 0 4px 12px rgba(6,164,148,0.4); white-space: normal; word-wrap: break-word; }
        .warning { background: #fff3cd; border-left: 4px solid #ffc107; padding: 14px 16px; border-radius: 6px; margin: 20px 0; font-size: 14px; }
        .info-box { background: #f0f4ff; border-radius: 8px; padding: 16px; margin: 20px 0; }
        .link-text { word-break: break-all; color: #06a494; font-size: 13px; margin-top: 10px; }
        .footer { background: #f1f3f5; padding: 20px; text-align: center; font-size: 13px; color: #666; }
        hr { border: none; border-top: 1px solid #eee; margin: 25px 0; }
    </style>
</head>
<body>
    <div class='container'>
        <div class='header'>
            <h1 style='margin:0 0 8px 0;'>QuasarEdu</h1>
            <p style='margin:0; opacity:0.9;'>By Project QuasarX</p>
        </div>
        <div class='content'>
            <h2>Dear STUDENT_NAME,</h2>
            <p>Please complete your <strong>Identity Verification</strong> using your smartphone. You can use any of the options below:</p>
            <div class='info-box'>
                <table style='border-collapse:collapse; width:100%; margin:8px 0;'>
                    <tr>
                        <td style='width:36px; vertical-align:top; padding-top:2px;'>
                            <div style='background:#06a494; color:white; border-radius:50%; width:28px; height:28px; text-align:center; line-height:28px; font-weight:bold; font-size:14px;'>1</div>
                        </td>
                        <td style='padding-left:10px; vertical-align:middle; font-size:14px;'>
                            Open the link below on your smartphone.
                        </td>
                    </tr>
                </table>
                <table style='border-collapse:collapse; width:100%; margin:8px 0;'>
                    <tr>
                        <td style='width:36px; vertical-align:top; padding-top:2px;'>
                            <div style='background:#06a494; color:white; border-radius:50%; width:28px; height:28px; text-align:center; line-height:28px; font-weight:bold; font-size:14px;'>2</div>
                        </td>
                        <td style='padding-left:10px; vertical-align:middle; font-size:14px;'>
                            Perform <strong>Face Verification</strong>. Then choose: <strong>Fingerprint Photo</strong>, <strong>Biometric/Face ID</strong>, or <strong>PIN/Password</strong>.
                        </td>
                    </tr>
                </table>
                <table style='border-collapse:collapse; width:100%; margin:8px 0;'>
                    <tr>
                        <td style='width:36px; vertical-align:top; padding-top:2px;'>
                            <div style='background:#06a494; color:white; border-radius:50%; width:28px; height:28px; text-align:center; line-height:28px; font-weight:bold; font-size:14px;'>3</div>
                        </td>
                        <td style='padding-left:10px; vertical-align:middle; font-size:14px;'>
                            Follow the on-screen instructions and submit.
                        </td>
                    </tr>
                </table>
            </div>
            <a href='VERIFICATION_LINK' class='btn-verify'>Tap Here to Verify Identity</a>
            <div class='warning'>&#x23F0; <strong>This link expires in 1 hour.</strong></div>
            <hr>
            <p style='font-size:13px; color:#555;'>If the button doesn't work, copy this link into your mobile browser:</p>
            <p class='link-text'>VERIFICATION_LINK</p>
            <hr>
            <tr>
    <td style='background:#f0f0f0; border-left: 4px solid #06a494; padding: 14px 16px; color: #333; font-size: 11px;'>
        <strong>Office Address:</strong><br>
        52448-54298 Boca Chica Blvd, Brownsville, TX 78521, United States
    </td>
</tr>
            <p>If you have any questions, contact <a href='mailto:AskQuasarEdu@gmail.com'>AskQuasarEdu@gmail.com</a></p>
        </div>
        <div class='footer'>
            <p>&#169; 2026 QuasarEdu | Powered By Project QuasarX<br>All Rights Reserved</p>
            <p>This is an automated email. Please do not reply.</p>
        </div>
    </div>
</body>
</html>
"""
            .Replace("STUDENT_NAME", studentName)
            .Replace("VERIFICATION_LINK", verificationLink);

            var message = new MailMessage();
            message.From = new MailAddress("noreplyquasaredu@gmail.com");
            message.To.Add(studentEmail);
            message.Subject = "Action Required: Identity Verification — QuasarEdu";
            message.Body = body;
            message.IsBodyHtml = true;

            using var smtp = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("noreplyquasaredu@gmail.com", "ubtx xfpw mhfr uktd"),
                EnableSsl = true,
            };

            try { smtp.Send(message); }
            catch (Exception ex) { Console.WriteLine($"Identity link email failed: {ex.Message}"); }
        }
    }
}