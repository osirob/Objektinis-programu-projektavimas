using Client.Facade;
using Microsoft.AspNetCore.SignalR.Client;
using Shared.Shared;
using Timer = System.Windows.Forms.Timer;


namespace Client
{
    public enum CurrentWeaponType
    {
        Pistol = 1,
        Rifle = 2,
        Shotgun = 3,
        Bazooka = 4
    }
    public partial class Game : Form
    {
        private HubConnection connection;
        GameManager gameManager = GameManager.Instance;
        private WeaponShop weaponShop;

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
        int health = 100;
        int score = 0;
        int money = 0;

        // Player
        int playerId;
        PictureBox player;

        // Weapons
        int shootingPower = 2;
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
        Pistol pistol = new Pistol("Pistol");
        PictureBox player1 = null;
        PictureBox player2 = null;

        // Bullets
        private PistolBullet pistolBulletClass;
        PictureBox pistolBullet;
        Timer pistonBulletTimer;
        private int standartWidth = 1;
        private int standartHeight = 1;

        List<Coin> gameCoins;
        private FakeCoinAdapter fakeCoin;

        //Strategy 
        private IShooting _shooting;

        public void setStrategy(IShooting strategy)
        {
            _shooting = strategy;
        }

        public Game()
        {
            BuildMap();
            InitializeComponent();
            player1 = (PictureBox)this.Controls["player1"];
            player2 = (PictureBox)this.Controls["player2"];
            _ = InilitizeConectionAsync();
            InitializeCllectableListeners();
            InitializeFakeCoins();
            UpdateStats();
            CheckPlayerIndex();
            StartGame = true;
            weaponShop = new WeaponShop();
            SendCordinatesTimer.Start();
            shopPanel.Visible = false;
            shopPanel.Enabled = false;

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

        //width: 0 - 900
        //height: 0 - 600
        //upper left corner is 0 0, lower right is 900, 600
        public void InitializeCllectableListeners()
        {
            gameCoins = new List<Coin>();
            connection.On<List<Coin>>("sendCoins", coins =>
            {
                gameCoins.AddRange(coins);
                foreach (Coin coin in gameCoins)
                {
                    var box = new PictureBox
                    {
                        Tag = coin.Tag,
                        Size = new Size(15, 15),
                        Location = new Point(coin.XCoord, coin.YCoord),
                        BackColor = Color.Yellow
                    };
                    this.Controls.Add(box);
                }
            });

            connection.On<int>("removeCoin", id =>
            {
                removeCoin(id);
            });
        }

        public void InitializeFakeCoins()
        {
            gameCoins = new List<Coin>();
            connection.On<List<Coin>>("sendFakeCoins", coins =>
            {
                gameCoins.AddRange(coins);
                for (int i = 0; i < 1; i++)
                {
                    Coin coin = gameCoins[6];
                    fakeCoin = new FakeCoinAdapter(coin);
                    fakeCoin.isFake();
                    var fakeBox = new PictureBox
                    {
                        Tag = coin.Tag,
                        Size = new Size(15, 15),
                        Location = new Point(coin.XCoord, coin.YCoord),
                        BackColor = Color.Red
                    };
                    Controls.Add(fakeBox);
                }

            });

            connection.On<int>("removeCoin", id =>
            {
                removeCoin(id);
            });
        }

        private void removeCoin(int coinId)
        {
            var coin = this.gameCoins.Where(c => c.Id == coinId).FirstOrDefault();
            if (coin != null)
            {
                foreach (Control x in this.Controls)
                {
                    if (x is PictureBox && (string)x.Tag == "coin" && x.Location.X == coin.XCoord && x.Location.Y == coin.YCoord)
                    {
                        this.Controls.Remove(x);
                        this.gameCoins.Remove(coin);
                    }
                }
            }
        }

        private void UpdateStats()
        {
            this.hpCountLabel.Text = this.health.ToString();
            this.moneyCountLabel.Text = this.money.ToString();
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
                player = (PictureBox)this.Controls["player2"];
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
                CoinIntersect();
                BulletIntersect();
                ticks++;

                if (ticks >= 100 && this.gameCoins.Count == 0)
                {
                    ticks = 0;
                    await connection.SendAsync("RequestCoins");
                    await connection.SendAsync("RequestFakeCoins");
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
                if (e.KeyCode == Keys.B)
                {
                    shopPanel.Visible = true;
                    shopPanel.Enabled = true;
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

                if (e.KeyCode == Keys.G)
                {
                    ShootBullet();
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

            setStrategy(pistol);
            pistolBulletClass = new PistolBullet();
            /*setStrategy(rifle);
            setStrategy(shotgun);
            setStrategy(bazooka);*/
            shootingPower = _shooting.Shoot(shootingPower);
            weaponNameLabel.Text = _shooting.Name;
            ammoCountLabel.Text = _shooting.Ammunition.ToString();
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

        private async void CoinIntersect()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "coin")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        var coin = gameCoins.Where(c => c.XCoord == x.Location.X && c.YCoord == x.Location.Y).FirstOrDefault();
                        this.money += coin.Value;
                        UpdateStats();
                        this.Controls.Remove(x);
                        this.gameCoins.Remove(coin);
                        //send to server for other player to remove same coin
                        await connection.SendAsync("PickedUpCoin", coin.Id, playerId);
                    }
                }
            }
        }

        private async void BulletIntersect()
        {
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "bullet")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        //var coin = gameCoins.Where(c => c.XCoord == x.Location.X && c.YCoord == x.Location.Y).FirstOrDefault();
                        //this.money += coin.Value;
                        this.health -= 10;
                        UpdateStats();
                        this.Controls.Remove(x);

                        //this.gameCoins.Remove(coin);
                        //send to server for other player to remove same coin
                        await connection.SendAsync("TakeDamage", playerId, 10);
                        if (this.health <= 0)
                        {
                            _ = TestDeathAsync();
                        }

                    }
                }
            }
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
                if (x is PictureBox && (string)x.Tag == "platform")
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

        private void SendCordinatesTimer_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _ = TestDeathAsync();
        }

        async Task TestDeathAsync()
        {
            await connection.SendAsync("Die", playerId);
        }

        public void MakeBullet()
        {
            pistolBullet = new PictureBox();
            pistolBullet.Tag = "bullet";

            //Pistol Standart Bullet
            /*StandartBullet standartBullet = new StandartBullet(pistolBulletClass);
            pistolBullet.BackColor = Color.Silver;
            pistolBullet.Size = new Size(standartBullet.CalculateWidth(standartWidth), standartBullet.CalculateHeight(standartHeight));
            pistolBullet.Tag = pistolBulletClass.Tag;*/

            //Pistol Gold Bullet
            GoldBullet goldBullet = new GoldBullet(pistolBulletClass);
            pistolBullet.BackColor = Color.Gold;
            pistolBullet.Size = new Size(goldBullet.CalculateWidth(standartWidth), goldBullet.CalculateHeight(standartHeight));
            //pistolBullet.Tag = pistolBulletClass.Tag;

            //Pistol Diamond Bullet
            /*DiamondBullet diamondBullet = new DiamondBullet(pistolBulletClass);
            pistolBullet.BackColor = Color.DodgerBlue;
            pistolBullet.Size = new Size(diamondBullet.CalculateWidth(standartWidth), diamondBullet.CalculateHeight(standartHeight));
            pistolBullet.Tag = pistolBulletClass.Tag;*/

            pistolBullet.Location = playerWeapon.Location;
            pistolBullet.Left = playerWeapon.Left + playerWeapon.Width / 2;
            pistolBullet.Top = playerWeapon.Top + playerWeapon.Height / 2;
            pistolBullet.BringToFront();
            Controls.Add(pistolBullet);

            pistonBulletTimer = new Timer();
            pistonBulletTimer.Interval = 20;
            pistonBulletTimer.Tick += new EventHandler(BulletTimerEvent);
            pistonBulletTimer.Start();
        }

        private void BulletTimerEvent(object sender, EventArgs e)
        {

            if (weaponAngle >= 0 && weaponAngle <= 180)
            {
                //trashLabel.Text = "ShootRight";
                moneyLabel.Text = shootingPower.ToString();
                pistolBullet.Left += shootingPower;
            }
            if (weaponAngle <= 360 && weaponAngle >= 180)
            {
                //trashLabel.Text = "ShootLeft";
                moneyLabel.Text = shootingPower.ToString();
                pistolBullet.Left -= shootingPower;
            }
            /*if (pistolBullet.Left > 1000 || pistolBullet.Top > 400)
            {
                pistonBulletTimer.Stop(); // stop the timer
                pistonBulletTimer.Dispose(); // dispose the timer event and component from the program
                pistonBulletTimer.Dispose(); // dispose the bullet
                pistonBulletTimer = null; // nullify the timer object
                pistolBullet = null; // nullify the bullet object
            }*/
        }

        private void ShootBullet()
        {
            MakeBullet();
        }

        private void BuildMap()
        {
            Map map = GameManagerServer.Instance.GetMap();
            foreach (MapEntity mapEntity in map.getMapEntities())
            {
                PictureBox mapObject = new PictureBox
                {
                    Tag = mapEntity.getTag(),
                    Size = new Size(mapEntity.getSizeX(), mapEntity.getSizeY()),
                    Location = new Point(mapEntity.getPosX(), mapEntity.getPosY()),
                    BackColor = mapEntity.getColor(),
                    Name = mapEntity.getName(),
                };
                this.Controls.Add(mapObject);
            }
        }

        private void buyPistolButton_Click(object sender, EventArgs e)
        {
            var weap = weaponShop.BuyWeapon(CurrentWeaponType.Pistol, ref this.money);
            if (weap != null)
            {
                _shooting = weap;
                weaponNameLabel.Text = _shooting.Name;
                moneyCountLabel.Text = money.ToString();
                ammoCountLabel.Text = _shooting.Ammunition.ToString();
            }
        }

        private void closeShopButton_Click(object sender, EventArgs e)
        {
            shopPanel.Visible = false;
            shopPanel.Enabled = false;
        }

        private void buyRifleButton_Click(object sender, EventArgs e)
        {
            var weap = weaponShop.BuyWeapon(CurrentWeaponType.Rifle, ref this.money);
            if (weap != null)
            {
                _shooting = weap;
                weaponNameLabel.Text = _shooting.Name;
                moneyCountLabel.Text = money.ToString();
                ammoCountLabel.Text = _shooting.Ammunition.ToString();
            }
        }

        private void buyShotgunButton_Click(object sender, EventArgs e)
        {
            var weap = weaponShop.BuyWeapon(CurrentWeaponType.Shotgun, ref this.money);
            if (weap != null)
            {
                _shooting = weap;
                weaponNameLabel.Text = _shooting.Name;
                moneyCountLabel.Text = money.ToString();
                ammoCountLabel.Text = _shooting.Ammunition.ToString();
            }
        }

        private void buyBazookaButton_Click(object sender, EventArgs e)
        {
            var weap = weaponShop.BuyWeapon(CurrentWeaponType.Bazooka, ref this.money);
            if (weap != null)
            {
                _shooting = weap;
                weaponNameLabel.Text = _shooting.Name;
                moneyCountLabel.Text = money.ToString();
                ammoCountLabel.Text = _shooting.Ammunition.ToString();
            }
        }

        private void buyPistolAmmoButton_Click(object sender, EventArgs e)
        {
            weaponShop.BuyAmmunition(CurrentWeaponType.Pistol, ref _shooting, ref this.money);
            ammoCountLabel.Text = _shooting.Ammunition.ToString();
            moneyCountLabel.Text = money.ToString();
        }

        private void buyRifleAmmoButton_Click(object sender, EventArgs e)
        {
            weaponShop.BuyAmmunition(CurrentWeaponType.Rifle, ref _shooting, ref this.money);
            ammoCountLabel.Text = _shooting.Ammunition.ToString();
            moneyCountLabel.Text = money.ToString();
        }

        private void buyShotgunAmmoButton_Click(object sender, EventArgs e)
        {
            weaponShop.BuyAmmunition(CurrentWeaponType.Shotgun, ref _shooting, ref this.money);
            ammoCountLabel.Text = _shooting.Ammunition.ToString();
            moneyCountLabel.Text = money.ToString();
        }

        private void buyBazookaAmmoButton_Click(object sender, EventArgs e)
        {
            weaponShop.BuyAmmunition(CurrentWeaponType.Bazooka, ref _shooting, ref this.money);
            ammoCountLabel.Text = _shooting.Ammunition.ToString();
            moneyCountLabel.Text = money.ToString();
        }
    }
}
