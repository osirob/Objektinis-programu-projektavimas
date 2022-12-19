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
            this.shopPanel = new System.Windows.Forms.Panel();
            this.endingPanel = new System.Windows.Forms.Panel();
            this.level3MoneyRed = new System.Windows.Forms.Label();
            this.level2MoneyRed = new System.Windows.Forms.Label();
            this.level1MoneyRed = new System.Windows.Forms.Label();
            this.level3MoneyBlue = new System.Windows.Forms.Label();
            this.level2MoneyBlue = new System.Windows.Forms.Label();
            this.level1MoneyBlue = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.gameOver = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.damageBoostButton = new System.Windows.Forms.Button();
            this.boostSpeedButton = new System.Windows.Forms.Button();
            this.jumpBoostButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.closeShopButton = new System.Windows.Forms.Button();
            this.buyBazookaAmmoButton = new System.Windows.Forms.Button();
            this.buyBazookaButton = new System.Windows.Forms.Button();
            this.bazookaAmmoCostLabel = new System.Windows.Forms.Label();
            this.bazookaCostLabel = new System.Windows.Forms.Label();
            this.bazookaLabel = new System.Windows.Forms.Label();
            this.buyShotgunAmmoButton = new System.Windows.Forms.Button();
            this.buyShotgunButton = new System.Windows.Forms.Button();
            this.shotgunAmmoCostLabel = new System.Windows.Forms.Label();
            this.shotgunCostLabel = new System.Windows.Forms.Label();
            this.shotgunLabel = new System.Windows.Forms.Label();
            this.buyRifleAmmoButton = new System.Windows.Forms.Button();
            this.buyRifleButton = new System.Windows.Forms.Button();
            this.rifleAmmoCostLabel = new System.Windows.Forms.Label();
            this.rifleCostLabel = new System.Windows.Forms.Label();
            this.rifleLabel = new System.Windows.Forms.Label();
            this.buyPistolAmmoButton = new System.Windows.Forms.Button();
            this.buyPistolButton = new System.Windows.Forms.Button();
            this.pistolAmmoPriceLabel = new System.Windows.Forms.Label();
            this.pistolPriceLabel = new System.Windows.Forms.Label();
            this.pistolLabel = new System.Windows.Forms.Label();
            this.ammoLabel = new System.Windows.Forms.Label();
            this.ammoCountLabel = new System.Windows.Forms.Label();
            this.weaponLabel = new System.Windows.Forms.Label();
            this.weaponNameLabel = new System.Windows.Forms.Label();
            this.updateWeaponNotif = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.moneyTotalCountLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.levelLabel = new System.Windows.Forms.Label();
            this.shopPanel.SuspendLayout();
            this.endingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // hpLabel
            // 
            this.hpLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.hpLabel.Location = new System.Drawing.Point(909, 6);
            this.hpLabel.Name = "hpLabel";
            this.hpLabel.Size = new System.Drawing.Size(120, 25);
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
            // trashLabel
            // 
            this.trashLabel.AutoSize = true;
            this.trashLabel.Location = new System.Drawing.Point(213, 233);
            this.trashLabel.Name = "trashLabel";
            this.trashLabel.Size = new System.Drawing.Size(61, 15);
            this.trashLabel.TabIndex = 7;
            this.trashLabel.Text = "trashLabel";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(-8, -2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
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
            this.hpCountLabel.Location = new System.Drawing.Point(949, 6);
            this.hpCountLabel.Name = "hpCountLabel";
            this.hpCountLabel.Size = new System.Drawing.Size(80, 22);
            this.hpCountLabel.TabIndex = 9;
            this.hpCountLabel.Text = "hpCount";
            // 
            // moneyLabel
            // 
            this.moneyLabel.AutoSize = true;
            this.moneyLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.moneyLabel.Location = new System.Drawing.Point(878, 31);
            this.moneyLabel.Name = "moneyLabel";
            this.moneyLabel.Size = new System.Drawing.Size(70, 22);
            this.moneyLabel.TabIndex = 10;
            this.moneyLabel.Text = "Money:";
            // 
            // moneyCountLabel
            // 
            this.moneyCountLabel.AutoSize = true;
            this.moneyCountLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.moneyCountLabel.Location = new System.Drawing.Point(949, 31);
            this.moneyCountLabel.Name = "moneyCountLabel";
            this.moneyCountLabel.Size = new System.Drawing.Size(110, 22);
            this.moneyCountLabel.TabIndex = 11;
            this.moneyCountLabel.Text = "moneyCount";
            // 
            // shopPanel
            // 
            this.shopPanel.BackColor = System.Drawing.SystemColors.Control;
            this.shopPanel.Controls.Add(this.label4);
            this.shopPanel.Controls.Add(this.label3);
            this.shopPanel.Controls.Add(this.label2);
            this.shopPanel.Controls.Add(this.damageBoostButton);
            this.shopPanel.Controls.Add(this.boostSpeedButton);
            this.shopPanel.Controls.Add(this.jumpBoostButton);
            this.shopPanel.Controls.Add(this.label1);
            this.shopPanel.Controls.Add(this.closeShopButton);
            this.shopPanel.Controls.Add(this.buyBazookaAmmoButton);
            this.shopPanel.Controls.Add(this.buyBazookaButton);
            this.shopPanel.Controls.Add(this.bazookaAmmoCostLabel);
            this.shopPanel.Controls.Add(this.bazookaCostLabel);
            this.shopPanel.Controls.Add(this.bazookaLabel);
            this.shopPanel.Controls.Add(this.buyShotgunAmmoButton);
            this.shopPanel.Controls.Add(this.buyShotgunButton);
            this.shopPanel.Controls.Add(this.shotgunAmmoCostLabel);
            this.shopPanel.Controls.Add(this.shotgunCostLabel);
            this.shopPanel.Controls.Add(this.shotgunLabel);
            this.shopPanel.Controls.Add(this.buyRifleAmmoButton);
            this.shopPanel.Controls.Add(this.buyRifleButton);
            this.shopPanel.Controls.Add(this.rifleAmmoCostLabel);
            this.shopPanel.Controls.Add(this.rifleCostLabel);
            this.shopPanel.Controls.Add(this.rifleLabel);
            this.shopPanel.Controls.Add(this.buyPistolAmmoButton);
            this.shopPanel.Controls.Add(this.buyPistolButton);
            this.shopPanel.Controls.Add(this.pistolAmmoPriceLabel);
            this.shopPanel.Controls.Add(this.pistolPriceLabel);
            this.shopPanel.Controls.Add(this.pistolLabel);
            this.shopPanel.Location = new System.Drawing.Point(130, 143);
            this.shopPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.shopPanel.Name = "shopPanel";
            this.shopPanel.Size = new System.Drawing.Size(703, 294);
            this.shopPanel.TabIndex = 12;
            // 
            // endingPanel
            // 
            this.endingPanel.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.endingPanel.Controls.Add(this.level3MoneyRed);
            this.endingPanel.Controls.Add(this.level2MoneyRed);
            this.endingPanel.Controls.Add(this.level1MoneyRed);
            this.endingPanel.Controls.Add(this.level3MoneyBlue);
            this.endingPanel.Controls.Add(this.level2MoneyBlue);
            this.endingPanel.Controls.Add(this.level1MoneyBlue);
            this.endingPanel.Controls.Add(this.label12);
            this.endingPanel.Controls.Add(this.label11);
            this.endingPanel.Controls.Add(this.label10);
            this.endingPanel.Controls.Add(this.label9);
            this.endingPanel.Controls.Add(this.label8);
            this.endingPanel.Controls.Add(this.label7);
            this.endingPanel.Controls.Add(this.gameOver);
            this.endingPanel.Location = new System.Drawing.Point(181, 78);
            this.endingPanel.Name = "endingPanel";
            this.endingPanel.Size = new System.Drawing.Size(580, 259);
            this.endingPanel.TabIndex = 22;
            this.endingPanel.Visible = false;
            // 
            // level3MoneyRed
            // 
            this.level3MoneyRed.AutoSize = true;
            this.level3MoneyRed.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.level3MoneyRed.ForeColor = System.Drawing.Color.OrangeRed;
            this.level3MoneyRed.Location = new System.Drawing.Point(425, 180);
            this.level3MoneyRed.Name = "level3MoneyRed";
            this.level3MoneyRed.Size = new System.Drawing.Size(22, 25);
            this.level3MoneyRed.TabIndex = 12;
            this.level3MoneyRed.Text = "0";
            this.level3MoneyRed.Visible = false;
            // 
            // level2MoneyRed
            // 
            this.level2MoneyRed.AutoSize = true;
            this.level2MoneyRed.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.level2MoneyRed.ForeColor = System.Drawing.Color.OrangeRed;
            this.level2MoneyRed.Location = new System.Drawing.Point(424, 155);
            this.level2MoneyRed.Name = "level2MoneyRed";
            this.level2MoneyRed.Size = new System.Drawing.Size(22, 25);
            this.level2MoneyRed.TabIndex = 11;
            this.level2MoneyRed.Text = "0";
            this.level2MoneyRed.Visible = false;
            // 
            // level1MoneyRed
            // 
            this.level1MoneyRed.AutoSize = true;
            this.level1MoneyRed.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.level1MoneyRed.ForeColor = System.Drawing.Color.OrangeRed;
            this.level1MoneyRed.Location = new System.Drawing.Point(424, 130);
            this.level1MoneyRed.Name = "level1MoneyRed";
            this.level1MoneyRed.Size = new System.Drawing.Size(22, 25);
            this.level1MoneyRed.TabIndex = 10;
            this.level1MoneyRed.Text = "0";
            this.level1MoneyRed.Visible = false;
            // 
            // level3MoneyBlue
            // 
            this.level3MoneyBlue.AutoSize = true;
            this.level3MoneyBlue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.level3MoneyBlue.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.level3MoneyBlue.Location = new System.Drawing.Point(193, 180);
            this.level3MoneyBlue.Name = "level3MoneyBlue";
            this.level3MoneyBlue.Size = new System.Drawing.Size(22, 25);
            this.level3MoneyBlue.TabIndex = 9;
            this.level3MoneyBlue.Text = "0";
            this.level3MoneyBlue.Visible = false;
            // 
            // level2MoneyBlue
            // 
            this.level2MoneyBlue.AutoSize = true;
            this.level2MoneyBlue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.level2MoneyBlue.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.level2MoneyBlue.Location = new System.Drawing.Point(193, 155);
            this.level2MoneyBlue.Name = "level2MoneyBlue";
            this.level2MoneyBlue.Size = new System.Drawing.Size(22, 25);
            this.level2MoneyBlue.TabIndex = 8;
            this.level2MoneyBlue.Text = "0";
            this.level2MoneyBlue.Visible = false;
            // 
            // level1MoneyBlue
            // 
            this.level1MoneyBlue.AutoSize = true;
            this.level1MoneyBlue.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.level1MoneyBlue.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.level1MoneyBlue.Location = new System.Drawing.Point(193, 130);
            this.level1MoneyBlue.Name = "level1MoneyBlue";
            this.level1MoneyBlue.Size = new System.Drawing.Size(22, 25);
            this.level1MoneyBlue.TabIndex = 7;
            this.level1MoneyBlue.Text = "0";
            this.level1MoneyBlue.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label12.Location = new System.Drawing.Point(25, 180);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 25);
            this.label12.TabIndex = 6;
            this.label12.Text = "LEVEL3:";
            this.label12.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label11.Location = new System.Drawing.Point(25, 155);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 25);
            this.label11.TabIndex = 5;
            this.label11.Text = "LEVEL2:";
            this.label11.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(25, 130);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 25);
            this.label10.TabIndex = 4;
            this.label10.Text = "LEVEL1:";
            this.label10.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.Color.OrangeRed;
            this.label9.Location = new System.Drawing.Point(409, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 28);
            this.label9.TabIndex = 3;
            this.label9.Text = "RED";
            this.label9.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label8.Location = new System.Drawing.Point(180, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 28);
            this.label8.TabIndex = 2;
            this.label8.Text = "BLUE";
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(117, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(330, 28);
            this.label7.TabIndex = 1;
            this.label7.Text = "TOTAL COLLECTED MONEY RESULTS:";
            this.label7.Visible = false;
            // 
            // gameOver
            // 
            this.gameOver.AutoSize = true;
            this.gameOver.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gameOver.Location = new System.Drawing.Point(209, 11);
            this.gameOver.Name = "gameOver";
            this.gameOver.Size = new System.Drawing.Size(172, 37);
            this.gameOver.TabIndex = 0;
            this.gameOver.Text = "GAME OVER!";
            this.gameOver.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(549, 229);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 14);
            this.label4.TabIndex = 27;
            this.label4.Text = "Cost: 1000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(313, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 26;
            this.label3.Text = "Cost: 1000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(67, 229);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 14);
            this.label2.TabIndex = 25;
            this.label2.Text = "Cost: 1000";
            // 
            // damageBoostButton
            // 
            this.damageBoostButton.Location = new System.Drawing.Point(507, 246);
            this.damageBoostButton.Name = "damageBoostButton";
            this.damageBoostButton.Size = new System.Drawing.Size(143, 29);
            this.damageBoostButton.TabIndex = 24;
            this.damageBoostButton.Text = "Boost Damage";
            this.damageBoostButton.UseVisualStyleBackColor = true;
            this.damageBoostButton.Click += new System.EventHandler(this.damageBoostButton_Click);
            // 
            // boostSpeedButton
            // 
            this.boostSpeedButton.Location = new System.Drawing.Point(275, 246);
            this.boostSpeedButton.Name = "boostSpeedButton";
            this.boostSpeedButton.Size = new System.Drawing.Size(143, 29);
            this.boostSpeedButton.TabIndex = 23;
            this.boostSpeedButton.Text = "Boost Speed";
            this.boostSpeedButton.UseVisualStyleBackColor = true;
            this.boostSpeedButton.Click += new System.EventHandler(this.boostSpeedButton_Click);
            // 
            // jumpBoostButton
            // 
            this.jumpBoostButton.Location = new System.Drawing.Point(33, 246);
            this.jumpBoostButton.Name = "jumpBoostButton";
            this.jumpBoostButton.Size = new System.Drawing.Size(143, 29);
            this.jumpBoostButton.TabIndex = 22;
            this.jumpBoostButton.Text = "Boost Jump";
            this.jumpBoostButton.UseVisualStyleBackColor = true;
            this.jumpBoostButton.Click += new System.EventHandler(this.jumpBoostButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(285, 180);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 37);
            this.label1.TabIndex = 21;
            this.label1.Text = "Bonuses";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // closeShopButton
            // 
            this.closeShopButton.Location = new System.Drawing.Point(664, 2);
            this.closeShopButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.closeShopButton.Name = "closeShopButton";
            this.closeShopButton.Size = new System.Drawing.Size(30, 31);
            this.closeShopButton.TabIndex = 20;
            this.closeShopButton.Text = "X";
            this.closeShopButton.UseVisualStyleBackColor = true;
            this.closeShopButton.Click += new System.EventHandler(this.closeShopButton_Click);
            // 
            // buyBazookaAmmoButton
            // 
            this.buyBazookaAmmoButton.Location = new System.Drawing.Point(507, 127);
            this.buyBazookaAmmoButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buyBazookaAmmoButton.Name = "buyBazookaAmmoButton";
            this.buyBazookaAmmoButton.Size = new System.Drawing.Size(80, 38);
            this.buyBazookaAmmoButton.TabIndex = 19;
            this.buyBazookaAmmoButton.Text = "BuyAmmo";
            this.buyBazookaAmmoButton.UseVisualStyleBackColor = true;
            this.buyBazookaAmmoButton.Click += new System.EventHandler(this.buyBazookaAmmoButton_Click);
            // 
            // buyBazookaButton
            // 
            this.buyBazookaButton.Location = new System.Drawing.Point(507, 89);
            this.buyBazookaButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buyBazookaButton.Name = "buyBazookaButton";
            this.buyBazookaButton.Size = new System.Drawing.Size(98, 33);
            this.buyBazookaButton.TabIndex = 18;
            this.buyBazookaButton.Text = "Buy bazooka";
            this.buyBazookaButton.UseVisualStyleBackColor = true;
            this.buyBazookaButton.Click += new System.EventHandler(this.buyBazookaButton_Click);
            // 
            // bazookaAmmoCostLabel
            // 
            this.bazookaAmmoCostLabel.AutoSize = true;
            this.bazookaAmmoCostLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bazookaAmmoCostLabel.Location = new System.Drawing.Point(507, 73);
            this.bazookaAmmoCostLabel.Name = "bazookaAmmoCostLabel";
            this.bazookaAmmoCostLabel.Size = new System.Drawing.Size(98, 14);
            this.bazookaAmmoCostLabel.TabIndex = 17;
            this.bazookaAmmoCostLabel.Text = "Ammo cost: 55";
            // 
            // bazookaCostLabel
            // 
            this.bazookaCostLabel.AutoSize = true;
            this.bazookaCostLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bazookaCostLabel.Location = new System.Drawing.Point(507, 53);
            this.bazookaCostLabel.Name = "bazookaCostLabel";
            this.bazookaCostLabel.Size = new System.Drawing.Size(119, 14);
            this.bazookaCostLabel.TabIndex = 16;
            this.bazookaCostLabel.Text = "Weapon cost: 500";
            // 
            // bazookaLabel
            // 
            this.bazookaLabel.AutoSize = true;
            this.bazookaLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bazookaLabel.Location = new System.Drawing.Point(507, 31);
            this.bazookaLabel.Name = "bazookaLabel";
            this.bazookaLabel.Size = new System.Drawing.Size(80, 22);
            this.bazookaLabel.TabIndex = 15;
            this.bazookaLabel.Text = "Bazooka";
            // 
            // buyShotgunAmmoButton
            // 
            this.buyShotgunAmmoButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buyShotgunAmmoButton.Location = new System.Drawing.Point(352, 127);
            this.buyShotgunAmmoButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buyShotgunAmmoButton.Name = "buyShotgunAmmoButton";
            this.buyShotgunAmmoButton.Size = new System.Drawing.Size(80, 38);
            this.buyShotgunAmmoButton.TabIndex = 14;
            this.buyShotgunAmmoButton.Text = "Buy Ammo";
            this.buyShotgunAmmoButton.UseVisualStyleBackColor = true;
            this.buyShotgunAmmoButton.Click += new System.EventHandler(this.buyShotgunAmmoButton_Click);
            // 
            // buyShotgunButton
            // 
            this.buyShotgunButton.Location = new System.Drawing.Point(352, 89);
            this.buyShotgunButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buyShotgunButton.Name = "buyShotgunButton";
            this.buyShotgunButton.Size = new System.Drawing.Size(98, 33);
            this.buyShotgunButton.TabIndex = 13;
            this.buyShotgunButton.Text = "Buy shotgun";
            this.buyShotgunButton.UseVisualStyleBackColor = true;
            this.buyShotgunButton.Click += new System.EventHandler(this.buyShotgunButton_Click);
            // 
            // shotgunAmmoCostLabel
            // 
            this.shotgunAmmoCostLabel.AutoSize = true;
            this.shotgunAmmoCostLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.shotgunAmmoCostLabel.Location = new System.Drawing.Point(352, 73);
            this.shotgunAmmoCostLabel.Name = "shotgunAmmoCostLabel";
            this.shotgunAmmoCostLabel.Size = new System.Drawing.Size(98, 14);
            this.shotgunAmmoCostLabel.TabIndex = 12;
            this.shotgunAmmoCostLabel.Text = "Ammo cost: 45";
            // 
            // shotgunCostLabel
            // 
            this.shotgunCostLabel.AutoSize = true;
            this.shotgunCostLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.shotgunCostLabel.Location = new System.Drawing.Point(352, 52);
            this.shotgunCostLabel.Name = "shotgunCostLabel";
            this.shotgunCostLabel.Size = new System.Drawing.Size(119, 14);
            this.shotgunCostLabel.TabIndex = 11;
            this.shotgunCostLabel.Text = "Weapon cost: 400";
            // 
            // shotgunLabel
            // 
            this.shotgunLabel.AutoSize = true;
            this.shotgunLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.shotgunLabel.Location = new System.Drawing.Point(352, 31);
            this.shotgunLabel.Name = "shotgunLabel";
            this.shotgunLabel.Size = new System.Drawing.Size(80, 22);
            this.shotgunLabel.TabIndex = 10;
            this.shotgunLabel.Text = "Shotgun";
            // 
            // buyRifleAmmoButton
            // 
            this.buyRifleAmmoButton.Location = new System.Drawing.Point(200, 127);
            this.buyRifleAmmoButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buyRifleAmmoButton.Name = "buyRifleAmmoButton";
            this.buyRifleAmmoButton.Size = new System.Drawing.Size(78, 38);
            this.buyRifleAmmoButton.TabIndex = 9;
            this.buyRifleAmmoButton.Text = "Buy Ammo";
            this.buyRifleAmmoButton.UseVisualStyleBackColor = true;
            this.buyRifleAmmoButton.Click += new System.EventHandler(this.buyRifleAmmoButton_Click);
            // 
            // buyRifleButton
            // 
            this.buyRifleButton.Location = new System.Drawing.Point(200, 89);
            this.buyRifleButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buyRifleButton.Name = "buyRifleButton";
            this.buyRifleButton.Size = new System.Drawing.Size(98, 33);
            this.buyRifleButton.TabIndex = 8;
            this.buyRifleButton.Text = "Buy rifle";
            this.buyRifleButton.UseVisualStyleBackColor = true;
            this.buyRifleButton.Click += new System.EventHandler(this.buyRifleButton_Click);
            // 
            // rifleAmmoCostLabel
            // 
            this.rifleAmmoCostLabel.AutoSize = true;
            this.rifleAmmoCostLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rifleAmmoCostLabel.Location = new System.Drawing.Point(200, 74);
            this.rifleAmmoCostLabel.Name = "rifleAmmoCostLabel";
            this.rifleAmmoCostLabel.Size = new System.Drawing.Size(98, 14);
            this.rifleAmmoCostLabel.TabIndex = 7;
            this.rifleAmmoCostLabel.Text = "Ammo cost: 35";
            // 
            // rifleCostLabel
            // 
            this.rifleCostLabel.AutoSize = true;
            this.rifleCostLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rifleCostLabel.Location = new System.Drawing.Point(200, 53);
            this.rifleCostLabel.Name = "rifleCostLabel";
            this.rifleCostLabel.Size = new System.Drawing.Size(119, 14);
            this.rifleCostLabel.TabIndex = 6;
            this.rifleCostLabel.Text = "Weapon cost: 300";
            // 
            // rifleLabel
            // 
            this.rifleLabel.AutoSize = true;
            this.rifleLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.rifleLabel.Location = new System.Drawing.Point(200, 31);
            this.rifleLabel.Name = "rifleLabel";
            this.rifleLabel.Size = new System.Drawing.Size(60, 22);
            this.rifleLabel.TabIndex = 5;
            this.rifleLabel.Text = "Rifle";
            // 
            // buyPistolAmmoButton
            // 
            this.buyPistolAmmoButton.Location = new System.Drawing.Point(51, 127);
            this.buyPistolAmmoButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buyPistolAmmoButton.Name = "buyPistolAmmoButton";
            this.buyPistolAmmoButton.Size = new System.Drawing.Size(70, 38);
            this.buyPistolAmmoButton.TabIndex = 4;
            this.buyPistolAmmoButton.Text = "Buy Ammo";
            this.buyPistolAmmoButton.UseVisualStyleBackColor = true;
            this.buyPistolAmmoButton.Click += new System.EventHandler(this.buyPistolAmmoButton_Click);
            // 
            // buyPistolButton
            // 
            this.buyPistolButton.Location = new System.Drawing.Point(51, 90);
            this.buyPistolButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buyPistolButton.Name = "buyPistolButton";
            this.buyPistolButton.Size = new System.Drawing.Size(70, 32);
            this.buyPistolButton.TabIndex = 3;
            this.buyPistolButton.Text = "Buy pistol";
            this.buyPistolButton.UseVisualStyleBackColor = true;
            this.buyPistolButton.Click += new System.EventHandler(this.buyPistolButton_Click);
            // 
            // pistolAmmoPriceLabel
            // 
            this.pistolAmmoPriceLabel.AutoSize = true;
            this.pistolAmmoPriceLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pistolAmmoPriceLabel.Location = new System.Drawing.Point(51, 74);
            this.pistolAmmoPriceLabel.Name = "pistolAmmoPriceLabel";
            this.pistolAmmoPriceLabel.Size = new System.Drawing.Size(98, 14);
            this.pistolAmmoPriceLabel.TabIndex = 2;
            this.pistolAmmoPriceLabel.Text = "Ammo cost: 25";
            // 
            // pistolPriceLabel
            // 
            this.pistolPriceLabel.AutoSize = true;
            this.pistolPriceLabel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pistolPriceLabel.Location = new System.Drawing.Point(51, 54);
            this.pistolPriceLabel.Name = "pistolPriceLabel";
            this.pistolPriceLabel.Size = new System.Drawing.Size(119, 14);
            this.pistolPriceLabel.TabIndex = 1;
            this.pistolPriceLabel.Text = "Weapon cost: 200";
            // 
            // pistolLabel
            // 
            this.pistolLabel.AutoSize = true;
            this.pistolLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.pistolLabel.Location = new System.Drawing.Point(51, 31);
            this.pistolLabel.Name = "pistolLabel";
            this.pistolLabel.Size = new System.Drawing.Size(70, 22);
            this.pistolLabel.TabIndex = 0;
            this.pistolLabel.Text = "Pistol";
            // 
            // ammoLabel
            // 
            this.ammoLabel.AutoSize = true;
            this.ammoLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ammoLabel.Location = new System.Drawing.Point(888, 56);
            this.ammoLabel.Name = "ammoLabel";
            this.ammoLabel.Size = new System.Drawing.Size(60, 22);
            this.ammoLabel.TabIndex = 13;
            this.ammoLabel.Text = "Ammo:";
            // 
            // ammoCountLabel
            // 
            this.ammoCountLabel.AutoSize = true;
            this.ammoCountLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ammoCountLabel.Location = new System.Drawing.Point(949, 56);
            this.ammoCountLabel.Name = "ammoCountLabel";
            this.ammoCountLabel.Size = new System.Drawing.Size(100, 22);
            this.ammoCountLabel.TabIndex = 14;
            this.ammoCountLabel.Text = "ammoCount";
            // 
            // weaponLabel
            // 
            this.weaponLabel.AutoSize = true;
            this.weaponLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.weaponLabel.Location = new System.Drawing.Point(868, 78);
            this.weaponLabel.Name = "weaponLabel";
            this.weaponLabel.Size = new System.Drawing.Size(80, 22);
            this.weaponLabel.TabIndex = 15;
            this.weaponLabel.Text = "Weapon:";
            // 
            // weaponNameLabel
            // 
            this.weaponNameLabel.AutoSize = true;
            this.weaponNameLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.weaponNameLabel.Location = new System.Drawing.Point(949, 78);
            this.weaponNameLabel.Name = "weaponNameLabel";
            this.weaponNameLabel.Size = new System.Drawing.Size(110, 22);
            this.weaponNameLabel.TabIndex = 16;
            this.weaponNameLabel.Text = "weaponName";
            // 
            // updateWeaponNotif
            // 
            this.updateWeaponNotif.AutoSize = true;
            this.updateWeaponNotif.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.updateWeaponNotif.Location = new System.Drawing.Point(306, 59);
            this.updateWeaponNotif.Name = "updateWeaponNotif";
            this.updateWeaponNotif.Size = new System.Drawing.Size(0, 46);
            this.updateWeaponNotif.TabIndex = 17;
            this.updateWeaponNotif.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(12, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(230, 22);
            this.label5.TabIndex = 18;
            this.label5.Text = "Total money collected:";
            // 
            // moneyTotalCountLabel
            // 
            this.moneyTotalCountLabel.AutoSize = true;
            this.moneyTotalCountLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.moneyTotalCountLabel.Location = new System.Drawing.Point(238, 31);
            this.moneyTotalCountLabel.Name = "moneyTotalCountLabel";
            this.moneyTotalCountLabel.Size = new System.Drawing.Size(20, 22);
            this.moneyTotalCountLabel.TabIndex = 19;
            this.moneyTotalCountLabel.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(370, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 22);
            this.label6.TabIndex = 20;
            this.label6.Text = "LEVEL:";
            // 
            // levelLabel
            // 
            this.levelLabel.AutoSize = true;
            this.levelLabel.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.levelLabel.Location = new System.Drawing.Point(440, 34);
            this.levelLabel.Name = "levelLabel";
            this.levelLabel.Size = new System.Drawing.Size(20, 22);
            this.levelLabel.TabIndex = 21;
            this.levelLabel.Text = "1";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1119, 661);
            this.Controls.Add(this.endingPanel);
            this.Controls.Add(this.levelLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.moneyTotalCountLabel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.updateWeaponNotif);
            this.Controls.Add(this.weaponNameLabel);
            this.Controls.Add(this.weaponLabel);
            this.Controls.Add(this.ammoCountLabel);
            this.Controls.Add(this.ammoLabel);
            this.Controls.Add(this.shopPanel);
            this.Controls.Add(this.moneyCountLabel);
            this.Controls.Add(this.moneyLabel);
            this.Controls.Add(this.hpCountLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trashLabel);
            this.Controls.Add(this.testLabel);
            this.Controls.Add(this.playerLabel);
            this.Controls.Add(this.hpLabel);
            this.Name = "Game";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyIsDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyIsUp);
            this.shopPanel.ResumeLayout(false);
            this.shopPanel.PerformLayout();
            this.endingPanel.ResumeLayout(false);
            this.endingPanel.PerformLayout();
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
        private Panel shopPanel;
        private Label pistolLabel;
        private Button buyPistolAmmoButton;
        private Button buyPistolButton;
        private Label pistolAmmoPriceLabel;
        private Label pistolPriceLabel;
        private Label rifleLabel;
        private Button buyRifleAmmoButton;
        private Button buyRifleButton;
        private Label rifleAmmoCostLabel;
        private Label rifleCostLabel;
        private Label shotgunLabel;
        private Label shotgunAmmoCostLabel;
        private Label shotgunCostLabel;
        private Label bazookaLabel;
        private Button buyShotgunAmmoButton;
        private Button buyShotgunButton;
        private Label bazookaAmmoCostLabel;
        private Label bazookaCostLabel;
        private Button buyBazookaAmmoButton;
        private Button buyBazookaButton;
        private Button closeShopButton;
        private Label ammoLabel;
        private Label ammoCountLabel;
        private Label weaponLabel;
        private Label weaponNameLabel;
        private Label updateWeaponNotif;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button damageBoostButton;
        private Button boostSpeedButton;
        private Button jumpBoostButton;
        private Label label1;
        private Label label5;
        private Label moneyTotalCountLabel;
        private Label label6;
        private Label levelLabel;
        private Panel endingPanel;
        private Label level3MoneyRed;
        private Label level2MoneyRed;
        private Label level1MoneyRed;
        private Label level3MoneyBlue;
        private Label level2MoneyBlue;
        private Label level1MoneyBlue;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label gameOver;
    }
}