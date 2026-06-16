using System.Data;

namespace Window_Forms
{
    public partial class NotificationsForm : Form
    {
        public NotificationsForm(DataTable data)
        {
            InitializeComponent();
            dgvNotifications.DataSource = data;
        }

        private void NotificationsForm_Load(object sender, EventArgs e)
        {
            if (dgvNotifications.Columns["Message"] is DataGridViewColumn messageColumn)
                messageColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            if (dgvNotifications.Columns["CreatedDate"] is DataGridViewColumn cdCol)
                cdCol.HeaderText = "Date / Time";

            if (dgvNotifications.Columns["IsRead"] is DataGridViewColumn irCol)
            {
                irCol.HeaderText = "Read";
                irCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                irCol.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                irCol.FillWeight = 60;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
