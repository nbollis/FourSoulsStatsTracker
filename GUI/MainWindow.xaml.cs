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

        private void PopulateChoices(bool onlyPlayers = false)
        {
            if (!onlyPlayers)
            {
                // Populates the character names fields
                characterPlayed1.Items.Add("Character Played");
                characterPlayed2.Items.Add("Character Played");
                characterPlayed3.Items.Add("Character Played");
                characterPlayed4.Items.Add("Character Played");
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

                // Populates the Souls fields
                player1Souls.Items.Add("Souls");
                player2Souls.Items.Add("Souls");
                player3Souls.Items.Add("Souls");
                player4Souls.Items.Add("Souls");
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
            }
            // Populates the player name fields
            playerName1.Items.Add("Player Name");
            playerName2.Items.Add("Player Name");
            playerName3.Items.Add("Player Name");
            playerName4.Items.Add("Player Name");
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
            PopulateChoices(true);
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Engine.ReloadStats();
            Engine.SaveAllData();
            Close();
        }

        private void ClearPlayers_Click(object sender, RoutedEventArgs e)
        {
            playerName1.SelectedItem = playerName1.Items[0];
            playerName2.SelectedItem = playerName2.Items[0];
            playerName3.SelectedItem = playerName3.Items[0];
            playerName4.SelectedItem = playerName4.Items[0];
        }

        private void ClearCharacters_Click(object sender, RoutedEventArgs e)
        {
            characterPlayed1.SelectedItem = characterPlayed1.Items[0];
            characterPlayed2.SelectedItem = characterPlayed2.Items[0];
            characterPlayed3.SelectedItem = characterPlayed3.Items[0];
            characterPlayed4.SelectedItem = characterPlayed4.Items[0];
        }

        private void ClearSouls_Click(object sender, RoutedEventArgs e)
        {
            player1Souls.SelectedItem = player1Souls.Items[0];
            player2Souls.SelectedItem = player2Souls.Items[0];
            player3Souls.SelectedItem = player3Souls.Items[0];
            player4Souls.SelectedItem = player4Souls.Items[0];
        }

        private void RowDefinition_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine("Event Fired");
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
    }
}
