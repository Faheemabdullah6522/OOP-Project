namespace Window_Forms
{
    partial class ChatbotForm
    {
        private System.ComponentModel.IContainer components = null;

        // Header controls
        private Panel   pnlHeader;
        private Label   lblTitle;
        private Label   lblSubtitle;
        private Button  btnClose;
        private Button  btnMinimize;
        private Button  btnClearChat;
        private PictureBox picIcon;

        // Messages area
        private Panel   pnlMessagesOuter;
        private FlowLayoutPanel pnlMessages;

        // Input area
        private Panel   pnlInputArea;
        private TextBox txtInput;
        private Button  btnSend;
        private Label   lblHint;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();

            // -------------------------------------------------------
            // FORM
            // -------------------------------------------------------
            this.Text            = "QuasarEdu Assistant";
            this.Size            = new Size(500, 700);
            this.MinimumSize     = new Size(500, 700);
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition   = FormStartPosition.Manual;
            this.BackColor       = Color.FromArgb(248, 250, 252);
            this.TopMost         = true;
            this.ShowInTaskbar   = false;

            // -------------------------------------------------------
            // HEADER PANEL  (teal gradient background)
            // -------------------------------------------------------
            pnlHeader = new Panel
            {
                Dock      = DockStyle.Top,
                Height    = 72,
                BackColor = Color.FromArgb(14, 116, 144),
                Padding   = new Padding(14, 10, 10, 10)
            };
            pnlHeader.MouseDown += PnlHeader_MouseDown;
            pnlHeader.MouseMove += PnlHeader_MouseMove;
            pnlHeader.MouseUp   += PnlHeader_MouseUp;

            // Bot icon circle
            picIcon = new PictureBox
            {
                Size      = new Size(40, 40),
                Location  = new Point(14, 16),
                BackColor = Color.FromArgb(8, 145, 178),
                SizeMode  = PictureBoxSizeMode.CenterImage
            };
            picIcon.Paint += (s, e) =>
            {
                // Draw a simple robot/chat icon using text
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                using var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, picIcon.Width - 1, picIcon.Height - 1);
                picIcon.Region = new Region(path);
                using var font = new Font("Segoe UI Emoji", 18f);
                var sf = new StringFormat
                {
                    Alignment     = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
                e.Graphics.DrawString("🤖", font, Brushes.White,
                    new RectangleF(0, 0, picIcon.Width, picIcon.Height), sf);
            };
            picIcon.MouseDown += PnlHeader_MouseDown;
            picIcon.MouseMove += PnlHeader_MouseMove;
            picIcon.MouseUp   += PnlHeader_MouseUp;

            // Title
            lblTitle = new Label
            {
                Text      = "QuasarEdu Assistant",
                Font      = new Font("Segoe UI Semibold", 11f, FontStyle.Bold),
                ForeColor = Color.White,
                Location  = new Point(64, 14),
                AutoSize  = true
            };
            lblTitle.MouseDown += PnlHeader_MouseDown;
            lblTitle.MouseMove += PnlHeader_MouseMove;
            lblTitle.MouseUp   += PnlHeader_MouseUp;

            // Online indicator + subtitle
            lblSubtitle = new Label
            {
                Text      = "● Online  •  Scholarship Help",
                Font      = new Font("Segoe UI", 8f),
                ForeColor = Color.FromArgb(186, 230, 253),
                Location  = new Point(64, 38),
                AutoSize  = true
            };
            lblSubtitle.MouseDown += PnlHeader_MouseDown;
            lblSubtitle.MouseMove += PnlHeader_MouseMove;
            lblSubtitle.MouseUp   += PnlHeader_MouseUp;

            // Close button
            btnClose = new Button
            {
                Text      = "✕",
                Font      = new Font("Segoe UI", 10f),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Size      = new Size(32, 32),
                Location  = new Point(454, 8),
                Cursor    = Cursors.Hand,
                TabStop   = false
            };
            btnClose.FlatAppearance.BorderSize      = 0;
            btnClose.FlatAppearance.MouseOverBackColor  = Color.FromArgb(239, 68, 68);
            btnClose.FlatAppearance.MouseDownBackColor  = Color.FromArgb(220, 38, 38);
            btnClose.Click += BtnClose_Click;

            // Minimize button
            btnMinimize = new Button
            {
                Text      = "–",
                Font      = new Font("Segoe UI", 12f),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Size      = new Size(32, 32),
                Location  = new Point(418, 8),
                Cursor    = Cursors.Hand,
                TabStop   = false
            };
            btnMinimize.FlatAppearance.BorderSize         = 0;
            btnMinimize.FlatAppearance.MouseOverBackColor = Color.FromArgb(8, 145, 178);
            btnMinimize.Click += BtnMinimize_Click;

            // Clear chat button
            btnClearChat = new Button
            {
                Text      = "🗑",
                Font      = new Font("Segoe UI", 10f),
                ForeColor = Color.FromArgb(186, 230, 253),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Size      = new Size(32, 32),
                Location  = new Point(382, 8),
                Cursor    = Cursors.Hand,
                TabStop   = false
            };
            btnClearChat.FlatAppearance.BorderSize         = 0;
            btnClearChat.FlatAppearance.MouseOverBackColor = Color.FromArgb(8, 145, 178);
            btnClearChat.Click += BtnClearChat_Click;

            pnlHeader.Controls.AddRange(new Control[]
            {
                picIcon, lblTitle, lblSubtitle,
                btnClose, btnMinimize, btnClearChat
            });

            // -------------------------------------------------------
            // MESSAGES AREA  (scrollable FlowLayoutPanel inside a Panel)
            // -------------------------------------------------------
            pnlMessagesOuter = new Panel
            {
                Dock        = DockStyle.Fill,
                BackColor   = Color.FromArgb(248, 250, 252),
                Padding     = new Padding(4, 6, 4, 6),
                AutoScroll  = false
            };

            pnlMessages = new FlowLayoutPanel
            {
                Dock           = DockStyle.Fill,
                AutoScroll     = true,
                FlowDirection  = FlowDirection.TopDown,
                WrapContents   = false,
                BackColor      = Color.Transparent,
                Padding        = new Padding(4, 6, 4, 6)
            };

            pnlMessagesOuter.Controls.Add(pnlMessages);

            // -------------------------------------------------------
            // INPUT AREA
            // -------------------------------------------------------
            pnlInputArea = new Panel
            {
                Dock      = DockStyle.Bottom,
                Height    = 80,
                BackColor = Color.White,
                Padding   = new Padding(10, 10, 10, 10)
            };

            // Top border line
            pnlInputArea.Paint += (s, e) =>
            {
                using var pen = new Pen(Color.FromArgb(226, 232, 240), 1);
                e.Graphics.DrawLine(pen, 0, 0, ((Panel)s!).Width, 0);
            };

            txtInput = new TextBox
            {
                Multiline = false,
                Font = new Font("Segoe UI", 10.3f),
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(241, 245, 249),
                ForeColor = Color.FromArgb(30, 41, 59),
                Location = new Point(22, 22),
                Size = new Size(386, 36),
            };
            txtInput.KeyDown += TxtInput_KeyDown;

            // Rounded background for input
            txtInput.Paint += (s, e) =>
            {
                // handled via BackColor + parent rounding
            };

            btnSend = new Button
            {
                Text      = "➤",
                Font      = new Font("Segoe UI", 13f, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(14, 116, 144),
                FlatStyle = FlatStyle.Flat,
                Size = new Size(52, 45),
                Location = new Point(434, 14),
                Cursor    = Cursors.Hand,
                TabStop   = false,
                TextAlign = ContentAlignment.MiddleCenter,
                Padding = new Padding(0)
            };
            btnSend.FlatAppearance.BorderSize         = 0;
            btnSend.FlatAppearance.MouseOverBackColor = Color.FromArgb(8, 145, 178);
            btnSend.FlatAppearance.MouseDownBackColor = Color.FromArgb(7, 89, 133);
            btnSend.Click += BtnSend_Click;

            // Round the send button
            btnSend.Paint += (s, e) =>
            {
                if (s is Button b)
                {
                    using var path = new System.Drawing.Drawing2D.GraphicsPath();
                    path.AddEllipse(0, 0, b.Width - 1, b.Height - 1);
                    b.Region = new Region(path);
                }
            };

            lblHint = new Label
            {
                Text      = "Press Enter to send",
                Font      = new Font("Segoe UI", 7.5f, FontStyle.Italic),
                ForeColor = Color.FromArgb(148, 163, 184),
                Location  = new Point(10, 44),
                AutoSize  = true
            };
            lblHint.Visible = false;

            pnlInputArea.Controls.AddRange(new Control[]
            {
                txtInput, btnSend, lblHint
            });

            // -------------------------------------------------------
            // ASSEMBLE FORM
            // -------------------------------------------------------
            this.Controls.Add(pnlMessagesOuter);
            this.Controls.Add(pnlHeader);
            this.Controls.Add(pnlInputArea);
        }
    }
}
