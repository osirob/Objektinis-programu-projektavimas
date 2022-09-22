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
            nicknameLabel.Visible = false;
            nicknameTextBox.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            button2.Visible = true;
            textBox1.Visible = true;
            startGameButton.Visible = true;

        }

        private async void button2_Click(object sender, EventArgs e)
        {
            await connection.SendAsync("SendMessage", textBox1.Text +" by " + nicknameTextBox.Text);
        }

        private async void startGameButton_Click(object sender, EventArgs e)
        {
            startGameButton.Visible = false;
            unreadyButton.Visible = true;
            connection.On<string>("checkReady", async (message) =>
            {
                if (Convert.ToInt32(message) == 2)
                {
                    startGameButton.Visible = false;
                    unreadyButton.Visible = false;
                    connection.On<string>("resetCount", (message) =>
                    {
                        
                    });
                    await connection.SendAsync("ResetReady", "Reseted");
                    StartGame();
                }
                else
                {
                    startGameButton.Visible = false;
                    unreadyButton.Visible = true;
                }
            });
            await connection.SendAsync("CheckHowManyReadyIs", "User checked");

        }

        private async void unreadyButton_Click(object sender, EventArgs e)
        {
            startGameButton.Visible = true;
            unreadyButton.Visible = false;

            await connection.SendAsync("UndoReady", "User checked");
        }

        //Still testing this
        private async void StartGame()
        {
            label4.Text = "Start game maybe will start";
            connection.On<string>("counter", (message) =>
            {
                if (message != "BEGIN")
                {
                    label4.Text = message;
                }
                else
                {
                    label4.Text = "Game is Started";
                }
                
            });

            await connection.SendAsync("StartCounting", "Counting started");
        }
    }
}