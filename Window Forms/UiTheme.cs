using System.Drawing;
using System.Windows.Forms;

namespace Window_Forms
{
    public static class UiTheme
    {
        public static readonly Color Primary = Color.FromArgb(9, 74, 158);
        public static readonly Color PrimaryLight = Color.FromArgb(33, 145, 245);
        public static readonly Color Accent = Color.FromArgb(20, 184, 166);
        public static readonly Color Danger = Color.FromArgb(220, 53, 69);
        public static readonly Color Surface = Color.White;
        public static readonly Color Page = Color.FromArgb(244, 248, 252);
        public static readonly Color Text = Color.FromArgb(31, 41, 55);
        public static readonly Color Muted = Color.FromArgb(107, 114, 128);

        public static void ApplyForm(Form form)
        {
            form.BackColor = Page;
            form.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            form.StartPosition = FormStartPosition.CenterScreen;
        }

        public static void StyleHeading(Label label)
        {
            label.ForeColor = Primary;
            label.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            label.AutoSize = false;
            label.TextAlign = ContentAlignment.MiddleLeft;
        }

        public static void StyleSubHeading(Label label)
        {
            label.ForeColor = Muted;
            label.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
        }

        public static void StyleButton(Control button, bool secondary = false, bool danger = false)
        {
            button.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            button.ForeColor = secondary ? Primary : Color.White;
            button.BackColor = danger ? Danger : secondary ? Color.White : PrimaryLight;
            button.Cursor = Cursors.Hand;

            if (button is Button winButton)
            {
                winButton.FlatStyle = FlatStyle.Flat;
                winButton.FlatAppearance.BorderSize = secondary ? 1 : 0;
                winButton.FlatAppearance.BorderColor = Color.FromArgb(205, 218, 235);
                winButton.UseVisualStyleBackColor = false;
            }
        }

        public static void StyleDangerButton(Control button)
        {
            StyleButton(button, danger: true);
        }

        public static void StyleGrid(DataGridView grid)
        {
            grid.BackgroundColor = Surface;
            grid.BorderStyle = BorderStyle.None;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.EnableHeadersVisualStyles = false;
            grid.GridColor = Color.FromArgb(226, 232, 240);
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToResizeRows = false;
            grid.ReadOnly = true;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;

            grid.ColumnHeadersDefaultCellStyle.BackColor = Primary;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = Primary;
            grid.ColumnHeadersHeight = 42;

            grid.DefaultCellStyle.BackColor = Surface;
            grid.DefaultCellStyle.ForeColor = Text;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(210, 232, 255);
            grid.DefaultCellStyle.SelectionForeColor = Text;
            grid.DefaultCellStyle.Padding = new Padding(8, 4, 8, 4);
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            grid.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 251, 255);
            grid.RowTemplate.Height = 44;
        }

        public static Panel CreateHeader(string title, string subtitle)
        {
            Panel header = new Panel
            {
                Dock = DockStyle.Top,
                Height = 92,
                BackColor = Surface,
                Padding = new Padding(24, 16, 24, 12)
            };

            Label titleLabel = new Label
            {
                Text = title,
                Dock = DockStyle.Top,
                Height = 34
            };
            StyleHeading(titleLabel);

            Label subtitleLabel = new Label
            {
                Text = subtitle,
                Dock = DockStyle.Top,
                Height = 24
            };
            StyleSubHeading(subtitleLabel);

            header.Controls.Add(subtitleLabel);
            header.Controls.Add(titleLabel);
            return header;
        }

        public static Panel CreateCard()
        {
            return new Panel
            {
                BackColor = Surface,
                Padding = new Padding(14),
                BorderStyle = BorderStyle.FixedSingle
            };
        }
    }
}
