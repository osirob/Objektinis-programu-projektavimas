using Microsoft.AspNetCore.SignalR.Client;
using Shared.Shared;

namespace Client
{
    public partial class Game : Form
    {
        private HubConnection connection;
        GameManager gameManager = GameManager.Instance;

        // Movement
        bool goleft = false;
        bool goright = false;
        bool jumping = false;
        int jumpSpeed = 10;
        int playerSpeed = 5;
        int force = 8;
        bool StartGame = false;
        int ticks = 0; //20ms is 1 tick

        // Stats
        int health = 0;
        int score = 0;

        // Player
        int playerId;
        PictureBox player;

        // Weapons
        int weaponSize = 10;
        PictureBox playerWeapon;
        bool rotatingUp = false;
        bool rotatingDown = false;
        double weaponAngle;
        int playerWeaponX;
        int playerWeaponY;
        double playerWeaponOffsetX;
        double playerWeaponOffsetY;
        int weaponDistance = 20;
        int weaponRotationSpeed = 5;
        PictureBox enemyWeapon;
        int enemyWeaponX;
        int enemyWeaponY;

        List<Coin> gameCoins;

        public Game()
        {
            InitializeComponent();
            player = player1;
            CheckPlayerIndex();
            _=InilitizeConectionAsync();
            InitializeCllectableListeners();
            StartGame = true;
            SendCordinatesTimer.Start();

            this.weaponAngle = 0;
            this.playerWeaponOffsetX = 0;
            this.playerWeaponOffsetY = 0;
            this.playerId = gameManager.GetYourId();
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
                AttachEventHandlers();
                CalculateWeaponParameters();
                CalculateAndSendPositionToAnotherPlayer();
                UpdateWeaponPositions();
                Movement();

                if (ticks >= 10) //if 10 secs or more elapsed 500
                {
                    ticks = 0;
                    await connection.SendAsync("RequestCoins");
                }
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
                if (e.KeyCode == Keys.Up)
                {
                    rotatingUp = true;
                }
                if (e.KeyCode == Keys.Down)
                {
                    rotatingDown = true;
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
                if (e.KeyCode == Keys.Up)
                {
                    rotatingUp = false;
                }
                if (e.KeyCode == Keys.Down)
                {
                    rotatingDown = false;
                }
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            // Creating the player's weapon.
            this.playerWeapon = new PictureBox();
            this.playerWeapon.Name = "weapon" + playerId;
            this.playerWeapon.Width = this.weaponSize;
            this.playerWeapon.Height = this.weaponSize;
            this.playerWeapon.BackColor = playerId == 0 ? Color.DarkBlue : Color.DarkRed;
            this.playerWeapon.Location = this.player.Location;
            this.Controls.Add(this.playerWeapon);

            // Creating the enemy's weapon.
            this.enemyWeapon = new PictureBox();
            this.enemyWeapon.Name = playerId == 0 ? "weapon" + 1 : "weapon" + 0;
            this.enemyWeapon.Width = this.weaponSize;
            this.enemyWeapon.Height = this.weaponSize;
            this.enemyWeapon.BackColor = playerId == 0 ? Color.DarkRed : Color.DarkBlue;
            this.enemyWeapon.Location = this.player2.Location;
            this.Controls.Add(this.enemyWeapon);
        }

        private double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        private void UpdateWeaponPositions()
        {
            this.playerWeapon.BringToFront();
            this.enemyWeapon.BringToFront();
            this.playerWeapon.Location = new Point(this.playerWeaponX, this.playerWeaponY);
            this.enemyWeapon.Location = new Point(this.enemyWeaponX, this.enemyWeaponY);
        }

        private void Movement()
        {
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

            if (rotatingUp)
            {
                this.weaponAngle -= this.weaponRotationSpeed;
            }

            if (rotatingDown)
            {
                this.weaponAngle += this.weaponRotationSpeed;
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
        }

        private async void CalculateAndSendPositionToAnotherPlayer()
        {
            if (playerId == 0)
            {
                this.playerWeaponX = Convert.ToInt32(this.player.Location.X + this.player.Width / 2 - this.weaponSize / 2 + this.playerWeaponOffsetX);
                this.playerWeaponY = Convert.ToInt32(this.player.Location.Y + this.player.Height / 2 - this.weaponSize / 2 + this.playerWeaponOffsetY);
                await connection.SendAsync("SendPlayer1WeaponCoordinatesToPlayer2", this.playerWeaponX + "," + this.playerWeaponY);
            }
            else
            {
                this.playerWeaponX = Convert.ToInt32(this.player2.Location.X + this.player2.Width / 2 - this.weaponSize / 2 + this.playerWeaponOffsetX);
                this.playerWeaponY = Convert.ToInt32(this.player2.Location.Y + this.player2.Height / 2 - this.weaponSize / 2 + this.playerWeaponOffsetY);
                await connection.SendAsync("SendPlayer2WeaponCoordinatesToPlayer1", this.playerWeaponX + "," + this.playerWeaponY);
            }
        }

        private void CalculateWeaponParameters()
        {
            this.playerWeaponOffsetX = Math.Sin(ConvertToRadians(this.weaponAngle)) * this.weaponDistance;
            this.playerWeaponOffsetY = Math.Cos(ConvertToRadians(this.weaponAngle)) * this.weaponDistance;
            if (this.weaponAngle < 0)
            {
                this.weaponAngle = 359;
            }
            if (this.weaponAngle >= 360)
            {
                this.weaponAngle = 0;
            }
        }

        private async void AttachEventHandlers()
        {
            if (playerId == 0)
            {
                testLabel.Text = "Player 0";
                connection.On<string>("secondPlayer", (message) =>
                {
                    string[] splitedText = message.Split(',');
                    player2.Left = Convert.ToInt32(splitedText[0]);
                    player2.Top = Convert.ToInt32(splitedText[1]);
                });
                await connection.SendAsync("GetFirtPlayerCordinates", player.Left + "," + player.Top);
                connection.On<string>("receivePlayer2WeaponCoordinates", (location) =>
                {
                    string[] splitedText = location.Split(',');
                    this.enemyWeaponX = Convert.ToInt32(splitedText[0]);
                    this.enemyWeaponY = Convert.ToInt32(splitedText[1]);
                });
            }
            if (playerId == 1)
            {
                testLabel.Text = "Player 1";
                connection.On<string>("firstPlayer", (message) =>
                {
                    string[] splitedText = message.Split(',');
                    player1.Left = Convert.ToInt32(splitedText[0]);
                    player1.Top = Convert.ToInt32(splitedText[1]);
                });
                await connection.SendAsync("GetSecondPlayerCordinates", player.Left + "," + player.Top);
                connection.On<string>("receivePlayer1WeaponCoordinates", (location) =>
                {
                    string[] splitedText = location.Split(',');
                    this.enemyWeaponX = Convert.ToInt32(splitedText[0]);
                    this.enemyWeaponY = Convert.ToInt32(splitedText[1]);
                });
            }
        }
    }
}
