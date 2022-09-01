namespace ConquerAndDevelopII
{
    partial class DealMenu
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
            this.label1 = new System.Windows.Forms.Label();
            this.ToMenu = new System.Windows.Forms.CheckedListBox();
            this.AdditionalTextBox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OfficialBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SGold = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DurationMenu = new System.Windows.Forms.NumericUpDown();
            this.ExpiringBox = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label9 = new System.Windows.Forms.Label();
            this.SGoldPerTurn = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.RGoldPerTurn = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.RGold = new System.Windows.Forms.NumericUpDown();
            this.TitleBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SGold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DurationMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SGoldPerTurn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGoldPerTurn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGold)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "To:";
            // 
            // ToMenu
            // 
            this.ToMenu.FormattingEnabled = true;
            this.ToMenu.Location = new System.Drawing.Point(15, 60);
            this.ToMenu.Name = "ToMenu";
            this.ToMenu.Size = new System.Drawing.Size(476, 49);
            this.ToMenu.TabIndex = 2;
            // 
            // AdditionalTextBox
            // 
            this.AdditionalTextBox.Location = new System.Drawing.Point(12, 245);
            this.AdditionalTextBox.MaxLength = 300;
            this.AdditionalTextBox.Multiline = true;
            this.AdditionalTextBox.Name = "AdditionalTextBox";
            this.AdditionalTextBox.Size = new System.Drawing.Size(479, 126);
            this.AdditionalTextBox.TabIndex = 3;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(403, 412);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(88, 43);
            this.SendButton.TabIndex = 4;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(12, 412);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(90, 43);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OfficialBox
            // 
            this.OfficialBox.AutoSize = true;
            this.OfficialBox.Checked = true;
            this.OfficialBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.OfficialBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.OfficialBox.Location = new System.Drawing.Point(12, 377);
            this.OfficialBox.Name = "OfficialBox";
            this.OfficialBox.Size = new System.Drawing.Size(97, 29);
            this.OfficialBox.TabIndex = 6;
            this.OfficialBox.Text = "Official";
            this.OfficialBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(10, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Additional text:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SGold
            // 
            this.SGold.Location = new System.Drawing.Point(37, 156);
            this.SGold.Name = "SGold";
            this.SGold.Size = new System.Drawing.Size(120, 20);
            this.SGold.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(222, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 78);
            this.label3.TabIndex = 9;
            this.label3.Text = "=>\r\n<=\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Gold";
            // 
            // DurationMenu
            // 
            this.DurationMenu.Location = new System.Drawing.Point(414, 381);
            this.DurationMenu.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.DurationMenu.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DurationMenu.Name = "DurationMenu";
            this.DurationMenu.Size = new System.Drawing.Size(77, 20);
            this.DurationMenu.TabIndex = 13;
            this.DurationMenu.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ExpiringBox
            // 
            this.ExpiringBox.AutoSize = true;
            this.ExpiringBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ExpiringBox.Location = new System.Drawing.Point(115, 377);
            this.ExpiringBox.Name = "ExpiringBox";
            this.ExpiringBox.Size = new System.Drawing.Size(109, 29);
            this.ExpiringBox.TabIndex = 14;
            this.ExpiringBox.Text = "Expiring";
            this.ExpiringBox.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(315, 378);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Duration";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(77, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 20);
            this.label7.TabIndex = 16;
            this.label7.Text = "YOU";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(364, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 20);
            this.label8.TabIndex = 17;
            this.label8.Text = "OTHERS";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Gold per Turn";
            // 
            // SGoldPerTurn
            // 
            this.SGoldPerTurn.Location = new System.Drawing.Point(37, 196);
            this.SGoldPerTurn.Name = "SGoldPerTurn";
            this.SGoldPerTurn.Size = new System.Drawing.Size(120, 20);
            this.SGoldPerTurn.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Gold per Turn";
            // 
            // RGoldPerTurn
            // 
            this.RGoldPerTurn.Location = new System.Drawing.Point(338, 196);
            this.RGoldPerTurn.Name = "RGoldPerTurn";
            this.RGoldPerTurn.Size = new System.Drawing.Size(120, 20);
            this.RGoldPerTurn.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(335, 139);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Gold";
            // 
            // RGold
            // 
            this.RGold.Location = new System.Drawing.Point(338, 156);
            this.RGold.Name = "RGold";
            this.RGold.Size = new System.Drawing.Size(120, 20);
            this.RGold.TabIndex = 20;
            // 
            // TitleBox
            // 
            this.TitleBox.Location = new System.Drawing.Point(15, 21);
            this.TitleBox.MaxLength = 50;
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new System.Drawing.Size(476, 20);
            this.TitleBox.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 5);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 25;
            this.label11.Text = "Title:";
            // 
            // DealMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 463);
            this.ControlBox = false;
            this.Controls.Add(this.label11);
            this.Controls.Add(this.TitleBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.RGoldPerTurn);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.RGold);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.SGoldPerTurn);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ExpiringBox);
            this.Controls.Add(this.DurationMenu);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SGold);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OfficialBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.AdditionalTextBox);
            this.Controls.Add(this.ToMenu);
            this.Controls.Add(this.label1);
            this.Name = "DealMenu";
            this.Text = "DealMenu";
            ((System.ComponentModel.ISupportInitialize)(this.SGold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DurationMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SGoldPerTurn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGoldPerTurn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox ToMenu;
        private System.Windows.Forms.TextBox AdditionalTextBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.CheckBox OfficialBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown SGold;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown DurationMenu;
        private System.Windows.Forms.CheckBox ExpiringBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown SGoldPerTurn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown RGoldPerTurn;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown RGold;
        private System.Windows.Forms.TextBox TitleBox;
        private System.Windows.Forms.Label label11;
    }
}