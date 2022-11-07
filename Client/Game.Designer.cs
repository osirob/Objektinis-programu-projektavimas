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
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.playerLabel = new System.Windows.Forms.Label();
            this.SendCordinatesTimer = new System.Windows.Forms.Timer(this.components);
            this.testLabel = new System.Windows.Forms.Label();
            this.trashLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.hpCountLabel = new System.Windows.Forms.Label();
            this.moneyLabel = new System.Windows.Forms.Label();
            this.moneyCountLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // hpLabel
            // 
            this.hpLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.hpLabel.Location = new System.Drawing.Point(917, 12);
            this.hpLabel.Name = "hpLabel";
            this.hpLabel.Size = new System.Drawing.Size(137, 33);
            this.hpLabel.TabIndex = 0;
            this.hpLabel.Text = "HP:";
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_TickAsync);
            // 
            // playerLabel
            // 
            this.playerLabel.Font = new System.Drawing.Font("Consolas", 16.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.playerLabel.Location = new System.Drawing.Point(423, 12);
            this.playerLabel.Name = "playerLabel";
            this.playerLabel.Size = new System.Drawing.Size(269, 33);
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
            this.testLabel.Location = new System.Drawing.Point(506, 245);
            this.testLabel.Name = "testLabel";
            this.testLabel.Size = new System.Drawing.Size(33, 20);
            this.testLabel.TabIndex = 6;
            this.testLabel.Text = "test";
            this.testLabel.Visible = false;
            // 
            // trashLabel
            // 
            this.trashLabel.AutoSize = true;
            this.trashLabel.Location = new System.Drawing.Point(243, 311);
            this.trashLabel.Name = "trashLabel";
            this.trashLabel.Size = new System.Drawing.Size(77, 20);
            this.trashLabel.TabIndex = 7;
            this.trashLabel.Text = "trashLabel";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(-9, -3);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 31);
            this.button1.TabIndex = 8;
            this.button1.Text = "Test Die Method";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // hpCountLabel
            // 
            this.hpCountLabel.AutoSize = true;
            this.hpCountLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.hpCountLabel.Location = new System.Drawing.Point(952, 12);
            this.hpCountLabel.Name = "hpCountLabel";
            this.hpCountLabel.Size = new System.Drawing.Size(103, 28);
            this.hpCountLabel.TabIndex = 9;
            this.hpCountLabel.Text = "hpCount";
            // 
            // moneyLabel
            // 
            this.moneyLabel.AutoSize = true;
            this.moneyLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.moneyLabel.Location = new System.Drawing.Point(882, 41);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(90, 28);
            this.moneyLabel.TabIndex = 10;
            this.moneyLabel.Text = "Money:";
            // 
            // moneyCountLabel
            // 
            this.moneyCountLabel.AutoSize = true;
            this.moneyCountLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.moneyCountLabel.Location = new System.Drawing.Point(952, 41);
            this.moneyCountLabel.Name = "moneyCountLabel";
            this.moneyCountLabel.Size = new System.Drawing.Size(142, 28);
            this.moneyCountLabel.TabIndex = 11;
            this.moneyCountLabel.Text = "moneyCount";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1067, 881);
            this.Controls.Add(this.moneyCountLabel);
            this.Controls.Add(this.moneyLabel);
            this.Controls.Add(this.hpCountLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trashLabel);
            this.Controls.Add(this.testLabel);
            this.Controls.Add(this.playerLabel);
            this.Controls.Add(this.hpLabel);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Game";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyIsUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label hpLabel;
        private System.Windows.Forms.Timer gameTimer;
        private Label playerLabel;
        private System.Windows.Forms.Timer SendCordinatesTimer;
        private Label testLabel;
        private Label trashLabel;
        private Button button1;
        private Label hpCountLabel;
        private Label moneyLabel;
        private Label moneyCountLabel;
    }
}