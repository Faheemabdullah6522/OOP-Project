namespace Window_Forms
{
    partial class ApplyForm
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
            lblTitle = new System.Windows.Forms.Label();
            lblRequiredDocs = new System.Windows.Forms.Label();
            lblComments = new System.Windows.Forms.Label();
            listBoxDocs = new System.Windows.Forms.ListBox();
            btnUpload = new Guna.UI2.WinForms.Guna2GradientButton();
            btnSubmit = new Guna.UI2.WinForms.Guna2GradientButton();
            btnCancel = new Guna.UI2.WinForms.Guna2GradientButton();
            txtComments = new Guna.UI2.WinForms.Guna2TextBox();
            openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            pnlHeader = new Guna.UI2.WinForms.Guna2GradientPanel();
            btnClose = new Guna.UI2.WinForms.Guna2Button();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            guna2DragControl1 = new Guna.UI2.WinForms.Guna2DragControl(components);
            pnlHeader.SuspendLayout();
            SuspendLayout();
            //
            // pnlHeader
            //
            pnlHeader.BackColor = System.Drawing.Color.Transparent;
            pnlHeader.Controls.Add(btnClose);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.FillColor = System.Drawing.Color.FromArgb(6, 148, 148);
            pnlHeader.FillColor2 = System.Drawing.Color.FromArgb(0, 240, 255);
            pnlHeader.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnlHeader.Size = new System.Drawing.Size(640, 72);
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
            btnClose.Location = new System.Drawing.Point(592, 18);
            btnClose.Name = "btnClose";
            btnClose.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnClose.Size = new System.Drawing.Size(36, 36);
            btnClose.TabIndex = 1;
            btnClose.Text = "X";
            btnClose.Click += BtnCancel_Click;
            btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // lblTitle
            //
            lblTitle.AutoSize = false;
            lblTitle.BackColor = System.Drawing.Color.Transparent;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.White;
            lblTitle.Location = new System.Drawing.Point(28, 16);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(550, 40);
            lblTitle.Text = "Applying for:";
            //
            // lblRequiredDocs
            //
            lblRequiredDocs.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblRequiredDocs.ForeColor = System.Drawing.Color.FromArgb(6, 148, 148);
            lblRequiredDocs.Location = new System.Drawing.Point(36, 94);
            lblRequiredDocs.Name = "lblRequiredDocs";
            lblRequiredDocs.Size = new System.Drawing.Size(200, 24);
            lblRequiredDocs.Text = "Required Documents";
            //
            // listBoxDocs
            //
            listBoxDocs.BackColor = System.Drawing.Color.FromArgb(255, 248, 252);
            listBoxDocs.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            listBoxDocs.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            listBoxDocs.Location = new System.Drawing.Point(36, 122);
            listBoxDocs.Name = "listBoxDocs";
            listBoxDocs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            listBoxDocs.Size = new System.Drawing.Size(568, 144);
            listBoxDocs.TabIndex = 2;
            //
            // btnUpload
            //
            btnUpload.Animated = true;
            btnUpload.AutoRoundedCorners = true;
            btnUpload.BackColor = System.Drawing.Color.Transparent;
            btnUpload.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            btnUpload.BorderRadius = 19;
            btnUpload.BorderThickness = 1;
            btnUpload.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnUpload.FillColor = System.Drawing.Color.White;
            btnUpload.FillColor2 = System.Drawing.Color.White;
            btnUpload.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnUpload.ForeColor = System.Drawing.Color.FromArgb(6, 148, 148);
            btnUpload.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            btnUpload.HoverState.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            btnUpload.HoverState.FillColor2 = System.Drawing.Color.FromArgb(255, 248, 252);
            btnUpload.Location = new System.Drawing.Point(36, 278);
            btnUpload.Name = "btnUpload";
            btnUpload.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnUpload.Size = new System.Drawing.Size(160, 40);
            btnUpload.TabIndex = 3;
            btnUpload.Text = "Upload Selected";
            btnUpload.Click += BtnUpload_Click;
            btnUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            //
            // lblComments
            //
            lblComments.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblComments.ForeColor = System.Drawing.Color.FromArgb(6, 148, 148);
            lblComments.Location = new System.Drawing.Point(36, 455);
            lblComments.Name = "lblComments";
            lblComments.Size = new System.Drawing.Size(150, 24);
            lblComments.Text = "Your Comments";
            //
            // txtComments
            //
            txtComments.Animated = true;
            txtComments.BackColor = System.Drawing.Color.Transparent;
            txtComments.BorderColor = System.Drawing.Color.FromArgb(0, 200, 210);
            txtComments.BorderRadius = 10;
            txtComments.BorderThickness = 1;
            txtComments.Cursor = System.Windows.Forms.Cursors.IBeam;
            txtComments.DefaultText = "";
            txtComments.FillColor = System.Drawing.Color.FromArgb(255, 248, 252);
            txtComments.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtComments.ForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            txtComments.HoverState.BorderColor = System.Drawing.Color.FromArgb(6, 148, 148);
            txtComments.Location = new System.Drawing.Point(36, 480);
            txtComments.Multiline = true;
            txtComments.Name = "txtComments";
            txtComments.PlaceholderForeColor = System.Drawing.Color.FromArgb(148, 163, 184);
            txtComments.PlaceholderText = "Additional comments (optional)";
            txtComments.SelectedText = "";
            txtComments.Size = new System.Drawing.Size(568, 96);
            txtComments.TabIndex = 4;
            //
            // btnSubmit
            //
            btnSubmit.Animated = true;
            btnSubmit.AutoRoundedCorners = true;
            btnSubmit.BackColor = System.Drawing.Color.Transparent;
            btnSubmit.BorderRadius = 22;
            btnSubmit.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnSubmit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            btnSubmit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            btnSubmit.DisabledState.FillColor = System.Drawing.Color.FromArgb(169, 169, 169);
            btnSubmit.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(169, 169, 169);
            btnSubmit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(141, 141, 141);
            btnSubmit.FillColor = System.Drawing.Color.FromArgb(255, 105, 180);
            btnSubmit.FillColor2 = System.Drawing.Color.FromArgb(0, 240, 255);
            btnSubmit.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnSubmit.ForeColor = System.Drawing.Color.White;
            btnSubmit.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal;
            btnSubmit.HoverState.FillColor = System.Drawing.Color.FromArgb(200, 60, 130);
            btnSubmit.HoverState.FillColor2 = System.Drawing.Color.FromArgb(255, 150, 200);
            btnSubmit.Location = new System.Drawing.Point(300, 610);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.ShadowDecoration.Color = System.Drawing.Color.FromArgb(80, 255, 105, 180);
            btnSubmit.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnSubmit.ShadowDecoration.Enabled = false;
            btnSubmit.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(0, 0, 6, 6);
            btnSubmit.Size = new System.Drawing.Size(180, 46);
            btnSubmit.TabIndex = 5;
            btnSubmit.Text = "Submit Application";
            btnSubmit.Click += BtnSubmit_Click;
            btnSubmit.Cursor = System.Windows.Forms.Cursors.Hand;
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
            btnCancel.Location = new System.Drawing.Point(490, 610);
            btnCancel.Name = "btnCancel";
            btnCancel.ShadowDecoration.CustomizableEdges = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            btnCancel.Size = new System.Drawing.Size(114, 42);
            btnCancel.TabIndex = 6;
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
            // ApplyForm
            //
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
            ClientSize = new System.Drawing.Size(640, 680);
            Controls.Add(btnSubmit);
            Controls.Add(btnCancel);
            Controls.Add(txtComments);
            Controls.Add(lblComments);
            Controls.Add(btnUpload);
            Controls.Add(listBoxDocs);
            Controls.Add(lblRequiredDocs);
            Controls.Add(pnlHeader);
            Font = new System.Drawing.Font("Segoe UI", 9.75F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MinimumSize = new System.Drawing.Size(640, 680);
            AcceptButton = btnSubmit;
            CancelButton = btnCancel;
            Name = "ApplyForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            KeyPreview = true;
            Text = "Apply for Scholarship";
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
            StartPosition = FormStartPosition.CenterScreen;
        }

        private Guna.UI2.WinForms.Guna2GradientPanel pnlHeader;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2DragControl guna2DragControl1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblRequiredDocs;
        private System.Windows.Forms.Label lblComments;
        private System.Windows.Forms.ListBox listBoxDocs;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Guna.UI2.WinForms.Guna2GradientButton btnUpload;
        private Guna.UI2.WinForms.Guna2GradientButton btnSubmit;
        private Guna.UI2.WinForms.Guna2GradientButton btnCancel;
        private Guna.UI2.WinForms.Guna2TextBox txtComments;
    }
}
