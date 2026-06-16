namespace Window_Forms
{
    partial class NotificationsForm
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

            dgvNotifications = new System.Windows.Forms.DataGridView();
            pnlHeader = new Guna.UI2.WinForms.Guna2GradientPanel();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            lblHeaderTitle = new System.Windows.Forms.Label();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);

            ((System.ComponentModel.ISupportInitialize)dgvNotifications).BeginInit();
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
            pnlHeader.Size = new System.Drawing.Size(760, 60);
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
            btnClose.Location = new System.Drawing.Point(718, 12);
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
            lblHeaderTitle.Location = new System.Drawing.Point(24, 12);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new System.Drawing.Size(300, 36);
            lblHeaderTitle.Text = "Notifications";
            //
            // dgvNotifications
            //
            dgvNotifications.AllowUserToAddRows = false;
            dgvNotifications.AllowUserToResizeRows = false;
            altRowStyle.BackColor = System.Drawing.Color.FromArgb(255, 240, 248);
            dgvNotifications.AlternatingRowsDefaultCellStyle = altRowStyle;
            dgvNotifications.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvNotifications.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvNotifications.BackgroundColor = System.Drawing.Color.White;
            dgvNotifications.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvNotifications.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            dgvNotifications.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(6, 148, 148);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            headerStyle.SelectionBackColor = System.Drawing.Color.FromArgb(6, 148, 148);
            headerStyle.SelectionForeColor = System.Drawing.Color.White;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvNotifications.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvNotifications.ColumnHeadersHeight = 44;
            dgvNotifications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            rowStyle.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            rowStyle.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 210, 225);
            rowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            rowStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvNotifications.DefaultCellStyle = rowStyle;
            dgvNotifications.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvNotifications.EnableHeadersVisualStyles = false;
            dgvNotifications.GridColor = System.Drawing.Color.FromArgb(150, 200, 210);
            dgvNotifications.Location = new System.Drawing.Point(0, 60);
            dgvNotifications.MultiSelect = false;
            dgvNotifications.Name = "dgvNotifications";
            dgvNotifications.ReadOnly = true;
            dgvNotifications.RowHeadersVisible = false;
            dgvNotifications.RowTemplate.Height = 44;
            dgvNotifications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvNotifications.Size = new System.Drawing.Size(760, 360);
            dgvNotifications.TabIndex = 1;
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
            // NotificationsForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            ClientSize = new System.Drawing.Size(760, 420);
            Controls.Add(dgvNotifications);
            Controls.Add(pnlHeader);
            Font = new System.Drawing.Font("Segoe UI", 9.75F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MinimumSize = new System.Drawing.Size(760, 420);
            Name = "NotificationsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Notifications";
            Load += NotificationsForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvNotifications).EndInit();
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvNotifications;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlHeader;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label lblHeaderTitle;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}
