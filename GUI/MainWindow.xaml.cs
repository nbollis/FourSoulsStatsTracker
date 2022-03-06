using FourSoulsStatsTracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Engine.LoadAllData(); //likely in here temperarily
            PopulateChoices();
        }

        private void PopulateChoices()
        {
            // Populates the character names fields
            foreach (var character in Character.characterNames)
            {
                if (!characterPlayed1.Items.Contains(character))
                {
                    characterPlayed1.Items.Add(character);
                    characterPlayed2.Items.Add(character);
                    characterPlayed3.Items.Add(character);
                    characterPlayed4.Items.Add(character);
                }
            }

            // Populates the souls fields
            for (int i = 1; i < 5; i++)
            {
                if (!player1Souls.Items.Contains(i))
                {
                    player1Souls.Items.Add(i);
                    player2Souls.Items.Add(i);
                    player3Souls.Items.Add(i);
                    player4Souls.Items.Add(i);
                }
            }

            // Populates the player name fields
            foreach (var player in Player.AllPlayers)
            {
                if (!playerName1.Items.Contains(player.Name))
                {
                    playerName1.Items.Add(player.Name);
                    playerName2.Items.Add(player.Name);
                    playerName3.Items.Add(player.Name);
                    playerName4.Items.Add(player.Name);
                }
            }

        }

        private void SaveGameButton_Click(object sender, RoutedEventArgs e)
        {

            string gameData = playerName1.SelectedItem.ToString() + ":";
            gameData += characterPlayed1.SelectedItem.ToString() + ":";
            gameData += player1Souls.SelectedItem.ToString() + ":";
            gameData += playerName2.SelectedItem.ToString() + ":";
            gameData += characterPlayed2.SelectedItem.ToString() + ":";
            gameData += player2Souls.SelectedItem.ToString() + ":";

            if (characterPlayed3.SelectedItem != null)
            {
                gameData += playerName3.SelectedItem.ToString() + ":";
                gameData += characterPlayed3.SelectedItem.ToString() + ":";
                gameData += player3Souls.SelectedItem.ToString() + ":";
            }
            if (characterPlayed4.SelectedItem != null)
            {
                gameData += playerName4.SelectedItem.ToString() + ":";
                gameData += characterPlayed4.SelectedItem.ToString() + ":";
                gameData += player4Souls.SelectedItem.ToString() + ":";
            }


            Engine.ParseGame(gameData);
            MessageBox.Show("Game Saved");
            Engine.ReloadStats();
        }

        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            AddPlayer addPlayerWindow = new();
            addPlayerWindow.ShowDialog();
            PopulateChoices();
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Engine.ReloadStats();
            Engine.SaveAllData();
            Close();
        }
    }
}
