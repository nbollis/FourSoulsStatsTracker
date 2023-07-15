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

namespace FourSoulsGUI
{
    /// <summary>
    /// Interaction logic for TextResponseDialogWindow.xaml
    /// </summary>
    public partial class TextResponseDialogWindow : Window
    {
        public TextResponseDialogWindow()
        {
            InitializeComponent();
        }

        public string ResponseText
        {
            get => NameTextBox.Text;
            set => NameTextBox.Text = value;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {

            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NameTextBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            var textBox = e.OriginalSource as TextBox;
            if (textBox != null)
                textBox.SelectAll();
        }
    }
}
