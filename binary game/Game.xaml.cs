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
using System.Windows.Threading;

namespace binary_game
{
    /// <summary>
    /// Interaction logic for Game.xaml
    /// </summary>
    public partial class Game : Window
    {
        int _1_add = 0;
        int _2_add = 0;
        int _4_add = 0;
        int _8_add = 0;
        int _16_add = 0;
        int _32_add = 0;
        int _64_add = 0;
        int _128_add = 0;

        
        int randomNumber;
        int score;
        int RoundCount = 1;
        int _sec = 0;

        DispatcherTimer gameTimer;
        string playerName;

        public Game(string playerName)
        {
            InitializeComponent();
            this.playerName = playerName;
            InitializeGame();
        }

        public void InitializeGame()
        {
            gameTimer = new DispatcherTimer();
            gameTimer.Tick += gameTimer_Tick;
            gameTimer.Interval = new TimeSpan(0, 0, 0, 1, 0);

            gameTimer.Start();
            GenerateRandomNumber();
        }

        private void GenerateRandomNumber()
        {
            Random rnd = new Random();
            randomNumber = rnd.Next(0, 256);
            given_num.Content = randomNumber.ToString();        
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            _sec = int.Parse(timer_label.Content.ToString());
            _sec--;

            if (_sec == 0)
            {
                gameTimer.Stop();
                MessageBox.Show("Times up!");
                _sec = 30;

                btn1.Text = "0";
                btn2.Text = "0";
                btn4.Text = "0";
                btn8.Text = "0";
                btn16.Text = "0";
                btn32.Text = "0";
                btn64.Text = "0";
                btn128.Text = "0";

                _1_add = 0;
                _2_add = 0;
                _4_add = 0;
                _8_add = 0;
                _16_add = 0;
                _32_add = 0;
                _64_add = 0;
                _128_add = 0;

                empty_cone_8.Source = new BitmapImage(new Uri("/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTExL3JtNjA0LWVsZW1lbnQtMDg3OC5wbmc-removebg-preview.png", UriKind.RelativeOrAbsolute));
                empty_cone_7.Source = new BitmapImage(new Uri("/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTExL3JtNjA0LWVsZW1lbnQtMDg3OC5wbmc-removebg-preview.png", UriKind.RelativeOrAbsolute));
                empty_cone_6.Source = new BitmapImage(new Uri("/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTExL3JtNjA0LWVsZW1lbnQtMDg3OC5wbmc-removebg-preview.png", UriKind.RelativeOrAbsolute));
                empty_cone_5.Source = new BitmapImage(new Uri("/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTExL3JtNjA0LWVsZW1lbnQtMDg3OC5wbmc-removebg-preview.png", UriKind.RelativeOrAbsolute));
                empty_cone_4.Source = new BitmapImage(new Uri("/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTExL3JtNjA0LWVsZW1lbnQtMDg3OC5wbmc-removebg-preview.png", UriKind.RelativeOrAbsolute));
                empty_cone_3.Source = new BitmapImage(new Uri("/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTExL3JtNjA0LWVsZW1lbnQtMDg3OC5wbmc-removebg-preview.png", UriKind.RelativeOrAbsolute));
                empty_cone_2.Source = new BitmapImage(new Uri("/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTExL3JtNjA0LWVsZW1lbnQtMDg3OC5wbmc-removebg-preview.png", UriKind.RelativeOrAbsolute));
                empty_cone.Source = new BitmapImage(new Uri("/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTExL3JtNjA0LWVsZW1lbnQtMDg3OC5wbmc-removebg-preview.png", UriKind.RelativeOrAbsolute));

                rounds_label.Content = RoundCount.ToString();
                score_label.Content = score.ToString();
                Close();
            }
            timer_label.Content = _sec.ToString();
        }

        private void EndGame()
        {
            gameTimer.Stop();
            UpdateLeaderboard();
            MessageBox.Show($"Game Over! Your score: {score}");
        }

        private void UpdateLeaderboard()
        {
            string filePath = "leaderboard.csv";
            string[] lines = File.ReadAllLines(filePath);

            List<string> leaderboardEntries = new List<string>();

            leaderboardEntries.AddRange(lines);

            // Calculate total play time in minutes and seconds
            int totalPlayTimeSeconds = (30 * (RoundCount - 1)) + (30 - _sec);
            int totalPlayTimeMinutes = totalPlayTimeSeconds / 60;
            int remainingSeconds = totalPlayTimeSeconds % 60;

            // Add the current player's name, score, and total play time to the leaderboard entries
            leaderboardEntries.Add($"{playerName},{score},{totalPlayTimeMinutes}m {remainingSeconds}s");

            leaderboardEntries.Add($"{playerName},{score},{(30 - _sec)}");


            File.WriteAllLines(filePath, leaderboardEntries);
        }


        private void _1_btn_Click(object sender, RoutedEventArgs e)
        {
            if (btn1.Text == "0")
            {
                empty_cone_8.Source = new BitmapImage(new Uri("/ice_cream-removebg-preview.png", UriKind.RelativeOrAbsolute));
                btn1.Text = "1";
                _1_add = 1;
            }
            else
            {
                empty_cone_8.Source = new BitmapImage(new Uri("/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTExL3JtNjA0LWVsZW1lbnQtMDg3OC5wbmc-removebg-preview.png", UriKind.RelativeOrAbsolute));
                btn1.Text = "0";
                _1_add = 0;
            }
        }
        private void _2_btn_Click(object sender, RoutedEventArgs e)
        {
            if (btn2.Text == "0")
            {
                empty_cone_7.Source = new BitmapImage(new Uri("/ice_cream-removebg-preview.png", UriKind.RelativeOrAbsolute));
                btn2.Text = "1";
                _2_add = 2;
            }
            else
            {
                empty_cone_7.Source = new BitmapImage(new Uri("/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTExL3JtNjA0LWVsZW1lbnQtMDg3OC5wbmc-removebg-preview.png", UriKind.RelativeOrAbsolute));
                btn2.Text = "0";
                _2_add = 0;
            }
        }

        private void _4_btn_Click(object sender, RoutedEventArgs e)
        {
            if (btn4.Text == "0")
            {
                empty_cone_6.Source = new BitmapImage(new Uri("/ice_cream-removebg-preview.png", UriKind.RelativeOrAbsolute));
                btn4.Text = "1";
                _4_add = 4;
            }
            else
            {
                empty_cone_6.Source = new BitmapImage(new Uri("/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTExL3JtNjA0LWVsZW1lbnQtMDg3OC5wbmc-removebg-preview.png", UriKind.RelativeOrAbsolute));
                btn4.Text = "0";
                _4_add = 0;
            }
        }

        private void _8_btn_Click(object sender, RoutedEventArgs e)
        {
            if (btn8.Text == "0")
            {
                empty_cone_5.Source = new BitmapImage(new Uri("/ice_cream-removebg-preview.png", UriKind.RelativeOrAbsolute));
                btn8.Text = "1";
                _8_add = 8;
            }
            else
            {
                empty_cone_5.Source = new BitmapImage(new Uri("/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTExL3JtNjA0LWVsZW1lbnQtMDg3OC5wbmc-removebg-preview.png", UriKind.RelativeOrAbsolute));
                btn8.Text = "0";
                _8_add = 0;
            }
        }

        private void _16_btn_Click(object sender, RoutedEventArgs e)
        {
            if (btn16.Text == "0")
            {
                empty_cone_4.Source = new BitmapImage(new Uri("/ice_cream-removebg-preview.png", UriKind.RelativeOrAbsolute));
                btn16.Text = "1";
                _16_add = 16;
            }
            else
            {
                empty_cone_4.Source = new BitmapImage(new Uri("/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTExL3JtNjA0LWVsZW1lbnQtMDg3OC5wbmc-removebg-preview.png", UriKind.RelativeOrAbsolute));
                btn16.Text = "0";
                _16_add = 0;
            }
        }

        private void _32_btn_Click(object sender, RoutedEventArgs e)
        {
            if (btn32.Text == "0")
            {
                empty_cone_3.Source = new BitmapImage(new Uri("/ice_cream-removebg-preview.png", UriKind.RelativeOrAbsolute));
                btn32.Text = "1";
                _32_add = 32;
            }
            else
            {
                empty_cone_3.Source = new BitmapImage(new Uri("/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTExL3JtNjA0LWVsZW1lbnQtMDg3OC5wbmc-removebg-preview.png", UriKind.RelativeOrAbsolute));
                btn32.Text = "0";
                _32_add = 0;
            }
        }

        private void _64_btn_Click(object sender, RoutedEventArgs e)
        {
            if (btn64.Text == "0")
            {
                empty_cone_2.Source = new BitmapImage(new Uri("/ice_cream-removebg-preview.png", UriKind.RelativeOrAbsolute));
                btn64.Text = "1";
                _64_add = 64;
            }
            else
            {
                empty_cone_2.Source = new BitmapImage(new Uri("/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTExL3JtNjA0LWVsZW1lbnQtMDg3OC5wbmc-removebg-preview.png", UriKind.RelativeOrAbsolute));
                btn64.Text = "0";
                _64_add = 0;
            }
        }

        private void _128_btn_Click(object sender, RoutedEventArgs e)
        {
            if (btn128.Text == "0")
            {
                empty_cone.Source = new BitmapImage(new Uri("/ice_cream-removebg-preview.png", UriKind.RelativeOrAbsolute));
                btn128.Text = "1";
                _128_add = 128;
            }
            else
            {
                empty_cone.Source = new BitmapImage(new Uri("/cHJpdmF0ZS9sci9pbWFnZXMvd2Vic2l0ZS8yMDIyLTExL3JtNjA0LWVsZW1lbnQtMDg3OC5wbmc-removebg-preview.png", UriKind.RelativeOrAbsolute));
                btn128.Text = "0";
                _128_add = 0;
            }
        }

        private void submit_btn_Click(object sender, RoutedEventArgs e)
        {
            int button_1 = _1_add;
            int button_2 = _2_add;
            int button_4 = _4_add;
            int button_8 = _8_add;
            int button_16 = _16_add;
            int button_32 = _32_add;
            int button_64 = _64_add;
            int button_128 = _128_add;
            int results = button_1 + button_2 + button_4 + button_8 + button_16 + button_32 + button_64 + button_128;

            if (results.ToString() == given_num.Content.ToString())
            {
                gameTimer.Stop();
                RoundCount++;
                rounds_label.Content = RoundCount.ToString();

                double minus = RoundCount * 0.066;
                int roundTimer = 30 - (int)(30 * minus);
                timer_label.Content = roundTimer.ToString();

                if (RoundCount >= 11)
                {
                    _sec = 10;
                    timer_label.Content = _sec.ToString();
                }

                MessageBox.Show("Correct");

                btn1.Text = "0";
                btn2.Text = "0";
                btn4.Text = "0";
                btn8.Text = "0";
                btn16.Text = "0";
                btn32.Text = "0";
                btn64.Text = "0";
                btn128.Text = "0";
                given_num.Content = "x";
                _1_add = 0;
                _2_add = 0;
                _4_add = 0;
                _8_add = 0;
                _16_add = 0;
                _32_add = 0;
                _64_add = 0;
                _128_add = 0;
                InitializeGame();

                score += 1;
                score_label.Content = score.ToString();
            }
            else
            {
                MessageBox.Show("Incorrect!");
                EndGame();
            }
        }
    }
}
