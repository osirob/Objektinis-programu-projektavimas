using Microsoft.AspNetCore.SignalR.Client;

namespace Client
{
    public partial class BLOCKS : Form
    {
        private HubConnection connection;
        public BLOCKS()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void connectButton_Click(object sender, EventArgs e)
        {
            connection = new HubConnectionBuilder().WithUrl("https://localhost:7021/gameHub").Build();
            connection.On<string>("recievingMessage", (message) =>
            {
                label4.Text = message;
            });

            connection.On<string>("checkOnline", (message) =>
            {
                label5.Text = "Online now is:" + message;
            });

            await connection.StartAsync();
            label2.Text = "Yes";
            connectButton.Visible = false;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await connection.SendAsync("SendMessage", textBox1.Text);
        }
    }
}