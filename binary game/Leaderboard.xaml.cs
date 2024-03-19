using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Leaderboard.xaml
    /// </summary>
    public partial class Leaderboard : Window
    {
        
        public Leaderboard(string playerName)
        {
            InitializeComponent();
            LoadLeaderboard();
        }


        private void LoadLeaderboard()
        {
            // Load leaderboard from CSV file
            string filePath = "leaderboard.csv";

            if (File.Exists(filePath))
            {
                // Read all lines from the file
                string[] lines = File.ReadAllLines(filePath);

                // Sort the leaderboard by score (descending order)
                Array.Sort(lines, (x, y) =>
                {
                    int scoreX = int.Parse(x.Split(',')[1]);
                    int scoreY = int.Parse(y.Split(',')[1]);
                    return scoreY.CompareTo(scoreX);
                });

                // Populate leaderboardListBox_Name, leaderboardListBox_Score, and leaderboardListBox_PlayTime
                leaderboardListBox_Name.ItemsSource = lines.Select(line => line.Split(',')[0]).Take(10);
                leaderboardListBox_Score.ItemsSource = lines.Select(line => line.Split(',')[1]).Take(10);
                leaderboardListBox_PlayTime.ItemsSource = lines.Select(line => line.Split(',')[2]).Take(10);
            }
            else
            {
                MessageBox.Show("Leaderboard file not found.");
            }
        }
    }
}