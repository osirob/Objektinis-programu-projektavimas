namespace Client
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.hpLabel = new System.Windows.Forms.Label();
            this.groundPlatform = new System.Windows.Forms.PictureBox();
            this.floatingPlatform = new System.Windows.Forms.PictureBox();
            this.player1 = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.player2 = new System.Windows.Forms.PictureBox();
            this.playerLabel = new System.Windows.Forms.Label();
            this.SendCordinatesTimer = new System.Windows.Forms.Timer(this.components);
            this.testLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groundPlatform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.floatingPlatform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2)).BeginInit();
            this.SuspendLayout();
            // 
            // hpLabel
            // 
            this.hpLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.hpLabel.Location = new System.Drawing.Point(802, 9);
            this.hpLabel.Name = "hpLabel";
            this.hpLabel.Size = new System.Drawing.Size(120, 25);
            this.hpLabel.TabIndex = 0;
            this.hpLabel.Text = "HP: 100";
            // 
            // groundPlatform
            // 
            this.groundPlatform.BackColor = System.Drawing.Color.Green;
            this.groundPlatform.Location = new System.Drawing.Point(-18, 637);
            this.groundPlatform.Name = "groundPlatform";
            this.groundPlatform.Size = new System.Drawing.Size(982, 30);
            this.groundPlatform.TabIndex = 1;
            this.groundPlatform.TabStop = false;
            this.groundPlatform.Tag = "platform";
            // 
            // floatingPlatform
            // 
            this.floatingPlatform.BackColor = System.Drawing.Color.Brown;
            this.floatingPlatform.Location = new System.Drawing.Point(149, 528);
            this.floatingPlatform.Name = "floatingPlatform";
            this.floatingPlatform.Size = new System.Drawing.Size(189, 30);
            this.floatingPlatform.TabIndex = 2;
            this.floatingPlatform.TabStop = false;
            this.floatingPlatform.Tag = "platform";
            // 
            // player1
            // 
            this.player1.BackColor = System.Drawing.Color.Blue;
            this.player1.Location = new System.Drawing.Point(802, 545);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(35, 60);
            this.player1.TabIndex = 3;
            this.player1.TabStop = false;
            this.player1.Tag = "player1";
            this.player1.Click += new System.EventHandler(this.player_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_TickAsync);
            // 
            // player2
            // 
            this.player2.BackColor = System.Drawing.Color.Red;
            this.player2.Location = new System.Drawing.Point(33, 545);
            this.player2.Name = "player2";
            this.player2.Size = new System.Drawing.Size(35, 60);
            this.player2.TabIndex = 4;
            this.player2.TabStop = false;
            this.player2.Tag = "player2";
            this.player2.Click += new System.EventHandler(this.player2_Click);
            // 
            // playerLabel
            // 
            this.playerLabel.Font = new System.Drawing.Font("Consolas", 16.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.playerLabel.Location = new System.Drawing.Point(370, 9);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(235, 25);
            this.playerLabel.TabIndex = 5;
            this.playerLabel.Text = "Player1: Name";
            // 
            // SendCordinatesTimer
            // 
            this.SendCordinatesTimer.Interval = 20;
            this.SendCordinatesTimer.Tick += new System.EventHandler(this.SendCordinatesTimer_Tick);
            // 
            // testLabel
            // 
            this.testLabel.AutoSize = true;
            this.testLabel.Location = new System.Drawing.Point(443, 184);
            this.testLabel.Name = "testLabel";
            this.testLabel.Size = new System.Drawing.Size(26, 15);
            this.testLabel.TabIndex = 6;
            this.testLabel.Text = "test";
            this.testLabel.Visible = false;
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(934, 661);
            this.Controls.Add(this.testLabel);
            this.Controls.Add(this.playerLabel);
            this.Controls.Add(this.player2);
            this.Controls.Add(this.player1);
            this.Controls.Add(this.floatingPlatform);
            this.Controls.Add(this.groundPlatform);
            this.Controls.Add(this.hpLabel);
            this.Name = "Game";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.groundPlatform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.floatingPlatform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label hpLabel;
        private PictureBox groundPlatform;
        private PictureBox floatingPlatform;
        private PictureBox player1;
        private System.Windows.Forms.Timer gameTimer;
        private PictureBox player2;
        private Label playerLabel;
        private System.Windows.Forms.Timer SendCordinatesTimer;
        private Label testLabel;
    }
}