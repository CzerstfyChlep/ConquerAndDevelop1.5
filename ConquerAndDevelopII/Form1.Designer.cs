namespace ConquerAndDevelopII
{
    partial class MainForm
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
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.IPBox = new System.Windows.Forms.TextBox();
            this.MainMenuPanel = new System.Windows.Forms.Panel();
            this.LobbiesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.MaxSlotsLabel = new System.Windows.Forms.Label();
            this.MaxSlots = new System.Windows.Forms.NumericUpDown();
            this.GamePasswordBox = new System.Windows.Forms.TextBox();
            this.GameNameBox = new System.Windows.Forms.TextBox();
            this.StartGameButton = new System.Windows.Forms.Button();
            this.LobbyPanel = new System.Windows.Forms.Panel();
            this.GameNameLabel = new System.Windows.Forms.Label();
            this.ExitButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.PlayersBox = new System.Windows.Forms.GroupBox();
            this.LobbyLabel = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MainGameInfoPanel = new System.Windows.Forms.Panel();
            this.DevelopmentButton = new System.Windows.Forms.Button();
            this.IncomeLabel = new System.Windows.Forms.Label();
            this.CreateADealButton = new System.Windows.Forms.Button();
            this.ProvinceBox = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.HireDisbandSoldierButton = new System.Windows.Forms.Button();
            this.DevelopmentLebel = new System.Windows.Forms.Label();
            this.BuildingSlot1 = new System.Windows.Forms.PictureBox();
            this.GoldLabel = new System.Windows.Forms.Label();
            this.LoggedPanel = new System.Windows.Forms.Panel();
            this.LoggedAsLabel = new System.Windows.Forms.Label();
            this.GuestLogin = new System.Windows.Forms.Button();
            this.LoginPanel.SuspendLayout();
            this.MainMenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSlots)).BeginInit();
            this.LobbyPanel.SuspendLayout();
            this.PlayersBox.SuspendLayout();
            this.MainGameInfoPanel.SuspendLayout();
            this.ProvinceBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BuildingSlot1)).BeginInit();
            this.LoggedPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoginBox
            // 
            this.LoginBox.Location = new System.Drawing.Point(0, 1);
            this.LoginBox.MaxLength = 32;
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(78, 20);
            this.LoginBox.TabIndex = 0;
            this.LoginBox.Text = "Login";
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(84, 1);
            this.PasswordBox.MaxLength = 16;
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '*';
            this.PasswordBox.Size = new System.Drawing.Size(80, 20);
            this.PasswordBox.TabIndex = 1;
            this.PasswordBox.Text = "Password";
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(246, 0);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(43, 22);
            this.LoginButton.TabIndex = 2;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(295, 0);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(65, 22);
            this.RegisterButton.TabIndex = 3;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // LoginPanel
            // 
            this.LoginPanel.Controls.Add(this.IPBox);
            this.LoginPanel.Controls.Add(this.RegisterButton);
            this.LoginPanel.Controls.Add(this.LoginBox);
            this.LoginPanel.Controls.Add(this.LoginButton);
            this.LoginPanel.Controls.Add(this.PasswordBox);
            this.LoginPanel.Location = new System.Drawing.Point(40, 12);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(365, 23);
            this.LoginPanel.TabIndex = 4;
            // 
            // IPBox
            // 
            this.IPBox.Location = new System.Drawing.Point(170, 1);
            this.IPBox.MaxLength = 16;
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(70, 20);
            this.IPBox.TabIndex = 4;
            this.IPBox.Text = "IP";
            // 
            // MainMenuPanel
            // 
            this.MainMenuPanel.Controls.Add(this.LobbiesPanel);
            this.MainMenuPanel.Controls.Add(this.MaxSlotsLabel);
            this.MainMenuPanel.Controls.Add(this.MaxSlots);
            this.MainMenuPanel.Controls.Add(this.GamePasswordBox);
            this.MainMenuPanel.Controls.Add(this.GameNameBox);
            this.MainMenuPanel.Controls.Add(this.StartGameButton);
            this.MainMenuPanel.Enabled = false;
            this.MainMenuPanel.Location = new System.Drawing.Point(127, 59);
            this.MainMenuPanel.Name = "MainMenuPanel";
            this.MainMenuPanel.Size = new System.Drawing.Size(200, 306);
            this.MainMenuPanel.TabIndex = 5;
            this.MainMenuPanel.Visible = false;
            // 
            // LobbiesPanel
            // 
            this.LobbiesPanel.AutoScroll = true;
            this.LobbiesPanel.Location = new System.Drawing.Point(3, 110);
            this.LobbiesPanel.Name = "LobbiesPanel";
            this.LobbiesPanel.Size = new System.Drawing.Size(194, 175);
            this.LobbiesPanel.TabIndex = 7;
            // 
            // MaxSlotsLabel
            // 
            this.MaxSlotsLabel.AutoSize = true;
            this.MaxSlotsLabel.Location = new System.Drawing.Point(3, 57);
            this.MaxSlotsLabel.Name = "MaxSlotsLabel";
            this.MaxSlotsLabel.Size = new System.Drawing.Size(54, 13);
            this.MaxSlotsLabel.TabIndex = 6;
            this.MaxSlotsLabel.Text = "Max. slots";
            // 
            // MaxSlots
            // 
            this.MaxSlots.Location = new System.Drawing.Point(121, 55);
            this.MaxSlots.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.MaxSlots.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.MaxSlots.Name = "MaxSlots";
            this.MaxSlots.Size = new System.Drawing.Size(76, 20);
            this.MaxSlots.TabIndex = 6;
            this.MaxSlots.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // GamePasswordBox
            // 
            this.GamePasswordBox.Location = new System.Drawing.Point(3, 29);
            this.GamePasswordBox.MaxLength = 16;
            this.GamePasswordBox.Name = "GamePasswordBox";
            this.GamePasswordBox.Size = new System.Drawing.Size(194, 20);
            this.GamePasswordBox.TabIndex = 7;
            this.GamePasswordBox.Text = "Game password";
            // 
            // GameNameBox
            // 
            this.GameNameBox.Location = new System.Drawing.Point(3, 3);
            this.GameNameBox.MaxLength = 32;
            this.GameNameBox.Name = "GameNameBox";
            this.GameNameBox.Size = new System.Drawing.Size(194, 20);
            this.GameNameBox.TabIndex = 6;
            this.GameNameBox.Text = "Game name";
            // 
            // StartGameButton
            // 
            this.StartGameButton.Location = new System.Drawing.Point(3, 81);
            this.StartGameButton.Name = "StartGameButton";
            this.StartGameButton.Size = new System.Drawing.Size(194, 23);
            this.StartGameButton.TabIndex = 6;
            this.StartGameButton.Text = "Start new game";
            this.StartGameButton.UseVisualStyleBackColor = true;
            this.StartGameButton.Click += new System.EventHandler(this.StartGameButton_Click);
            // 
            // LobbyPanel
            // 
            this.LobbyPanel.Controls.Add(this.GameNameLabel);
            this.LobbyPanel.Controls.Add(this.ExitButton);
            this.LobbyPanel.Controls.Add(this.StartButton);
            this.LobbyPanel.Controls.Add(this.PlayersBox);
            this.LobbyPanel.Enabled = false;
            this.LobbyPanel.Location = new System.Drawing.Point(40, 59);
            this.LobbyPanel.Name = "LobbyPanel";
            this.LobbyPanel.Size = new System.Drawing.Size(365, 191);
            this.LobbyPanel.TabIndex = 6;
            this.LobbyPanel.Visible = false;
            // 
            // GameNameLabel
            // 
            this.GameNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GameNameLabel.Location = new System.Drawing.Point(6, 3);
            this.GameNameLabel.Name = "GameNameLabel";
            this.GameNameLabel.Size = new System.Drawing.Size(354, 37);
            this.GameNameLabel.TabIndex = 3;
            this.GameNameLabel.Text = "GameName";
            this.GameNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExitButton
            // 
            this.ExitButton.Location = new System.Drawing.Point(276, 159);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(84, 23);
            this.ExitButton.TabIndex = 2;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Enabled = false;
            this.StartButton.Location = new System.Drawing.Point(277, 47);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(85, 69);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Visible = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // PlayersBox
            // 
            this.PlayersBox.Controls.Add(this.LobbyLabel);
            this.PlayersBox.Location = new System.Drawing.Point(6, 47);
            this.PlayersBox.Name = "PlayersBox";
            this.PlayersBox.Size = new System.Drawing.Size(265, 135);
            this.PlayersBox.TabIndex = 0;
            this.PlayersBox.TabStop = false;
            this.PlayersBox.Text = "Players";
            // 
            // LobbyLabel
            // 
            this.LobbyLabel.AutoSize = true;
            this.LobbyLabel.Location = new System.Drawing.Point(6, 16);
            this.LobbyLabel.Name = "LobbyLabel";
            this.LobbyLabel.Size = new System.Drawing.Size(57, 13);
            this.LobbyLabel.TabIndex = 0;
            this.LobbyLabel.Text = "LobbyText";
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 250;
            this.toolTip1.ReshowDelay = 100;
            // 
            // MainGameInfoPanel
            // 
            this.MainGameInfoPanel.Controls.Add(this.DevelopmentButton);
            this.MainGameInfoPanel.Controls.Add(this.IncomeLabel);
            this.MainGameInfoPanel.Controls.Add(this.CreateADealButton);
            this.MainGameInfoPanel.Controls.Add(this.ProvinceBox);
            this.MainGameInfoPanel.Controls.Add(this.GoldLabel);
            this.MainGameInfoPanel.Location = new System.Drawing.Point(427, 13);
            this.MainGameInfoPanel.Name = "MainGameInfoPanel";
            this.MainGameInfoPanel.Size = new System.Drawing.Size(180, 448);
            this.MainGameInfoPanel.TabIndex = 7;
            // 
            // DevelopmentButton
            // 
            this.DevelopmentButton.Location = new System.Drawing.Point(8, 109);
            this.DevelopmentButton.Name = "DevelopmentButton";
            this.DevelopmentButton.Size = new System.Drawing.Size(163, 41);
            this.DevelopmentButton.TabIndex = 9;
            this.DevelopmentButton.Text = "Development Map";
            this.DevelopmentButton.UseVisualStyleBackColor = true;
            this.DevelopmentButton.Click += new System.EventHandler(this.DevelopmentButton_Click);
            // 
            // IncomeLabel
            // 
            this.IncomeLabel.AutoSize = true;
            this.IncomeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.IncomeLabel.Location = new System.Drawing.Point(4, 38);
            this.IncomeLabel.Name = "IncomeLabel";
            this.IncomeLabel.Size = new System.Drawing.Size(67, 31);
            this.IncomeLabel.TabIndex = 8;
            this.IncomeLabel.Text = "Inc.:";
            // 
            // CreateADealButton
            // 
            this.CreateADealButton.Location = new System.Drawing.Point(8, 214);
            this.CreateADealButton.Name = "CreateADealButton";
            this.CreateADealButton.Size = new System.Drawing.Size(163, 23);
            this.CreateADealButton.TabIndex = 3;
            this.CreateADealButton.Text = "Create a Deal";
            this.CreateADealButton.UseVisualStyleBackColor = true;
            this.CreateADealButton.Click += new System.EventHandler(this.SendGoldButton_Click);
            // 
            // ProvinceBox
            // 
            this.ProvinceBox.Controls.Add(this.label2);
            this.ProvinceBox.Controls.Add(this.HireDisbandSoldierButton);
            this.ProvinceBox.Controls.Add(this.DevelopmentLebel);
            this.ProvinceBox.Controls.Add(this.BuildingSlot1);
            this.ProvinceBox.Location = new System.Drawing.Point(3, 246);
            this.ProvinceBox.Name = "ProvinceBox";
            this.ProvinceBox.Size = new System.Drawing.Size(174, 197);
            this.ProvinceBox.TabIndex = 2;
            this.ProvinceBox.TabStop = false;
            this.ProvinceBox.Text = "None";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(4, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 47);
            this.label2.TabIndex = 8;
            this.label2.Text = "Soldier costs 20 gold to hire and 5 gold to maintain. Shortcut: S/C";
            // 
            // HireDisbandSoldierButton
            // 
            this.HireDisbandSoldierButton.Location = new System.Drawing.Point(7, 13);
            this.HireDisbandSoldierButton.Name = "HireDisbandSoldierButton";
            this.HireDisbandSoldierButton.Size = new System.Drawing.Size(161, 23);
            this.HireDisbandSoldierButton.TabIndex = 3;
            this.HireDisbandSoldierButton.Text = "Hire/Disband Soldier";
            this.HireDisbandSoldierButton.UseVisualStyleBackColor = true;
            this.HireDisbandSoldierButton.Click += new System.EventHandler(this.HireDisbandSoldierButton_Click);
            // 
            // DevelopmentLebel
            // 
            this.DevelopmentLebel.AutoSize = true;
            this.DevelopmentLebel.Location = new System.Drawing.Point(9, 39);
            this.DevelopmentLebel.Name = "DevelopmentLebel";
            this.DevelopmentLebel.Size = new System.Drawing.Size(73, 13);
            this.DevelopmentLebel.TabIndex = 2;
            this.DevelopmentLebel.Text = "Development:";
            // 
            // BuildingSlot1
            // 
            this.BuildingSlot1.Location = new System.Drawing.Point(69, 55);
            this.BuildingSlot1.Name = "BuildingSlot1";
            this.BuildingSlot1.Size = new System.Drawing.Size(50, 51);
            this.BuildingSlot1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.BuildingSlot1.TabIndex = 0;
            this.BuildingSlot1.TabStop = false;
            this.BuildingSlot1.Click += new System.EventHandler(this.BuildingSlot1_Click);
            // 
            // GoldLabel
            // 
            this.GoldLabel.AutoSize = true;
            this.GoldLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GoldLabel.Location = new System.Drawing.Point(4, 4);
            this.GoldLabel.Name = "GoldLabel";
            this.GoldLabel.Size = new System.Drawing.Size(79, 31);
            this.GoldLabel.TabIndex = 1;
            this.GoldLabel.Text = "Gold:";
            // 
            // LoggedPanel
            // 
            this.LoggedPanel.Controls.Add(this.LoggedAsLabel);
            this.LoggedPanel.Enabled = false;
            this.LoggedPanel.Location = new System.Drawing.Point(12, 438);
            this.LoggedPanel.Name = "LoggedPanel";
            this.LoggedPanel.Size = new System.Drawing.Size(365, 23);
            this.LoggedPanel.TabIndex = 8;
            this.LoggedPanel.Visible = false;
            // 
            // LoggedAsLabel
            // 
            this.LoggedAsLabel.AutoSize = true;
            this.LoggedAsLabel.Location = new System.Drawing.Point(3, 5);
            this.LoggedAsLabel.Name = "LoggedAsLabel";
            this.LoggedAsLabel.Size = new System.Drawing.Size(63, 13);
            this.LoggedAsLabel.TabIndex = 0;
            this.LoggedAsLabel.Text = "Logged as: ";
            // 
            // GuestLogin
            // 
            this.GuestLogin.Location = new System.Drawing.Point(40, 37);
            this.GuestLogin.Name = "GuestLogin";
            this.GuestLogin.Size = new System.Drawing.Size(101, 22);
            this.GuestLogin.TabIndex = 5;
            this.GuestLogin.Text = "Login as guest";
            this.GuestLogin.UseVisualStyleBackColor = true;
            this.GuestLogin.Click += new System.EventHandler(this.GuestLogin_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.LoginButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 473);
            this.Controls.Add(this.GuestLogin);
            this.Controls.Add(this.LoggedPanel);
            this.Controls.Add(this.MainGameInfoPanel);
            this.Controls.Add(this.LobbyPanel);
            this.Controls.Add(this.MainMenuPanel);
            this.Controls.Add(this.LoginPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Conquer And Develop 1.5";
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.MainMenuPanel.ResumeLayout(false);
            this.MainMenuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSlots)).EndInit();
            this.LobbyPanel.ResumeLayout(false);
            this.PlayersBox.ResumeLayout(false);
            this.PlayersBox.PerformLayout();
            this.MainGameInfoPanel.ResumeLayout(false);
            this.MainGameInfoPanel.PerformLayout();
            this.ProvinceBox.ResumeLayout(false);
            this.ProvinceBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BuildingSlot1)).EndInit();
            this.LoggedPanel.ResumeLayout(false);
            this.LoggedPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox LoginBox;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Button LoginButton;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Panel LoginPanel;
        private System.Windows.Forms.Panel MainMenuPanel;
        private System.Windows.Forms.Label MaxSlotsLabel;
        private System.Windows.Forms.NumericUpDown MaxSlots;
        private System.Windows.Forms.TextBox GamePasswordBox;
        private System.Windows.Forms.TextBox GameNameBox;
        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.Panel LobbyPanel;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.GroupBox PlayersBox;
        private System.Windows.Forms.Label LobbyLabel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Label GameNameLabel;
        private System.Windows.Forms.FlowLayoutPanel LobbiesPanel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel MainGameInfoPanel;
        private System.Windows.Forms.Panel LoggedPanel;
        private System.Windows.Forms.Label LoggedAsLabel;
        private System.Windows.Forms.Label GoldLabel;
        private System.Windows.Forms.PictureBox BuildingSlot1;
        private System.Windows.Forms.GroupBox ProvinceBox;
        private System.Windows.Forms.Label DevelopmentLebel;
        private System.Windows.Forms.Button CreateADealButton;
        private System.Windows.Forms.Label IncomeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DevelopmentButton;
        private System.Windows.Forms.TextBox IPBox;
        private System.Windows.Forms.Button HireDisbandSoldierButton;
        private System.Windows.Forms.Button GuestLogin;
    }
}

