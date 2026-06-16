using System.Data;
using Microsoft.Data.SqlClient;

namespace Window_Forms
{
    public partial class OTP : Form
    {
        private readonly string email;
        private readonly string correctOtp;

        // NEW: OTP Security variables
        private DateTime _otpExpiryTime;
        private int _otpAttempts = 0;
        private const int MAX_OTP_ATTEMPTS = 3;

        public OTP(string email, string otp)
        {
            InitializeComponent();
            this.email = email;
            correctOtp = otp;
            txtEmail.Text = email;

            // CHECK 2: Set expiration to 5 minutes from the moment the form opens
            _otpExpiryTime = DateTime.Now.AddMinutes(5);
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            // CHECK 4: Prevent double-clicks by disabling the button
            btnVerify.Enabled = false;

            try
            {
                string enteredOtp = txtOtp.Text.Trim();

                // CHECK 1: Empty input validation
                if (string.IsNullOrWhiteSpace(enteredOtp))
                {
                    ToastForm.ShowWarning("Please enter the OTP.");
                    return;
                }

                // CHECK 3: Brute-force limit
                if (_otpAttempts >= MAX_OTP_ATTEMPTS)
                {
                    ToastForm.ShowError("Too many failed attempts. Please register again.");
                    Close(); // Close the form, forcing them to restart
                    return;
                }

                // CHECK 2: OTP Expiry validation
                if (DateTime.Now > _otpExpiryTime)
                {
                    ToastForm.ShowWarning("OTP has expired (5-minute limit). Please register again.");
                    Close(); // Force them to restart
                    return;
                }

                if (enteredOtp != correctOtp)
                {
                    _otpAttempts++;
                    int attemptsLeft = MAX_OTP_ATTEMPTS - _otpAttempts;
                    ToastForm.ShowWarning($"Wrong OTP. You have {attemptsLeft} attempts left.");
                    return;
                }

                // Database execution for successful OTP
                Database.ExecuteProc("sp_VerifyUserEmail",
                    new SqlParameter("@Email", email));

                Database.ExecuteProc("sp_CreateStudentFromUser",
                    new SqlParameter("@Email", email));

                DataTable user = Database.QueryProc("sp_GetUserLoginInfo",
                    new SqlParameter("@Email", email));

                if (user.Rows.Count > 0)
                {
                    Session.UserId = Convert.ToInt32(user.Rows[0]["Id"]);
                    Session.UserEmail = user.Rows[0]["Email"].ToString();
                    Session.UserRole = user.Rows[0]["Role"].ToString();
                }

                ToastForm.ShowSuccess("Account created successfully!");

                
                    StudentDashboard studentDash = new StudentDashboard();
                    studentDash.Show();
                    Close();
                
            }
            catch (Exception ex)
            {
                ToastForm.ShowError("OTP verification failed.\n\n" + ex.Message);
            }
            finally
            {
                // CHECK 4: Re-enable the button regardless of success or error
                btnVerify.Enabled = true;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            System.Windows.Forms.Application.Exit();
        }
    }
}