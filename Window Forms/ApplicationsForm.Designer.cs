namespace Window_Forms
{
    partial class ApplicationsForm
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

            dgvApplications = new System.Windows.Forms.DataGridView();
            pnlActions = new System.Windows.Forms.Panel();
            btnDownloadReceipt = new Guna.UI2.WinForms.Guna2GradientButton();
            btnWithdraw = new Guna.UI2.WinForms.Guna2GradientButton();
            pnlHeader = new Guna.UI2.WinForms.Guna2GradientPanel();
            btnReapply = new Guna.UI2.WinForms.Guna2GradientButton();
            btnContinueDraft = new Guna.UI2.WinForms.Guna2GradientButton();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            lblHeaderTitle = new System.Windows.Forms.Label();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);

            ((System.ComponentModel.ISupportInitialize)dgvApplications).BeginInit();
            pnlActions.SuspendLayout();
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
            pnlHeader.Size = new System.Drawing.Size(920, 60);
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
            btnClose.Location = new System.Drawing.Point(878, 14);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnClose.Size = new System.Drawing.Size(32, 32);
            btnClose.TabIndex = 1;
            btnClose.Text = "X";
            btnClose.Click += BtnClose_Click;
            btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // lblHeaderTitle
            //
            lblHeaderTitle.AutoSize = false;
            lblHeaderTitle.BackColor = System.Drawing.Color.Transparent;
            lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            lblHeaderTitle.Location = new System.Drawing.Point(24, 14);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new System.Drawing.Size(300, 36);
            lblHeaderTitle.Text = "My Applications";
            //
            // dgvApplications
            //
            dgvApplications.AllowUserToAddRows = false;
            dgvApplications.AllowUserToResizeRows = false;
            altRowStyle.BackColor = System.Drawing.Color.FromArgb(255, 240, 248);
            dgvApplications.AlternatingRowsDefaultCellStyle = altRowStyle;
            dgvApplications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvApplications.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvApplications.BackgroundColor = System.Drawing.Color.White;
            dgvApplications.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvApplications.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            dgvApplications.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(6, 148, 148);
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            headerStyle.SelectionBackColor = System.Drawing.Color.FromArgb(6, 148, 148);
            headerStyle.SelectionForeColor = System.Drawing.Color.White;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvApplications.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvApplications.ColumnHeadersHeight = 62;
            dgvApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            rowStyle.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            rowStyle.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 210, 225);
            rowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            rowStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvApplications.DefaultCellStyle = rowStyle;
            dgvApplications.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvApplications.EnableHeadersVisualStyles = false;
            dgvApplications.GridColor = System.Drawing.Color.FromArgb(150, 200, 210);
            dgvApplications.Location = new System.Drawing.Point(0, 60);
            dgvApplications.MultiSelect = false;
            dgvApplications.Name = "dgvApplications";
            dgvApplications.ReadOnly = true;
            dgvApplications.RowHeadersVisible = false;
            dgvApplications.RowTemplate.Height = 44;
            dgvApplications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvApplications.Size = new System.Drawing.Size(920, 416);
            dgvApplications.TabIndex = 1;
            //
            // pnlActions
            //
            pnlActions.BackColor = System.Drawing.Color.FromArgb(240, 250, 255);
            pnlActions.Controls.Add(btnDownloadReceipt);
            pnlActions.Controls.Add(btnWithdraw);
            pnlActions.Controls.Add(btnReapply);
            pnlActions.Controls.Add(btnContinueDraft);
            pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlActions.Height = 64;
            pnlActions.Padding = new System.Windows.Forms.Padding(14);
            pnlActions.TabIndex = 2;
            //
            // btnDownloadReceipt
            //
            btnDownloadReceipt.Animated = true;
            btnDownloadReceipt.AutoRoundedCorners = true;
            btnDownloadReceipt.BackColor = System.Drawing.Color.Transparent;
            btnDownloadReceipt.BorderRadius = 20;
            btnDownloadReceipt.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnDownloadReceipt.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnDownloadReceipt.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnDownloadReceipt.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnDownloadReceipt.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnDownloadReceipt.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnDownloadReceipt.FillColor = System.Drawing.Color.FromArgb(255, 105, 180);
            btnDownloadReceipt.FillColor2 = System.Drawing.Color.FromArgb(0, 240, 255);
            btnDownloadReceipt.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnDownloadReceipt.ForeColor = System.Drawing.Color.White;
            btnDownloadReceipt.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnDownloadReceipt.HoverState.FillColor = System.Drawing.Color.FromArgb(200, 60, 130);
            btnDownloadReceipt.HoverState.FillColor2 = System.Drawing.Color.FromArgb(255, 150, 200);
            btnDownloadReceipt.Location = new System.Drawing.Point(14, 12);
            btnDownloadReceipt.Name = "btnDownloadReceipt";
            btnDownloadReceipt.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnDownloadReceipt.ShadowDecoration.Enabled = false;
            btnDownloadReceipt.Size = new System.Drawing.Size(200, 40);
            btnDownloadReceipt.TabIndex = 0;
            btnDownloadReceipt.Text = "Download PDF Receipt";
            btnDownloadReceipt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            btnDownloadReceipt.Padding = new System.Windows.Forms.Padding(0);
            btnDownloadReceipt.Click += BtnDownloadReceipt_Click;
            btnDownloadReceipt.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // btnWithdraw
            //
            btnWithdraw.Animated = true;
            btnWithdraw.AutoRoundedCorners = true;
            btnWithdraw.BackColor = System.Drawing.Color.Transparent;
            btnWithdraw.BorderRadius = 20;
            btnWithdraw.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnWithdraw.FillColor = System.Drawing.Color.FromArgb(220, 53, 69);
            btnWithdraw.FillColor2 = System.Drawing.Color.FromArgb(245, 101, 101);
            btnWithdraw.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnWithdraw.ForeColor = System.Drawing.Color.White;
            btnWithdraw.HoverState.FillColor = System.Drawing.Color.FromArgb(200, 30, 40);
            btnWithdraw.HoverState.FillColor2 = System.Drawing.Color.FromArgb(220, 70, 70);
            btnWithdraw.Location = new System.Drawing.Point(230, 12);
            btnWithdraw.Name = "btnWithdraw";
            btnWithdraw.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnWithdraw.Size = new System.Drawing.Size(160, 40);
            btnWithdraw.TabIndex = 1;
            btnWithdraw.Text = "Withdraw Application";
            btnWithdraw.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            btnWithdraw.Padding = new System.Windows.Forms.Padding(0);
            btnWithdraw.Click += BtnWithdraw_Click;
            btnWithdraw.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // btnReapply
            //
            btnReapply.Animated = true;
            btnReapply.AutoRoundedCorners = true;
            btnReapply.BackColor = System.Drawing.Color.Transparent;
            btnReapply.BorderRadius = 20;
            btnReapply.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnReapply.FillColor = System.Drawing.Color.FromArgb(220, 38, 38);
            btnReapply.FillColor2 = System.Drawing.Color.FromArgb(245, 101, 101);
            btnReapply.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnReapply.ForeColor = System.Drawing.Color.White;
            btnReapply.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnReapply.HoverState.FillColor = System.Drawing.Color.FromArgb(180, 20, 20);
            btnReapply.HoverState.FillColor2 = System.Drawing.Color.FromArgb(220, 70, 70);
            btnReapply.Location = new System.Drawing.Point(406, 12);
            btnReapply.Name = "btnReapply";
            btnReapply.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnReapply.Size = new System.Drawing.Size(160, 40);
            btnReapply.TabIndex = 2;
            btnReapply.Text = "Reapply";
            btnReapply.Visible = false;   // hidden until a rejected/withdrawn row is selected
            btnReapply.Enabled = false;
            btnReapply.Click += BtnReapply_Click;
            btnReapply.Cursor = System.Windows.Forms.Cursors.Hand;

            // btnContinueDraft
            btnContinueDraft.Animated = true;
            btnContinueDraft.AutoRoundedCorners = true;
            btnContinueDraft.BackColor = System.Drawing.Color.Transparent;
            btnContinueDraft.BorderRadius = 20;
            btnContinueDraft.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnContinueDraft.FillColor = System.Drawing.Color.FromArgb(6, 148, 148);
            btnContinueDraft.FillColor2 = System.Drawing.Color.FromArgb(0, 200, 180);
            btnContinueDraft.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnContinueDraft.ForeColor = System.Drawing.Color.White;
            btnContinueDraft.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnContinueDraft.HoverState.FillColor = System.Drawing.Color.FromArgb(4, 110, 110);
            btnContinueDraft.HoverState.FillColor2 = System.Drawing.Color.FromArgb(0, 160, 145);
            btnContinueDraft.Location = new System.Drawing.Point(720, 12);
            btnContinueDraft.Name = "btnContinueDraft";
            btnContinueDraft.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnContinueDraft.Size = new System.Drawing.Size(170, 40);
            btnContinueDraft.TabIndex = 3;
            btnContinueDraft.Text = "Continue Draft";
            btnContinueDraft.Visible = false;
            btnContinueDraft.Enabled = false;
            btnContinueDraft.Click += BtnContinueDraft_Click;
            btnContinueDraft.Cursor = System.Windows.Forms.Cursors.Hand;

            // guna2BorderlessForm1
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
            // ApplicationsForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            ClientSize = new System.Drawing.Size(920, 560);
            Controls.Add(dgvApplications);
            Controls.Add(pnlActions);
            Controls.Add(pnlHeader);
            Font = new System.Drawing.Font("Segoe UI", 9.75F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MinimumSize = new System.Drawing.Size(920, 560);
            Name = "ApplicationsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "My Applications";
            Load += ApplicationsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvApplications).EndInit();
            pnlActions.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvApplications;
        private System.Windows.Forms.Panel pnlActions;
        private Guna.UI2.WinForms.Guna2GradientButton btnDownloadReceipt;
        private Guna.UI2.WinForms.Guna2GradientButton btnWithdraw;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlHeader;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label lblHeaderTitle;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private Guna.UI2.WinForms.Guna2GradientButton btnReapply;
        private Guna.UI2.WinForms.Guna2GradientButton btnContinueDraft;
    }
}
