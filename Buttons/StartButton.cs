using System.Windows;
using System.Windows.Controls;

namespace Gra2WPF
{
    /// <summary>
    /// Handles creating and handling a Start button.
    /// </summary>
    public class StartButton : Buttons
    {
        public StartButton(MainWindow window, int column, int row) 
            : base(window, column, row)
        {
        }

        /// <summary>
        /// Makes button appear in defined spot.
        /// </summary>
        public override void Init()//inicjuje przycisk wstawiając go w odpowiednie miejsce na planszy
        {
            Btn = new Button();
            Btn.Content = "Start";
            Btn.Name = "btnStart";
            Btn.Click += Click;
            Grid.SetColumn(Btn, Column);
            Grid.SetRow(Btn, Row);
            _Window.Board.Children.Add(Btn);
        }

        /// <summary>
        /// Initiates all the movement on the board.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Click(object sender, RoutedEventArgs e)//wywołuje wydarzenie w momencie przyciśnięcia Start
        {
            _Window.InitTimer(_Window.AppearSpeed);
            Btn.IsEnabled = false;//blokuje przycisk start, żeby nie móc uruchomić gry kilkakrotnie
            Btn.IsEnabled = false;//blokuje przycisk settings na czas gry
            _Window._PauseButton.Btn.IsEnabled = true;//odblokowuje przycisk pauzy
        }
    }
}

