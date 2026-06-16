namespace Window_Forms
{
    partial class AddEditScholarshipForm
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
            txtTitle = new Guna.UI2.WinForms.Guna2TextBox();
            txtDesc = new Guna.UI2.WinForms.Guna2TextBox();
            txtEligibility = new Guna.UI2.WinForms.Guna2TextBox();
            txtAmount = new Guna.UI2.WinForms.Guna2TextBox();
            txtRequiredDocs = new Guna.UI2.WinForms.Guna2TextBox();
            txtMinCgpa = new Guna.UI2.WinForms.Guna2TextBox();
            txtMaxIncome = new Guna.UI2.WinForms.Guna2TextBox();
            txtDegreeProgram = new Guna.UI2.WinForms.Guna2TextBox();
            txtSemesterYear = new Guna.UI2.WinForms.Guna2TextBox();
            dtpDeadline = new Guna.UI2.WinForms.Guna2DateTimePicker();
            chkActive = new Guna.UI2.WinForms.Guna2CheckBox();
            chkNeedBased = new Guna.UI2.WinForms.Guna2CheckBox();
            btnSave = new Guna.UI2.WinForms.Guna2GradientButton();
            btnCancel = new Guna.UI2.WinForms.Guna2GradientButton();
            lblTitle = new System.Windows.Forms.Label();
            lblDesc = new System.Windows.Forms.Label();
            lblElig = new System.Windows.Forms.Label();
            lblAmount = new System.Windows.Forms.Label();
            lblDeadline = new System.Windows.Forms.Label();
            lblActive = new System.Windows.Forms.Label();
            lblRequiredDocs = new System.Windows.Forms.Label();
            lblMinCgpa = new System.Windows.Forms.Label();
            lblMaxIncome = new System.Windows.Forms.Label();
            lblDegreeProgram = new System.Windows.Forms.Label();
            lblSemesterYear = new System.Windows.Forms.Label();
            lblNeedBased = new System.Windows.Forms.Label();
            lblHeaderTitle = new System.Windows.Forms.Label();
            pnlBody = new System.Windows.Forms.Panel();
            pnlHeader = new Guna.UI2.WinForms.Guna2GradientPanel();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
            pnlBody.SuspendLayout();
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
            pnlHeader.Size = new System.Drawing.Size(580, 72);
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
            btnClose.Location = new System.Drawing.Point(530, 18);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnClose.Size = new System.Drawing.Size(36, 36);
            btnClose.TabIndex = 1;
            btnClose.Text = "X";
            btnClose.Click += BtnCancel_Click;
            btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // lblHeaderTitle
            //
            lblHeaderTitle.AutoSize = false;
            lblHeaderTitle.BackColor = System.Drawing.Color.Transparent;
            lblHeaderTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblHeaderTitle.ForeColor = System.Drawing.Color.White;
            lblHeaderTitle.Location = new System.Drawing.Point(24, 16);
            lblHeaderTitle.Name = "lblHeaderTitle";
            lblHeaderTitle.Size = new System.Drawing.Size(400, 40);
            lblHeaderTitle.Text = "Scholarship Details";
            //
            // pnlBody
            //
            pnlBody.BackColor = System.Drawing.Color.White;
            pnlBody.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pnlBody.Controls.Add(lblTitle);
            pnlBody.Controls.Add(txtTitle);
            pnlBody.Controls.Add(lblDesc);
            pnlBody.Controls.Add(txtDesc);
            pnlBody.Controls.Add(lblElig);
            pnlBody.Controls.Add(txtEligibility);
            pnlBody.Controls.Add(lblAmount);
            pnlBody.Controls.Add(txtAmount);
            pnlBody.Controls.Add(lblDeadline);
            pnlBody.Controls.Add(dtpDeadline);
            pnlBody.Controls.Add(lblRequiredDocs);
            pnlBody.Controls.Add(txtRequiredDocs);
            pnlBody.Controls.Add(lblMinCgpa);
            pnlBody.Controls.Add(txtMinCgpa);
            pnlBody.Controls.Add(lblMaxIncome);
            pnlBody.Controls.Add(txtMaxIncome);
            pnlBody.Controls.Add(lblDegreeProgram);
            pnlBody.Controls.Add(txtDegreeProgram);
            pnlBody.Controls.Add(lblSemesterYear);
            pnlBody.Controls.Add(txtSemesterYear);
            pnlBody.Controls.Add(lblNeedBased);
            pnlBody.Controls.Add(chkNeedBased);
            pnlBody.Controls.Add(lblActive);
            pnlBody.Controls.Add(chkActive);
            pnlBody.Location = new System.Drawing.Point(24, 90);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new System.Drawing.Size(532, 468);
            pnlBody.TabIndex = 1;
            //
            // lblTitle
            //
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblTitle.Location = new System.Drawing.Point(22, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(150, 24);
            lblTitle.Text = "Title";
            //
            // txtTitle
            //
            txtTitle.Animated = true;
            txtTitle.BackColor = System.Drawing.Color.Transparent;
            txtTitle.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            txtTitle.BorderRadius = 8;
            txtTitle.BorderThickness = 1;
            txtTitle.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtTitle.DefaultText = "";
            txtTitle.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            txtTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtTitle.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtTitle.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            txtTitle.Location = new System.Drawing.Point(180, 18);
            txtTitle.Name = "txtTitle";
            txtTitle.PlaceholderForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            txtTitle.PlaceholderText = "Scholarship title";
            txtTitle.SelectedText = "";
            txtTitle.Size = new System.Drawing.Size(330, 34);
            //
            // lblDesc
            //
            lblDesc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblDesc.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblDesc.Location = new System.Drawing.Point(22, 62);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new System.Drawing.Size(150, 24);
            lblDesc.Text = "Description";
            //
            // txtDesc
            //
            txtDesc.Animated = true;
            txtDesc.BackColor = System.Drawing.Color.Transparent;
            txtDesc.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            txtDesc.BorderRadius = 8;
            txtDesc.BorderThickness = 1;
            txtDesc.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtDesc.DefaultText = "";
            txtDesc.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            txtDesc.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtDesc.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtDesc.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            txtDesc.Location = new System.Drawing.Point(180, 60);
            txtDesc.Name = "txtDesc";
            txtDesc.PlaceholderForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            txtDesc.PlaceholderText = "Brief description";
            txtDesc.SelectedText = "";
            txtDesc.Size = new System.Drawing.Size(330, 34);
            //
            // lblElig
            //
            lblElig.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblElig.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblElig.Location = new System.Drawing.Point(22, 104);
            lblElig.Name = "lblElig";
            lblElig.Size = new System.Drawing.Size(150, 24);
            lblElig.Text = "Criteria";
            //
            // txtEligibility
            //
            txtEligibility.Animated = true;
            txtEligibility.BackColor = System.Drawing.Color.Transparent;
            txtEligibility.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            txtEligibility.BorderRadius = 8;
            txtEligibility.BorderThickness = 1;
            txtEligibility.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtEligibility.DefaultText = "";
            txtEligibility.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            txtEligibility.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtEligibility.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtEligibility.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            txtEligibility.Location = new System.Drawing.Point(180, 102);
            txtEligibility.Name = "txtEligibility";
            txtEligibility.PlaceholderForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            txtEligibility.PlaceholderText = "Eligibility Criteria";
            txtEligibility.SelectedText = "";
            txtEligibility.Size = new System.Drawing.Size(330, 34);
            //
            // lblAmount
            //
            lblAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblAmount.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblAmount.Location = new System.Drawing.Point(22, 146);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new System.Drawing.Size(150, 24);
            lblAmount.Text = "Amount";
            //
            // txtAmount
            //
            txtAmount.Animated = true;
            txtAmount.BackColor = System.Drawing.Color.Transparent;
            txtAmount.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            txtAmount.BorderRadius = 8;
            txtAmount.BorderThickness = 1;
            txtAmount.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtAmount.DefaultText = "";
            txtAmount.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            txtAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtAmount.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtAmount.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            txtAmount.Location = new System.Drawing.Point(180, 144);
            txtAmount.Name = "txtAmount";
            txtAmount.PlaceholderForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            txtAmount.PlaceholderText = "0.00";
            txtAmount.SelectedText = "";
            txtAmount.Size = new System.Drawing.Size(160, 34);
            //
            // lblDeadline
            //
            lblDeadline.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblDeadline.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblDeadline.Location = new System.Drawing.Point(22, 188);
            lblDeadline.Name = "lblDeadline";
            lblDeadline.Size = new System.Drawing.Size(150, 24);
            lblDeadline.Text = "Deadline";
            //
            // dtpDeadline
            //
            dtpDeadline.Animated = true;
            dtpDeadline.BackColor = System.Drawing.Color.Transparent;
            dtpDeadline.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            dtpDeadline.BorderRadius = 8;
            dtpDeadline.BorderThickness = 1;
            dtpDeadline.Checked = true;
            dtpDeadline.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            dtpDeadline.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtpDeadline.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            dtpDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpDeadline.Location = new System.Drawing.Point(180, 186);
            dtpDeadline.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            dtpDeadline.MinDate = new System.DateTime(2024, 1, 1, 0, 0, 0, 0);
            dtpDeadline.Name = "dtpDeadline";
            dtpDeadline.Size = new System.Drawing.Size(160, 34);
            dtpDeadline.Value = new System.DateTime(2026, 12, 31, 0, 0, 0, 0);
            //
            // lblRequiredDocs
            //
            lblRequiredDocs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblRequiredDocs.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblRequiredDocs.Location = new System.Drawing.Point(22, 230);
            lblRequiredDocs.Name = "lblRequiredDocs";
            lblRequiredDocs.Size = new System.Drawing.Size(150, 24);
            lblRequiredDocs.Text = "Required Docs";
            //
            // txtRequiredDocs
            //
            txtRequiredDocs.Animated = true;
            txtRequiredDocs.BackColor = System.Drawing.Color.Transparent;
            txtRequiredDocs.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            txtRequiredDocs.BorderRadius = 8;
            txtRequiredDocs.BorderThickness = 1;
            txtRequiredDocs.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtRequiredDocs.DefaultText = "";
            txtRequiredDocs.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            txtRequiredDocs.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtRequiredDocs.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtRequiredDocs.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            txtRequiredDocs.Location = new System.Drawing.Point(180, 228);
            txtRequiredDocs.Name = "txtRequiredDocs";
            txtRequiredDocs.PlaceholderForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            txtRequiredDocs.PlaceholderText = "Comma-separated list";
            txtRequiredDocs.SelectedText = "";
            txtRequiredDocs.Size = new System.Drawing.Size(330, 34);
            //
            // lblMinCgpa
            //
            lblMinCgpa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblMinCgpa.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblMinCgpa.Location = new System.Drawing.Point(22, 272);
            lblMinCgpa.Name = "lblMinCgpa";
            lblMinCgpa.Size = new System.Drawing.Size(150, 24);
            lblMinCgpa.Text = "Minimum CGPA";
            //
            // txtMinCgpa
            //
            txtMinCgpa.Animated = true;
            txtMinCgpa.BackColor = System.Drawing.Color.Transparent;
            txtMinCgpa.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            txtMinCgpa.BorderRadius = 8;
            txtMinCgpa.BorderThickness = 1;
            txtMinCgpa.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtMinCgpa.DefaultText = "";
            txtMinCgpa.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            txtMinCgpa.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtMinCgpa.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtMinCgpa.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            txtMinCgpa.Location = new System.Drawing.Point(180, 270);
            txtMinCgpa.Name = "txtMinCgpa";
            txtMinCgpa.PlaceholderForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            txtMinCgpa.PlaceholderText = "e.g. 3.0";
            txtMinCgpa.SelectedText = "";
            txtMinCgpa.Size = new System.Drawing.Size(130, 34);
            //
            // lblMaxIncome
            //
            lblMaxIncome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblMaxIncome.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblMaxIncome.Location = new System.Drawing.Point(22, 314);
            lblMaxIncome.Name = "lblMaxIncome";
            lblMaxIncome.Size = new System.Drawing.Size(150, 24);
            lblMaxIncome.Text = "Max Family Income";
            //
            // txtMaxIncome
            //
            txtMaxIncome.Animated = true;
            txtMaxIncome.BackColor = System.Drawing.Color.Transparent;
            txtMaxIncome.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            txtMaxIncome.BorderRadius = 8;
            txtMaxIncome.BorderThickness = 1;
            txtMaxIncome.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtMaxIncome.DefaultText = "";
            txtMaxIncome.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            txtMaxIncome.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtMaxIncome.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtMaxIncome.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            txtMaxIncome.Location = new System.Drawing.Point(180, 312);
            txtMaxIncome.Name = "txtMaxIncome";
            txtMaxIncome.PlaceholderForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            txtMaxIncome.PlaceholderText = "e.g. 50000";
            txtMaxIncome.SelectedText = "";
            txtMaxIncome.Size = new System.Drawing.Size(160, 34);
            //
            // lblDegreeProgram
            //
            lblDegreeProgram.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblDegreeProgram.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblDegreeProgram.Location = new System.Drawing.Point(22, 356);
            lblDegreeProgram.Name = "lblDegreeProgram";
            lblDegreeProgram.Size = new System.Drawing.Size(150, 24);
            lblDegreeProgram.Text = "Degree / Dept";
            //
            // txtDegreeProgram
            //
            txtDegreeProgram.Animated = true;
            txtDegreeProgram.BackColor = System.Drawing.Color.Transparent;
            txtDegreeProgram.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            txtDegreeProgram.BorderRadius = 8;
            txtDegreeProgram.BorderThickness = 1;
            txtDegreeProgram.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtDegreeProgram.DefaultText = "";
            txtDegreeProgram.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            txtDegreeProgram.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtDegreeProgram.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtDegreeProgram.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            txtDegreeProgram.Location = new System.Drawing.Point(180, 354);
            txtDegreeProgram.Name = "txtDegreeProgram";
            txtDegreeProgram.PlaceholderForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            txtDegreeProgram.PlaceholderText = "e.g. BS Computer Science";
            txtDegreeProgram.SelectedText = "";
            txtDegreeProgram.Size = new System.Drawing.Size(250, 34);
            //
            // lblSemesterYear
            //
            lblSemesterYear.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblSemesterYear.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblSemesterYear.Location = new System.Drawing.Point(22, 398);
            lblSemesterYear.Name = "lblSemesterYear";
            lblSemesterYear.Size = new System.Drawing.Size(150, 24);
            lblSemesterYear.Text = "Semester / Year";
            //
            // txtSemesterYear
            //
            txtSemesterYear.Animated = true;
            txtSemesterYear.BackColor = System.Drawing.Color.Transparent;
            txtSemesterYear.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            txtSemesterYear.BorderRadius = 8;
            txtSemesterYear.BorderThickness = 1;
            txtSemesterYear.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtSemesterYear.DefaultText = "";
            txtSemesterYear.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            txtSemesterYear.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtSemesterYear.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtSemesterYear.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            txtSemesterYear.Location = new System.Drawing.Point(180, 396);
            txtSemesterYear.Name = "txtSemesterYear";
            txtSemesterYear.PlaceholderForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            txtSemesterYear.PlaceholderText = "e.g. 3rd / 2026";
            txtSemesterYear.SelectedText = "";
            txtSemesterYear.Size = new System.Drawing.Size(180, 34);
            //
            // lblNeedBased
            //
            lblNeedBased.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblNeedBased.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblNeedBased.Location = new System.Drawing.Point(22, 442);
            lblNeedBased.Name = "lblNeedBased";
            lblNeedBased.Size = new System.Drawing.Size(120, 24);
            lblNeedBased.Text = "Need-Based";
            //
            // chkNeedBased
            //
            chkNeedBased.Animated = true;
            chkNeedBased.BackColor = System.Drawing.Color.FromArgb(255, 248, 252);
            chkNeedBased.CheckedState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            chkNeedBased.CheckedState.BorderRadius = 4;
            chkNeedBased.CheckedState.BorderThickness = 1;
            chkNeedBased.CheckedState.FillColor = System.Drawing.Color.FromArgb(6, 148, 148);
            chkNeedBased.Location = new System.Drawing.Point(180, 440);
            chkNeedBased.Name = "chkNeedBased";
            chkNeedBased.Size = new System.Drawing.Size(22, 22);
            chkNeedBased.TabIndex = 21;
            chkNeedBased.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            chkNeedBased.UncheckedState.BorderRadius = 4;
            chkNeedBased.UncheckedState.BorderThickness = 1;
            chkNeedBased.UncheckedState.FillColor = System.Drawing.Color.White;
            //
            // lblActive
            //
            lblActive.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblActive.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblActive.Location = new System.Drawing.Point(330, 442);
            lblActive.Name = "lblActive";
            lblActive.Size = new System.Drawing.Size(60, 24);
            lblActive.Text = "Active";
            //
            // chkActive
            //
            chkActive.Animated = true;
            chkActive.BackColor = System.Drawing.Color.FromArgb(255, 248, 252);
            chkActive.Checked = true;
            chkActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            chkActive.CheckedState.BorderRadius = 4;
            chkActive.CheckedState.BorderThickness = 1;
            chkActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(6, 148, 148);
            chkActive.Location = new System.Drawing.Point(395, 440);
            chkActive.Name = "chkActive";
            chkActive.Size = new System.Drawing.Size(22, 22);
            chkActive.TabIndex = 23;
            chkActive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            chkActive.UncheckedState.BorderRadius = 4;
            chkActive.UncheckedState.BorderThickness = 1;
            chkActive.UncheckedState.FillColor = System.Drawing.Color.White;
            //
            // btnSave
            //
            btnSave.Animated = true;
            btnSave.AutoRoundedCorners = true;
            btnSave.BackColor = System.Drawing.Color.Transparent;
            btnSave.BorderRadius = 22;
            btnSave.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnSave.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnSave.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnSave.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnSave.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnSave.FillColor = System.Drawing.Color.FromArgb(255, 105, 180);
            btnSave.FillColor2 = System.Drawing.Color.FromArgb(0, 240, 255);
            btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnSave.HoverState.FillColor = System.Drawing.Color.FromArgb(200, 60, 130);
            btnSave.HoverState.FillColor2 = System.Drawing.Color.FromArgb(255, 150, 200);
            btnSave.Location = new System.Drawing.Point(316, 580);
            btnSave.Name = "btnSave";
            btnSave.ShadowDecoration.Color = System.Drawing.Color.FromArgb(80, 255, 105, 180);
            btnSave.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnSave.ShadowDecoration.Enabled = false;
            btnSave.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 6, 6);
            btnSave.Size = new System.Drawing.Size(120, 44);
            btnSave.TabIndex = 2;
            btnSave.Text = "Save";
            btnSave.Click += BtnSave_Click;
            btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // btnCancel
            //
            btnCancel.Animated = true;
            btnCancel.AutoRoundedCorners = true;
            btnCancel.BackColor = System.Drawing.Color.Transparent;
            btnCancel.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            btnCancel.BorderRadius = 22;
            btnCancel.BorderThickness = 1;
            btnCancel.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnCancel.FillColor = System.Drawing.Color.White;
            btnCancel.FillColor2 = System.Drawing.Color.White;
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnCancel.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            btnCancel.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            btnCancel.HoverState.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            btnCancel.HoverState.FillColor2 = System.Drawing.Color.FromArgb(255, 248, 252);
            btnCancel.HoverState.ForeColor = System.Drawing.Color.FromArgb(6, 148, 148);
            btnCancel.Location = new System.Drawing.Point(448, 580);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnCancel.Size = new System.Drawing.Size(110, 44);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "Cancel";
            btnCancel.Click += BtnCancel_Click;
            btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
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
            // AddEditScholarshipForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            ClientSize = new System.Drawing.Size(580, 650);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(pnlBody);
            Controls.Add(pnlHeader);
            Font = new System.Drawing.Font("Segoe UI", 9.75F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MinimumSize = new System.Drawing.Size(580, 650);
            AcceptButton = btnSave;
            CancelButton = btnCancel;
            Name = "AddEditScholarshipForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Scholarship";
            pnlBody.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Guna.UI2.WinForms.Guna2GradientPanel pnlHeader;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.Label lblHeaderTitle;
        private System.Windows.Forms.Label lblTitle, lblDesc, lblElig, lblAmount, lblDeadline, lblActive, lblRequiredDocs, lblMinCgpa, lblMaxIncome, lblDegreeProgram, lblSemesterYear, lblNeedBased;
        private Guna.UI2.WinForms.Guna2TextBox txtTitle, txtDesc, txtEligibility, txtAmount, txtRequiredDocs, txtMinCgpa, txtMaxIncome, txtDegreeProgram, txtSemesterYear;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpDeadline;
        private Guna.UI2.WinForms.Guna2CheckBox chkActive, chkNeedBased;
        private Guna.UI2.WinForms.Guna2GradientButton btnSave, btnCancel;
        private System.Windows.Forms.Panel pnlBody;
    }
}
