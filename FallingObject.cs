using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Gra2WPF
{
    /// <summary>
    /// Abstract class for objects falling in the main screen.
    /// It contains methods 
    /// </summary>
    public abstract class FallingObject//nadklasa abstrakcyjna dla obiektów
    {
        public Shape shape { get; set; }
        public int PosX { get; set; }//pozycja na osi x
        public int PosY { get; set; }//pozycja na osi y
        public abstract MainWindow Window { get; }
        public abstract int Velocity { get; set; }//tu mieszka prędkość (domyślna jest nadawana przez fabrykę)
        public Random rand = new Random();
        public DispatcherTimer _Timer = new DispatcherTimer();//timer odliczający czas do kolejnego ruchu
        public ObjectMover MoveObjects = new ObjectMover();//publikuje kolejne wydarzenie po upływie tick'a w w.w. timerze
        public int Value { get; set; }//wartość punktowa obiektu(domyślna nadawana przez fabrykę)

        /// <summary>
        /// Makes the object appear on the board and subscribes it to all the events that are 
        /// necessary for moving and reacting for mouse click.
        /// </summary>
        public void Appear()//wymusza nadpisanie metody pojawienia się obiektu na planszy
        {
            GetShape();

            Window.Board.Children.Add(shape);//dodaje obiekt na planszę
            Window.Draw(this);//rysuje obiekt na planszy
            Window.MoveObjects.Moved += this.OnMoved;//subskrybuje wydarzenie pojawienia się na ekranie
            Window.DestroyObject.Destroyed += OnDestroyed;//subskrybuje wydarzenie kliknięcia
            MoveObjects.Moved += OnMoved;//subskrybuje polecenie ruchu
            Window.PauseGame.Paused += OnPaused;//subskrybuje pauzę 
            Window.PauseGame.UnPaused += OnUnPaused;//subskrybuje wznowienie
            InitTimer();//uruchamia lokalny timer (ma własny, żeby móc wyróżniać się prędkością)
        }
        
        /// <summary>
        /// A method called by Moved method.
        /// It checks if the mouseclick localisation is the same as the object localisation.
        /// If true, it gets rid of the object.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void OnDestroyed(object source, EventArgs args)//metoda wywołana przez wydarzenie Moved - sprawdza, czy miejsce kliknięcia pokrywa się z obecnością obiektu
        {
            if ((int)(Mouse.GetPosition(shape).X / MainWindow.SIZE) == 0 && (int)(Mouse.GetPosition(shape).Y / MainWindow.SIZE) == 0)
            {
                Window.DestroyObject.Destroyed -= OnDestroyed;//obiekt przestaje reagować na klikanie
                Window.Board.Children.Remove(shape);//usuwa obiekt z planszy
                Window.AddPoints(Value);//zwraca właściwą ilość punktów do pola z punktami na głównym ekranie
                MoveObjects.Moved -= OnMoved;//przestaje się poruszać (mimo zdjęcia z tablicy szedłby dalej i docierał do dolnej krawędzi)
            }
        }

        /// <summary>
        /// A method called when object reaches the bottom edge of the board.
        /// It checks if the 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void OnMoved(object source, EventArgs args)
        {
            if(shape.Fill == Brushes.Red)//jeśli w poprzednim ruchu dotarł do krawędzi i zmienił kolor na czerwony, teraz znika i odbiera punkty życia
            {
                Window.Board.Children.Remove(shape);
                MoveObjects.Moved -= OnMoved;
                Window._LiveHandler.LoseLife();//odbiera punkty życia
            }
            if (PosY < Window.Board.Height / MainWindow.SIZE - 1)//sprawdza, czy obiekt znajduje się na krawędzi
            {
                PosY += 1;
                Window.Draw(this);
            }
            else if(PosY >= Window.Board.Height / MainWindow.SIZE - 1)//skoro obiekt jest na krawędzi, to zmienia jego kolor na czerwony
            {
                shape.Fill = Brushes.Red;
            }       
        }

        /// <summary>
        /// Runs dispatcher timer which causes move every tick.
        /// </summary>
        public void InitTimer()//uruchamia timer wywołujący ruch
        {
            _Timer.Tick += new EventHandler(move);
            _Timer.Interval = new TimeSpan(0, 0, 0, 0, Velocity);//velocity określa prędkość obiektu
            _Timer.Start();
        }

        /// <summary>
        /// An intermediary object passing an event.
        /// Without this intermediate, VS shuts down.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void move(object sender, EventArgs e)
        {
            MoveObjects.MoveNow();//przekazuje subskrybentom, żeby ruszyli dupy
        }
        
        /// <summary>
        /// Stops  the object movement.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void OnPaused(object source, EventArgs args)//zatrzymuje ruch na planszy po wciśnięciu Pause
        {
            _Timer.Tick -= move;
        }

        /// <summary>
        /// Resume yhe object movement.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="args"></param>
        public void OnUnPaused(object source, EventArgs args)//wznawia timer po wciśnięciu Resume
        {
            InitTimer();
        }
        public abstract Shape GetShape();
    }
}
