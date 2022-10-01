using Microsoft.AspNetCore.SignalR.Client;
using Shared.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

        GameManager gameManager = GameManager.Instance;

        // Stats
        int health = 0;
        int score = 0;

        // Player index
        int playerIndex = -1;


        PictureBox player;

        public Game()
        {
            InitializeComponent();
            player = player1;
            CheckPlayerIndex();
            //AsignPlayers();
            _=InilitizeConectionAsync();
            StartGame = true;
            SendCordinatesTimer.Start();
        }

        public async Task InilitizeConectionAsync()
        {
            connection = new HubConnectionBuilder().WithUrl("https://localhost:7021/gameHub").Build();
            await connection.StartAsync();
        }
        /**
        private async void AsignPlayers()
        {
            connection = new HubConnectionBuilder().WithUrl("https://localhost:7021/gameHub").Build();
            await connection.StartAsync();
            connection.On<string>("asigningPlayers", (message) =>
            {
                if(message == "1")
                {
                    playerIndex = int.Parse(message);
                    playerLabel.Text = message;
                    player = player1;
                    
                }
                else
                {
                    playerIndex = int.Parse(message);
                    playerLabel.Text = message;
                    player = player2;
                    
                }
            });
            await connection.SendAsync("AsignPlayer", "");
        }
        */
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
        private void gameTimer_TickAsync(object sender, EventArgs e)
        {
            if (StartGame)
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

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void Game_Load(object sender, EventArgs e)
        {

        }

        private void SendCordinatesTimer_Tick(object sender, EventArgs e)
        {
            SendCordinates_TickAsync();
        }

        private void player2_Click(object sender, EventArgs e)
        {

        }
    }
}
