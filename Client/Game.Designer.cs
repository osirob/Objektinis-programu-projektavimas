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
            this.player = new System.Windows.Forms.PictureBox();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groundPlatform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.floatingPlatform)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).BeginInit();
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
            // player
            // 
            this.player.BackColor = System.Drawing.Color.Blue;
            this.player.Location = new System.Drawing.Point(785, 541);
            this.player.Name = "player";
            this.player.Size = new System.Drawing.Size(35, 60);
            this.player.TabIndex = 3;
            this.player.TabStop = false;
            this.player.Tag = "player";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(934, 661);
            this.Controls.Add(this.player);
            this.Controls.Add(this.floatingPlatform);
            this.Controls.Add(this.groundPlatform);
            this.Controls.Add(this.hpLabel);
            this.Name = "Game";
            this.Text = "Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyIsUp);
            ((System.ComponentModel.ISupportInitialize)(this.groundPlatform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.floatingPlatform)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label hpLabel;
        private PictureBox groundPlatform;
        private PictureBox floatingPlatform;
        private PictureBox player;
        private System.Windows.Forms.Timer gameTimer;
    }
}