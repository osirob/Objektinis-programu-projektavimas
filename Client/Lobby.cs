using Microsoft.AspNetCore.SignalR.Client;
using Shared.Shared;

namespace Client
{
    public partial class BLOCKS : Form
    {
        private HubConnection connection;
        GameManager gameManager = GameManager.Instance;
        private Player me;
        private Player other;

        public BLOCKS()
        {
            InitializeComponent();
            player1Name.Text = String.Empty;
            player2Name.Text = String.Empty;
        }

        public void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void connectButton_Click(object sender, EventArgs e)
        {
            if (nicknameTextBox.Text == String.Empty) { return; } //can add message form with OK button "please enter nickname" 
            connectedToLobbyPanel.BringToFront();

            //establish connection with gamehub
            connection = new HubConnectionBuilder().WithUrl("https://localhost:7021/gameHub").Build();

            await connection.StartAsync();

            await connection.InvokeAsync<Player>("ConnectPlayer", nicknameTextBox.Text).ContinueWith(task => 
            {
                if(task.Result == null)
                {
                    //game full
                    return;
                }

                this.me = task.Result;
                gameManager.SetPlayer(task.Result, true);
                setMyPlayer();
            });

            await connection.InvokeAsync<Player>("GetOtherPLayer", this.me.Id).ContinueWith(task => 
            { 
                if(task.Result == null)
                {
                    //no other player yet
                    return;
                }

                this.other = task.Result;
                gameManager.SetPlayer(task.Result, false);
                setOtherPlayer();
            });

            connection.On<Player>("NewPlayer", otherPlayer => { this.other = otherPlayer; setOtherPlayer(); }); connectedToLobbyPanel.BringToFront();
        }

        private void setMyPlayer()
        {
            player1Name.Visible = true;
            player1Name.Text = this.me.Name;
        }

        private void setOtherPlayer()
        {
            if(this.other != null)
            {
                player2Name.Visible = true;
                player2Name.Text = this.other.Name;
            }
            readyButton.Visible = true;
        }

        private async void readyButton_Click(object sender, EventArgs e)
        {
            readyButton.Visible = false;
            notReadyButton.Visible = true;
            connection.On<string>("checkReady", async (message) =>
            {
                if (Convert.ToInt32(message) == 2)
                {
                    readyButton.Visible = false;
                    notReadyButton.Visible = false;
                    connection.On<string>("resetCount", (message) =>
                    {
                        
                    });
                    await connection.SendAsync("ResetReady", "Reseted");
                    StartGame();
                }
                else
                {
                    readyButton.Visible = false;
                    notReadyButton.Visible = true;
                }
            });
            await connection.SendAsync("CheckHowManyReadyIs", "User checked");

        }

        private async void notReadyButton_Click(object sender, EventArgs e)
        {
            readyButton.Visible = true;
            notReadyButton.Visible = false;

            await connection.SendAsync("UndoReady", "User checked");
        }

        //Still testing this
        private async void StartGame()
        {
            
            var openedForms = 0;
            counter.Visible = true;
            ////label4.Text = "Start game maybe will start";
            connection.On<string>("counter", (message) =>
            {
                if (message != "BEGIN")
                {
                    counter.Text = message;
                }
                else
                {
                    counter.Text = "Game is Started";
                    Thread.Sleep(300);
                    //this.Visible = false;
                    if(openedForms == 0)
                    {
                        Game gameForm = new Game();
                        gameForm.Visible = true;
                        openedForms++;
                    }

                }
                
            });

            await connection.SendAsync("StartCounting", "Counting started");
        }
    }
}