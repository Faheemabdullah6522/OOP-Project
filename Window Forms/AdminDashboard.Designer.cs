namespace Window_Forms
{
    partial class AdminDashboard
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
            pnlStats = new System.Windows.Forms.Panel();
            cardTotalScholarships = new System.Windows.Forms.Panel();
            lblStatValue1 = new System.Windows.Forms.Label();
            lblStatLabel1 = new System.Windows.Forms.Label();
            cardTotalApplications = new System.Windows.Forms.Panel();
            lblStatValue2 = new System.Windows.Forms.Label();
            lblStatLabel2 = new System.Windows.Forms.Label();
            cardPendingReviews = new System.Windows.Forms.Panel();
            lblStatValue3 = new System.Windows.Forms.Label();
            lblStatLabel3 = new System.Windows.Forms.Label();
            cardApprovalRate = new System.Windows.Forms.Panel();
            lblStatValue4 = new System.Windows.Forms.Label();
            lblStatLabel4 = new System.Windows.Forms.Label();
            btnAdd = new Guna.UI2.WinForms.Guna2GradientButton();
            btnEdit = new Guna.UI2.WinForms.Guna2GradientButton();
            btnDelete = new Guna.UI2.WinForms.Guna2GradientButton();
            btnViewApplications = new Guna.UI2.WinForms.Guna2GradientButton();
            btnViewStudents = new Guna.UI2.WinForms.Guna2GradientButton();
            btnViewDocuments = new Guna.UI2.WinForms.Guna2GradientButton();
            btnLogout = new Guna.UI2.WinForms.Guna2GradientButton();
            lblWelcome = new System.Windows.Forms.Label();
            lblSubtitle = new System.Windows.Forms.Label();
            btnCharts = new Guna.UI2.WinForms.Guna2GradientButton();
            btnRefresh = new Guna.UI2.WinForms.Guna2GradientButton();
            chartStatus = new Guna.Charts.WinForms.GunaChart();
            pnlChart = new System.Windows.Forms.Panel();

            ((System.ComponentModel.ISupportInitialize)dgvScholarships).BeginInit();
            pnlHeader.SuspendLayout();
            pnlGrid.SuspendLayout();
            pnlChart.SuspendLayout();
            SuspendLayout();

            // dgvScholarships
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
            dgvScholarships.Size = new System.Drawing.Size(1096, 320);
            dgvScholarships.TabIndex = 0;
            dgvScholarships.CellFormatting += DgvScholarships_CellFormatting;

            // pnlGrid
            pnlGrid.BackColor = System.Drawing.Color.White;
            pnlGrid.Controls.Add(dgvScholarships);
            pnlGrid.Location = new System.Drawing.Point(35, 200);
            pnlGrid.Name = "pnlGrid";
            pnlGrid.Size = new System.Drawing.Size(1120, 320);
            pnlGrid.TabIndex = 1;
            pnlGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // pnlChart
            pnlChart.BackColor = System.Drawing.Color.White;
            pnlChart.Controls.Add(chartStatus);
            pnlChart.Location = new System.Drawing.Point(30, 200);
            pnlChart.Name = "pnlChart";
            pnlChart.Size = new System.Drawing.Size(1096, 320);
            pnlChart.TabIndex = 2;
            pnlChart.Visible = false;

            // chartStatus
            chartStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            chartStatus.Legend.Display = true;
            chartStatus.Legend.Position = Guna.Charts.WinForms.LegendPosition.Right;
            chartStatus.Location = new System.Drawing.Point(0, 0);
            chartStatus.Name = "chartStatus";
            chartStatus.Size = new System.Drawing.Size(1096, 320);
            chartStatus.TabIndex = 0;
            chartStatus.Title.Text = "Application Status";

            //
            // pnlStats
            //
            pnlStats.BackColor = System.Drawing.Color.FromArgb(240, 250, 255);
            pnlStats.Controls.Add(cardTotalScholarships);
            pnlStats.Controls.Add(cardTotalApplications);
            pnlStats.Controls.Add(cardPendingReviews);
            pnlStats.Controls.Add(cardApprovalRate);
            pnlStats.Location = new System.Drawing.Point(30, 95);
            pnlStats.Name = "pnlStats";
            pnlStats.Size = new System.Drawing.Size(1140, 95);
            pnlStats.TabIndex = 2;
            //
            // cardTotalScholarships
            //
            cardTotalScholarships.BackColor = System.Drawing.Color.FromArgb(6, 148, 148);
            cardTotalScholarships.Controls.Add(lblStatValue1);
            cardTotalScholarships.Controls.Add(lblStatLabel1);
            cardTotalScholarships.Location = new System.Drawing.Point(0, 8);
            cardTotalScholarships.Name = "cardTotalScholarships";
            cardTotalScholarships.Size = new System.Drawing.Size(270, 80);
            cardTotalScholarships.TabIndex = 0;
            //
            // lblStatValue1
            //
            lblStatValue1.AutoSize = true;
            lblStatValue1.BackColor = System.Drawing.Color.Transparent;
            lblStatValue1.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            lblStatValue1.ForeColor = System.Drawing.Color.White;
            lblStatValue1.Location = new System.Drawing.Point(16, 8);
            lblStatValue1.Name = "lblStatValue1";
            lblStatValue1.Size = new System.Drawing.Size(40, 47);
            lblStatValue1.TabIndex = 0;
            lblStatValue1.Text = "0";
            //
            // lblStatLabel1
            //
            lblStatLabel1.AutoSize = true;
            lblStatLabel1.BackColor = System.Drawing.Color.Transparent;
            lblStatLabel1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblStatLabel1.ForeColor = System.Drawing.Color.FromArgb(200, 240, 245);
            lblStatLabel1.Location = new System.Drawing.Point(18, 52);
            lblStatLabel1.Name = "lblStatLabel1";
            lblStatLabel1.Size = new System.Drawing.Size(110, 17);
            lblStatLabel1.TabIndex = 1;
            lblStatLabel1.Text = "Total Scholarships";
            //
            // cardTotalApplications
            //
            cardTotalApplications.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            cardTotalApplications.Controls.Add(lblStatValue2);
            cardTotalApplications.Controls.Add(lblStatLabel2);
            cardTotalApplications.Location = new System.Drawing.Point(290, 8);
            cardTotalApplications.Name = "cardTotalApplications";
            cardTotalApplications.Size = new System.Drawing.Size(270, 80);
            cardTotalApplications.TabIndex = 1;
            //
            // lblStatValue2
            //
            lblStatValue2.AutoSize = true;
            lblStatValue2.BackColor = System.Drawing.Color.Transparent;
            lblStatValue2.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            lblStatValue2.ForeColor = System.Drawing.Color.White;
            lblStatValue2.Location = new System.Drawing.Point(16, 8);
            lblStatValue2.Name = "lblStatValue2";
            lblStatValue2.Size = new System.Drawing.Size(40, 47);
            lblStatValue2.TabIndex = 0;
            lblStatValue2.Text = "0";
            //
            // lblStatLabel2
            //
            lblStatLabel2.AutoSize = true;
            lblStatLabel2.BackColor = System.Drawing.Color.Transparent;
            lblStatLabel2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblStatLabel2.ForeColor = System.Drawing.Color.FromArgb(200, 240, 245);
            lblStatLabel2.Location = new System.Drawing.Point(18, 52);
            lblStatLabel2.Name = "lblStatLabel2";
            lblStatLabel2.Size = new System.Drawing.Size(111, 17);
            lblStatLabel2.TabIndex = 1;
            lblStatLabel2.Text = "Total Applications";
            //
            // cardPendingReviews
            //
            cardPendingReviews.BackColor = System.Drawing.Color.FromArgb(255, 193, 7);
            cardPendingReviews.Controls.Add(lblStatValue3);
            cardPendingReviews.Controls.Add(lblStatLabel3);
            cardPendingReviews.Location = new System.Drawing.Point(580, 8);
            cardPendingReviews.Name = "cardPendingReviews";
            cardPendingReviews.Size = new System.Drawing.Size(270, 80);
            cardPendingReviews.TabIndex = 2;
            //
            // lblStatValue3
            //
            lblStatValue3.AutoSize = true;
            lblStatValue3.BackColor = System.Drawing.Color.Transparent;
            lblStatValue3.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            lblStatValue3.ForeColor = System.Drawing.Color.White;
            lblStatValue3.Location = new System.Drawing.Point(16, 8);
            lblStatValue3.Name = "lblStatValue3";
            lblStatValue3.Size = new System.Drawing.Size(40, 47);
            lblStatValue3.TabIndex = 0;
            lblStatValue3.Text = "0";
            //
            // lblStatLabel3
            //
            lblStatLabel3.AutoSize = true;
            lblStatLabel3.BackColor = System.Drawing.Color.Transparent;
            lblStatLabel3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblStatLabel3.ForeColor = System.Drawing.Color.FromArgb(255, 240, 200);
            lblStatLabel3.Location = new System.Drawing.Point(18, 52);
            lblStatLabel3.Name = "lblStatLabel3";
            lblStatLabel3.Size = new System.Drawing.Size(101, 17);
            lblStatLabel3.TabIndex = 1;
            lblStatLabel3.Text = "Pending Reviews";
            //
            // cardApprovalRate
            //
            cardApprovalRate.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            cardApprovalRate.Controls.Add(lblStatValue4);
            cardApprovalRate.Controls.Add(lblStatLabel4);
            cardApprovalRate.Location = new System.Drawing.Point(870, 8);
            cardApprovalRate.Name = "cardApprovalRate";
            cardApprovalRate.Size = new System.Drawing.Size(270, 80);
            cardApprovalRate.TabIndex = 3;
            //
            // lblStatValue4
            //
            lblStatValue4.AutoSize = true;
            lblStatValue4.BackColor = System.Drawing.Color.Transparent;
            lblStatValue4.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            lblStatValue4.ForeColor = System.Drawing.Color.White;
            lblStatValue4.Location = new System.Drawing.Point(16, 8);
            lblStatValue4.Name = "lblStatValue4";
            lblStatValue4.Size = new System.Drawing.Size(40, 47);
            lblStatValue4.TabIndex = 0;
            lblStatValue4.Text = "0";
            //
            // lblStatLabel4
            //
            lblStatLabel4.AutoSize = true;
            lblStatLabel4.BackColor = System.Drawing.Color.Transparent;
            lblStatLabel4.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblStatLabel4.ForeColor = System.Drawing.Color.FromArgb(200, 220, 255);
            lblStatLabel4.Location = new System.Drawing.Point(18, 52);
            lblStatLabel4.Name = "lblStatLabel4";
            lblStatLabel4.Size = new System.Drawing.Size(91, 17);
            lblStatLabel4.TabIndex = 1;
            lblStatLabel4.Text = "Approval Rate";
            //
            // btnAdd
            btnAdd.Animated = true;
            btnAdd.AutoRoundedCorners = true;
            btnAdd.BackColor = System.Drawing.Color.Transparent;
            btnAdd.BorderRadius = 20;
            btnAdd.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnAdd.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnAdd.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnAdd.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnAdd.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnAdd.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnAdd.FillColor = System.Drawing.Color.FromArgb(6, 148, 148);
            btnAdd.FillColor2 = System.Drawing.Color.FromArgb(255, 150, 200);
            btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnAdd.ForeColor = System.Drawing.Color.White;
            btnAdd.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnAdd.HoverState.FillColor = System.Drawing.Color.FromArgb(200, 60, 130);
            btnAdd.HoverState.FillColor2 = System.Drawing.Color.FromArgb(220, 90, 160);
            btnAdd.Location = new System.Drawing.Point(30, 535);
            btnAdd.Name = "btnAdd";
            btnAdd.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnAdd.ShadowDecoration.Enabled = false;
            btnAdd.ShadowDecoration.Color = System.Drawing.Color.FromArgb(80, 6, 148, 148);
            btnAdd.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            btnAdd.Size = new System.Drawing.Size(160, 44);
            btnAdd.TabIndex = 2;
            btnAdd.Text = "Add Scholarship";
            btnAdd.Click += BtnAdd_Click;
            btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            // btnEdit
            btnEdit.Animated = true;
            btnEdit.AutoRoundedCorners = true;
            btnEdit.BackColor = System.Drawing.Color.Transparent;
            btnEdit.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            btnEdit.BorderRadius = 20;
            btnEdit.BorderThickness = 1;
            btnEdit.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnEdit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnEdit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnEdit.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnEdit.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnEdit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnEdit.FillColor = System.Drawing.Color.White;
            btnEdit.FillColor2 = System.Drawing.Color.White;
            btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnEdit.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnEdit.Location = new System.Drawing.Point(204, 535);
            btnEdit.Name = "btnEdit";
            btnEdit.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnEdit.Size = new System.Drawing.Size(130, 44);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit";
            btnEdit.Click += BtnEdit_Click;
            btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            // btnDelete
            btnDelete.Animated = true;
            btnDelete.AutoRoundedCorners = true;
            btnDelete.BackColor = System.Drawing.Color.Transparent;
            btnDelete.BorderRadius = 20;
            btnDelete.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnDelete.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnDelete.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnDelete.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnDelete.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnDelete.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnDelete.FillColor = System.Drawing.Color.FromArgb(220, 53, 69);
            btnDelete.FillColor2 = System.Drawing.Color.FromArgb(245, 101, 101);
            btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnDelete.ForeColor = System.Drawing.Color.White;
            btnDelete.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnDelete.HoverState.FillColor = System.Drawing.Color.FromArgb(200, 30, 40);
            btnDelete.HoverState.FillColor2 = System.Drawing.Color.FromArgb(220, 70, 70);
            btnDelete.Location = new System.Drawing.Point(348, 535);
            btnDelete.Name = "btnDelete";
            btnDelete.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnDelete.ShadowDecoration.Enabled = false;
            btnDelete.ShadowDecoration.Color = System.Drawing.Color.FromArgb(80, 220, 53, 69);
            btnDelete.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            btnDelete.Size = new System.Drawing.Size(130, 44);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.Click += BtnDelete_Click;
            btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            // btnViewApplications
            btnViewApplications.Animated = true;
            btnViewApplications.AutoRoundedCorners = true;
            btnViewApplications.BackColor = System.Drawing.Color.Transparent;
            btnViewApplications.BorderRadius = 20;
            btnViewApplications.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnViewApplications.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnViewApplications.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnViewApplications.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnViewApplications.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnViewApplications.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnViewApplications.FillColor = System.Drawing.Color.FromArgb(255, 193, 7);
            btnViewApplications.FillColor2 = System.Drawing.Color.FromArgb(255, 213, 79);
            btnViewApplications.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnViewApplications.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            btnViewApplications.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnViewApplications.HoverState.FillColor = System.Drawing.Color.FromArgb(230, 170, 0);
            btnViewApplications.HoverState.FillColor2 = System.Drawing.Color.FromArgb(240, 190, 50);
            btnViewApplications.Location = new System.Drawing.Point(492, 535);
            btnViewApplications.Name = "btnViewApplications";
            btnViewApplications.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnViewApplications.ShadowDecoration.Enabled = false;
            btnViewApplications.ShadowDecoration.Color = System.Drawing.Color.FromArgb(80, 255, 193, 7);
            btnViewApplications.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 4, 4);
            btnViewApplications.Size = new System.Drawing.Size(160, 44);
            btnViewApplications.TabIndex = 5;
            btnViewApplications.Text = "Applications";
            btnViewApplications.Click += BtnViewApplications_Click;
            btnViewApplications.Cursor = System.Windows.Forms.Cursors.Hand;
            // btnViewStudents
            btnViewStudents.Animated = true;
            btnViewStudents.AutoRoundedCorners = true;
            btnViewStudents.BackColor = System.Drawing.Color.Transparent;
            btnViewStudents.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            btnViewStudents.BorderRadius = 20;
            btnViewStudents.BorderThickness = 1;
            btnViewStudents.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnViewStudents.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnViewStudents.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnViewStudents.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnViewStudents.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnViewStudents.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnViewStudents.FillColor = System.Drawing.Color.White;
            btnViewStudents.FillColor2 = System.Drawing.Color.White;
            btnViewStudents.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnViewStudents.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnViewStudents.Location = new System.Drawing.Point(666, 535);
            btnViewStudents.Name = "btnViewStudents";
            btnViewStudents.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnViewStudents.Size = new System.Drawing.Size(140, 44);
            btnViewStudents.TabIndex = 6;
            btnViewStudents.Text = "Students";
            btnViewStudents.Click += BtnViewStudents_Click;
            btnViewStudents.Cursor = System.Windows.Forms.Cursors.Hand;
            // btnViewDocuments
            btnViewDocuments.Animated = true;
            btnViewDocuments.AutoRoundedCorners = true;
            btnViewDocuments.BackColor = System.Drawing.Color.Transparent;
            btnViewDocuments.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            btnViewDocuments.BorderRadius = 20;
            btnViewDocuments.BorderThickness = 1;
            btnViewDocuments.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnViewDocuments.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnViewDocuments.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnViewDocuments.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnViewDocuments.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnViewDocuments.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnViewDocuments.FillColor = System.Drawing.Color.White;
            btnViewDocuments.FillColor2 = System.Drawing.Color.White;
            btnViewDocuments.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnViewDocuments.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnViewDocuments.Location = new System.Drawing.Point(820, 535);
            btnViewDocuments.Name = "btnViewDocuments";
            btnViewDocuments.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnViewDocuments.Size = new System.Drawing.Size(150, 44);
            btnViewDocuments.TabIndex = 7;
            btnViewDocuments.Text = "Documents";
            btnViewDocuments.Click += BtnViewDocuments_Click;
            btnViewDocuments.Cursor = System.Windows.Forms.Cursors.Hand;
            // btnCharts
            btnCharts.Animated = true;
            btnCharts.AutoRoundedCorners = true;
            btnCharts.BackColor = System.Drawing.Color.Transparent;
            btnCharts.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            btnCharts.BorderRadius = 20;
            btnCharts.BorderThickness = 1;
            btnCharts.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnCharts.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnCharts.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnCharts.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnCharts.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnCharts.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnCharts.FillColor = System.Drawing.Color.White;
            btnCharts.FillColor2 = System.Drawing.Color.White;
            btnCharts.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnCharts.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnCharts.Location = new System.Drawing.Point(980, 535);
            btnCharts.Name = "btnCharts";
            btnCharts.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnCharts.Size = new System.Drawing.Size(150, 44);
            btnCharts.TabIndex = 8;
            btnCharts.Text = "Charts";
            btnCharts.Click += BtnCharts_Click;
            btnCharts.Cursor = System.Windows.Forms.Cursors.Hand;
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
            btnRefresh.Location = new System.Drawing.Point(950, 22);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnRefresh.Size = new System.Drawing.Size(110, 36);
            btnRefresh.TabIndex = 10;
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
            btnLogout.TabIndex = 9;
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
            lblWelcome.Text = "Admin Dashboard";

            // lblSubtitle
            lblSubtitle.BackColor = System.Drawing.Color.Transparent;
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(255, 210, 225);
            lblSubtitle.Location = new System.Drawing.Point(32, 58);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new System.Drawing.Size(600, 20);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Manage scholarships, review applications, and print student documents.";

            // pnlHeader
            pnlHeader.BackColor = System.Drawing.Color.FromArgb(6, 148, 148);
            pnlHeader.Controls.Add(btnLogout);
            pnlHeader.Controls.Add(btnRefresh);
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new System.Drawing.Size(1200, 85);
            pnlHeader.TabIndex = 0;

            // toolTip1
            toolTip1 = new System.Windows.Forms.ToolTip(components);
            toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            toolTip1.ToolTipTitle = "Hint";
            toolTip1.SetToolTip(btnAdd, "Add a new scholarship");
            toolTip1.SetToolTip(btnEdit, "Edit the selected scholarship");
            toolTip1.SetToolTip(btnDelete, "Delete the selected scholarship");
            toolTip1.SetToolTip(btnViewApplications, "Review and manage pending applications");
            toolTip1.SetToolTip(btnViewStudents, "View registered students and their profiles");
            toolTip1.SetToolTip(btnViewDocuments, "View all uploaded student documents");
            toolTip1.SetToolTip(btnLogout, "Sign out of your account");
            toolTip1.SetToolTip(btnCharts, "View application statistics chart");
            toolTip1.SetToolTip(btnRefresh, "Refresh the scholarship list and stats");

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

            // AdminDashboard
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            ClientSize = new System.Drawing.Size(1200, 620);
            Controls.Add(pnlHeader);
            Controls.Add(btnViewDocuments);
            Controls.Add(btnViewStudents);
            Controls.Add(btnViewApplications);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(pnlStats);
            Controls.Add(pnlGrid);
            Controls.Add(pnlChart);
            Controls.Add(btnCharts);
            Font = new System.Drawing.Font("Segoe UI", 9.75F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MinimumSize = new System.Drawing.Size(1200, 620);
            Name = "AdminDashboard";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Admin Dashboard";
            Load += AdminDashboard_Load;
            ((System.ComponentModel.ISupportInitialize)dgvScholarships).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlStats.ResumeLayout(false);
            pnlGrid.ResumeLayout(false);
            pnlChart.ResumeLayout(false);
            ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvScholarships;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.Panel cardTotalScholarships;
        private System.Windows.Forms.Panel cardTotalApplications;
        private System.Windows.Forms.Panel cardPendingReviews;
        private System.Windows.Forms.Panel cardApprovalRate;
        private System.Windows.Forms.Label lblStatValue1, lblStatValue2, lblStatValue3, lblStatValue4;
        private System.Windows.Forms.Label lblStatLabel1, lblStatLabel2, lblStatLabel3, lblStatLabel4;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubtitle;
        private Guna.UI2.WinForms.Guna2GradientButton btnAdd;
        private Guna.UI2.WinForms.Guna2GradientButton btnEdit;
        private Guna.UI2.WinForms.Guna2GradientButton btnDelete;
        private Guna.UI2.WinForms.Guna2GradientButton btnViewApplications;
        private Guna.UI2.WinForms.Guna2GradientButton btnViewStudents;
        private Guna.UI2.WinForms.Guna2GradientButton btnViewDocuments;
        private Guna.UI2.WinForms.Guna2GradientButton btnLogout;
        private Guna.UI2.WinForms.Guna2GradientButton btnCharts;
        private Guna.Charts.WinForms.GunaChart chartStatus;
        private System.Windows.Forms.Panel pnlChart;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.ToolTip toolTip1;
        private Guna.UI2.WinForms.Guna2GradientButton btnRefresh;
    }
}
