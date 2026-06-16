namespace Window_Forms
{
    partial class OTP
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

            pnlLeft = new Guna.UI2.WinForms.Guna2GradientPanel();
            lblQuote = new Label();
            Label lblQuote2 = new Label();
            lblAppName = new Label();
            lblTitle = new Label();
            pictureBoxLogo = new PictureBox();
            pnlRight = new Guna.UI2.WinForms.Guna2GradientPanel();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            lblFormTitle = new Label();
            lblEmail = new Label();
            lblOtp = new Label();
            txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            txtOtp = new Guna.UI2.WinForms.Guna2TextBox();
            btnVerify = new Guna.UI2.WinForms.Guna2GradientButton();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);

            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            pnlRight.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = Color.Transparent;
            pnlLeft.Controls.Add(lblQuote);
            pnlLeft.Controls.Add(lblAppName);
            pnlLeft.Controls.Add(lblTitle);
            pnlLeft.Controls.Add(lblQuote2);
            pnlLeft.Controls.Add(pictureBoxLogo);
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
            // pictureBoxLogo
            // 
            pictureBoxLogo.BackColor = Color.Transparent;
            pictureBoxLogo.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBoxLogo.Location = new Point(125, 90);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(235, 140);
            pictureBoxLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = false;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(62, 230);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(377, 47);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Security Matters";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = false;
            lblAppName.BackColor = Color.Transparent;
            lblAppName.Font = new Font("Segoe UI", 13F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location = new Point(128, 275);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(320, 25);
            lblAppName.TabIndex = 2;
            lblAppName.Text = "One-Time Password Verification";
            // 
            // lblQuote
            // 
            lblQuote.AutoSize = false;
            lblQuote.BackColor = Color.Transparent;
            lblQuote.Font = new Font("Segoe UI", 11F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblQuote.ForeColor = Color.White;
            lblQuote.Location = new Point(50, 295);
            lblQuote.Name = "lblQuote";
            lblQuote.Size = new Size(400, 200);
            lblQuote.TabIndex = 3;
            lblQuote.Text = "We're keeping your data safe. Please enter the one-time password sent to your email to\r\nverify your identity.";
            lblQuote.TextAlign = ContentAlignment.MiddleCenter;

            // lblQuote2
            lblQuote2.AutoSize = false;
            lblQuote2.BackColor = Color.Transparent;
            lblQuote2.Font = new Font("Segoe UI", 11F, FontStyle.Italic, GraphicsUnit.Point, 0);
            lblQuote2.ForeColor = Color.White;
            lblQuote2.Location = new Point(61, 470);
            lblQuote2.Name = "lblQuote2";
            lblQuote2.Size = new Size(350, 200);
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
            pnlRight.Controls.Add(lblOtp);
            pnlRight.Controls.Add(txtEmail);
            pnlRight.Controls.Add(txtOtp);
            pnlRight.Controls.Add(btnVerify);
            pnlRight.CustomizableEdges = customizableEdges3;
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.FillColor = Color.White;
            pnlRight.FillColor2 = Color.FromArgb(255, 248, 252);
            pnlRight.Location = new Point(500, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.ShadowDecoration.CustomizableEdges = customizableEdges4;
            pnlRight.Size = new Size(500, 600);
            pnlRight.TabIndex = 1;
            // 
            // btnClose
            // 
            btnClose.Animated = true;
            btnClose.BackColor = Color.Transparent;
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
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.BackColor = Color.Transparent;
            lblFormTitle.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFormTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblFormTitle.Location = new Point(50, 80);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(250, 45);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "Verify OTP";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.BackColor = Color.Transparent;
            lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.ForeColor = Color.FromArgb(71, 85, 105);
            lblEmail.Location = new Point(50, 160);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(41, 19);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
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
            txtEmail.FillColor = Color.FromArgb(255, 255, 255);
            txtEmail.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEmail.ForeColor = Color.FromArgb(100, 116, 139);
            txtEmail.Location = new Point(50, 185);
            txtEmail.Margin = new Padding(3, 4, 3, 4);
            txtEmail.Name = "txtEmail";
            txtEmail.PasswordChar = '\0';
            txtEmail.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtEmail.ReadOnly = true;
            txtEmail.SelectedText = "";
            txtEmail.Size = new Size(400, 48);
            txtEmail.TabIndex = 1;
            // 
            // lblOtp
            // 
            lblOtp.AutoSize = true;
            lblOtp.BackColor = Color.Transparent;
            lblOtp.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblOtp.ForeColor = Color.FromArgb(71, 85, 105);
            lblOtp.Location = new Point(50, 270);
            lblOtp.Name = "lblOtp";
            lblOtp.Size = new Size(71, 19);
            lblOtp.TabIndex = 1;
            lblOtp.Text = "Enter OTP";
            // 
            // txtOtp
            // 
            txtOtp.Animated = true;
            txtOtp.BackColor = Color.Transparent;
            txtOtp.BorderColor = Color.FromArgb(0, 200, 210);
            txtOtp.BorderRadius = 12;
            txtOtp.BorderThickness = 1;
            txtOtp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            txtOtp.Cursor = Cursors.IBeam;
            txtOtp.DefaultText = "";
            txtOtp.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtOtp.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtOtp.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtOtp.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtOtp.FillColor = Color.FromArgb(255, 248, 252);
            txtOtp.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtOtp.ForeColor = Color.FromArgb(15, 23, 42);
            txtOtp.HoverState.BorderColor = Color.FromArgb(6, 148, 148);
            txtOtp.IconRightSize = new Size(20, 20);
            txtOtp.Location = new Point(50, 295);
            txtOtp.Margin = new Padding(3, 4, 3, 4);
            txtOtp.MaxLength = 6;
            txtOtp.Name = "txtOtp";
            txtOtp.PasswordChar = '\0';
            txtOtp.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            txtOtp.PlaceholderText = "Enter 6-digit code";
            txtOtp.SelectedText = "";
            txtOtp.Size = new Size(400, 48);
            txtOtp.TabIndex = 2;
            // 
            // btnVerify
            // 
            btnVerify.Animated = true;
            btnVerify.AnimatedGIF = true;
            btnVerify.AutoRoundedCorners = true;
            btnVerify.BackColor = Color.Transparent;
            btnVerify.BorderRadius = 24;
            btnVerify.CustomizableEdges = customizableEdges7;
            btnVerify.DisabledState.BorderColor = Color.DarkGray;
            btnVerify.DisabledState.CustomBorderColor = Color.DarkGray;
            btnVerify.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnVerify.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnVerify.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnVerify.FillColor = Color.FromArgb(6, 148, 148);
            btnVerify.FillColor2 = Color.FromArgb(0, 240, 255);
            btnVerify.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVerify.ForeColor = Color.White;
            btnVerify.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnVerify.HoverState.FillColor = Color.FromArgb(200, 60, 130);
            btnVerify.HoverState.FillColor2 = Color.FromArgb(255, 150, 200);
            btnVerify.Location = new Point(50, 380);
            btnVerify.Name = "btnVerify";
            btnVerify.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btnVerify.Size = new Size(400, 50);
            btnVerify.TabIndex = 3;
            btnVerify.Text = "Verify";
            btnVerify.Click += btnVerify_Click;
            btnVerify.Cursor = System.Windows.Forms.Cursors.Hand;
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.BorderRadius = 24;
            guna2BorderlessForm1.HasFormShadow = true;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
            guna2BorderlessForm1.DragForm = false;
            guna2BorderlessForm1.ResizeForm = false;
            guna2BorderlessForm1.TransparentWhileDrag = false;
            // 
            // guna2DragControl1
            // 
            guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
            guna2DragControl1.TargetControl = pnlLeft;
            guna2DragControl1.UseTransparentDrag = true;
            // 
            // OTP
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 600);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            Font = new Font("Segoe UI", 9.75F);
            FormBorderStyle = FormBorderStyle.None;
            MinimumSize = new Size(1000, 600);
            Name = "OTP";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "OTP";
            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2GradientPanel pnlLeft;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlRight;
        private Label lblQuote;
        private Label lblAppName;
        private Label lblTitle;
        private PictureBox pictureBoxLogo;
        private Label lblFormTitle;
        private Label lblEmail;
        private Label lblOtp;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtOtp;
        private Guna.UI2.WinForms.Guna2GradientButton btnVerify;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}
