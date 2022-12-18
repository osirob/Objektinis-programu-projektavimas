using Client.Facade;
using Microsoft.AspNetCore.SignalR.Client;
using Shared.Shared;
using Timer = System.Windows.Forms.Timer;
using Shared.Prototype;
using Shared.Bridge;
using Shared.State;


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
        int testCount = 0;
        // Weapons
        int shootingPower = 1;
        int weaponSize = 10;
        PictureBox playerWeapon;
        bool rotatingUp = false;
        bool rotatingDown = false;
        double weaponAngle;
        double snapshotWeaponAngle;
        double enemyWeaponAngle;
        int playerWeaponX;
        int playerWeaponY;
        double playerWeaponOffsetX;
        double playerWeaponOffsetY;
        int weaponDistance = 20;
        int weaponRotationSpeed = 5;
        PictureBox enemyWeapon;
        int enemyWeaponX;
        int enemyWeaponY;
        private Pistol pistol;
        private Rifle riffle;
        private Shotgun shotgun;
        private Bazooka bazooka;
        PictureBox player1 = null;
        PictureBox player2 = null;
        bool shootedMyself = true;

        // Bullets
        private PistolBullet pistolBulletClass;
        private RiffleBullet riffleBulletClass;
        private ShotgunBullet shotgunBulletClass;
        private BazookaBullet bazookaBulletClass;
        private PictureBox bullet;
        Timer pistonBulletTimer;
        private int standartWidth = 1;
        private int standartHeight = 1;

        List<Coin> gameCoins;
        private FakeCoinAdapter fakeCoin;

        Map map;

        Bonuses bonuses; 
        PlayerState playerState;

        //Strategy 
        private IShooting _shooting;
        public void setStrategy(IShooting strategy)
        {
            _shooting = strategy;
        }

        //States
        private DefaultState defaultState;
        private ShoppingState shoppingState;
        private NoAmmoState noAmmoState;
        private LowHealthState lowHealthState;

        public Game()
        {
            bonuses = new Bonuses();
            defaultState = new DefaultState();
            shoppingState = new ShoppingState();
            noAmmoState = new NoAmmoState();
            lowHealthState = new LowHealthState();
            BuildMap();
            InitializeComponent();
            player1 = (PictureBox)this.Controls["player1"];
            player2 = (PictureBox)this.Controls["player2"];
            _ = InilitizeConectionAsync();
            InitializeCllectableListeners();
            InitializeFakeCoins();
            UpdateStats();
            CheckPlayerIndex();
            ManageBulletShot();
            UpdateCointsFromServer();
            UopdateBonusesFromServer();
            UpdateMovementFromState();
            UpdateHealthFromServer();

            StartGame = true;
            
            weaponShop = new WeaponShop();
            SendCordinatesTimer.Start();
            shopPanel.Visible = false;
            shopPanel.Enabled = false;

            this.weaponAngle = 0;
            this.enemyWeaponAngle = 0;
            this.snapshotWeaponAngle = 0;
            this.playerWeaponOffsetX = 20;
            this.playerWeaponOffsetY = 0;
            this.playerId = gameManager.GetYourId();
        }

        public async Task InilitizeConectionAsync()
        {
            connection = new HubConnectionBuilder().WithUrl("https://localhost:7021/gameHub").Build();
            await connection.StartAsync();

            connection.On<int>("level2Map", async n =>
            {
                foreach (Control c in this.Controls)
                {
                    if (c is PictureBox)
                    {
                        if ((string)c.Tag != "player1")
                        {
                            if ((string)c.Tag != "player2") 
                            {
                                if ((string)c.Name != "weapon1")
                                {
                                    if ((string)c.Name != "weapon0")
                                    {
                                        this.Controls.Remove(c);
                                    }
                                }
                            }
                        }
                    }
                }
                PictureBox mapObject = null;
                foreach (MapObject mapEntity in GameManagerServer.Instance.GetMap2().getMapEntities())
                {
                    if (mapEntity is MapEntity)
                    {
                        MapEntity tempMapEntity = (MapEntity)mapEntity;
                        if (tempMapEntity.getTag() == "player1")
                        {
                            player1.Location = new Point(tempMapEntity.getPosX(), tempMapEntity.getPosY());
                        }
                        else if (tempMapEntity.getTag() == "player2")
                        {
                            player2.Location = new Point(tempMapEntity.getPosX(), tempMapEntity.getPosY());
                        }
                        else
                        {
                            mapObject = new PictureBox
                            {
                                Tag = tempMapEntity.getTag(),
                                Size = new Size(tempMapEntity.getSizeX(), tempMapEntity.getSizeY()),
                                Location = new Point(tempMapEntity.getPosX(), tempMapEntity.getPosY()),
                                BackColor = tempMapEntity.getColor(),
                                Name = tempMapEntity.getName(),
                            };
                            this.Controls.Add(mapObject);
                        }
                    }
                };
                foreach (MapObject mapEntity in map.getFloatingPlatforms())
                {
                    if (mapEntity is FloatingPlatform)
                    {
                        FloatingPlatform tempFloatingPlatform = (FloatingPlatform)mapEntity;
                        mapObject = new PictureBox
                        {
                            Tag = tempFloatingPlatform.block.tag,
                            Size = new Size(tempFloatingPlatform.block.sizeX, tempFloatingPlatform.block.sizeY),
                            Location = new Point(tempFloatingPlatform.block.x, tempFloatingPlatform.block.y),
                            BackColor = tempFloatingPlatform.block.color,
                            Name = tempFloatingPlatform.block.name,
                            BorderStyle = BorderStyle.FixedSingle
                        };
                    }
                    this.Controls.Add(mapObject);
                }
            });
            connection.On<int>("level3Map", async n =>
            {
                foreach (Control c in this.Controls)
                {
                    if (c is PictureBox)
                    {
                        if ((string)c.Tag != "player1")
                        {
                            if ((string)c.Tag != "player2")
                            {
                                if ((string)c.Name != "weapon1")
                                {
                                    if ((string)c.Name != "weapon0")
                                    {
                                        this.Controls.Remove(c);
                                    }
                                }
                            }
                        }
                    }
                }
                PictureBox mapObject = null;
                foreach (MapObject mapEntity in GameManagerServer.Instance.GetMap3().getMapEntities())
                {
                    if (mapEntity is MapEntity)
                    {
                        MapEntity tempMapEntity = (MapEntity)mapEntity;
                        if (tempMapEntity.getTag() == "player1")
                        {
                            player1.Location = new Point(tempMapEntity.getPosX(), tempMapEntity.getPosY());
                        }
                        else if (tempMapEntity.getTag() == "player2")
                        {
                            player2.Location = new Point(tempMapEntity.getPosX(), tempMapEntity.getPosY());
                        }
                        else
                        {
                            mapObject = new PictureBox
                            {
                                Tag = tempMapEntity.getTag(),
                                Size = new Size(tempMapEntity.getSizeX(), tempMapEntity.getSizeY()),
                                Location = new Point(tempMapEntity.getPosX(), tempMapEntity.getPosY()),
                                BackColor = tempMapEntity.getColor(),
                                Name = tempMapEntity.getName(),
                            };
                            this.Controls.Add(mapObject);
                        }
                    }
                };
                foreach (MapObject mapEntity in map.getFloatingPlatforms())
                {
                    if (mapEntity is FloatingPlatform)
                    {
                        FloatingPlatform tempFloatingPlatform = (FloatingPlatform)mapEntity;
                        mapObject = new PictureBox
                        {
                            Tag = tempFloatingPlatform.block.tag,
                            Size = new Size(tempFloatingPlatform.block.sizeX, tempFloatingPlatform.block.sizeY),
                            Location = new Point(tempFloatingPlatform.block.x, tempFloatingPlatform.block.y),
                            BackColor = tempFloatingPlatform.block.color,
                            Name = tempFloatingPlatform.block.name,
                            BorderStyle = BorderStyle.FixedSingle
                        };
                    }
                    this.Controls.Add(mapObject);
                }
            });
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
            if (health <= 40)
            {
                SetState(lowHealthState);
            }
            else
            {
                SetState(defaultState);
            }
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
                SendRequest();
                SendRequestUpdateHealth();
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
                    SetState(shoppingState);
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

            // Creating Bullets classes
            bullet = new PictureBox();
            pistolBulletClass = new PistolBullet();
            riffleBulletClass = new RiffleBullet();
            shotgunBulletClass = new ShotgunBullet();
            bazookaBulletClass = new BazookaBullet();

            // Creating weapons
            pistol = new Pistol("Pistol");
            riffle = new Rifle("Riffle");
            shotgun = new Shotgun("Shotgun");
            bazooka = new Bazooka("Bazooka");
            setStrategy(pistol);

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
            int count = 1;
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
                        //trashLabel.Text = count.ToString();
                        count++;
                        //this.gameCoins.Remove(coin);
                        //send to server for other player to remove same coin
                        await connection.SendAsync("TakeDamage", playerId, Convert.ToInt32(10/bonuses.DamageReducerBonus));
                        if (this.health <= 0)
                        {
                            _ = TestDeathAsync();
                            MessageBox.Show(GameManagerServer.currLevel.ToString());
                            if (GameManagerServer.currLevel == 1)
                            {
                                GameManagerServer.currLevel = 2;
                                BuildNewLevel2(2);
                                this.health = 100;
                            }
                            if (GameManagerServer.currLevel == 2)
                            {
                                GameManagerServer.currLevel = 3;
                                BuildNewLevel3(3);
                                this.health = 100;
                            }
                        }

                    }
                }
            }
        }

        private async void Movement()
        {
            player.Top += jumpSpeed * bonuses.JumpBonus;
            if (jumping && force < 0)
            {
                jumping = false;
            }

            if (goleft)
            {
                player.Left -= playerSpeed * bonuses.SpeedBonus;
            }

            if (goright)
            {
                player.Left += playerSpeed * bonuses.SpeedBonus;
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
                if (x.Tag != null) {
                    if (x is PictureBox && (string)x.Tag == "platform")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && !jumping)
                        {
                            force = 8;
                            player.Top = x.Top - player.Height;
                        }
                    }
                    if (x is PictureBox && (string)x.Tag == "healing_bouncy")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && !jumping)
                        {
                            jumping = true;
                            jumpSpeed = -12;
                            force = 8;
                            await connection.SendAsync("TakeDamage", playerId, -10);
                            health += 10;
                            UpdateStats();
                            player.Top = x.Top - player.Height;
                        }
                    }
                    if (x is PictureBox && (string)x.Tag == "healing_sticky")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && !jumping)
                        {
                            jumping = true;
                            await connection.SendAsync("TakeDamage", playerId, -1);
                            health += 1;
                            UpdateStats();
                            player.Top = x.Top - player.Height;
                        }
                    }
                    if (x is PictureBox && (string)x.Tag == "malicious_sticky")
                    {
                        if (player.Bounds.IntersectsWith(x.Bounds) && !jumping)
                        {
                            await connection.SendAsync("TakeDamage", playerId, 1);
                            health -= 1;
                            UpdateStats();
                            if (this.health < 0)
                            {
                                _ = TestDeathAsync();
                                if (GameManagerServer.currLevel == 1)
                                {
                                    GameManagerServer.currLevel = 2;
                                    BuildNewLevel2(2);
                                    this.health = 100;
                                }
                                if (GameManagerServer.currLevel == 2)
                                {
                                    GameManagerServer.currLevel = 3;
                                    BuildNewLevel3(3);
                                    this.health = 100;
                                }
                            }
                            jumping = true;
                            player.Top = x.Top - player.Height;
                        }
                    }
                    if (x is PictureBox && (string)x.Tag == "malicious_bouncy")
                    {
                        if(player.Bounds.IntersectsWith(x.Bounds) && !jumping)
                            {
                            jumping = true;
                            jumpSpeed = -12;
                            force = 8;
                            await connection.SendAsync("TakeDamage", playerId, 1);
                            if (this.health < 0)
                            {
                                _ = TestDeathAsync();
                                if (GameManagerServer.currLevel == 1)
                                {
                                    this.health = 100;
                                    GameManagerServer.currLevel = 2;
                                    BuildNewLevel2(2);
                                }
                                if (GameManagerServer.currLevel == 2)
                                {
                                    this.health = 100;
                                    GameManagerServer.currLevel = 3;
                                    BuildNewLevel3(3);
                                }
                            }
                            health -= 1;
                            UpdateStats();
                            player.Top = x.Top - player.Height;
                        }
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
            this.playerWeaponOffsetX = Math.Sin(ConvertToRadians(this.weaponAngle)) * this.weaponDistance*1.5;
            this.playerWeaponOffsetY = Math.Cos(ConvertToRadians(this.weaponAngle)) * this.weaponDistance*1.5;
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

        private async void ManageBulletShot()
        {
            connection.On<string>("bulletCords", cords =>
            {
                string[] cordsArr = cords.Split(',');
                enemyWeaponAngle = Convert.ToDouble(cordsArr[6]);
                ShootBullet(Convert.ToInt32(cordsArr[0]), Convert.ToInt32(cordsArr[1]), Convert.ToInt32(cordsArr[2]), Convert.ToInt32(cordsArr[3]), Convert.ToInt32(cordsArr[4]), Convert.ToInt32(cordsArr[5]));
            });
        }

        private async void UpdateCointsFromServer()
        {
            connection.On<int>("updateCoins", value =>
            {
                money = value;
                moneyCountLabel.Text = value.ToString();
                
            });
    
        }

        private async void UpdateHealthFromServer()
        {
            connection.On<int>("updateHealth", value =>
            {
                health = value;
                hpCountLabel.Text = value.ToString();

            });

        }

        private async void UopdateBonusesFromServer()
        {
            connection.On<Bonuses>("bonuses", value =>
            {
                bonuses = value;

            });

        }

        private async void UpdateMovementFromState()
        {
            connection.On<int>("getMovement", value =>
            {
                playerSpeed += value;
            });
        }

        private async void SendRequest()
        {
            await connection.SendAsync("RequestUpdateCoins", playerId);
        }

        private async void SendRequestUpdateHealth()
        {
            await connection.SendAsync("RequestUpdateHealth", playerId);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _ = TestDeathAsync();
        }

        async Task TestDeathAsync()
        {
            await connection.SendAsync("Die", playerId);
        }

        async Task BuildNewLevel2(int level)
        {
            await connection.SendAsync("BuildNewLevel2", level);
        }

        async Task BuildNewLevel3(int level)
        {
            await connection.SendAsync("BuildNewLevel3", level);
        }

        public async Task MakeBulletAsync(int? weaponCordX = null,int? weaponCordY = null,int? left =null, int? width = null, int? top = null, int? heigt = null)
        {
            switch (_shooting.Name)
            {
                case "Pistol":
                {
                    bullet.Tag = "bullet";
                    bullet.BackColor = Color.Red;
                    bullet.Size = new Size(pistolBulletClass.CalculateWidth(standartWidth),
                        pistolBulletClass.CalculateHeight(standartHeight));
                }
                    break;
                case "Riffle":
                {
                    bullet.Tag = "bullet";
                    bullet.Size = new Size(riffleBulletClass.CalculateWidth(standartWidth),
                        pistolBulletClass.CalculateHeight(standartHeight));
                    }
                    break;
                case "Shotgun":
                    {
                        bullet.Tag = "bullet";
                        bullet.BackColor = Color.Red;
                        bullet.Size = new Size(shotgunBulletClass.CalculateWidth(standartWidth), pistolBulletClass.CalculateHeight(standartHeight));
                    }
                    break;
                case "Bazooka":
                {
                    bullet.Tag = "bullet";
                    bullet.BackColor = Color.Red;
                    bullet.Size = new Size(bazookaBulletClass.CalculateWidth(standartWidth), pistolBulletClass.CalculateHeight(standartHeight));
                }
                    break;
            }


            //Pistol Standart Bullet
            /*StandartBullet standartBullet = new StandartBullet(pistolBulletClass);
            bullet.BackColor = Color.Silver;
            bullet.Size = new Size(standartBullet.CalculateWidth(standartWidth), standartBullet.CalculateHeight(standartHeight));
            bullet.Tag = pistolBulletClass.Tag;*/

            //Pistol Gold Bullet
            /*GoldBullet goldBullet = new GoldBullet(pistolBulletClass);
            bullet.BackColor = Color.Yellow;
            bullet.Size = new Size(goldBullet.CalculateWidth(standartWidth), goldBullet.CalculateHeight(standartHeight));*/
            //pistolBullet.Tag = pistolBulletClass.Tag;

            //Pistol Diamond Bullet
            /*DiamondBullet diamondBullet = new DiamondBullet(pistolBulletClass);
            bullet.BackColor = Color.DodgerBlue;
            bullet.Size = new Size(diamondBullet.CalculateWidth(standartWidth), diamondBullet.CalculateHeight(standartHeight));
            bullet.Tag = pistolBulletClass.Tag;*/

            if (weaponCordX != null && weaponCordY != null)
            {
                bullet.Location = new Point(Convert.ToInt32(weaponCordX), Convert.ToInt32(weaponCordY));
                bullet.Left = Convert.ToInt32(left) + Convert.ToInt32(width);
                bullet.Top = Convert.ToInt32(top) + Convert.ToInt32(heigt);
                shootedMyself = false;
            }
            else
            {
                bullet.Location = playerWeapon.Location;
                //trashLabel.Text = testCount.ToString();
                testCount++;
                bullet.Left = playerWeapon.Left + playerWeapon.Width;
                bullet.Top = playerWeapon.Top + playerWeapon.Height;
                shootedMyself = true;
                await connection.SendAsync("SendBulletCords", bullet.Location.X + "," + bullet.Location.Y+","+ playerWeapon.Left + "," + playerWeapon.Width + "," + playerWeapon.Top + "," + playerWeapon.Height + "," + weaponAngle);
            }
            bullet.BringToFront();
            Controls.Add(bullet);

            pistonBulletTimer = new Timer();
            pistonBulletTimer.Interval = 20;
            snapshotWeaponAngle = weaponAngle;
            pistonBulletTimer.Tick += new EventHandler(BulletTimerEvent);
            pistonBulletTimer.Start();
        }

        private void BulletTimerEvent(object sender, EventArgs e)
        {

            if(enemyWeaponAngle != 0 && shootedMyself == false)
            {
                if (enemyWeaponAngle >= 0 && enemyWeaponAngle <= 180)
                {
                    bullet.Left += shootingPower;
                }
                if (enemyWeaponAngle <= 360 && enemyWeaponAngle >= 180)
                {
                    bullet.Left -= shootingPower;
                }
            }
            else
            {
                if (snapshotWeaponAngle >= 0 && snapshotWeaponAngle <= 180)
                {
                    bullet.Left += shootingPower;
                }
                if (snapshotWeaponAngle <= 360 && snapshotWeaponAngle >= 180)
                {
                    bullet.Left -= shootingPower;
                }
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

        private void ShootBullet(int? weaponCordX = null, int? weaponCordY = null, int? left = null, int? width = null, int? top = null, int? heigth = null)
        {
            if(weaponCordX != null && weaponCordY != null)
            {
                _ = MakeBulletAsync(weaponCordX, weaponCordY,left,width,top,heigth);
            }
            else
            {
                MakeBulletAsync();
            }
        }

        private async void BuildMap()
        {
            Map map = GameManagerServer.Instance.GetMap();
            PictureBox mapObject = null;
            foreach (MapObject mapEntity in map.getMapEntities())
            {
                if (mapEntity is MapEntity)
                {
                    MapEntity tempMapEntity = (MapEntity)mapEntity;
                    mapObject = new PictureBox
                    {
                        Tag = tempMapEntity.getTag(),
                        Size = new Size(tempMapEntity.getSizeX(), tempMapEntity.getSizeY()),
                        Location = new Point(tempMapEntity.getPosX(), tempMapEntity.getPosY()),
                        BackColor = tempMapEntity.getColor(),
                        Name = tempMapEntity.getName(),
                    };
                }
                this.Controls.Add(mapObject);
            };
            foreach (MapObject mapEntity in map.getFloatingPlatforms())
            {
                if (mapEntity is FloatingPlatform)
                {
                    FloatingPlatform tempFloatingPlatform = (FloatingPlatform)mapEntity;
                    mapObject = new PictureBox
                    {
                        Tag = tempFloatingPlatform.block.tag,
                        Size = new Size(tempFloatingPlatform.block.sizeX, tempFloatingPlatform.block.sizeY),
                        Location = new Point(tempFloatingPlatform.block.x, tempFloatingPlatform.block.y),
                        BackColor = tempFloatingPlatform.block.color,
                        Name = tempFloatingPlatform.block.name,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                }
                this.Controls.Add(mapObject);
            }
        }

        private async void BuildMap2()
        {
            PictureBox mapObject = null;
            foreach (MapObject mapEntity in this.map.getMapEntities())
            {
                if (mapEntity is MapEntity)
                {
                    MapEntity tempMapEntity = (MapEntity)mapEntity;
                    if (tempMapEntity.getTag() == "player1")
                    {
                        player1.Location = new Point(tempMapEntity.getPosX(), tempMapEntity.getPosY());
                    }
                    else if (tempMapEntity.getTag() == "player2")
                    {
                        player2.Location = new Point(tempMapEntity.getPosX(), tempMapEntity.getPosY());
                    }
                    else
                    {
                        mapObject = new PictureBox
                        {
                            Tag = tempMapEntity.getTag(),
                            Size = new Size(tempMapEntity.getSizeX(), tempMapEntity.getSizeY()),
                            Location = new Point(tempMapEntity.getPosX(), tempMapEntity.getPosY()),
                            BackColor = tempMapEntity.getColor(),
                            Name = tempMapEntity.getName(),
                        };
                        this.Controls.Add(mapObject);
                    }
                }
            };
            foreach (MapObject mapEntity in map.getFloatingPlatforms())
            {
                if (mapEntity is FloatingPlatform)
                {
                    FloatingPlatform tempFloatingPlatform = (FloatingPlatform)mapEntity;
                    mapObject = new PictureBox
                    {
                        Tag = tempFloatingPlatform.block.tag,
                        Size = new Size(tempFloatingPlatform.block.sizeX, tempFloatingPlatform.block.sizeY),
                        Location = new Point(tempFloatingPlatform.block.x, tempFloatingPlatform.block.y),
                        BackColor = tempFloatingPlatform.block.color,
                        Name = tempFloatingPlatform.block.name,
                        BorderStyle = BorderStyle.FixedSingle
                    };
                }
                this.Controls.Add(mapObject);
            }
        }


        public async void PriceDecreasion(int price)
        {
            await connection.SendAsync("DecreaseCoins", price, playerId);
        }

        private async void DecreaseCoinBuyingWeapon(IShooting weapo, string weaponType)
        {
            if(weapo != null)
            {

                switch (weaponType)
                {
                    case "Pistol":
                        {
                            var pistol = weapo as Pistol;

                            if (pistol != null)
                            {
                                PriceDecreasion(pistol.Price * -1);
                            }
                            break;
                        }
                    case "Shotgun":
                        {
                            var shotgun = weapo as Shotgun;

                            if (shotgun != null)
                            {
                                PriceDecreasion(shotgun.Price * -1);

                            }
                            break;
                        }
                    case "Rifle":
                        {
                            var rifle = weapo as Rifle;

                            if (rifle != null)
                            {
                                PriceDecreasion(riffle.Price * -1);
                            }
                            break;
                        }
                    case "Bazooka":
                        {
                            var bazooka = weapo as Bazooka;

                            if (bazooka != null)
                            {
                                PriceDecreasion(bazooka.Price * -1);
                            }
                            break;
                        }
                    default:
                        break;
                }

                if(weaponType == "Pistol")
                {
                    var pistol = weapo as Pistol;

                    if(pistol != null)
                    {
                        await connection.SendAsync("DecreaseCoins", pistol.Price * -1,playerId);
                    }      
                }
            }
        }
        private void buyPistolButton_Click(object sender, EventArgs e)
        {
            var weap = weaponShop.BuyWeapon(CurrentWeaponType.Pistol, ref this.money);
            if (weap != null)
            {
                DecreaseCoinBuyingWeapon(weap, "Pistol");
                setStrategy(pistol);
                //weaponNameLabel.Text = _shooting.Name;
                moneyCountLabel.Text = money.ToString();
                ammoCountLabel.Text = _shooting.Ammunition.ToString();
            }
        }

        private void closeShopButton_Click(object sender, EventArgs e)
        {
            shopPanel.Visible = false;
            shopPanel.Enabled = false;
            UpdateStats();
        }

        private void buyRifleButton_Click(object sender, EventArgs e)
        {
            var weap = weaponShop.BuyWeapon(CurrentWeaponType.Rifle, ref this.money);
            if (weap != null)
            {
                DecreaseCoinBuyingWeapon(weap, "Rifle");
                setStrategy(riffle);
                //weaponNameLabel.Text = _shooting.Name;
                moneyCountLabel.Text = money.ToString();
                ammoCountLabel.Text = _shooting.Ammunition.ToString();
            }
        }

        private void buyShotgunButton_Click(object sender, EventArgs e)
        {
            var weap = weaponShop.BuyWeapon(CurrentWeaponType.Shotgun, ref this.money);
            if (weap != null)
            {
                DecreaseCoinBuyingWeapon(weap, "Shotgun");
                setStrategy(shotgun);
                //weaponNameLabel.Text = _shooting.Name;
                moneyCountLabel.Text = money.ToString();
                ammoCountLabel.Text = _shooting.Ammunition.ToString();
            }
        }

        private void buyBazookaButton_Click(object sender, EventArgs e)
        {
            var weap = weaponShop.BuyWeapon(CurrentWeaponType.Bazooka, ref this.money);
            if (weap != null)
            {
                DecreaseCoinBuyingWeapon(weap, "Bazooka");
                setStrategy(bazooka);
                //weaponNameLabel.Text = _shooting.Name;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private async void GetBonuses(string bonusesName)
        {
            if(money >= 1000)
            {
                
                await connection.SendAsync("GetBonuses", playerId,bonusesName);
                PriceDecreasion(-1000);
            }
        }

        private async void SetState(PlayerState state)
        {
            await connection.SendAsync("GetMovementByStatus", playerId, state);
        }

        private void boostSpeedButton_Click(object sender, EventArgs e)
        {
            GetBonuses("Speed");
        }

        private void jumpBoostButton_Click(object sender, EventArgs e)
        {
            GetBonuses("Jump");
        }

        private void damageBoostButton_Click(object sender, EventArgs e)
        {
            GetBonuses("Damage");
        }


    }
}
