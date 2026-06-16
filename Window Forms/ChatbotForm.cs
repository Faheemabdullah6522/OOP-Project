using System.Drawing.Drawing2D;

namespace Window_Forms
{
    /// <summary>
    /// Floating chatbot window for QuasarEdu.
    /// Answers questions about the scholarship system ONLY.
    /// </summary>
    public partial class ChatbotForm : Form
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam,
            [System.Runtime.InteropServices.MarshalAs(
                System.Runtime.InteropServices.UnmanagedType.LPWStr)] string lParam);

        private const int EM_SETCUEBANNER = 0x1501;
        // ---------------------------------------------------------------
        // Singleton — only one chat window open at a time
        // ---------------------------------------------------------------
        private static ChatbotForm? _instance;

        public static void ShowChatbot(Form? owner = null)
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new ChatbotForm();
                _instance.FormClosed += (_, _) => _instance = null;
            }

            if (owner != null && !owner.IsDisposed)
            {
                // Position at the bottom-right of the owner window
                _instance.StartPosition = FormStartPosition.Manual;
                _instance.Location = new Point(
                    owner.Right  - _instance.Width  - 20,
                    owner.Bottom - _instance.Height - 50);
            }

            _instance.Show();
            _instance.BringToFront();
            _instance.txtInput.Focus();
        }

        // ---------------------------------------------------------------
        // System prompt — strictly limits the bot to QuasarEdu topics
        // ---------------------------------------------------------------
        private const string SystemPrompt = @"
You are the QuasarEdu Scholarship Assistant — an AI chatbot built into the QuasarEdu Scholarship Management System used by Pakistani university students.

Your ONLY purpose is to assist users with questions about this system. You may help with:
• How to apply for scholarships
• Understanding application status: Pending, Approved, Rejected, Withdrawn
• How to complete the student profile (required fields: CNIC, marks, address, CGPA, etc.)
• Which documents to upload (CNIC copy, domicile, income/salary proof, degree certificate, photo)
• Scholarship eligibility criteria (CGPA requirements, family income limits, degree program requirements)
• Application deadlines and timelines
• How identity verification works
• Login, password reset, and account verification issues
• Need-based vs merit-based scholarships
- Identity verification: students MUST verify their identity via fingerprint registration 
  in the Profile form before they can submit a scholarship application. 
  Without verified identity, they will not be able to apply.
- If students have any problem during identity verification, they should contact the support team (AskQuasarEdu@gmail.com) for assistance.
- Income/Salary proof: students must upload a valid document showing their family income or salary. 
  This can be a payslip, bank statement, or official letter etc from employer. 
  The document must clearly show the amount and the name of the earner. It is compulsory for need-based scholarships, and may also be required for merit-based scholarships that have income criteria.
- If students have questions about what counts as valid income/salary proof, they should contact the support team (AskQuasarEdu@gmail.com).
- After approval of need-based scholarships, students will be required to visit the QuasarEdu office in person along with PDF receipt of their scholarship application.
- If someone say hello or hi or who are you etc, tell them or greet them back but also remind them that you can only help with QuasarEdu Scholarship questions. Don't engage in general chit-chat and don't say QuasarEdu is a scholarship management system etc. Just greet and then immediately say how you can help with scholarship questions.
If a user asks about ANYTHING unrelated to this system (e.g., general knowledge, homework, coding help, weather, news, recipes, etc.), respond ONLY with:
""I'm only able to help with QuasarEdu Scholarship questions. For anything else, please reach out to the relevant organization's support desk.""

Be concise, warm, and helpful. Use simple, clear language. If the user writes in Urdu, respond in Urdu.
Do not mention that you are powered by Gemini or any other AI model.
";

        // ---------------------------------------------------------------
        // State
        // ---------------------------------------------------------------
        private readonly List<(string role, string text)> _history = new();
        private bool _isDragging;
        private Point _dragOffset;

        // ---------------------------------------------------------------
        // Constructor
        // ---------------------------------------------------------------
        public ChatbotForm()
        {
            InitializeComponent();
            this.Load += (s, e) =>
            {
                SendMessage(txtInput.Handle, EM_SETCUEBANNER, 1, "Ask about scholarships...");
            };
            AddWelcomeMessage();
        }

        // ---------------------------------------------------------------
        // Startup welcome bubble
        // ---------------------------------------------------------------
        private void AddWelcomeMessage()
        {
            AddBotBubble(
                "👋 Hi! I'm the QuasarEdu Assistant.\n\n" +
                "How can I help you today?");
        }

        // ---------------------------------------------------------------
        // SEND MESSAGE
        // ---------------------------------------------------------------
        private async void SendMessage()
        {
            string userText = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(userText)) return;

            txtInput.Clear();
            btnSend.Enabled = false;
            txtInput.Enabled = false;

            // Add user bubble
            AddUserBubble(userText);

            // Add to history
            _history.Add(("user", userText));

            // Show typing indicator
            var typingLabel = AddTypingIndicator();

            try
            {
                string reply = await GeminiService.ChatAsync(_history, SystemPrompt);

                // Remove typing indicator
                pnlMessages.Controls.Remove(typingLabel);
                typingLabel.Dispose();

                // Add bot reply
                AddBotBubble(reply);
                _history.Add(("model", reply));

                // Keep history manageable (last 20 turns = 10 exchanges)
                if (_history.Count > 20)
                    _history.RemoveRange(0, _history.Count - 20);
            }
            catch (Exception ex)
            {
                pnlMessages.Controls.Remove(typingLabel);
                typingLabel.Dispose();
                AddBotBubble($"⚠️ Error: {ex.Message}");
            }
            finally
            {
                btnSend.Enabled  = true;
                txtInput.Enabled = true;
                txtInput.Focus();
            }
        }

        // ---------------------------------------------------------------
        // BUBBLE BUILDERS
        // ---------------------------------------------------------------
        private void AddUserBubble(string text)
        {
            AddBubble(text, isUser: true);
        }

        private void AddBotBubble(string text)
        {
            AddBubble(text, isUser: false);
        }

        private void AddBubble(string text, bool isUser)
        {
            int panelWidth = pnlMessages.ClientSize.Width - 20;

            var lbl = new Label
            {
                Text = text,
                AutoSize = true,
                MaximumSize = new Size(220, 0),
                Padding = new Padding(10, 8, 10, 8),
                Font = new Font("Segoe UI", 9.5f),
                BackColor = isUser
                    ? Color.FromArgb(14, 116, 144)
                    : Color.FromArgb(241, 245, 249),
                ForeColor = isUser ? Color.White : Color.FromArgb(30, 41, 59),
                UseMnemonic = false
            };
            lbl.Paint += (s, e) =>
            {
                if (s is Label l)
                {
                    using var path = RoundedRectangle(l.ClientRectangle, 12);
                    l.Region = new Region(path);
                }
            };

            // Force AutoSize to calculate size
            lbl.Size = lbl.GetPreferredSize(new Size(220, 0));

            var time = new Label
            {
                Text = DateTime.Now.ToString("h:mm tt"),
                Font = new Font("Segoe UI", 7f),
                ForeColor = Color.FromArgb(148, 163, 184),
                AutoSize = true
            };
            time.Size = time.GetPreferredSize(Size.Empty);

            int bubbleX = isUser ? panelWidth - lbl.Width - 10 : 10;
            int timeX = isUser ? panelWidth - time.Width - 10 : 10;

            lbl.Location = new Point(bubbleX, 4);
            time.Location = new Point(timeX, lbl.Bottom + 2);

            var wrapper = new Panel
            {
                Width = panelWidth,
                Height = lbl.Height + time.Height + 12,
                BackColor = Color.Transparent
            };

            wrapper.Controls.Add(lbl);
            wrapper.Controls.Add(time);

            pnlMessages.Controls.Add(wrapper);
            ScrollToBottom();
        }

        private Label AddTypingIndicator()
        {
            var lbl = new Label
            {
                Text      = "● ● ●",
                AutoSize  = true,
                Width = pnlMessages.ClientSize.Width - 20,
                Padding   = new Padding(14, 10, 14, 10),
                Font      = new Font("Segoe UI", 10f, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 116, 139),
                BackColor = Color.Transparent
            };
            pnlMessages.Controls.Add(lbl);
            ScrollToBottom();
            return lbl;
        }

        private static GraphicsPath RoundedRectangle(Rectangle bounds, int radius)
        {
            var path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void ScrollToBottom()
        {
            if (pnlMessages.Controls.Count == 0) return;
            pnlMessages.ScrollControlIntoView(
                pnlMessages.Controls[pnlMessages.Controls.Count - 1]);
        }

        // ---------------------------------------------------------------
        // EVENT HANDLERS
        // ---------------------------------------------------------------
        private void BtnSend_Click(object sender, EventArgs e) => SendMessage();

        private void TxtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                SendMessage();
            }
        }

        private void BtnClose_Click(object sender, EventArgs e) => Close();

        private void BtnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BtnClearChat_Click(object sender, EventArgs e)
        {
            _history.Clear();
            pnlMessages.Controls.Clear();
            AddWelcomeMessage();
        }

        // ---------------------------------------------------------------
        // DRAG TO MOVE (borderless form)
        // ---------------------------------------------------------------
        private void PnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDragging = true;
                _dragOffset = e.Location;
            }
        }

        private void PnlHeader_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
                Location = new Point(
                    Left + e.X - _dragOffset.X,
                    Top  + e.Y - _dragOffset.Y);
        }

        private void PnlHeader_MouseUp(object sender, MouseEventArgs e)
        {
            _isDragging = false;
        }

        // ---------------------------------------------------------------
        // ROUNDED FORM
        // ---------------------------------------------------------------
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            using var path = RoundedRectangle(ClientRectangle, 16);
            Region = new Region(path);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (WindowState != FormWindowState.Minimized)
            {
                using var path = RoundedRectangle(ClientRectangle, 16);
                Region = new Region(path);
            }
        }
    }
}
