namespace Window_Forms
{
    partial class Loading
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            lblPercent = new System.Windows.Forms.Label();
            progressBar1 = new Guna.UI2.WinForms.Guna2ProgressBar();
            lblVersion = new System.Windows.Forms.Label();
            lblQuote = new System.Windows.Forms.Label();
            pictureBoxLogo = new System.Windows.Forms.PictureBox();
            lblTitle = new System.Windows.Forms.Label();
            timer1 = new System.Windows.Forms.Timer(components);
            lblAppName = new System.Windows.Forms.Label();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
            guna2GradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            //
            // guna2GradientPanel1
            //
            guna2GradientPanel1.BackColor = System.Drawing.Color.Transparent;
            guna2GradientPanel1.Controls.Add(lblPercent);
            guna2GradientPanel1.Controls.Add(progressBar1);
            guna2GradientPanel1.Controls.Add(lblVersion);
            guna2GradientPanel1.Controls.Add(lblQuote);
            guna2GradientPanel1.Controls.Add(pictureBoxLogo);
            guna2GradientPanel1.Controls.Add(lblTitle);
            guna2GradientPanel1.Controls.Add(lblAppName);
            guna2GradientPanel1.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2GradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(6, 148, 148);
            guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(0, 240, 255);
            guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            guna2GradientPanel1.Name = "guna2GradientPanel1";
            guna2GradientPanel1.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            guna2GradientPanel1.Size = new System.Drawing.Size(650, 550);
            guna2GradientPanel1.TabIndex = 0;
            //
            // pictureBoxLogo
            //
            pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            pictureBoxLogo.Image = (System.Drawing.Image)resources.GetObject("pictureBox3.Image");
            pictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBoxLogo.Location = new System.Drawing.Point(206, 80);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new System.Drawing.Size(235, 140);
            pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBoxLogo.TabIndex = 0;
            pictureBoxLogo.TabStop = false;
            //
            // lblTitle
            //
            lblTitle.AutoSize = false;
            lblTitle.BackColor = System.Drawing.Color.Transparent;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(40, 210);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(570, 45);
            lblTitle.Text = "QuasarEdu";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblQuote
            //
            lblQuote.AutoSize = false;
            lblQuote.BackColor = System.Drawing.Color.Transparent;
            lblQuote.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Italic);
            lblQuote.ForeColor = System.Drawing.Color.FromArgb(255, 210, 225);
            lblQuote.Location = new System.Drawing.Point(60, 318);
            lblQuote.Name = "lblQuote";
            lblQuote.Size = new System.Drawing.Size(530, 60);
            lblQuote.Text = "© 2026 QuasarEdu | Powered By Project QuasarX\r\nAll Rights Reserved";
            lblQuote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblAppName
            lblAppName.AutoSize = false;
            lblAppName.BackColor = System.Drawing.Color.Transparent;
            lblAppName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            lblAppName.ForeColor = System.Drawing.Color.FromArgb(255, 210, 225);
            lblAppName.Location = new System.Drawing.Point(262, 258);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new System.Drawing.Size(295, 20);
            lblAppName.TabIndex = 2;
            lblAppName.Text = "By Project QuasarX";

            // progressBar1
            progressBar1.BackColor = System.Drawing.Color.Transparent;
            progressBar1.BorderRadius = 8;
            progressBar1.FillColor = System.Drawing.Color.FromArgb(70, 160, 220);
            progressBar1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            progressBar1.ForeColor = System.Drawing.Color.White;
            progressBar1.Location = new System.Drawing.Point(60, 385);
            progressBar1.Maximum = 100;
            progressBar1.Minimum = 0;
            progressBar1.Name = "progressBar1";
            progressBar1.ProgressColor = System.Drawing.Color.FromArgb(255, 255, 255);
            progressBar1.ProgressColor2 = System.Drawing.Color.FromArgb(255, 210, 225);
            progressBar1.Size = new System.Drawing.Size(530, 24);
            progressBar1.TabIndex = 1;

            //
            // lblPercent
            //
            lblPercent.AutoSize = false;
            lblPercent.BackColor = System.Drawing.Color.Transparent;
            lblPercent.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblPercent.ForeColor = System.Drawing.Color.White;
            lblPercent.Location = new System.Drawing.Point(60, 410);
            lblPercent.Name = "lblPercent";
            lblPercent.Size = new System.Drawing.Size(530, 30);
            lblPercent.Text = "0%";
            lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            //
            // lblVersion
            //
            lblVersion.AutoSize = true;
            lblVersion.BackColor = System.Drawing.Color.Transparent;
            lblVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular);
            lblVersion.ForeColor = System.Drawing.Color.FromArgb(255, 210, 225);
            lblVersion.Location = new System.Drawing.Point(540, 520);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new System.Drawing.Size(90, 20);
            lblVersion.Text = "Ver 1.0";
            lblVersion.Visible = false;
            //
            // timer1
            //
            timer1.Interval = 100;
            timer1.Tick += timer1_Tick_1;
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
            guna2DragControl1.TargetControl = guna2GradientPanel1;
            guna2DragControl1.UseTransparentDrag = true;
            //
            // Loading
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(6, 148, 148);
            ClientSize = new System.Drawing.Size(650, 550);
            Controls.Add(guna2GradientPanel1);
            Font = new System.Drawing.Font("Segoe UI", 9.75F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MinimumSize = new System.Drawing.Size(650, 550);
            Name = "Loading";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Loading";
            Load += Form1_Load;
            guna2GradientPanel1.ResumeLayout(false);
            guna2GradientPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2ProgressBar progressBar1;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblQuote;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblAppName;
    }
}
