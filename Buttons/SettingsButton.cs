using System.Windows;
using System.Windows.Controls;

namespace Gra2WPF
{
    /// <summary>
    /// Handles creating and handling a settings button.
    /// </summary>
    public class SettingsButton : Buttons
    {
        public SettingsButton(MainWindow window, int column, int row) 
            : base(window, column, row)
        {
        }

        /// <summary>
        /// Opens a new window where it is possible to change some properties by user. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Click(object sender, RoutedEventArgs e)
        {
            Settings settings = new Settings(_Window, _Window.OvalFactory, _Window.RectFactory);
            settings.Show();
        }

        /// <summary>
        /// Makes button appear in defined spot.
        /// </summary>
        public override void Init()
        {
            Btn = new Button
            {
                Content = "Settings",
                Name = "btnSettings"
            };
            Btn.Click += Click;
            Grid.SetColumn(Btn, Column);
            Grid.SetRow(Btn, Row);
            _Window.Board.Children.Add(Btn);
        }
    }
}

