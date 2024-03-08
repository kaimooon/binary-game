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

namespace binary_game
{
    /// <summary>
    /// Interaction logic for Name.xaml
    /// </summary>
    public partial class Name : Window
    {
        public event EventHandler<string> PlayerNameSubmitted;

        public Name()
        {
            InitializeComponent();
        }

        private void name_submit_Click(object sender, RoutedEventArgs e)
        {
            string playerName = name_input.Text;

            // Check if there are subscribers to the event
            if (PlayerNameSubmitted != null)
            {
                // Call the event handler method directly with the player's name
                PlayerNameSubmitted(sender, playerName);
            }

            // Close the Name window
            this.Close();
        }
    }
}
