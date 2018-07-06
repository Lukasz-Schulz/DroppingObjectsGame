using System.Windows;
using System.Windows.Controls;

namespace Gra2WPF
{
    /// <summary>
    /// Handles creating and handling a reset button.
    /// </summary>
    public class ResetButton : Buttons
    {
        public ResetButton(MainWindow window, int column, int row)
            : base(window, column, row) { }

        /// <summary>
        /// Closes current window and opens new window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            _Window.PauseGame.Pause();//pauses game to stop all the movement which would continue to happen after window is closed
            _Window.Close();
        }

        /// <summary>
        /// Makes button appear in defined spot.
        /// </summary>
        public override void Init()
        {
            Button btnReset = new Button();
            btnReset.Content = "Reset";
            btnReset.Name = "btnReset";
            btnReset.Click += Click;
            Grid.SetColumn(btnReset, Column);
            Grid.SetRow(btnReset, Row);
            _Window.Board.Children.Add(btnReset);
        }
    }
}

