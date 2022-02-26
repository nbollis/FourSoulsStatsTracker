using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FourSoulsStatsTracker;

namespace GUI
{
    public partial class Form1 : Form

    {
        GameDataPerPlayer player1 = new GameDataPerPlayer();
        GameDataPerPlayer player2 = new GameDataPerPlayer();
        GameDataPerPlayer player3 = new GameDataPerPlayer();
        GameDataPerPlayer player4 = new GameDataPerPlayer();

        public Form1()
        {
            InitializeComponent();
        }

        private void SaveGameDataButton_Click(object sender, EventArgs e)
        {
            player1.playerName = PlayerName1.Text;
            player2.playerName = PlayerName2.Text;
            player3.playerName = PlayerName3.Text;
            player4.playerName = PlayerName4.Text;

            player1.characterPlayed = CharacterName1.Text;
            player2.characterPlayed = CharacterName2.Text;
            player3.characterPlayed = CharacterName3.Text;
            player4.characterPlayed = CharacterName4.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            player1Souls.DataSource = new ComboItem[]
            {
                new ComboItem
            }
        }
    }
}
