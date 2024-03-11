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
        private string filePath = "leaderboard.csv";
        public Leaderboard()
        {
            InitializeComponent();
            LoadLeaderboard();
        }

        private void LoadLeaderboard()
        {
            if (!File.Exists(filePath))
                return;

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                for (int i = 0; i < Math.Min(lines.Length, 10); i++)
                {
                    string[] parts = lines[i].Split(',');
                    if (parts.Length >= 3)
                    {
                        // Display the name, score, and play time in corresponding labels
                        switch (i)
                        {
                            case 0:
                                first_place.Content = parts[0];
                                first_place_score.Content = parts[1];
                                first_place_pt.Content = parts[2];
                                break;
                            case 1:
                                second_place.Content = parts[0];
                                second_place_score.Content = parts[1];
                                second_place_pt.Content = parts[2];
                                break;
                            case 2:
                                third_place.Content = parts[0];
                                third_place_score.Content = parts[1];
                                third_place_pt.Content = parts[2];
                                break;
                            case 3:
                                fourth_place.Content = parts[0];
                                fourth_place_score.Content = parts[1];
                                fourth_place_pt.Content = parts[2];
                                break;
                            case 4:
                                fifth_place.Content = parts[0];
                                fifth_place_score.Content = parts[1];
                                fifth_place_pt.Content = parts[2];
                                break;
                            case 5:
                                sixth_place.Content = parts[0];
                                sixth_place_score.Content = parts[1];
                                sixth_place_pt.Content = parts[2];
                                break;
                            case 6:
                                seventh_place.Content = parts[0];
                                seventh_place_score.Content = parts[1];
                                seventh_place_pt.Content = parts[2];
                                break;
                            case 7:
                                eighth_place.Content = parts[0];
                                eighth_place_score.Content = parts[1];
                                eighth_place_pt.Content = parts[2];
                                break;
                            case 8:
                                ninth_place.Content = parts[0];
                                ninth_place_score.Content = parts[1];
                                ninth_place_pt.Content = parts[2];
                                break;
                            case 9:
                                tenth_place.Content = parts[0];
                                tenth_place_score.Content = parts[1];
                                tenth_place_pt.Content = parts[2];
                                break;
                                
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading leaderboard: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}