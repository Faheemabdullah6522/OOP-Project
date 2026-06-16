namespace Window_Forms
{
    partial class StudentListForm
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

            dgvStudents = new System.Windows.Forms.DataGridView();
            pnlFilters = new System.Windows.Forms.Panel();
            txtSearch = new Guna.UI2.WinForms.Guna2TextBox();
            txtMaxIncome = new Guna.UI2.WinForms.Guna2TextBox();
            txtMinCgpa = new Guna.UI2.WinForms.Guna2TextBox();
            btnFilter = new Guna.UI2.WinForms.Guna2GradientButton();
            btnClear = new Guna.UI2.WinForms.Guna2GradientButton();
            pnlHeader = new Guna.UI2.WinForms.Guna2GradientPanel();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            lblHeaderTitle = new System.Windows.Forms.Label();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);

            ((System.ComponentModel.ISupportInitialize)dgvStudents).BeginInit();
            pnlFilters.SuspendLayout();
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
            pnlHeader.Size = new System.Drawing.Size(1100, 60);
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
            btnClose.Location = new System.Drawing.Point(1058, 14);
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
            lblHeaderTitle.Text = "Registered Students";
            //
            // pnlFilters
            //
            pnlFilters.BackColor = System.Drawing.Color.White;
            pnlFilters.Controls.Add(txtSearch);
            pnlFilters.Controls.Add(txtMaxIncome);
            pnlFilters.Controls.Add(txtMinCgpa);
            pnlFilters.Controls.Add(btnFilter);
            pnlFilters.Controls.Add(btnClear);
            pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            pnlFilters.Height = 60;
            pnlFilters.Padding = new System.Windows.Forms.Padding(14);
            pnlFilters.TabIndex = 1;
            //
            // txtSearch
            //
            txtSearch.Animated = true;
            txtSearch.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            txtSearch.BorderRadius = 8;
            txtSearch.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtSearch.DefaultText = "";
            txtSearch.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtSearch.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            txtSearch.Location = new System.Drawing.Point(14, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search name, CNIC, department";
            txtSearch.Size = new System.Drawing.Size(220, 36);
            txtSearch.TabIndex = 0;
            //
            // txtMaxIncome
            //
            txtMaxIncome.Animated = true;
            txtMaxIncome.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            txtMaxIncome.BorderRadius = 8;
            txtMaxIncome.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtMaxIncome.DefaultText = "";
            txtMaxIncome.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            txtMaxIncome.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtMaxIncome.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtMaxIncome.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            txtMaxIncome.Location = new System.Drawing.Point(244, 12);
            txtMaxIncome.Name = "txtMaxIncome";
            txtMaxIncome.PlaceholderText = "Max income";
            txtMaxIncome.Size = new System.Drawing.Size(120, 36);
            txtMaxIncome.TabIndex = 1;
            //
            // txtMinCgpa
            //
            txtMinCgpa.Animated = true;
            txtMinCgpa.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            txtMinCgpa.BorderRadius = 8;
            txtMinCgpa.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtMinCgpa.DefaultText = "";
            txtMinCgpa.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            txtMinCgpa.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtMinCgpa.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtMinCgpa.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            txtMinCgpa.Location = new System.Drawing.Point(374, 12);
            txtMinCgpa.Name = "txtMinCgpa";
            txtMinCgpa.PlaceholderText = "Min CGPA";
            txtMinCgpa.Size = new System.Drawing.Size(100, 36);
            txtMinCgpa.TabIndex = 2;
            //
            // btnFilter
            //
            btnFilter.Animated = true;
            btnFilter.AutoRoundedCorners = true;
            btnFilter.BackColor = System.Drawing.Color.Transparent;
            btnFilter.BorderRadius = 15;
            btnFilter.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnFilter.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnFilter.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnFilter.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnFilter.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnFilter.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnFilter.FillColor = System.Drawing.Color.FromArgb(255, 105, 180);
            btnFilter.FillColor2 = System.Drawing.Color.FromArgb(0, 240, 255);
            btnFilter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnFilter.ForeColor = System.Drawing.Color.White;
            btnFilter.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnFilter.HoverState.FillColor = System.Drawing.Color.FromArgb(200, 60, 130);
            btnFilter.HoverState.FillColor2 = System.Drawing.Color.FromArgb(255, 150, 200);
            btnFilter.Location = new System.Drawing.Point(488, 14);
            btnFilter.Name = "btnFilter";
            btnFilter.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnFilter.ShadowDecoration.Enabled = false;
            btnFilter.Size = new System.Drawing.Size(90, 30);
            btnFilter.TabIndex = 3;
            btnFilter.Text = "Filter";
            btnFilter.Click += BtnFilter_Click;
            btnFilter.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // btnClear
            //
            btnClear.Animated = true;
            btnClear.AutoRoundedCorners = true;
            btnClear.BackColor = System.Drawing.Color.Transparent;
            btnClear.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            btnClear.BorderRadius = 15;
            btnClear.BorderThickness = 1;
            btnClear.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnClear.FillColor = System.Drawing.Color.White;
            btnClear.FillColor2 = System.Drawing.Color.White;
            btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnClear.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnClear.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            btnClear.HoverState.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            btnClear.HoverState.FillColor2 = System.Drawing.Color.FromArgb(255, 248, 252);
            btnClear.HoverState.ForeColor = System.Drawing.Color.FromArgb(6, 148, 148);
            btnClear.Location = new System.Drawing.Point(588, 14);
            btnClear.Name = "btnClear";
            btnClear.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnClear.Size = new System.Drawing.Size(90, 30);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.Click += BtnClear_Click;
            btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // dgvStudents
            //
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.AllowUserToResizeRows = false;
            altRowStyle.BackColor = System.Drawing.Color.FromArgb(255, 240, 248);
            dgvStudents.AlternatingRowsDefaultCellStyle = altRowStyle;
            dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            dgvStudents.BackgroundColor = System.Drawing.Color.White;
            dgvStudents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvStudents.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Single;
            dgvStudents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(6, 148, 148);
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            headerStyle.SelectionBackColor = System.Drawing.Color.FromArgb(6, 148, 148);
            headerStyle.SelectionForeColor = System.Drawing.Color.White;
            headerStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvStudents.ColumnHeadersDefaultCellStyle = headerStyle;
            dgvStudents.ColumnHeadersHeight = 60;
            dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            rowStyle.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            rowStyle.Padding = new System.Windows.Forms.Padding(8, 6, 8, 6);
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(255, 210, 225);
            rowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            rowStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvStudents.DefaultCellStyle = rowStyle;
            dgvStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            dgvStudents.EnableHeadersVisualStyles = false;
            // Change cell border style to show both horizontal and vertical lines
            dgvStudents.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // Make grid lines more visible with a darker color
            dgvStudents.GridColor = Color.FromArgb(150, 200, 210);
            dgvStudents.Location = new System.Drawing.Point(0, 120);
            dgvStudents.MultiSelect = false;
            dgvStudents.Name = "dgvStudents";
            dgvStudents.ReadOnly = true;
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.RowTemplate.Height = 44;
            dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new System.Drawing.Size(1100, 530);
            dgvStudents.TabIndex = 2;
            dgvStudents.CellDoubleClick += DgvStudents_CellDoubleClick;
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
            // StudentListForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            ClientSize = new System.Drawing.Size(1100, 650);
            Controls.Add(dgvStudents);
            Controls.Add(pnlFilters);
            Controls.Add(pnlHeader);
            Font = new System.Drawing.Font("Segoe UI", 9.75F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MinimumSize = new System.Drawing.Size(1100, 650);
            Name = "StudentListForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Registered Students";
            Load += StudentListForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvStudents).EndInit();
            pnlFilters.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Panel pnlFilters;
        private Guna.UI2.WinForms.Guna2TextBox txtSearch;
        private Guna.UI2.WinForms.Guna2TextBox txtMaxIncome;
        private Guna.UI2.WinForms.Guna2TextBox txtMinCgpa;
        private Guna.UI2.WinForms.Guna2GradientButton btnFilter;
        private Guna.UI2.WinForms.Guna2GradientButton btnClear;
        private Guna.UI2.WinForms.Guna2GradientPanel pnlHeader;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private System.Windows.Forms.Label lblHeaderTitle;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
    }
}
