using FourSoulsCore;
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
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for AddPlayer.xaml
    /// </summary>
    public partial class AddPlayer : Window
    {
        public event EventHandler OnAddPlayerClick;
        public AddPlayer()
        {
            InitializeComponent();
        }

        private void AddPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            string name = newPlayerName.Text;
            if (Player.AllPlayers.Any(p => p.Name.Equals(name)))
            {
                MessageBox.Show("Player already exists!");
            }
            else if (name.Equals("") || name.Equals(" "))
            {
                MessageBox.Show("Player's name cannot be empty!");
            }
            else
            {
                try
                {
                    var player = new Player(name);
                    Player.AddPlayer(player);
                    newPlayerName.Clear();
                }
                catch (Exception ea)
                {
                    Console.WriteLine(ea.Message);
                }
            }

            
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
