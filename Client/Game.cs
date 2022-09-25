using Microsoft.AspNetCore.SignalR.Client;
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

        // Stats
        int health = 0;
        int score = 0;

        // Player index
        int playerIndex = -1;

        PictureBox player;

        public Game()
        {
            InitializeComponent();
            AsignPlayers();
            CheckPlayerIndex();
        }

        private async void AsignPlayers()
        {
            connection = new HubConnectionBuilder().WithUrl("https://localhost:7021/gameHub").Build();
            await connection.StartAsync();
            connection.On<string>("asigningPlayers", (message) =>
            {
                playerIndex = int.Parse(message);
            });
            await connection.SendAsync("AsignPlayer", "");
        }

        private void CheckPlayerIndex()
        {
            if (playerIndex == 1)
            {
                player = player1;
            }
            else
            {
                player = player2;
            }
        }

        //This method executes each 20ms, basically making it the engine
        private void gameTimer_Tick(object sender, EventArgs e)
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

        private void keyIsDown(object sender, KeyEventArgs e)
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

        private void keyIsUp(object sender, KeyEventArgs e)
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

        private void player_Click(object sender, EventArgs e)
        {

        }

        private void Game_Load(object sender, EventArgs e)
        {

        }
    }
}
