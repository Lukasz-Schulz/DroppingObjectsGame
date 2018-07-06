using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Gra2WPF
{
    /// <summary>
    /// Abstract factory for creating falling objects
    /// </summary>
    public abstract class ObjectFactory 
    {
        public ObjectFactory()//automatycznie dodaje nowo powstającą fabrykę na listę
        {
            AddToFactoryList();
        }
        public int VelocitySettings { get; set; } = 500;//przechowuje domyślną, a następnie ustawioną prędkość spadania obiektów;
        Random rand = new Random();
        public abstract FallingObject GetObject(MainWindow window);

        /// <summary>
        /// Automaticly adds new factory to the singleton AvailableFactoryList.
        /// </summary>
        public void AddToFactoryList()//automatycznie dodaje każdą nowo powstającą fabrykę na listę
        {
            AvailableFactoryList.Instance.AddToList(this);
        }

        /// <summary>
        /// Draws a color for the falling object
        /// </summary>
        /// <returns></returns>
        protected Brush Color() //losuje kolor dla obiektu
        {
            switch (rand.Next(0, 3))
            {
                case 0:
                    return Brushes.Yellow;
                case 1:
                    return Brushes.Green;
                case 2:
                    return Brushes.Blue;
                default:
                    return Brushes.Red;
            }
        }
    }
}
