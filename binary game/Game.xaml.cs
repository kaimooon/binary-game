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
        int _calc = 0;
        int _sec = 0;

        private int randomNumber;
        private int score;
        private int timerInterval;
        private int currentBinaryValue;
        private DispatcherTimer gameTimer;
        private string playerName;

        public Game(string playerName)
        {
            InitializeComponent();
            this.playerName = playerName;
            InitializeGame();
        }

        public void InitializeGame()
        {
            score = 0;
            timerInterval = 40; // Set the initial timer interval
            gameTimer = new DispatcherTimer();
            gameTimer.Tick += GameTimer_Tick;
            gameTimer.Interval = TimeSpan.FromSeconds(2); // Set the interval to 2 seconds
            gameTimer.Start();
            UpdateTimerLabel();
            GenerateRandomNumber();
        }

        private void GenerateRandomNumber()
        {
            Random rnd = new Random();
            randomNumber = rnd.Next(0, 256);
            given_num.Content = randomNumber.ToString();
            //ResetBinaryInputs();
        }

        //private void ResetBinaryInputs()
        //{
        //    currentBinaryValue = 0;
        //    // Resetting binary input text boxes and buttons
        //    _128_btn.Content = "0";
        //    _64_btn.Content = "0";
        //    _32_btn.Content = "0";
        //    _16_btn.Content = "0";
        //    _8_btn.Content = "0";
        //    _4_btn.Content = "0";
        //    _2_btn.Content = "0";
        //    _1_btn.Content = "0";
        //}

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            timerInterval--; // Decrease the timer interval by 1 second
            if (timerInterval <= 0)
            {
                EndGame();
            }
            else
            {
                UpdateTimerLabel();
            }
        }

        private void UpdateTimerLabel()
        {
            timer_label.Content = timerInterval.ToString();
        }

        private void EndGame()
        {
            gameTimer.Stop();
            UpdateLeaderboard();
            MessageBox.Show($"Game Over! Your score: {score}");
        }

        private void UpdateLeaderboard()
        {
            string playerName = "Player"; // You can add logic to get the player's name
            string filePath = "leaderboard.csv";
            string[] lines = File.ReadAllLines(filePath);
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                for (int i = 0; i < Math.Min(10, lines.Length); i++)
                {
                    writer.WriteLine(lines[i]);
                }
                writer.WriteLine($"{playerName},{score},{40 - timerInterval}");
            }
        }

        private void BinaryButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int value = int.Parse(button.Content.ToString());
            currentBinaryValue ^= value; // Toggle the bit value
            button.Content = currentBinaryValue == value ? "1" : "0";
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentBinaryValue == randomNumber)
            {
                score++;
                timerInterval -= 2; // Reduce time for next round
                if (timerInterval <= 20) // Cap the minimum interval
                    timerInterval = 20;
                gameTimer.Interval = TimeSpan.FromSeconds(timerInterval);
                GenerateRandomNumber(); // Generate a new random number
            }
            else
            {
                MessageBox.Show("Incorrect! Try again.");
            }
        }
    }
}