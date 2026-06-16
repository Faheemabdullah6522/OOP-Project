namespace Window_Forms
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));

            guna2GradientPanelLeft = new Guna.UI2.WinForms.Guna2GradientPanel();
            lblQuote = new Label();
            Label lblQuote2 = new Label();
            lblAppName = new Label();
            lblWelcomeTitle = new Label();
            pictureBoxLogo = new PictureBox();
            guna2GradientPanelRight = new Guna.UI2.WinForms.Guna2GradientPanel();
            lblLoginTitle = new Label();
            lblEmail = new Label();
            lblPassword = new Label();
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            btnLogin = new Guna.UI2.WinForms.Guna2GradientButton();
            btnRegister = new Guna.UI2.WinForms.Guna2GradientButton();
            btnForgotPassword = new Guna.UI2.WinForms.Guna2Button();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
            btnClose = new Guna.UI2.WinForms.Guna2Button();

            guna2GradientPanelLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            guna2GradientPanelRight.SuspendLayout();
            SuspendLayout();

            // guna2GradientPanelLeft
            guna2GradientPanelLeft.BackColor = Color.Transparent;
            guna2GradientPanelLeft.Controls.Add(lblQuote);
            guna2GradientPanelLeft.Controls.Add(lblQuote2);
            guna2GradientPanelLeft.Controls.Add(lblAppName);
            guna2GradientPanelLeft.Controls.Add(lblWelcomeTitle);
            guna2GradientPanelLeft.Controls.Add(pictureBoxLogo);
            guna2GradientPanelLeft.CustomizableEdges = customizableEdges1;
            guna2GradientPanelLeft.Dock = DockStyle.Left;
            guna2GradientPanelLeft.FillColor = Color.FromArgb(6, 148, 148);
            guna2GradientPanelLeft.FillColor2 = Color.FromArgb(0, 240, 255);
            guna2GradientPanelLeft.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            guna2GradientPanelLeft.Location = new Point(0, 0);
            guna2GradientPanelLeft.Name = "guna2GradientPanelLeft";
            guna2GradientPanelLeft.ShadowDecoration.CustomizableEdges = customizableEdges2;
            guna2GradientPanelLeft.Size = new Size(500, 600);
            guna2GradientPanelLeft.TabIndex = 0;

            // pictureBoxLogo
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBoxLogo.Location = new Point(125, 90);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(235, 140);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;

            // lblWelcomeTitle
            lblWelcomeTitle.AutoSize = false;
            lblWelcomeTitle.BackColor = Color.Transparent;
            lblWelcomeTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcomeTitle.ForeColor = Color.White;
            lblWelcomeTitle.Location = new Point(36, 230);
            lblWelcomeTitle.Name = "lblWelcomeTitle";
            lblWelcomeTitle.Size = new Size(430, 45);
            lblWelcomeTitle.TabIndex = 1;
            lblWelcomeTitle.Text = "Welcome To QuasarEdu";
            lblWelcomeTitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblAppName
            lblAppName.AutoSize = false;
            lblAppName.BackColor = Color.Transparent;
            lblAppName.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAppName.ForeColor = Color.FromArgb(255, 210, 225);
            lblAppName.Location = new Point(163, 280);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(295, 25);
            lblAppName.TabIndex = 2;
            lblAppName.Text = "By Project QuasarX";

            // lblQuote
            lblQuote.AutoSize = false;
            lblQuote.BackColor = Color.Transparent;
            lblQuote.Font = new Font("Segoe UI", 11F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblQuote.ForeColor = Color.White;
            lblQuote.Location = new Point(53, 348);
            lblQuote.Name = "lblQuote";
            lblQuote.Size = new Size(380, 60);
            lblQuote.TabIndex = 3;
            lblQuote.Text = "\"The best of people are those who are most beneficial \nto people\"\r\n- Prophet Muhammad ﷺ";
            lblQuote.TextAlign = ContentAlignment.MiddleCenter;

            // lblQuote2
            lblQuote2.AutoSize = false;
            lblQuote2.BackColor = Color.Transparent;
            lblQuote2.Font = new Font("Segoe UI", 11F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblQuote2.ForeColor = Color.White;
            lblQuote2.Location = new Point(61, 470);
            lblQuote2.Name = "lblQuote2";
            lblQuote2.Size = new Size(350, 100);
            lblQuote2.TabIndex = 3;
            lblQuote2.Text = "© 2026 QuasarEdu | Powered By Project QuasarX\r\nAll Rights Reserved";
            lblQuote2.TextAlign = ContentAlignment.MiddleCenter;

            // guna2GradientPanelRight
            guna2GradientPanelRight.BackColor = Color.Transparent;
            guna2GradientPanelRight.Controls.Add(btnClose);
            guna2GradientPanelRight.Controls.Add(lblLoginTitle);
            guna2GradientPanelRight.Controls.Add(lblEmail);
            guna2GradientPanelRight.Controls.Add(lblPassword);
            guna2GradientPanelRight.Controls.Add(txtEmail);
            guna2GradientPanelRight.Controls.Add(txtPassword);
            guna2GradientPanelRight.Controls.Add(btnLogin);
            guna2GradientPanelRight.Controls.Add(btnRegister);
            guna2GradientPanelRight.Controls.Add(btnForgotPassword);
            guna2GradientPanelRight.CustomizableEdges = customizableEdges3;
            guna2GradientPanelRight.Dock = DockStyle.Fill;
            guna2GradientPanelRight.FillColor = Color.White;
            guna2GradientPanelRight.FillColor2 = Color.FromArgb(255, 248, 252);
            guna2GradientPanelRight.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            guna2GradientPanelRight.Location = new Point(500, 0);
            guna2GradientPanelRight.Name = "guna2GradientPanelRight";
            guna2GradientPanelRight.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2GradientPanelRight.Size = new Size(500, 600);
            guna2GradientPanelRight.TabIndex = 1;

            // btnClose
            btnClose.Animated = true;
            btnClose.BackColor = Color.Transparent;
            btnClose.ButtonMode = Guna.UI2.WinForms.Enums.ButtonMode.RadioButton;
            btnClose.CustomizableEdges = customizableEdges5;
            btnClose.DisabledState.BorderColor = Color.DarkGray;
            btnClose.DisabledState.CustomBorderColor = Color.DarkGray;
            btnClose.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnClose.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnClose.FillColor = Color.Transparent;
            btnClose.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClose.ForeColor = Color.FromArgb(100, 116, 139);
            btnClose.HoverState.FillColor = Color.FromArgb(254, 226, 226);
            btnClose.HoverState.ForeColor = Color.FromArgb(220, 38, 38);
            btnClose.Location = new Point(450, 12);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btnClose.Size = new Size(38, 38);
            btnClose.TabIndex = 4;
            btnClose.Text = "X";
            btnClose.Click += BtnClose_Click;
            btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            // lblLoginTitle
            lblLoginTitle.AutoSize = true;
            lblLoginTitle.BackColor = Color.Transparent;
            lblLoginTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblLoginTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblLoginTitle.Location = new Point(50, 80);
            lblLoginTitle.Name = "lblLoginTitle";
            lblLoginTitle.Size = new Size(250, 45);
            lblLoginTitle.TabIndex = 0;
            lblLoginTitle.Text = "Sign In";

            // lblEmail
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.FromArgb(71, 85, 105);
            lblEmail.Location = new Point(50, 160);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(41, 19);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email";

            // txtEmail
            txtEmail.Animated = true;
            txtEmail.BackColor = Color.Transparent;
            txtEmail.BorderColor = Color.FromArgb(0, 200, 210);
            txtEmail.BorderRadius = 12;
            txtEmail.BorderThickness = 1;
            txtEmail.Cursor = Cursors.IBeam;
            txtEmail.DefaultText = "";
            txtEmail.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtEmail.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtEmail.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.FillColor = Color.FromArgb(255, 248, 252);
            txtEmail.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.ForeColor = Color.FromArgb(15, 23, 42);
            txtEmail.HoverState.BorderColor = Color.FromArgb(6, 148, 148);
            txtEmail.IconRightSize = new Size(20, 20);
            txtEmail.Location = new Point(50, 185);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.PasswordChar = '\0';
            txtEmail.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtEmail.PlaceholderText = "you@example.com";
            txtEmail.SelectedText = "";
            txtEmail.Size = new Size(400, 48);
            txtEmail.TabIndex = 2;

            // lblPassword
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.ForeColor = Color.FromArgb(71, 85, 105);
            lblPassword.Location = new Point(50, 260);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(64, 19);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";

            // txtPassword
            txtPassword.Animated = true;
            txtPassword.BackColor = Color.Transparent;
            txtPassword.BorderColor = Color.FromArgb(0, 200, 210);
            txtPassword.BorderRadius = 12;
            txtPassword.BorderThickness = 1;
            txtPassword.Cursor = Cursors.IBeam;
            txtPassword.DefaultText = "";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.FillColor = Color.FromArgb(255, 248, 252);
            txtPassword.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtPassword.HoverState.BorderColor = Color.FromArgb(6, 148, 148);
            txtPassword.IconRightSize = new Size(20, 20);
            txtPassword.Location = new Point(50, 285);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '?';
            txtPassword.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtPassword.PlaceholderText = "Enter your password";
            txtPassword.SelectedText = "";
            txtPassword.Size = new Size(400, 48);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;

            // btnLogin
            btnLogin.Animated = true;
            btnLogin.AnimatedGIF = true;
            btnLogin.AutoRoundedCorners = true;
            btnLogin.BackColor = Color.Transparent;
            btnLogin.BorderRadius = 24;
            btnLogin.CustomizableEdges = customizableEdges7;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.FillColor = Color.FromArgb(6, 148, 148);
            btnLogin.FillColor2 = Color.FromArgb(0, 240, 255);
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnLogin.HoverState.FillColor = Color.FromArgb(200, 60, 130);
            btnLogin.HoverState.FillColor2 = Color.FromArgb(255, 150, 200);
            btnLogin.Location = new Point(50, 370);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.Color = Color.FromArgb(6, 148, 148, 80);
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnLogin.ShadowDecoration.Enabled = false;
            btnLogin.ShadowDecoration.Shadow = new Padding(0, 0, 8, 8);
            btnLogin.Size = new Size(400, 50);
            btnLogin.TabIndex = 5;
            btnLogin.Text = "Sign In";
            btnLogin.Click += btnLogin_Click;
            btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            // btnRegister
            btnRegister.Animated = true;
            btnRegister.AnimatedGIF = true;
            btnRegister.AutoRoundedCorners = true;
            btnRegister.BackColor = Color.Transparent;
            btnRegister.BorderColor = Color.FromArgb(0, 200, 210);
            btnRegister.BorderRadius = 24;
            btnRegister.BorderThickness = 1;
            btnRegister.CustomizableEdges = customizableEdges7;
            btnRegister.DisabledState.BorderColor = Color.DarkGray;
            btnRegister.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRegister.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRegister.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnRegister.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRegister.FillColor = Color.Transparent;
            btnRegister.FillColor2 = Color.Transparent;
            btnRegister.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = Color.FromArgb(71, 85, 105);
            btnRegister.HoverState.BorderColor = Color.FromArgb(6, 148, 148);
            btnRegister.HoverState.FillColor = Color.FromArgb(255, 248, 252);
            btnRegister.HoverState.FillColor2 = Color.FromArgb(255, 248, 252);
            btnRegister.HoverState.ForeColor = Color.FromArgb(6, 148, 148);
            btnRegister.Location = new Point(50, 435);
            btnRegister.Name = "btnRegister";
            btnRegister.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnRegister.Size = new Size(400, 50);
            btnRegister.TabIndex = 6;
            btnRegister.Text = "Create Account";
            btnRegister.Click += btnRegister_Click;
            btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // btnForgotPassword
            //
            btnForgotPassword.Animated = true;
            btnForgotPassword.BackColor = System.Drawing.Color.Transparent;
            btnForgotPassword.CustomizableEdges = customizableEdges7;
            btnForgotPassword.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnForgotPassword.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnForgotPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnForgotPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnForgotPassword.FillColor = System.Drawing.Color.Transparent;
            btnForgotPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Underline);
            btnForgotPassword.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            btnForgotPassword.HoverState.ForeColor = System.Drawing.Color.FromArgb(6, 148, 148);
            btnForgotPassword.Location = new System.Drawing.Point(50, 495);
            btnForgotPassword.Name = "btnForgotPassword";
            btnForgotPassword.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnForgotPassword.Size = new System.Drawing.Size(400, 30);
            btnForgotPassword.TabIndex = 7;
            btnForgotPassword.Text = "Forgot Password?";
            btnForgotPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            btnForgotPassword.Click += BtnForgotPassword_Click;
            btnForgotPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            
            // guna2BorderlessForm1
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.BorderRadius = 24;
            guna2BorderlessForm1.HasFormShadow = true;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
            guna2BorderlessForm1.DragForm = false;
            guna2BorderlessForm1.ResizeForm = false;
            guna2BorderlessForm1.TransparentWhileDrag = false;

            // guna2DragControl1
            guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
            guna2DragControl1.TargetControl = guna2GradientPanelLeft;
            guna2DragControl1.UseTransparentDrag = true;

            // Login
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 560);
            Controls.Add(guna2GradientPanelRight);
            Controls.Add(guna2GradientPanelLeft);
            Font = new Font("Segoe UI", 9.75F);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(1000, 560);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            guna2GradientPanelLeft.ResumeLayout(false);
            guna2GradientPanelLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            guna2GradientPanelRight.ResumeLayout(false);
            guna2GradientPanelRight.PerformLayout();
            ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanelLeft;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanelRight;
        private Label lblQuote;
        private Label lblAppName;
        private Label lblWelcomeTitle;
        private PictureBox pictureBoxLogo;
        private Label lblLoginTitle;
        private Label lblEmail;
        private Label lblPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2GradientButton btnLogin;
        private Guna.UI2.WinForms.Guna2GradientButton btnRegister;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Button btnForgotPassword;
    }
}
