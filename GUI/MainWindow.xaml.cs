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
            foreach (var character in Character.characterNames)
            {
                characterPlayed1.Items.Add(character);
                characterPlayed2.Items.Add(character);
                characterPlayed3.Items.Add(character);
                characterPlayed4.Items.Add(character);
            }

            for (int i = 1; i < 5; i++)
            {
                player1Souls.Items.Add(i);
                player2Souls.Items.Add(i);
                player3Souls.Items.Add(i);
                player4Souls.Items.Add(i);
            }

            foreach (var player in Player.GetPlayerList())
            {
                playerName1.Items.Add(player);
                playerName2.Items.Add(player);
                playerName3.Items.Add(player);
                playerName4.Items.Add(player);
            }

        }

        private void SaveGameButton_Click(object sender, RoutedEventArgs e)
        {
            Engine.ParseGame();
            Engine.ReloadStats();
        }
    }
}
