using System;
using System.Windows;
using System.Windows.Controls;

namespace Gra2WPF
{
    public partial class MainWindow
    {
        /// <summary>
        /// Class responsible for creating and handling a pause button
        /// </summary>
        public class PauseButton : Buttons
        {
            public bool IsPaused { get; set; } = false;//describes game state

            public PauseButton(MainWindow window, int column, int row) 
                : base(window, column, row)
            {
                _Window.PauseGame.Paused += OnPaused;//subscribes Pause method to an event
                _Window.PauseGame.UnPaused += OnUnPaused;//subscribes Resume method to an event
            }
            /// <summary>
            /// Creates and draws a new Pause button
            /// </summary>
            public override void Init()
            {
                Btn = new Button
                {
                    Content = "Pause",
                    Name = "btnPause"
                };
                Btn.Click += Click;
                Grid.SetColumn(Btn, Column);
                Grid.SetRow(Btn, Row);
                _Window.Board.Children.Add(Btn);
                Btn.IsEnabled = false;//blokuje przycisk do czasu odpalenia gry
            }

            /// <summary>
            /// Handles an event which is raised after the button is clicked
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            public override void Click(object sender, RoutedEventArgs e)//wywołuje odpowiednie wydarzenie w momencie przyciśnięcia Pause
            {
                if (IsPaused == false)
                {
                    _Window.PauseGame.Pause();
                    IsPaused = true;
                }
                else if (IsPaused == true)
                {
                    _Window.PauseGame.UnPause();
                    IsPaused = false;
                }
            }

            /// <summary>
            /// Handles an event which is run when the pause button is clicked
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="args"></param>
            private void OnPaused(object sender, EventArgs args)//metoda wywoływana przez przycisk Pause, 
            {
                try
                {
                    _Window.Timer.Stop();
                    Btn.Content = "Resume";
                }
                catch { }
            }

            /// <summary>
            /// Handles an event which is run when the  resume button is clicked
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="args"></param>
            private void OnUnPaused(object sender, EventArgs args)//metoda wywoływana przez przycisk Pause, 
            {
                _Window.Timer.Start();
                Btn.Content = "Pause";
            }
        }
    }
}

