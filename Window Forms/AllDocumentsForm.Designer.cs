namespace Window_Forms
{
    partial class AllDocumentsForm
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

            dgvDocuments = new System.Windows.Forms.DataGridView();
            pnlActions = new System.Windows.Forms.Panel();
            btnOpen = new Guna.UI2.WinForms.Guna2GradientButton();
            btnPrint = new Guna.UI2.WinForms.Guna2GradientButton();
            pnlHeader = new Guna.UI2.WinForms.Guna2GradientPanel();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            lblHeaderTitle = new System.Windows.Forms.Label();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);

            ((System.ComponentModel.ISupportInitialize)dgvDocuments).BeginInit();
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
            pnlHeader.Size = new System.Drawing.Size(980, 60);
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
            btnClose.Location = new System.Drawing.Point(938, 14);
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
            lblHeaderTitle.Size = new System.Drawing.Size(400, 36);
            lblHeaderTitle.Text = "All Student Documents";
            //
            // dgvDocuments
            //
            dgvDocuments.AllowUserToAddRows = false;
            dgvDocuments.AllowUserToResizeRows = false;
            altRowStyle.BackColor = System.Drawing.Color.FromArgb(255, 240, 248);
            dgvDocuments.AlternatingRowsDefaultCellStyle = altRowStyle;
            dgvDocuments.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvDocuments.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvDocuments.BackgroundColor = System.Drawing.Color.White;
            dgvDocuments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvDocuments.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            dgvDocuments.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(6, 148, 148);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            headerStyle.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            headerStyle.SelectionBackColor = System.Drawing.Color.FromArgb(6, 148, 148);
            headerStyle.SelectionForeColor = System.Drawing.Color.White;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvDocuments.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvDocuments.ColumnHeadersHeight = 44;
            dgvDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            rowStyle.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            rowStyle.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 210, 225);
            rowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            rowStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvDocuments.DefaultCellStyle = rowStyle;
            dgvDocuments.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvDocuments.EnableHeadersVisualStyles = false;
            dgvDocuments.GridColor = System.Drawing.Color.FromArgb(150, 200, 210);
            dgvDocuments.Location = new System.Drawing.Point(0, 60);
            dgvDocuments.MultiSelect = false;
            dgvDocuments.Name = "dgvDocuments";
            dgvDocuments.ReadOnly = true;
            dgvDocuments.RowHeadersVisible = false;
            dgvDocuments.RowTemplate.Height = 44;
            dgvDocuments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvDocuments.Size = new System.Drawing.Size(980, 436);
            dgvDocuments.TabIndex = 1;
            //
            // pnlActions
            //
            pnlActions.BackColor = System.Drawing.Color.FromArgb(240, 250, 255);
            pnlActions.Controls.Add(btnOpen);
            pnlActions.Controls.Add(btnPrint);
            pnlActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlActions.Height = 64;
            pnlActions.Padding = new System.Windows.Forms.Padding(14);
            pnlActions.TabIndex = 2;
            //
            // btnOpen
            //
            btnOpen.Animated = true;
            btnOpen.AutoRoundedCorners = true;
            btnOpen.BackColor = System.Drawing.Color.Transparent;
            btnOpen.BorderRadius = 20;
            btnOpen.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnOpen.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnOpen.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnOpen.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnOpen.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnOpen.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnOpen.FillColor = System.Drawing.Color.White;
            btnOpen.FillColor2 = System.Drawing.Color.White;
            btnOpen.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnOpen.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnOpen.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            btnOpen.BorderThickness = 1;
            btnOpen.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            btnOpen.HoverState.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            btnOpen.HoverState.FillColor2 = System.Drawing.Color.FromArgb(255, 248, 252);
            btnOpen.HoverState.ForeColor = System.Drawing.Color.FromArgb(6, 148, 148);
            btnOpen.Location = new System.Drawing.Point(14, 12);
            btnOpen.Name = "btnOpen";
            btnOpen.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnOpen.Size = new System.Drawing.Size(140, 40);
            btnOpen.TabIndex = 0;
            btnOpen.Text = "Open Selected";
            btnOpen.Click += BtnOpen_Click;
            btnOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // btnPrint
            //
            btnPrint.Animated = true;
            btnPrint.AutoRoundedCorners = true;
            btnPrint.BackColor = System.Drawing.Color.Transparent;
            btnPrint.BorderRadius = 20;
            btnPrint.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnPrint.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnPrint.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnPrint.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnPrint.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnPrint.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnPrint.FillColor = System.Drawing.Color.FromArgb(255, 105, 180);
            btnPrint.FillColor2 = System.Drawing.Color.FromArgb(0, 240, 255);
            btnPrint.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnPrint.ForeColor = System.Drawing.Color.White;
            btnPrint.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnPrint.HoverState.FillColor = System.Drawing.Color.FromArgb(200, 60, 130);
            btnPrint.HoverState.FillColor2 = System.Drawing.Color.FromArgb(255, 150, 200);
            btnPrint.Location = new System.Drawing.Point(164, 12);
            btnPrint.Name = "btnPrint";
            btnPrint.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnPrint.ShadowDecoration.Enabled = false;
            btnPrint.Size = new System.Drawing.Size(140, 40);
            btnPrint.TabIndex = 1;
            btnPrint.Text = "Print Selected";
            btnPrint.Click += BtnPrint_Click;
            btnPrint.Cursor = System.Windows.Forms.Cursors.Hand;
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
            guna2DragControl1.TargetControl = pnlHeader;
            guna2DragControl1.UseTransparentDrag = true;
            //
            // AllDocumentsForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            ClientSize = new System.Drawing.Size(980, 560);
            Controls.Add(dgvDocuments);
            Controls.Add(pnlActions);
            Controls.Add(pnlHeader);
            Font = new System.Drawing.Font("Segoe UI", 9.75F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MinimumSize = new System.Drawing.Size(980, 560);
            Name = "AllDocumentsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "All Student Documents";
            Load += AllDocumentsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDocuments).EndInit();
            pnlActions.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvDocuments;
        private System.Windows.Forms.Panel pnlActions;
        private Guna.UI2.WinForms.Guna2GradientButton btnOpen;
        private Guna.UI2.WinForms.Guna2GradientButton btnPrint;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlHeader;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label lblHeaderTitle;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}
