namespace Window_Forms
{
    partial class ForgotPasswordForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();

            pnlHeader = new Guna.UI2.WinForms.Guna2GradientPanel();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            lblTitle = new Label();
            lblEmail = new Label();
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            btnSendOtp = new Guna.UI2.WinForms.Guna2GradientButton();
            lblOtpSent = new Label();
            lblOtp = new Label();
            txtOtp = new Guna.UI2.WinForms.Guna2TextBox();
            lblNewPassword = new Label();
            txtNewPassword = new Guna.UI2.WinForms.Guna2TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            btnResetPassword = new Guna.UI2.WinForms.Guna2GradientButton();
            btnCancel = new Guna.UI2.WinForms.Guna2GradientButton();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);

            pnlHeader.SuspendLayout();
            SuspendLayout();
            //
            // pnlHeader
            //
            pnlHeader.BackColor = System.Drawing.Color.Transparent;
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.CustomizableEdges = customizableEdges1;
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.FillColor = System.Drawing.Color.FromArgb(6, 148, 148);
            pnlHeader.FillColor2 = System.Drawing.Color.FromArgb(0, 240, 255);
            pnlHeader.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlHeader.Size = new System.Drawing.Size(460, 60);
            pnlHeader.TabIndex = 0;
            //
            // btnClose
            //
            btnClose.Animated = true;
            btnClose.BackColor = System.Drawing.Color.Transparent;
            btnClose.CustomizableEdges = customizableEdges3;
            btnClose.FillColor = System.Drawing.Color.Transparent;
            btnClose.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            btnClose.ForeColor = System.Drawing.Color.FromArgb(255, 210, 225);
            btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(254, 226, 226);
            btnClose.HoverState.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            btnClose.Location = new System.Drawing.Point(418, 14);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnClose.Size = new System.Drawing.Size(32, 32);
            btnClose.TabIndex = 1;
            btnClose.Text = "X";
            btnClose.Click += BtnCancel_Click;
            btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.BackColor = System.Drawing.Color.Transparent;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(24, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(180, 30);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Reset Password";
            //
            // lblEmail
            //
            lblEmail.AutoSize = true;
            lblEmail.BackColor = System.Drawing.Color.Transparent;
            lblEmail.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblEmail.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblEmail.Location = new System.Drawing.Point(40, 85);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new System.Drawing.Size(41, 19);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email";
            //
            // txtEmail
            //
            txtEmail.Animated = true;
            txtEmail.BackColor = System.Drawing.Color.Transparent;
            txtEmail.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            txtEmail.BorderRadius = 8;
            txtEmail.BorderThickness = 1;
            txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtEmail.DefaultText = "";
            txtEmail.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            txtEmail.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtEmail.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            txtEmail.Location = new System.Drawing.Point(40, 110);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "you@example.com";
            txtEmail.SelectedText = "";
            txtEmail.Size = new System.Drawing.Size(380, 44);
            txtEmail.TabIndex = 2;
            //
            // btnSendOtp
            //
            btnSendOtp.Animated = true;
            btnSendOtp.AutoRoundedCorners = true;
            btnSendOtp.BackColor = System.Drawing.Color.Transparent;
            btnSendOtp.BorderRadius = 20;
            btnSendOtp.CustomizableEdges = customizableEdges5;
            btnSendOtp.FillColor = System.Drawing.Color.FromArgb(6, 148, 148);
            btnSendOtp.FillColor2 = System.Drawing.Color.FromArgb(0, 240, 255);
            btnSendOtp.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnSendOtp.ForeColor = System.Drawing.Color.White;
            btnSendOtp.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnSendOtp.HoverState.FillColor = System.Drawing.Color.FromArgb(200, 60, 130);
            btnSendOtp.HoverState.FillColor2 = System.Drawing.Color.FromArgb(255, 150, 200);
            btnSendOtp.Location = new System.Drawing.Point(40, 165);
            btnSendOtp.Name = "btnSendOtp";
            btnSendOtp.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnSendOtp.Size = new System.Drawing.Size(180, 40);
            btnSendOtp.TabIndex = 3;
            btnSendOtp.Text = "Send OTP";
            btnSendOtp.Click += BtnSendOtp_Click;
            btnSendOtp.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // lblOtpSent
            //
            lblOtpSent.AutoSize = true;
            lblOtpSent.BackColor = System.Drawing.Color.Transparent;
            lblOtpSent.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            lblOtpSent.ForeColor = System.Drawing.Color.FromArgb(16, 185, 129);
            lblOtpSent.Location = new System.Drawing.Point(40, 173);
            lblOtpSent.Name = "lblOtpSent";
            lblOtpSent.Size = new System.Drawing.Size(225, 17);
            lblOtpSent.TabIndex = 4;
            lblOtpSent.Text = "OTP sent! Check your email inbox.";
            lblOtpSent.Visible = false;
            //
            // lblOtp
            //
            lblOtp.AutoSize = true;
            lblOtp.BackColor = System.Drawing.Color.Transparent;
            lblOtp.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblOtp.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblOtp.Location = new System.Drawing.Point(40, 210);
            lblOtp.Name = "lblOtp";
            lblOtp.Size = new System.Drawing.Size(36, 19);
            lblOtp.TabIndex = 5;
            lblOtp.Text = "OTP";
            lblOtp.Visible = false;
            //
            // txtOtp
            //
            txtOtp.Animated = true;
            txtOtp.BackColor = System.Drawing.Color.Transparent;
            txtOtp.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            txtOtp.BorderRadius = 8;
            txtOtp.BorderThickness = 1;
            txtOtp.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtOtp.DefaultText = "";
            txtOtp.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            txtOtp.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            txtOtp.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtOtp.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            txtOtp.Location = new System.Drawing.Point(40, 235);
            txtOtp.Name = "txtOtp";
            txtOtp.PlaceholderText = "000000";
            txtOtp.SelectedText = "";
            txtOtp.Size = new System.Drawing.Size(380, 50);
            txtOtp.TabIndex = 6;
            txtOtp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            txtOtp.Visible = false;
            //
            // lblNewPassword
            //
            lblNewPassword.AutoSize = true;
            lblNewPassword.BackColor = System.Drawing.Color.Transparent;
            lblNewPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblNewPassword.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblNewPassword.Location = new System.Drawing.Point(40, 305);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new System.Drawing.Size(98, 19);
            lblNewPassword.TabIndex = 7;
            lblNewPassword.Text = "New Password";
            //
            // txtNewPassword
            //
            txtNewPassword.Animated = true;
            txtNewPassword.BackColor = System.Drawing.Color.Transparent;
            txtNewPassword.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            txtNewPassword.BorderRadius = 8;
            txtNewPassword.BorderThickness = 1;
            txtNewPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtNewPassword.DefaultText = "";
            txtNewPassword.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtNewPassword.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtNewPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            txtNewPassword.Location = new System.Drawing.Point(40, 330);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '●';
            txtNewPassword.PlaceholderText = "Enter new password";
            txtNewPassword.SelectedText = "";
            txtNewPassword.Size = new System.Drawing.Size(380, 44);
            txtNewPassword.TabIndex = 8;
            txtNewPassword.UseSystemPasswordChar = true;
            //
            // lblConfirmPassword
            //
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblConfirmPassword.Location = new System.Drawing.Point(40, 390);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new System.Drawing.Size(137, 19);
            lblConfirmPassword.TabIndex = 9;
            lblConfirmPassword.Text = "Confirm Password";
            //
            // txtConfirmPassword
            //
            txtConfirmPassword.Animated = true;
            txtConfirmPassword.BackColor = System.Drawing.Color.Transparent;
            txtConfirmPassword.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            txtConfirmPassword.BorderRadius = 8;
            txtConfirmPassword.BorderThickness = 1;
            txtConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtConfirmPassword.DefaultText = "";
            txtConfirmPassword.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            txtConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtConfirmPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            txtConfirmPassword.Location = new System.Drawing.Point(40, 415);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '●';
            txtConfirmPassword.PlaceholderText = "Confirm new password";
            txtConfirmPassword.SelectedText = "";
            txtConfirmPassword.Size = new System.Drawing.Size(380, 44);
            txtConfirmPassword.TabIndex = 10;
            txtConfirmPassword.UseSystemPasswordChar = true;
            //
            // btnResetPassword
            //
            btnResetPassword.Animated = true;
            btnResetPassword.AutoRoundedCorners = true;
            btnResetPassword.BackColor = System.Drawing.Color.Transparent;
            btnResetPassword.BorderRadius = 20;
            btnResetPassword.CustomizableEdges = customizableEdges7;
            btnResetPassword.FillColor = System.Drawing.Color.FromArgb(6, 148, 148);
            btnResetPassword.FillColor2 = System.Drawing.Color.FromArgb(0, 240, 255);
            btnResetPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnResetPassword.ForeColor = System.Drawing.Color.White;
            btnResetPassword.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnResetPassword.HoverState.FillColor = System.Drawing.Color.FromArgb(200, 60, 130);
            btnResetPassword.HoverState.FillColor2 = System.Drawing.Color.FromArgb(255, 150, 200);
            btnResetPassword.Location = new System.Drawing.Point(40, 480);
            btnResetPassword.Name = "btnResetPassword";
            btnResetPassword.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnResetPassword.Size = new System.Drawing.Size(180, 44);
            btnResetPassword.TabIndex = 11;
            btnResetPassword.Text = "Reset Password";
            btnResetPassword.Click += BtnResetPassword_Click;
            btnResetPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // btnCancel
            //
            btnCancel.Animated = true;
            btnCancel.AutoRoundedCorners = true;
            btnCancel.BackColor = System.Drawing.Color.Transparent;
            btnCancel.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            btnCancel.BorderRadius = 20;
            btnCancel.BorderThickness = 1;
            btnCancel.CustomizableEdges = customizableEdges7;
            btnCancel.FillColor = System.Drawing.Color.White;
            btnCancel.FillColor2 = System.Drawing.Color.White;
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnCancel.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnCancel.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            btnCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            btnCancel.HoverState.FillColor2 = System.Drawing.Color.FromArgb(255, 248, 252);
            btnCancel.HoverState.ForeColor = System.Drawing.Color.FromArgb(6, 148, 148);
            btnCancel.Location = new System.Drawing.Point(240, 480);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnCancel.Size = new System.Drawing.Size(180, 44);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Cancel";
            btnCancel.Click += BtnCancel_Click;
            btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // guna2BorderlessForm1
            //
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.BorderRadius = 24;
            guna2BorderlessForm1.HasFormShadow = true;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
            guna2BorderlessForm1.DragForm = false;
            guna2BorderlessForm1.ResizeForm = false;
            //
            // guna2DragControl1
            //
            guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
            guna2DragControl1.TargetControl = pnlHeader;
            guna2DragControl1.UseTransparentDrag = true;
            //
            // ForgotPasswordForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(460, 550);
            Controls.Add(btnResetPassword);
            Controls.Add(btnCancel);
            Controls.Add(txtConfirmPassword);
            Controls.Add(lblConfirmPassword);
            Controls.Add(txtNewPassword);
            Controls.Add(lblNewPassword);
            Controls.Add(txtOtp);
            Controls.Add(lblOtp);
            Controls.Add(lblOtpSent);
            Controls.Add(btnSendOtp);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(pnlHeader);
            Font = new System.Drawing.Font("Segoe UI", 9.75F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MinimumSize = new System.Drawing.Size(460, 550);
            Name = "ForgotPasswordForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Reset Password";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private Guna.UI2.WinForms.Guna2GradientPanel pnlHeader;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblEmail, lblOtp, lblNewPassword, lblConfirmPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail, txtOtp, txtNewPassword, txtConfirmPassword;
        private Guna.UI2.WinForms.Guna2GradientButton btnSendOtp, btnResetPassword, btnCancel;
        private System.Windows.Forms.Label lblOtpSent;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}
