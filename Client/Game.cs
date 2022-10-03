using Microsoft.AspNetCore.SignalR.Client;
using Shared.Shared;

namespace Client
{
    public partial class Game : Form
    {
        private HubConnection connection;

        // Movement
        bool goleft = false;
        bool goright = false;
        bool jumping = false;
        int jumpSpeed = 10;
        int playerSpeed = 5;
        int force = 8;
        bool StartGame = false;
        int ticks = 0; //20ms is 1 tick

        GameManager gameManager = GameManager.Instance;

        // Stats
        int health = 0;
        int score = 0;

        // Player index
        int playerIndex = -1;


        PictureBox player;
        List<Coin> gameCoins;

        public Game()
        {
            InitializeComponent();
            player = player1;
            CheckPlayerIndex();
            //AsignPlayers();
            _=InilitizeConectionAsync();
            InitializeCllectableListeners();
            StartGame = true;
            SendCordinatesTimer.Start();
        }

        public async Task InilitizeConectionAsync()
        {
            connection = new HubConnectionBuilder().WithUrl("https://localhost:7021/gameHub").Build();
            await connection.StartAsync();
        }

        public void InitializeCllectableListeners()
        {
            gameCoins = new List<Coin>();
            connection.On<List<Coin>>("sendCoins", coins => {
                gameCoins.AddRange(coins);
                trashLabel.Text = $"Recieved {coins.Count} coins";
                foreach(Coin coin in gameCoins)
                {
                    var box = new PictureBox
                    {
                        Tag = coin.Tag,
                        Size = new Size(15, 15),
                        Location = new Point(coin.XCoord, 50), //change coord logic later
                        BackColor = Color.Yellow
                    };
                    this.Controls.Add(box);
                }
            });
        }
        
        private void CheckPlayerIndex()
        {
            if (gameManager.GetYourId() == 0)
            {
                player = player1;
                playerLabel.Text = gameManager.GetName();
            }
            else
            {
                playerLabel.Text = gameManager.GetName();
                player = player2;
            }
        }

        //This method executes each 20ms, basically making it the engine
        private async void gameTimer_TickAsync(object sender, EventArgs e)
        {
            if (StartGame)
            {
                ticks++;

                player.Top += jumpSpeed;

                if (jumping && force < 0)
                {
                    jumping = false;
                }

                if (goleft)
                {
                    player.Left -= playerSpeed;
                }

                if (goright)
                {
                    player.Left += playerSpeed;
                }

                if (jumping)
                {
                    jumpSpeed = -12;
                    force -= 1;
                }
                else
                {
                    jumpSpeed = 12;
                }

                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && x.Tag == "platform")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && !jumping)
                        {
                            force = 8;
                            player.Top = x.Top - player.Height;
                        }
                    }
                }

                if(ticks >= 10) //if 10 secs or more elapsed 500
                {
                    ticks = 0;
                    await connection.SendAsync("RequestCoins");
                }
            }
        }


        public async Task SendCordinates_TickAsync()
        {

            if (gameManager.GetYourId() == 0)
            {
                testLabel.Text = "Player 0";
                connection.On<string>("secondPlayer", (message) =>
                {
                    string[] splitedText = message.Split(',');
                    player2.Left = Convert.ToInt32(splitedText[0]);
                    player2.Top = Convert.ToInt32(splitedText[1]);
                });
                await connection.SendAsync("GetFirtPlayerCordinates", player.Left + "," + player.Top);
            }
            else
            {
                testLabel.Text = "Player 1";
                connection.On<string>("firstPlayer", (message) =>
                {
                    string[] splitedText = message.Split(',');
                    player1.Left = Convert.ToInt32(splitedText[0]);
                    player1.Top = Convert.ToInt32(splitedText[1]);
                });
                await connection.SendAsync("GetSecondPlayerCordinates", player.Left + "," + player.Top);
            }
        }

        private void keyIsDown(object sender, KeyEventArgs e)
        {
            if (StartGame)
            {
                if (e.KeyCode == Keys.Left)
                {
                    goleft = true;
                }
                if (e.KeyCode == Keys.Right)
                {
                    goright = true;
                }
                if (e.KeyCode == Keys.Space && !jumping)
                {
                    jumping = true;
                }
            }
        }

        private void keyIsUp(object sender, KeyEventArgs e)
        {
            if (StartGame)
            {
                if (e.KeyCode == Keys.Left)
                {
                    goleft = false;
                }

                if (e.KeyCode == Keys.Right)
                {
                    goright = false;
                }
                if (jumping)
                {
                    jumping = false;
                }
            }
        }

        private void SendCordinatesTimer_Tick(object sender, EventArgs e)
        {
            SendCordinates_TickAsync();
        }
    }
}
