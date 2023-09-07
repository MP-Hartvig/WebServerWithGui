namespace WebServerWithGui
{
    public partial class Form1 : Form
    {
        private readonly Manager _manager;
        private string defaultPort = "8080";

        public Form1(Manager manager)
        {
            _manager = manager;
            InitializeComponent();
            tbPort.PlaceholderText = defaultPort;
            btnStop.Enabled = false;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbPort.Text))
            {
                tbPort.Text = defaultPort;
            }

            _manager.StartServer(tbServerIp.Text, tbPort.Text, tbContent.Text);

            btnStart.Enabled = false;

            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _manager.StopServer();

            btnStart.Enabled = true;

            btnStop.Enabled = false;
        }
    }
}