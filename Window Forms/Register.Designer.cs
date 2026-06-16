namespace Window_Forms
{
    partial class Register
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Register));
            pnlLeft = new Guna.UI2.WinForms.Guna2GradientPanel();
            lblQuote = new Label();
            Label lblQuote2 = new Label();
            lblAppName = new Label();
            lblTitle = new Label();
            pnlRight = new Guna.UI2.WinForms.Guna2GradientPanel();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            lblFormTitle = new Label();
            lblEmail = new Label();
            lblPassword = new Label();
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            btnRegister = new Guna.UI2.WinForms.Guna2GradientButton();
            btnLogin = new Guna.UI2.WinForms.Guna2GradientButton();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
            pictureBox1 = new PictureBox();
            pnlLeft.SuspendLayout();
            pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.Transparent;
            pnlLeft.Controls.Add(pictureBox1);
            pnlLeft.Controls.Add(lblQuote);
            pnlLeft.Controls.Add(lblQuote2);
            pnlLeft.Controls.Add(lblAppName);
            pnlLeft.Controls.Add(lblTitle);
            pnlLeft.CustomizableEdges = customizableEdges1;
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.FillColor = Color.FromArgb(6, 148, 148);
            pnlLeft.FillColor2 = Color.FromArgb(0, 240, 255);
            pnlLeft.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.ShadowDecoration.CustomizableEdges = customizableEdges2;
            pnlLeft.Size = new Size(500, 600);
            pnlLeft.TabIndex = 0;
            // 
            // lblQuote
            // 
            lblQuote.AutoSize = false;
            lblQuote.BackColor = Color.Transparent;
            lblQuote.Font = new Font("Segoe UI", 11F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblQuote.ForeColor = Color.White;
            lblQuote.Location = new Point(53, 345);
            lblQuote.Name = "lblQuote";
            lblQuote.Size = new Size(380, 45);
            lblQuote.TabIndex = 3;
            lblQuote.Text = "\"Make things easy and do not make them difficult\"\r\nProphet Muhammad ﷺ";
            lblQuote.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = false;
            lblAppName.BackColor = Color.Transparent;
            lblAppName.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAppName.ForeColor = Color.FromArgb(255, 210, 225);
            lblAppName.Location = new Point(122, 260);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(270, 100);
            lblAppName.TabIndex = 2;
            lblAppName.Text = "Create your account in Seconds !";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = false;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(50, 210);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(400, 45);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Start Your Journey";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // lblQuote2
            lblQuote2.AutoSize = false;
            lblQuote2.BackColor = Color.Transparent;
            lblQuote2.Font = new Font("Segoe UI", 11F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblQuote2.ForeColor = Color.White;
            lblQuote2.Location = new Point(61, 440);
            lblQuote2.Name = "lblQuote2";
            lblQuote2.Size = new Size(350, 100);
            lblQuote2.TabIndex = 3;
            lblQuote2.Text = "© 2026 QuasarEdu | Powered By Project QuasarX\r\nAll Rights Reserved";
            lblQuote2.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // pnlRight
            // 
            pnlRight.BackColor = Color.Transparent;
            pnlRight.Controls.Add(btnClose);
            pnlRight.Controls.Add(lblFormTitle);
            pnlRight.Controls.Add(lblEmail);
            pnlRight.Controls.Add(lblPassword);
            pnlRight.Controls.Add(txtEmail);
            pnlRight.Controls.Add(txtPassword);
            pnlRight.Controls.Add(btnRegister);
            pnlRight.Controls.Add(btnLogin);
            pnlRight.CustomizableEdges = customizableEdges11;
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.FillColor = Color.White;
            pnlRight.FillColor2 = Color.FromArgb(255, 248, 252);
            pnlRight.Location = new Point(500, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.ShadowDecoration.CustomizableEdges = customizableEdges12;
            pnlRight.Size = new Size(500, 600);
            pnlRight.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Animated = true;
            btnClose.BackColor = Color.Transparent;
            btnClose.CustomizableEdges = customizableEdges3;
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
            btnClose.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnClose.Size = new Size(38, 38);
            btnClose.TabIndex = 4;
            btnClose.Text = "X";
            btnClose.Click += BtnClose_Click;
            btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.BackColor = Color.Transparent;
            lblFormTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFormTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblFormTitle.Location = new Point(50, 80);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(170, 54);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Sign Up";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.FromArgb(71, 85, 105);
            lblEmail.Location = new Point(50, 160);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(54, 23);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.BackColor = Color.Transparent;
            lblPassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPassword.ForeColor = Color.FromArgb(71, 85, 105);
            lblPassword.Location = new Point(50, 260);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(85, 23);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // txtEmail
            // 
            txtEmail.Animated = true;
            txtEmail.BackColor = Color.Transparent;
            txtEmail.BorderColor = Color.FromArgb(0, 200, 210);
            txtEmail.BorderRadius = 12;
            txtEmail.Cursor = Cursors.IBeam;
            txtEmail.CustomizableEdges = customizableEdges5;
            txtEmail.DefaultText = "";
            txtEmail.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtEmail.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtEmail.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtEmail.FillColor = Color.FromArgb(255, 248, 252);
            txtEmail.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.ForeColor = Color.FromArgb(15, 23, 42);
            txtEmail.HoverState.BorderColor = Color.FromArgb(6, 148, 148);
            txtEmail.Location = new Point(50, 185);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtEmail.PlaceholderText = "you@example.com";
            txtEmail.SelectedText = "";
            txtEmail.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtEmail.Size = new Size(400, 48);
            txtEmail.TabIndex = 2;
            // 
            // txtPassword
            // 
            txtPassword.Animated = true;
            txtPassword.BackColor = Color.Transparent;
            txtPassword.BorderColor = Color.FromArgb(0, 200, 210);
            txtPassword.BorderRadius = 12;
            txtPassword.Cursor = Cursors.IBeam;
            txtPassword.CustomizableEdges = customizableEdges7;
            txtPassword.DefaultText = "";
            txtPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPassword.FillColor = Color.FromArgb(255, 248, 252);
            txtPassword.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtPassword.HoverState.BorderColor = Color.FromArgb(6, 148, 148);
            txtPassword.Location = new Point(50, 285);
            txtPassword.Margin = new Padding(3, 4, 3, 4);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '?';
            txtPassword.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtPassword.PlaceholderText = "Create a password";
            txtPassword.SelectedText = "";
            txtPassword.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtPassword.Size = new Size(400, 48);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            btnRegister.Animated = true;
            btnRegister.AutoRoundedCorners = true;
            btnRegister.BackColor = Color.Transparent;
            btnRegister.BorderRadius = 24;
            btnRegister.CustomizableEdges = customizableEdges9;
            btnRegister.DisabledState.BorderColor = Color.DarkGray;
            btnRegister.DisabledState.CustomBorderColor = Color.DarkGray;
            btnRegister.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnRegister.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnRegister.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnRegister.FillColor = Color.FromArgb(6, 148, 148);
            btnRegister.FillColor2 = Color.FromArgb(0, 240, 255);
            btnRegister.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRegister.ForeColor = Color.White;
            btnRegister.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnRegister.HoverState.FillColor = Color.FromArgb(200, 60, 130);
            btnRegister.HoverState.FillColor2 = Color.FromArgb(255, 150, 200);
            btnRegister.Location = new Point(50, 370);
            btnRegister.Name = "btnRegister";
            btnRegister.ShadowDecoration.Color = Color.FromArgb(6, 148, 148, 80);
            btnRegister.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnRegister.ShadowDecoration.Enabled = false;
            btnRegister.ShadowDecoration.Shadow = new Padding(0, 0, 8, 8);
            btnRegister.Size = new Size(400, 50);
            btnRegister.TabIndex = 5;
            btnRegister.Text = "Create Account";
            btnRegister.Click += btnRegister_Click;
            btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            // 
            // btnLogin
            // 
            btnLogin.Animated = true;
            btnLogin.AutoRoundedCorners = true;
            btnLogin.BackColor = Color.Transparent;
            btnLogin.BorderColor = Color.FromArgb(0, 200, 210);
            btnLogin.BorderRadius = 24;
            btnLogin.BorderThickness = 1;
            btnLogin.CustomizableEdges = customizableEdges9;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.FillColor = Color.Transparent;
            btnLogin.FillColor2 = Color.Transparent;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.FromArgb(71, 85, 105);
            btnLogin.HoverState.BorderColor = Color.FromArgb(6, 148, 148);
            btnLogin.HoverState.FillColor = Color.FromArgb(255, 248, 252);
            btnLogin.HoverState.FillColor2 = Color.FromArgb(255, 248, 252);
            btnLogin.HoverState.ForeColor = Color.FromArgb(6, 148, 148);
            btnLogin.Location = new Point(50, 435);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges10;
            btnLogin.Size = new Size(400, 50);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Sign In";
            btnLogin.Click += btnLogin_Click;
            btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.BorderRadius = 24;
            guna2BorderlessForm1.HasFormShadow = true;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.DragForm = false;
            guna2BorderlessForm1.ResizeForm = false;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2DragControl1
            // 
            guna2DragControl1.DockIndicatorTransparencyValue = 0.6D;
            guna2DragControl1.TargetControl = pnlLeft;
            guna2DragControl1.UseTransparentDrag = true;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(125, 80);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(235, 140);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 520);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Font = new Font("Segoe UI", 9.75F);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(1000, 520);
            Name = "Register";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2GradientPanel pnlLeft;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlRight;
        private Label lblQuote;
        private Label lblAppName;
        private Label lblTitle;
        private Label lblFormTitle;
        private Label lblEmail;
        private Label lblPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private Guna.UI2.WinForms.Guna2GradientButton btnRegister;
        private Guna.UI2.WinForms.Guna2GradientButton btnLogin;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private PictureBox pictureBox1;
    }
}
