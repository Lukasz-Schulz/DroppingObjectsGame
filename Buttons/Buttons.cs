using System.Windows;
using System.Windows.Controls;

namespace Gra2WPF
{
        /// <summary>
        /// Its subclasses create and handle the buttons functions
        /// </summary>
        public abstract class Buttons
        {
            public MainWindow _Window { get; }
            public int Column { get; }//button localisation
            public int Row { get; }//button localisation
            public Button Btn { get; protected set; }

            public Buttons(MainWindow window, int column, int row)
            {
                _Window = window;
                Column = column;
                Row = row;
                Init();
            }

        /// <summary>
        /// Draws a button in specific row
        /// </summary>
            public abstract void Init();

        /// <summary>
        /// Raises an event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
            public abstract void Click(object sender, RoutedEventArgs e);
        }
    
}

