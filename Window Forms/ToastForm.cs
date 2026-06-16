using Guna.UI2.WinForms;

namespace Window_Forms
{
    public enum ToastType
    {
        Success,
        Error,
        Info,
        Warning
    }

    public class ToastForm : Form
    {
        private System.Windows.Forms.Timer closeTimer;

        public ToastForm(string title, string message, ToastType type, int durationMs)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.TopMost = true;
            this.ShowInTaskbar = false;
            this.Size = new Size(520, 120);
            Guna2BorderlessForm borderlessForm = new Guna2BorderlessForm();
            borderlessForm.ContainerControl = this;
            borderlessForm.BorderRadius = 25;
            borderlessForm.HasFormShadow = true;
            borderlessForm.DragForm = false;
            borderlessForm.ResizeForm = false;

            Guna2GradientPanel panel = new Guna2GradientPanel();
            panel.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel.Dock = DockStyle.Fill;
            panel.BorderRadius = 12;
            panel.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            panel.ShadowDecoration.Enabled = true;

            Color color1;
            Color color2;
            switch (type)
            {
                case ToastType.Success:
                    color1 = Color.FromArgb(16, 185, 129);
                    color2 = Color.FromArgb(5, 150, 105);
                    break;
                case ToastType.Error:
                    color1 = Color.FromArgb(239, 68, 68);
                    color2 = Color.FromArgb(220, 38, 38);
                    break;
                case ToastType.Info:
                    color1 = Color.FromArgb(59, 130, 246);
                    color2 = Color.FromArgb(37, 99, 235);
                    break;
                case ToastType.Warning:
                default:
                    color1 = Color.FromArgb(245, 158, 11);
                    color2 = Color.FromArgb(217, 119, 6);
                    break;
            }
            panel.FillColor = color1;
            panel.FillColor2 = color2;
            panel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Location = new Point(20, 14);
            lblTitle.Size = new Size(460, 35);
            lblTitle.AutoSize = false;

            Label lblMessage = new Label();
            lblMessage.Text = message;
            lblMessage.Font = new Font("Segoe UI", 10F);
            lblMessage.ForeColor = Color.White;
            lblMessage.BackColor = Color.Transparent;
            lblMessage.Location = new Point(20, 59);
            lblMessage.Size = new Size(480, 65);
            lblMessage.AutoSize = false;

            Guna2Button btnClose = new Guna2Button();
            btnClose.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnClose.Text = "X";
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.FillColor = Color.Transparent;
            btnClose.HoverState.FillColor = Color.FromArgb(255, 255, 255, 50);
            btnClose.Size = new Size(30, 30);
            btnClose.Location = new Point(480, 8);
            btnClose.Cursor = Cursors.Hand;
            btnClose.Click += BtnClose_Click;

            panel.Controls.Add(lblTitle);
            panel.Controls.Add(lblMessage);
            panel.Controls.Add(btnClose);
            this.Controls.Add(panel);

            closeTimer = new System.Windows.Forms.Timer();
            closeTimer.Interval = durationMs;
            closeTimer.Tick += CloseTimer_Tick;
            closeTimer.Start();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            closeTimer.Stop();
            this.Close();
        }

        private void CloseTimer_Tick(object sender, EventArgs e)
        {
            closeTimer.Stop();
            this.Close();
        }

        private static int _currentOffset = 0;
        private static readonly object _lock = new object();

        private static Point GetNextPosition(int toastHeight)
        {
            lock (_lock)
            {
                int margin = 12;
                int x = Screen.PrimaryScreen.WorkingArea.Right - 490;
                int y = Screen.PrimaryScreen.WorkingArea.Top + 10 + _currentOffset;
                _currentOffset += toastHeight + margin;
                return new Point(x, y);
            }
        }

        private void OnToastClosed()
        {
            lock (_lock)
            {
                _currentOffset = Math.Max(0, _currentOffset - (this.Height + 12));
            }
        }

        public static void ShowSuccess(string message)
        {
            ToastForm toast = new ToastForm("Success", message, ToastType.Success, 3000);
            toast.Location = GetNextPosition(toast.Height);
            toast.FormClosed += (s, e) => toast.OnToastClosed();
            toast.Show();
        }

        public static void ShowError(string message)
        {
            ToastForm toast = new ToastForm("Error", message, ToastType.Error, 4000);
            toast.Location = GetNextPosition(toast.Height);
            toast.FormClosed += (s, e) => toast.OnToastClosed();
            toast.Show();
        }

        public static void ShowInfo(string message)
        {
            ToastForm toast = new ToastForm("Info", message, ToastType.Info, 3000);
            toast.Location = GetNextPosition(toast.Height);
            toast.FormClosed += (s, e) => toast.OnToastClosed();
            toast.Show();
        }

        public static void ShowWarning(string message)
        {
            ToastForm toast = new ToastForm("Warning", message, ToastType.Warning, 4000);
            toast.Location = GetNextPosition(toast.Height);
            toast.FormClosed += (s, e) => toast.OnToastClosed();
            toast.Show();
        }
    }
}