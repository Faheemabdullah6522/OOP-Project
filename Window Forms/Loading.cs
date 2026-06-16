

namespace Window_Forms
{
    public partial class Loading : Form
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            timer1.Interval = 100;
            timer1.Start();
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            progressBar1.Value += 3;
            lblPercent.Text = progressBar1.Value.ToString() + "%";

            if (progressBar1.Value >= progressBar1.Maximum)
            {
                timer1.Stop();

                Login loginForm = new Login();
                loginForm.Show();
                this.Hide();
            }
        }
    }
}
