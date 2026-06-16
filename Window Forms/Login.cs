using System.Data;
using System.Media;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using Window_Forms.Models;
using Window_Forms.Repositories;
using BCrypt.Net;

namespace Window_Forms
{
    public partial class Login : Form
    {
        private UserRepository _userRepo;
        private StudentRepository _studentRepo;

       
        private ToolTip _capsLockToolTip;

        private static Dictionary<string, (int Attempts, DateTime LockoutEnd)> _loginAttempts = new();
        private const int MAX_ATTEMPTS = 5;
        private const int LOCKOUT_MINUTES = 15;

        public Login()
        {
            InitializeComponent();

            _userRepo = new UserRepository();
            _studentRepo = new StudentRepository();

            // Setup Caps Lock Warning
            _capsLockToolTip = new ToolTip();
            _capsLockToolTip.ToolTipIcon = ToolTipIcon.Warning;
            _capsLockToolTip.ToolTipTitle = "Warning";

            // Wire up events to detect Caps Lock while typing
            txtPassword.Enter += CheckCapsLock;
            txtPassword.KeyDown += CheckCapsLock;
        }

        // Caps Lock Check Method
        private void CheckCapsLock(object? sender, EventArgs e)
        {
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                _capsLockToolTip.Show("Caps Lock is ON", txtPassword, 0, txtPassword.Height + 5, 2000);
            }
            else
            {
                _capsLockToolTip.Hide(txtPassword);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            System.Windows.Forms.Application.Exit();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            SoundPlayer player = new SoundPlayer("click.wav");
            player.Play();

            Register reg = new Register();
            reg.Show();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Prevent Double Clicks
            btnLogin.Enabled = false;

            try
            {
                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text.Trim();

                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    ToastForm.ShowWarning("Enter both email and password.");
                    return;
                }

                // Email format validation
                if (!Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[a-zA-Z]{2,}$"))
                {
                    ToastForm.ShowWarning("Please enter a valid email address (e.g., user@domain.com).");
                    return;
                }

                // Brute Force / Lockout Check
                if (IsAccountLocked(email)) return;

                User user = _userRepo.GetByEmail(email);

                if (user == null)
                {
                    ToastForm.ShowWarning("Email not found in database.");
                    return;
                }

                if (user.IsVerified == false)
                {
                    ToastForm.ShowInfo("Please verify your email with OTP before logging in.");
                    return;
                }

                // Password Hashing Verification
                if (!VerifyPassword(password, user.Password))
                {
                    RecordFailedAttempt(email);
                    return;
                }

                // Reset login attempts on success
                _loginAttempts.Remove(email);

                Session.UserId = user.Id;
                Session.UserEmail = user.Email;
                Session.UserRole = user.Role;
                Session.FullName = user.FullName;
                Session.Phone = user.Phone;
                Session.Address = user.Address;
                Session.DateOfBirth = user.DateOfBirth;

                Student student = _studentRepo.GetByEmail(user.Email);

                if (student != null)
                {
                    if (Session.FullName == null) Session.FullName = student.FullName;
                    if (Session.Phone == null) Session.Phone = student.MobileNumber;
                    if (Session.Address == null) Session.Address = student.PermanentAddress ?? student.MailingAddress;
                    if (Session.DateOfBirth == null) Session.DateOfBirth = student.DateOfBirth;

                    Session.Department = student.Department;
                    Session.DegreeProgram = student.DegreeProgram;
                    Session.SemesterYear = student.SemesterYear;
                    Session.FamilyIncome = student.FamilyIncome;
                    Session.CGPA = student.CGPA;
                }

                ToastForm.ShowSuccess("Welcome back, " + Session.FullName + "!");

                SoundPlayer player = new SoundPlayer("success.wav");
                player.Play();

                bool isAdmin = string.Equals(Session.UserRole, "Admin", StringComparison.OrdinalIgnoreCase);

                if (isAdmin)
                {
                    AdminDashboard adminDashboard = new AdminDashboard();
                    adminDashboard.Show();
                }
                else
                {
                    StudentDashboard studentDashboard = new StudentDashboard();
                    studentDashboard.Show();
                }

                this.Hide();
            }
            catch (Exception ex)
            {
                ToastForm.ShowError("Login failed.\n\n" + ex.Message);
            }
            finally
            {
                // Re-enable the button regardless of success or error
                btnLogin.Enabled = true;
            }
        }

        private void BtnForgotPassword_Click(object sender, EventArgs e)
        {
            ForgotPasswordForm forgotForm = new ForgotPasswordForm();
            forgotForm.ShowDialog();
        }

        // ==========================================
        // HELPER METHODS FOR SECURITY CHECKS
        // ==========================================

        private bool IsAccountLocked(string email)
        {
            if (email.Equals("admin@sms.local", StringComparison.OrdinalIgnoreCase))
                return false;

            if (_loginAttempts.TryGetValue(email, out var attemptInfo))
            {
                if (attemptInfo.Attempts >= MAX_ATTEMPTS)
                {
                    if (DateTime.Now < attemptInfo.LockoutEnd)
                    {
                        var remaining = attemptInfo.LockoutEnd - DateTime.Now;
                        ToastForm.ShowWarning($"Account locked due to too many failed attempts.\nTry again in {remaining.Minutes}m {remaining.Seconds}s.");
                        return true; // Still locked
                    }
                    else
                    {
                        _loginAttempts.Remove(email); // Lockout expired
                    }
                }
            }
            return false; // Not locked
        }

        private void RecordFailedAttempt(string email)
        {
            if (email.Equals("admin@sms.local", StringComparison.OrdinalIgnoreCase))
            {
                ToastForm.ShowWarning("Invalid Credentials.");
                return;
            }

            if (_loginAttempts.ContainsKey(email))
            {
                var attempts = _loginAttempts[email].Attempts + 1;
                var lockout = attempts >= MAX_ATTEMPTS ? DateTime.Now.AddMinutes(LOCKOUT_MINUTES) : DateTime.MinValue;
                _loginAttempts[email] = (attempts, lockout);
            }
            else
            {
                _loginAttempts[email] = (1, DateTime.MinValue);
            }

            int attemptsLeft = MAX_ATTEMPTS - _loginAttempts[email].Attempts;

            if (attemptsLeft > 0)
            {
                ToastForm.ShowWarning($"Invalid credentials. {attemptsLeft} attempts remaining.");
            }
            else
            {
                ToastForm.ShowError($"Account locked for {LOCKOUT_MINUTES} minutes.");
            }
        }

        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            try
            {
                return BCrypt.Net.BCrypt.Verify(inputPassword, storedHash);
            }
            catch (BCrypt.Net.SaltParseException)
            {
                return inputPassword == storedHash;
            }
        }
    }
}