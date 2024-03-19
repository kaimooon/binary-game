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

namespace binary_game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string playerName;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void start_btn_Click(object sender, RoutedEventArgs e)
        {
            // Open the Name window
            Name nameWindow = new Name();
            nameWindow.PlayerNameSubmitted += NameWindow_PlayerNameSubmitted;
            nameWindow.ShowDialog();
            start_btn.IsEnabled = false;
        }

        private void NameWindow_PlayerNameSubmitted(object sender, string playerName)
        {
            this.playerName = playerName; // Update playerName field
            // Initialize the game window and pass the player's name
            Game gameWindow = new Game(playerName);
            gameWindow.ShowDialog();
            // Initialize the game after the game window is shown
            gameWindow.InitializeGame();
        }

        private void ldb_btn_Click(object sender, RoutedEventArgs e)
        {
            // Open the leaderboard window and pass the player's name
            Leaderboard leaderboardWindow = new Leaderboard(playerName);
            leaderboardWindow.ShowDialog();
        }

        private void exit_btn_Click(object sender, RoutedEventArgs e)
        {
            // Close the application when the Exit button is clicked
            Application.Current.Shutdown();
        }
    }
}