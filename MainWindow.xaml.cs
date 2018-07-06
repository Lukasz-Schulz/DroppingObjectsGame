using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Gra2WPF
{
    /// <summary>
    /// The main window containing the grid which visualises all that happens in the game.
    /// </summary>
    public partial class MainWindow : Window
    {
        public RectangleObjectFactory RectFactory = new RectangleObjectFactory();//Factory produkujące nowe, kwadratowe obiekty
        public OvalObjectFactory OvalFactory = new OvalObjectFactory();//Factory produkujące nowe, okrągłe obiekty

        public ObjectMover MoveObjects = new ObjectMover();//klasa z wydarzeniem odpowiedzialnym za poruszenie obiektów po każdym Tick'u
        public ObjectDestroyer DestroyObject = new ObjectDestroyer();//klasa z wydarzeniem uruchamianym po kliknięciu
        public GamePauser PauseGame = new GamePauser();//klasa z wydarzeniem odpowiedzialnym gdy chcemy wstrzymać grę

        ObjectRandomizer _ObjectRandomizer;

        public DispatcherTimer Timer { get; set; }//timer odliczający czas między kolejnymi wydarzeniami
        public static readonly int SIZE = 30;//stała określająca rozmiar obiektów

        public int AppearSpeed { get; set; } = 200;//prędkość podejmowania próby tworzenia nowych obiektów (przerwy w próbach w milisekundach)
        public int frequency { get; set; } = 4;//prawdopodobieństwo wystąpienia nowego obiektu (im mniejsza liczba tym większe)
        public int Points { get; set; }//tu mieszkają punkty

        public Label lblPoints { get; set; }//tu wyświetlają się punkty
        public Label Lives { get; set; }//tu wyświetla się liczba żyć
        public LiveHandler _LiveHandler { get; set; }
        public PauseButton _PauseButton { get; set; }
        public StartButton _StartButton { get; set; }
        public SettingsButton _SettingsButton { get; set; }
        public ResetButton _ResetButton { get; set; }
        
        public MainWindow()
        {
            InitializeComponent();
            InitBoard();//ustala rozmiar grida na podstawie parametru SIZE i dodaje na planszę przyciski i etykiety
            _ObjectRandomizer = new ObjectRandomizer(this);
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        /// <summary>
        /// Makes falling objects visible on the board.
        /// </summary>
        /// <param name="ob"></param>
        public void Draw(FallingObject ob)
        {
            Grid.SetColumn(ob.shape, ob.PosX);
            Grid.SetRow(ob.shape, ob.PosY);
        }

        /// <summary>
        /// Sets the grid size and add buttons and labels on it.
        /// </summary>
        void InitBoard()
        {
            ColumnDefinition firstColumn = new ColumnDefinition();//pierwsza kolumna, w której znajdują się przyciski
            firstColumn.Width = new GridLength(90);
            Board.ColumnDefinitions.Add(firstColumn);

            for (int i = 0; i <= Board.Width / SIZE; i++)//ustala szerokość kolumn
            {
                ColumnDefinition column = new ColumnDefinition();
                column.Width = new GridLength(SIZE);
                Board.ColumnDefinitions.Add(column);
            }

            for (int i = 0; i <= Board.Height / SIZE; i++)//ustala wysokość rzędów
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(SIZE);
                Board.RowDefinitions.Add(row);
            }

            InitPointLabel();
            _ResetButton = new ResetButton(this, 0, 6);
            _SettingsButton = new SettingsButton(this, 0, 3);
            _StartButton = new StartButton(this, 0, 1);
            _LiveHandler = new LiveHandler(this, 0, 5);
            _PauseButton = new PauseButton(this, 0, 7);
        }

        /// <summary>
        /// Initiates a timer which call object randomizer to create new falling objects every tick.
        /// </summary>
        /// <param name="appearSpeed"></param>
        public void InitTimer(int appearSpeed)
        {
            Timer = new DispatcherTimer();
            Timer.Tick += new EventHandler(_ObjectRandomizer.BuildNewObject);
            Timer.Interval = new TimeSpan(0, 0, 0, 0, appearSpeed);//appearSpeed is defining frequency of creating new objects.
            Timer.Start();
        }

        /// <summary>
        /// Calls all the falling object to check if they are under the cursor and if they are,
        /// to proceed their destroy method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Mouse_Click(object sender, MouseButtonEventArgs e)//wywołuje wydarzenie w momencie wykrycia naciśnięcia lewego przycisku myszy pod warunkiem, że gra trwa
        {
            if(_PauseButton.IsPaused == false)
            {
                DestroyObject.Destroy();
            }
        }

        /// <summary>
        /// Initiates a point label which visualises number of points, and draws it on the board.
        /// </summary>
        void InitPointLabel()
        {
            lblPoints = new Label();
            lblPoints.Content = $"Points: {Points}";
            lblPoints.Name = "lblPoints";

            Grid.SetColumn(lblPoints, 0);
            Grid.SetRow(lblPoints, 4);
            Board.Children.Add(lblPoints);
        }            
        
        /// <summary>
        /// Adds specific amount of points when called.
        /// </summary>
        /// <param name="objectValue"></param>
        public void AddPoints(int objectValue)//metoda nabijająca punkty
        {
            Points += objectValue;
            lblPoints.Content=$"Points: {Points}";//wyświetla punkty po dodaniu
        }
    }
}

