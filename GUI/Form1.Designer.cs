
namespace GUI
{
    partial class Form1
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.PlayerName1 = new System.Windows.Forms.TextBox();
            this.CharacterName1 = new System.Windows.Forms.TextBox();
            this.CharacterName2 = new System.Windows.Forms.TextBox();
            this.PlayerName2 = new System.Windows.Forms.TextBox();
            this.CharacterName4 = new System.Windows.Forms.TextBox();
            this.PlayerName4 = new System.Windows.Forms.TextBox();
            this.CharacterName3 = new System.Windows.Forms.TextBox();
            this.PlayerName3 = new System.Windows.Forms.TextBox();
            this.SaveGameDataButton = new System.Windows.Forms.Button();
            this.player1Souls = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(220, 22);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(350, 35);
            this.dateTimePicker1.TabIndex = 0;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // PlayerName1
            // 
            this.PlayerName1.AccessibleName = "Player1Name";
            this.PlayerName1.Location = new System.Drawing.Point(43, 83);
            this.PlayerName1.Name = "PlayerName1";
            this.PlayerName1.Size = new System.Drawing.Size(177, 35);
            this.PlayerName1.TabIndex = 1;
            this.PlayerName1.Text = "\r\n";
            this.PlayerName1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // CharacterName1
            // 
            this.CharacterName1.Location = new System.Drawing.Point(256, 83);
            this.CharacterName1.Name = "CharacterName1";
            this.CharacterName1.Size = new System.Drawing.Size(177, 35);
            this.CharacterName1.TabIndex = 2;
            // 
            // CharacterName2
            // 
            this.CharacterName2.Location = new System.Drawing.Point(256, 155);
            this.CharacterName2.Name = "CharacterName2";
            this.CharacterName2.Size = new System.Drawing.Size(177, 35);
            this.CharacterName2.TabIndex = 4;
            // 
            // PlayerName2
            // 
            this.PlayerName2.Location = new System.Drawing.Point(43, 155);
            this.PlayerName2.Name = "PlayerName2";
            this.PlayerName2.Size = new System.Drawing.Size(177, 35);
            this.PlayerName2.TabIndex = 3;
            // 
            // CharacterName4
            // 
            this.CharacterName4.Location = new System.Drawing.Point(256, 298);
            this.CharacterName4.Name = "CharacterName4";
            this.CharacterName4.Size = new System.Drawing.Size(177, 35);
            this.CharacterName4.TabIndex = 8;
            // 
            // PlayerName4
            // 
            this.PlayerName4.Location = new System.Drawing.Point(43, 298);
            this.PlayerName4.Name = "PlayerName4";
            this.PlayerName4.Size = new System.Drawing.Size(177, 35);
            this.PlayerName4.TabIndex = 7;
            // 
            // CharacterName3
            // 
            this.CharacterName3.Location = new System.Drawing.Point(256, 226);
            this.CharacterName3.Name = "CharacterName3";
            this.CharacterName3.Size = new System.Drawing.Size(177, 35);
            this.CharacterName3.TabIndex = 6;
            // 
            // PlayerName3
            // 
            this.PlayerName3.Location = new System.Drawing.Point(43, 226);
            this.PlayerName3.Name = "PlayerName3";
            this.PlayerName3.Size = new System.Drawing.Size(177, 35);
            this.PlayerName3.TabIndex = 5;
            // 
            // SaveGameDataButton
            // 
            this.SaveGameDataButton.Location = new System.Drawing.Point(282, 382);
            this.SaveGameDataButton.Name = "SaveGameDataButton";
            this.SaveGameDataButton.Size = new System.Drawing.Size(208, 40);
            this.SaveGameDataButton.TabIndex = 9;
            this.SaveGameDataButton.Text = "Save Game Data";
            this.SaveGameDataButton.UseVisualStyleBackColor = true;
            this.SaveGameDataButton.Click += new System.EventHandler(this.SaveGameDataButton_Click);
            // 
            // player1Souls
            // 
            this.player1Souls.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.player1Souls.FormattingEnabled = true;
            this.player1Souls.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4"});
            this.player1Souls.Location = new System.Drawing.Point(519, 83);
            this.player1Souls.Name = "player1Souls";
            this.player1Souls.Size = new System.Drawing.Size(212, 38);
            this.player1Souls.TabIndex = 10;
            this.player1Souls.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.player1Souls);
            this.Controls.Add(this.SaveGameDataButton);
            this.Controls.Add(this.CharacterName4);
            this.Controls.Add(this.PlayerName4);
            this.Controls.Add(this.CharacterName3);
            this.Controls.Add(this.PlayerName3);
            this.Controls.Add(this.CharacterName2);
            this.Controls.Add(this.PlayerName2);
            this.Controls.Add(this.CharacterName1);
            this.Controls.Add(this.PlayerName1);
            this.Controls.Add(this.dateTimePicker1);
            this.Name = "Form1";
            this.Text = "Game Analyzer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox PlayerName1;
        private System.Windows.Forms.TextBox CharacterName1;
        private System.Windows.Forms.TextBox CharacterName2;
        private System.Windows.Forms.TextBox PlayerName2;
        private System.Windows.Forms.TextBox CharacterName4;
        private System.Windows.Forms.TextBox PlayerName4;
        private System.Windows.Forms.TextBox CharacterName3;
        private System.Windows.Forms.TextBox PlayerName3;
        private System.Windows.Forms.Button SaveGameDataButton;
        private System.Windows.Forms.ComboBox player1Souls;
    }
}