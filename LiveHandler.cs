using System.Windows;
using System.Windows.Controls;

namespace Gra2WPF
{
    /// <summary>
    /// Draws a label with points count.
    /// Holds responsibility for counting lives which are left.
    /// </summary>
    public class LiveHandler
    {
        public int LiveCount { get; protected set; } = 5;//default lives amount
        public MainWindow _MainWindow { get; }
        Label Lives;
        public int Column { get; }
        public int Row { get; }

        public LiveHandler(MainWindow window, int column, int row)
        {
            _MainWindow = window;
            Column = column;
            Row = row;
            Init();
        }

        /// <summary>
        /// Subtracts lives count whenever an object hits bottom of the board.
        /// </summary>
        public void LoseLife()//Metoda uruchamia się, kiedy spadający obiekt dociera do dołu ekranu.
        {
            {
                --LiveCount;
                Lives.Content = LiveCount;
                LoseGame();
            }
        }

        /// <summary>
        /// Checks if the lives count dropped below 1. If yes, it restarts a game.
        /// </summary>
        public void LoseGame()//Sprawdza, czy ilość żyć nie spadła poniżej 1, jeśli tak, otwiera okno w którym proponuje zamknięcie okna lub grę od nowa
        {
            if (LiveCount < 1)
            {
                _MainWindow.PauseGame.Pause();
                _MainWindow.Timer.Stop();
                var result = MessageBox.Show("You Lose!");
                if (result == MessageBoxResult.OK)
                {
                    new MainWindow().Show();
                    _MainWindow.Close();
                }
            }
        }
        /// <summary>
         /// Creates a label that holds number of lives.
         /// </summary>
        public void Init()
        {
            Lives = new Label
            {
                Content = $"Lives: {LiveCount}",
                Name = "lblLives"
            };

            Grid.SetColumn(Lives, Column);
            Grid.SetRow(Lives, Row);
            _MainWindow.Board.Children.Add(Lives);
        }
    }
}

