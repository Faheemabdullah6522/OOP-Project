namespace Window_Forms
{
    partial class ApproveRejectForm
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
            dgvApps = new System.Windows.Forms.DataGridView();
            btnApprove = new Guna.UI2.WinForms.Guna2GradientButton();
            btnReject = new Guna.UI2.WinForms.Guna2GradientButton();
            btnViewDocs = new Guna.UI2.WinForms.Guna2GradientButton();
            btnViewProfile = new Guna.UI2.WinForms.Guna2GradientButton();
            btnDownloadReceipt = new Guna.UI2.WinForms.Guna2GradientButton();
            lblSubtitle = new System.Windows.Forms.Label();
            pnlGrid = new System.Windows.Forms.Panel();
            pnlHeader = new Guna.UI2.WinForms.Guna2GradientPanel();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            lblHeaderTitle = new System.Windows.Forms.Label();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
            ((System.ComponentModel.ISupportInitialize)dgvApps).BeginInit();
            pnlGrid.SuspendLayout();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            //
            // pnlHeader
            //
            pnlHeader.BackColor = System.Drawing.Color.Transparent;
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(lblHeaderTitle);
            pnlHeader.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.FillColor = System.Drawing.Color.FromArgb(6, 148, 148);
            pnlHeader.FillColor2 = System.Drawing.Color.FromArgb(0, 240, 255);
            pnlHeader.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlHeader.Size = new System.Drawing.Size(1120, 85);
            pnlHeader.TabIndex = 0;
            //
            // btnClose
            //
            btnClose.Animated = true;
            btnClose.BackColor = System.Drawing.Color.Transparent;
            btnClose.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnClose.FillColor = System.Drawing.Color.Transparent;
            btnClose.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            btnClose.ForeColor = System.Drawing.Color.FromArgb(255, 210, 225);
            btnClose.HoverState.FillColor = System.Drawing.Color.FromArgb(254, 226, 226);
            btnClose.HoverState.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            btnClose.Location = new System.Drawing.Point(1070, 18);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnClose.Size = new System.Drawing.Size(36, 36);
            btnClose.TabIndex = 1;
            btnClose.Text = "X";
            btnClose.Click += BtnClose_Click;
            btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // lblHeaderTitle
            //
            lblHeaderTitle.AutoSize = false;
            lblHeaderTitle.BackColor = System.Drawing.Color.Transparent;
            lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            lblHeaderTitle.Location = new System.Drawing.Point(35, 23);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new System.Drawing.Size(450, 60);
            lblHeaderTitle.Text = "Pending Applications";
            //
            // lblSubtitle
            //
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new System.Drawing.Point(39, 93);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new System.Drawing.Size(680, 24);
            lblSubtitle.Text = "Review student details, print documents, and export application receipts.";
            //
            // pnlGrid
            //
            pnlGrid.BackColor = System.Drawing.Color.White;
            pnlGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlGrid.Controls.Add(dgvApps);
            pnlGrid.Location = new System.Drawing.Point(32, 118);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Padding = new System.Windows.Forms.Padding(14);
            pnlGrid.Size = new System.Drawing.Size(1056, 430);
            pnlGrid.TabIndex = 1;
            //
            // dgvApps
            //
            dgvApps.AllowUserToAddRows = false;
            dgvApps.AllowUserToResizeRows = false;
            altRowStyle.BackColor = System.Drawing.Color.FromArgb(255, 240, 248);
            dgvApps.AlternatingRowsDefaultCellStyle = altRowStyle;
            dgvApps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvApps.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvApps.BackgroundColor = System.Drawing.Color.White;
            dgvApps.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvApps.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            dgvApps.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(6, 148, 148);
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            headerStyle.SelectionBackColor = System.Drawing.Color.FromArgb(6, 148, 148);
            headerStyle.SelectionForeColor = System.Drawing.Color.White;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvApps.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvApps.ColumnHeadersHeight = 60;
            dgvApps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            rowStyle.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            rowStyle.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 210, 225);
            rowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            rowStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvApps.DefaultCellStyle = rowStyle;
            dgvApps.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvApps.EnableHeadersVisualStyles = false;
            dgvApps.GridColor = System.Drawing.Color.FromArgb(150, 200, 210);
            dgvApps.MultiSelect = false;
            dgvApps.Name = "dgvApps";
            dgvApps.ReadOnly = true;
            dgvApps.RowHeadersVisible = false;
            dgvApps.RowTemplate.Height = 44;
            dgvApps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvApps.Size = new System.Drawing.Size(1026, 388);
            dgvApps.TabIndex = 0;
            //
            // btnApprove
            //
            btnApprove.Animated = true;
            btnApprove.AutoRoundedCorners = true;
            btnApprove.BackColor = System.Drawing.Color.Transparent;
            btnApprove.BorderRadius = 22;
            btnApprove.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnApprove.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnApprove.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnApprove.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnApprove.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnApprove.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnApprove.FillColor = System.Drawing.Color.FromArgb(255, 105, 180);
            btnApprove.FillColor2 = System.Drawing.Color.FromArgb(0, 240, 255);
            btnApprove.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnApprove.ForeColor = System.Drawing.Color.White;
            btnApprove.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnApprove.HoverState.FillColor = System.Drawing.Color.FromArgb(200, 60, 130);
            btnApprove.HoverState.FillColor2 = System.Drawing.Color.FromArgb(255, 150, 200);
            btnApprove.Location = new System.Drawing.Point(32, 556);
            btnApprove.Name = "btnApprove";
            btnApprove.ShadowDecoration.Color = System.Drawing.Color.FromArgb(80, 255, 105, 180);
            btnApprove.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnApprove.ShadowDecoration.Enabled = false;
            btnApprove.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 6, 6);
            btnApprove.Size = new System.Drawing.Size(130, 44);
            btnApprove.TabIndex = 2;
            btnApprove.Text = "Approve";
            btnApprove.Click += BtnApprove_Click;
            btnApprove.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // btnReject
            //
            btnReject.Animated = true;
            btnReject.AutoRoundedCorners = true;
            btnReject.BackColor = System.Drawing.Color.Transparent;
            btnReject.BorderRadius = 22;
            btnReject.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnReject.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnReject.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnReject.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnReject.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnReject.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnReject.FillColor = System.Drawing.Color.FromArgb(220, 53, 69);
            btnReject.FillColor2 = System.Drawing.Color.FromArgb(245, 101, 101);
            btnReject.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnReject.ForeColor = System.Drawing.Color.White;
            btnReject.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnReject.HoverState.FillColor = System.Drawing.Color.FromArgb(200, 30, 40);
            btnReject.HoverState.FillColor2 = System.Drawing.Color.FromArgb(220, 70, 70);
            btnReject.Location = new System.Drawing.Point(178, 556);
            btnReject.Name = "btnReject";
            btnReject.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnReject.ShadowDecoration.Enabled = false;
            btnReject.ShadowDecoration.Color = System.Drawing.Color.FromArgb(80, 220, 53, 69);
            btnReject.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 6, 6);
            btnReject.Size = new System.Drawing.Size(130, 44);
            btnReject.TabIndex = 3;
            btnReject.Text = "Reject";
            btnReject.Click += BtnReject_Click;
            btnReject.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // btnViewDocs
            //
            btnViewDocs.Animated = true;
            btnViewDocs.AutoRoundedCorners = true;
            btnViewDocs.BackColor = System.Drawing.Color.Transparent;
            btnViewDocs.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            btnViewDocs.BorderRadius = 22;
            btnViewDocs.BorderThickness = 1;
            btnViewDocs.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnViewDocs.FillColor = System.Drawing.Color.White;
            btnViewDocs.FillColor2 = System.Drawing.Color.White;
            btnViewDocs.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnViewDocs.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnViewDocs.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            btnViewDocs.HoverState.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            btnViewDocs.HoverState.FillColor2 = System.Drawing.Color.FromArgb(255, 248, 252);
            btnViewDocs.HoverState.ForeColor = System.Drawing.Color.FromArgb(6, 148, 148);
            btnViewDocs.Location = new System.Drawing.Point(324, 556);
            btnViewDocs.Name = "btnViewDocs";
            btnViewDocs.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnViewDocs.Size = new System.Drawing.Size(140, 44);
            btnViewDocs.TabIndex = 4;
            btnViewDocs.Text = "Documents";
            btnViewDocs.Click += BtnViewDocs_Click;
            btnViewDocs.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // btnViewProfile
            //
            btnViewProfile.Animated = true;
            btnViewProfile.AutoRoundedCorners = true;
            btnViewProfile.BackColor = System.Drawing.Color.Transparent;
            btnViewProfile.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            btnViewProfile.BorderRadius = 22;
            btnViewProfile.BorderThickness = 1;
            btnViewProfile.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnViewProfile.FillColor = System.Drawing.Color.White;
            btnViewProfile.FillColor2 = System.Drawing.Color.White;
            btnViewProfile.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnViewProfile.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnViewProfile.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            btnViewProfile.HoverState.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            btnViewProfile.HoverState.FillColor2 = System.Drawing.Color.FromArgb(255, 248, 252);
            btnViewProfile.HoverState.ForeColor = System.Drawing.Color.FromArgb(6, 148, 148);
            btnViewProfile.Location = new System.Drawing.Point(480, 556);
            btnViewProfile.Name = "btnViewProfile";
            btnViewProfile.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnViewProfile.Size = new System.Drawing.Size(140, 44);
            btnViewProfile.TabIndex = 5;
            btnViewProfile.Text = "View Profile";
            btnViewProfile.Click += BtnViewProfile_Click;
            btnViewProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // btnDownloadReceipt
            //
            btnDownloadReceipt.Animated = true;
            btnDownloadReceipt.AutoRoundedCorners = true;
            btnDownloadReceipt.BackColor = System.Drawing.Color.Transparent;
            btnDownloadReceipt.BorderRadius = 22;
            btnDownloadReceipt.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnDownloadReceipt.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnDownloadReceipt.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnDownloadReceipt.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnDownloadReceipt.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnDownloadReceipt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnDownloadReceipt.FillColor = System.Drawing.Color.FromArgb(255, 105, 180);
            btnDownloadReceipt.FillColor2 = System.Drawing.Color.FromArgb(0, 240, 255);
            btnDownloadReceipt.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnDownloadReceipt.ForeColor = System.Drawing.Color.White;
            btnDownloadReceipt.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnDownloadReceipt.HoverState.FillColor = System.Drawing.Color.FromArgb(200, 60, 130);
            btnDownloadReceipt.HoverState.FillColor2 = System.Drawing.Color.FromArgb(255, 150, 200);
            btnDownloadReceipt.Location = new System.Drawing.Point(636, 556);
            btnDownloadReceipt.Name = "btnDownloadReceipt";
            btnDownloadReceipt.ShadowDecoration.Color = System.Drawing.Color.FromArgb(80, 255, 105, 180);
            btnDownloadReceipt.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnDownloadReceipt.ShadowDecoration.Enabled = false;
            btnDownloadReceipt.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 6, 6);
            btnDownloadReceipt.Size = new System.Drawing.Size(140, 44);
            btnDownloadReceipt.TabIndex = 6;
            btnDownloadReceipt.Text = "PDF Receipt";
            btnDownloadReceipt.Click += BtnDownloadReceipt_Click;
            btnDownloadReceipt.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // toolTip1
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Hint";
            toolTip1.SetToolTip(btnApprove, "Approve the selected application");
            toolTip1.SetToolTip(btnReject, "Reject the selected application");
            toolTip1.SetToolTip(btnViewDocs, "View documents submitted by this student");
            toolTip1.SetToolTip(btnViewProfile, "View the student's full profile");
            toolTip1.SetToolTip(btnDownloadReceipt, "Download a PDF receipt for this application");

            // guna2BorderlessForm1
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
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
            // ApproveRejectForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            ClientSize = new System.Drawing.Size(1120, 630);
            Controls.Add(btnDownloadReceipt);
            Controls.Add(btnViewProfile);
            Controls.Add(btnViewDocs);
            Controls.Add(btnReject);
            Controls.Add(btnApprove);
            Controls.Add(lblSubtitle);
            Controls.Add(pnlGrid);
            Controls.Add(pnlHeader);
            Font = new System.Drawing.Font("Segoe UI", 9.75F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MinimumSize = new System.Drawing.Size(1120, 630);
            CancelButton = btnClose;
            Name = "ApproveRejectForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Manage Applications";
            Load += ApproveRejectForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvApps).EndInit();
            pnlGrid.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2GradientPanel pnlHeader;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.DataGridView dgvApps;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Label lblSubtitle;
        private Guna.UI2.WinForms.Guna2GradientButton btnApprove;
        private Guna.UI2.WinForms.Guna2GradientButton btnReject;
        private Guna.UI2.WinForms.Guna2GradientButton btnViewDocs;
        private Guna.UI2.WinForms.Guna2GradientButton btnViewProfile;
        private Guna.UI2.WinForms.Guna2GradientButton btnDownloadReceipt;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
