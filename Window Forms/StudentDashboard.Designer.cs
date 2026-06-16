namespace Window_Forms
{
    partial class StudentDashboard
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
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle rowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle altRowStyle = new System.Windows.Forms.DataGridViewCellStyle();

            dgvScholarships = new System.Windows.Forms.DataGridView();
            pnlHeader = new System.Windows.Forms.Panel();
            pnlGrid = new System.Windows.Forms.Panel();
            btnProfile = new Guna.UI2.WinForms.Guna2GradientButton();
            btnApply = new Guna.UI2.WinForms.Guna2GradientButton();
            btnSaveForLater = new Guna.UI2.WinForms.Guna2GradientButton();
            btnDownloadReceipt = new Guna.UI2.WinForms.Guna2GradientButton();
            btnMyApplications = new Guna.UI2.WinForms.Guna2GradientButton();
            btnNotifications = new Guna.UI2.WinForms.Guna2GradientButton();
            btnRefresh = new Guna.UI2.WinForms.Guna2GradientButton();
            btnLogout = new Guna.UI2.WinForms.Guna2GradientButton();
            lblWelcome = new System.Windows.Forms.Label();
            lblSubtitle = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)dgvScholarships).BeginInit();
            pnlHeader.SuspendLayout();
            pnlGrid.SuspendLayout();
            SuspendLayout();

            // dgvScholarships - Modern styled DataGridView
            dgvScholarships.AllowUserToAddRows = false;
            dgvScholarships.AllowUserToResizeRows = false;
            altRowStyle.BackColor = System.Drawing.Color.FromArgb(255, 248, 252);
            dgvScholarships.AlternatingRowsDefaultCellStyle = altRowStyle;
            dgvScholarships.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvScholarships.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvScholarships.BackgroundColor = System.Drawing.Color.White;
            dgvScholarships.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvScholarships.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            dgvScholarships.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(6, 148, 148);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            headerStyle.SelectionBackColor = System.Drawing.Color.FromArgb(6, 148, 148);
            headerStyle.SelectionForeColor = System.Drawing.Color.White;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvScholarships.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvScholarships.ColumnHeadersHeight = 65;
            dgvScholarships.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvScholarships.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvScholarships.EnableHeadersVisualStyles = false;
            dgvScholarships.GridColor = System.Drawing.Color.FromArgb(150, 200, 210);
            dgvScholarships.Location = new System.Drawing.Point(0, 0);
            dgvScholarships.MultiSelect = false;
            dgvScholarships.Name = "dgvScholarships";
            dgvScholarships.ReadOnly = true;
            dgvScholarships.RowHeadersVisible = false;
            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            rowStyle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            rowStyle.Padding = new System.Windows.Forms.Padding(12, 8, 12, 8);
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 210, 225);
            rowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            rowStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvScholarships.RowsDefaultCellStyle = rowStyle;
            dgvScholarships.RowTemplate.Height = 48;
            dgvScholarships.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvScholarships.Size = new System.Drawing.Size(1096, 430);
            dgvScholarships.TabIndex = 0;
            dgvScholarships.CellFormatting += DgvScholarships_CellFormatting;

            // pnlGrid - White card for the grid
            pnlGrid.BackColor = System.Drawing.Color.White;
            pnlGrid.Controls.Add(dgvScholarships);
            pnlGrid.Location = new System.Drawing.Point(40, 100);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Padding = new System.Windows.Forms.Padding(0);
            pnlGrid.Size = new System.Drawing.Size(1120, 440);
            pnlGrid.TabIndex = 1;
            pnlGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // btnProfile
            btnProfile.Animated = true;
            btnProfile.AutoRoundedCorners = true;
            btnProfile.BackColor = System.Drawing.Color.Transparent;
            btnProfile.BorderRadius = 20;
            btnProfile.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnProfile.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnProfile.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnProfile.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnProfile.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnProfile.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnProfile.FillColor = System.Drawing.Color.FromArgb(6, 148, 148);
            btnProfile.FillColor2 = System.Drawing.Color.FromArgb(255, 150, 200);
            btnProfile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnProfile.ForeColor = System.Drawing.Color.White;
            btnProfile.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnProfile.HoverState.FillColor = System.Drawing.Color.FromArgb(200, 60, 130);
            btnProfile.HoverState.FillColor2 = System.Drawing.Color.FromArgb(220, 90, 160);
            btnProfile.Location = new System.Drawing.Point(30, 550);
            btnProfile.Name = "btnProfile";
            btnProfile.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnProfile.ShadowDecoration.Enabled = false;
            btnProfile.ShadowDecoration.Color = System.Drawing.Color.FromArgb(80, 6, 148, 148);
            btnProfile.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            btnProfile.Size = new System.Drawing.Size(140, 44);
            btnProfile.TabIndex = 2;
            btnProfile.Text = "My Profile";
            btnProfile.Click += BtnProfile_Click;
            btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            // btnApply
            btnApply.Animated = true;
            btnApply.AutoRoundedCorners = true;
            btnApply.BackColor = System.Drawing.Color.Transparent;
            btnApply.BorderRadius = 20;
            btnApply.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnApply.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnApply.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnApply.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnApply.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnApply.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnApply.FillColor = System.Drawing.Color.FromArgb(220, 53, 69);
            btnApply.FillColor2 = System.Drawing.Color.FromArgb(245, 101, 101);
            btnApply.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnApply.ForeColor = System.Drawing.Color.White;
            btnApply.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnApply.HoverState.FillColor = System.Drawing.Color.FromArgb(200, 30, 40);
            btnApply.HoverState.FillColor2 = System.Drawing.Color.FromArgb(220, 70, 70);
            btnApply.Location = new System.Drawing.Point(186, 550);
            btnApply.Name = "btnApply";
            btnApply.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnApply.ShadowDecoration.Enabled = false;
            btnApply.ShadowDecoration.Color = System.Drawing.Color.FromArgb(80, 220, 53, 69);
            btnApply.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            btnApply.Size = new System.Drawing.Size(130, 44);
            btnApply.TabIndex = 3;
            btnApply.Text = "Apply Now";
            btnApply.Click += BtnApply_Click;
            btnApply.Cursor = System.Windows.Forms.Cursors.Hand;
            // btnSaveForLater
            btnSaveForLater.Animated = true;
            btnSaveForLater.AutoRoundedCorners = true;
            btnSaveForLater.BackColor = System.Drawing.Color.Transparent;
            btnSaveForLater.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            btnSaveForLater.BorderRadius = 20;
            btnSaveForLater.BorderThickness = 1;
            btnSaveForLater.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnSaveForLater.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnSaveForLater.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnSaveForLater.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnSaveForLater.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnSaveForLater.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnSaveForLater.FillColor = System.Drawing.Color.White;
            btnSaveForLater.FillColor2 = System.Drawing.Color.White;
            btnSaveForLater.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnSaveForLater.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnSaveForLater.Location = new System.Drawing.Point(332, 550);
            btnSaveForLater.Name = "btnSaveForLater";
            btnSaveForLater.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnSaveForLater.Size = new System.Drawing.Size(150, 44);
            btnSaveForLater.TabIndex = 4;
            btnSaveForLater.Text = "Save for Later";
            btnSaveForLater.Click += BtnSaveForLater_Click;
            btnSaveForLater.Cursor = System.Windows.Forms.Cursors.Hand;
            // btnDownloadReceipt
            btnDownloadReceipt.Animated = true;
            btnDownloadReceipt.AutoRoundedCorners = true;
            btnDownloadReceipt.BackColor = System.Drawing.Color.Transparent;
            btnDownloadReceipt.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            btnDownloadReceipt.BorderRadius = 20;
            btnDownloadReceipt.BorderThickness = 1;
            btnDownloadReceipt.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnDownloadReceipt.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnDownloadReceipt.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnDownloadReceipt.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnDownloadReceipt.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnDownloadReceipt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnDownloadReceipt.FillColor = System.Drawing.Color.White;
            btnDownloadReceipt.FillColor2 = System.Drawing.Color.White;
            btnDownloadReceipt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnDownloadReceipt.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnDownloadReceipt.Location = new System.Drawing.Point(498, 550);
            btnDownloadReceipt.Name = "btnDownloadReceipt";
            btnDownloadReceipt.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnDownloadReceipt.Size = new System.Drawing.Size(150, 44);
            btnDownloadReceipt.TabIndex = 5;
            btnDownloadReceipt.Text = "PDF Receipt";
            btnDownloadReceipt.Click += BtnDownloadReceipt_Click;
            btnDownloadReceipt.Cursor = System.Windows.Forms.Cursors.Hand;
            // btnMyApplications
            btnMyApplications.Animated = true;
            btnMyApplications.AutoRoundedCorners = true;
            btnMyApplications.BackColor = System.Drawing.Color.Transparent;
            btnMyApplications.BorderRadius = 20;
            btnMyApplications.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnMyApplications.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnMyApplications.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnMyApplications.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnMyApplications.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnMyApplications.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnMyApplications.FillColor = System.Drawing.Color.FromArgb(255, 193, 7);
            btnMyApplications.FillColor2 = System.Drawing.Color.FromArgb(255, 213, 79);
            btnMyApplications.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnMyApplications.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            btnMyApplications.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnMyApplications.HoverState.FillColor = System.Drawing.Color.FromArgb(230, 170, 0);
            btnMyApplications.HoverState.FillColor2 = System.Drawing.Color.FromArgb(240, 190, 50);
            btnMyApplications.Location = new System.Drawing.Point(664, 550);
            btnMyApplications.Name = "btnMyApplications";
            btnMyApplications.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnMyApplications.ShadowDecoration.Enabled = false;
            btnMyApplications.ShadowDecoration.Color = System.Drawing.Color.FromArgb(80, 255, 193, 7);
            btnMyApplications.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            btnMyApplications.Size = new System.Drawing.Size(180, 44);
            btnMyApplications.TabIndex = 6;
            btnMyApplications.Text = "My Applications";
            btnMyApplications.Click += BtnMyApplications_Click;
            btnMyApplications.Cursor = System.Windows.Forms.Cursors.Hand;
            // btnNotifications
            btnNotifications.Animated = true;
            btnNotifications.AutoRoundedCorners = true;
            btnNotifications.BackColor = System.Drawing.Color.Transparent;
            btnNotifications.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            btnNotifications.BorderRadius = 20;
            btnNotifications.BorderThickness = 1;
            btnNotifications.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnNotifications.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnNotifications.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnNotifications.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnNotifications.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnNotifications.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnNotifications.FillColor = System.Drawing.Color.White;
            btnNotifications.FillColor2 = System.Drawing.Color.White;
            btnNotifications.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnNotifications.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnNotifications.Location = new System.Drawing.Point(860, 550);
            btnNotifications.Name = "btnNotifications";
            btnNotifications.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnNotifications.Size = new System.Drawing.Size(130, 44);
            btnNotifications.TabIndex = 7;
            btnNotifications.Text = "Notifications";
            btnNotifications.Click += BtnNotifications_Click;
            btnNotifications.Cursor = System.Windows.Forms.Cursors.Hand;
            // btnRefresh
            btnRefresh.Animated = true;
            btnRefresh.AutoRoundedCorners = true;
            btnRefresh.BackColor = System.Drawing.Color.Transparent;
            btnRefresh.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            btnRefresh.BorderRadius = 20;
            btnRefresh.BorderThickness = 1;
            btnRefresh.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnRefresh.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnRefresh.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnRefresh.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnRefresh.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnRefresh.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnRefresh.FillColor = System.Drawing.Color.White;
            btnRefresh.FillColor2 = System.Drawing.Color.White;
            btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnRefresh.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnRefresh.Location = new System.Drawing.Point(1006, 550);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnRefresh.Size = new System.Drawing.Size(120, 44);
            btnRefresh.TabIndex = 8;
            btnRefresh.Text = "Refresh";
            btnRefresh.Click += BtnRefresh_Click;
            btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            // btnLogout
            btnLogout.Animated = true;
            btnLogout.AutoRoundedCorners = true;
            btnLogout.BackColor = System.Drawing.Color.Transparent;
            btnLogout.BorderRadius = 18;
            btnLogout.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnLogout.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnLogout.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnLogout.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnLogout.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnLogout.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnLogout.FillColor = System.Drawing.Color.FromArgb(220, 53, 69);
            btnLogout.FillColor2 = System.Drawing.Color.FromArgb(245, 101, 101);
            btnLogout.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnLogout.ForeColor = System.Drawing.Color.White;
            btnLogout.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnLogout.Location = new System.Drawing.Point(1070, 20);
            btnLogout.Name = "btnLogout";
            btnLogout.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnLogout.ShadowDecoration.Enabled = false;
            btnLogout.Size = new System.Drawing.Size(100, 36);
            btnLogout.TabIndex = 0;
            btnLogout.Text = "Logout";
            btnLogout.Click += BtnLogout_Click;
            btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            // lblWelcome
            lblWelcome.BackColor = System.Drawing.Color.Transparent;
            lblWelcome.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblWelcome.ForeColor = System.Drawing.Color.White;
            lblWelcome.Location = new System.Drawing.Point(30, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new System.Drawing.Size(600, 38);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome back!";

            // lblSubtitle
            lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(255, 210, 225);
            lblSubtitle.Location = new System.Drawing.Point(32, 58);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new System.Drawing.Size(600, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Browse and apply for scholarships that match your profile.";

            // pnlHeader - Gradient header
            pnlHeader.BackColor = System.Drawing.Color.FromArgb(6, 148, 148);
            pnlHeader.Controls.Add(btnLogout);
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(1200, 85);
            pnlHeader.TabIndex = 10;

            // toolTip1
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Hint";
            toolTip1.SetToolTip(btnProfile, "View and edit your student profile");
            toolTip1.SetToolTip(btnApply, "Apply for the selected scholarship");
            toolTip1.SetToolTip(btnSaveForLater, "Save this scholarship for later review");
            toolTip1.SetToolTip(btnDownloadReceipt, "Download a PDF receipt for your application");
            toolTip1.SetToolTip(btnMyApplications, "View all your submitted applications");
            toolTip1.SetToolTip(btnNotifications, "View your notifications");
            toolTip1.SetToolTip(btnRefresh, "Refresh the scholarship list");
            toolTip1.SetToolTip(btnLogout, "Sign out of your account");

            // guna2BorderlessForm1
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.BorderRadius = 24;
            guna2BorderlessForm1.HasFormShadow = true;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6;
            guna2BorderlessForm1.DragForm = false;
            guna2BorderlessForm1.ResizeForm = false;

            // guna2DragControl1
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
            guna2DragControl1.DockIndicatorTransparencyValue = 0.6;
            guna2DragControl1.TargetControl = pnlHeader;
            guna2DragControl1.UseTransparentDrag = true;

            // StudentDashboard
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            ClientSize = new System.Drawing.Size(1200, 620);
            Controls.Add(pnlHeader);
            Controls.Add(btnNotifications);
            Controls.Add(btnMyApplications);
            Controls.Add(btnDownloadReceipt);
            Controls.Add(btnSaveForLater);
            Controls.Add(btnApply);
            Controls.Add(btnProfile);
            Controls.Add(btnRefresh);
            Controls.Add(pnlGrid);
            Font = new System.Drawing.Font("Segoe UI", 9.75F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MinimumSize = new System.Drawing.Size(1200, 620);
            Name = "StudentDashboard";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Student Dashboard";
            Load += StudentDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dgvScholarships).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlGrid.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvScholarships;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubtitle;
        private Guna.UI2.WinForms.Guna2GradientButton btnProfile;
        private Guna.UI2.WinForms.Guna2GradientButton btnApply;
        private Guna.UI2.WinForms.Guna2GradientButton btnSaveForLater;
        private Guna.UI2.WinForms.Guna2GradientButton btnDownloadReceipt;
        private Guna.UI2.WinForms.Guna2GradientButton btnMyApplications;
        private Guna.UI2.WinForms.Guna2GradientButton btnNotifications;
        private Guna.UI2.WinForms.Guna2GradientButton btnRefresh;
        private Guna.UI2.WinForms.Guna2GradientButton btnLogout;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
