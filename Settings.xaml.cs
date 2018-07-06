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
using System.Windows.Shapes;

namespace Gra2WPF
{
    /// <summary>
    /// Window with tools allowing changes in some of the game properties.
    /// </summary>
    public partial class Settings : Window //okno ustawień
    {
        MainWindow MainWindow;
        ObjectFactory FirstFactory; // pole na fabrykę
        ObjectFactory SecondFactory; // pole na fabrykę
        ObjectFactory ThirdFactory; // pole na fabrykę

        int SelectedValue;//pole przechowujące wybraną wartość z suwaka

        /// <summary>
        /// Constructor taking three factories.
        /// </summary>
        /// <param name="mainWindow"></param>
        /// <param name="firstOF"></param>
        /// <param name="secondOF"></param>
        /// <param name="thirdOF"></param>
        public Settings(MainWindow mainWindow, ObjectFactory firstOF, ObjectFactory secondOF, ObjectFactory thirdOF)
            //konstruktor zakładający 3 fabryki
        {
            MainWindow = mainWindow;
            FirstFactory = firstOF;
            SecondFactory = secondOF;
            ThirdFactory = thirdOF;
            InitializeComponent();
        }

        /// <summary>
        /// Constructor taking two factories.
        /// </summary>
        /// <param name="mainWindow"></param>
        /// <param name="firstOF"></param>
        /// <param name="secondOF"></param>
        /// <param name="thirdOF"></param>
        public Settings(MainWindow mainWindow, ObjectFactory firstOF, ObjectFactory secondOF)//konstruktor zakładający 2 fabryki
        {
            MainWindow = mainWindow;
            FirstFactory = firstOF;
            SecondFactory = secondOF;
            InitializeComponent();
        }

        /// <summary>
        /// Constructor taking one factory.
        /// </summary>
        /// <param name="mainWindow"></param>
        /// <param name="firstOF"></param>
        /// <param name="secondOF"></param>
        /// <param name="thirdOF"></param>
        public Settings(MainWindow mainWindow, ObjectFactory firstOF)//konstruktor zakładający 1 fabrykę
        {
            MainWindow = mainWindow;
            FirstFactory = firstOF;
            InitializeComponent();
        }

        /// <summary>
        /// Sets the selected difficulty level, changing some of game properties.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
            //po naciśnięciu Confirm, zatwierdza się poziom trudności, 
            //a jego parametry wędrują do metody, która przekazuje je ich właściwościom
        {
            switch (SelectedValue)
            {
                case 1:
                    SetLevel(600, 700, 700, 450, 6);//hadrcoded properties
                    break;
                case 2:
                    SetLevel(500, 650, 700, 350, 5);
                    break;
                case 3:
                    SetLevel(450, 500, 550, 200, 4);
                    break;
                case 4:
                    SetLevel(400, 400, 450, 200, 3);
                    break;
                case 5:
                    SetLevel(150, 300, 250, 150, 2);
                    break;
            }
            Close();
        }

        /// <summary>
        /// Sets the label content to the slider value
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sliderDifficulty_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
            //ustawia SelectedValue na wartość z suwaka
        {
            SelectedValue = (int)sliderDifficulty.Value;
            try
            {
                lblDificulty.Content = SelectedValue;
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        /// <summary>
        /// Changes falling object factories' properties with new, based on chosen difficulty level.
        /// </summary>
        /// <param name="firstvelocity"></param>
        /// <param name="secondvelocity"></param>
        /// <param name="thirdvelocity"></param>
        /// <param name="appearspeed"></param>
        /// <param name="frequency"></param>
        private void SetLevel(int firstvelocity, int secondvelocity, int thirdvelocity, int appearspeed, int frequency)
            //dopasowuje nowe parametry fabrykom, zależnie od ich ilości
            //i zmienia domyślne parametry związane z częstotliwością produkcji
        {
            if (FirstFactory != null)
            {
                FirstFactory.VelocitySettings = firstvelocity;
            }
            if (SecondFactory != null)
            {
                SecondFactory.VelocitySettings = secondvelocity;
            }
            if (ThirdFactory != null)
            {
                ThirdFactory.VelocitySettings = thirdvelocity;
            }
            MainWindow.AppearSpeed = appearspeed;
            MainWindow.frequency = frequency;
        }
    }
}
