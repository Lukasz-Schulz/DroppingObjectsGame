using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Gra2WPF
{
    /// <summary>
    /// Concrete, oval shaped falling object.
    /// </summary>
    class OvalObject : FallingObject
    {
        public override MainWindow Window { get; }
        public override int Velocity { get; set; } = 500;//domyślna prędkość obiektu
        public Brush Color { get; }//tu mieszka kolor

        public OvalObject(MainWindow mainWindow, int velocity, Brush color)//konstruktor, do którego parametry pochodzą z odpowiedniej podfabryki
        {
            Window = mainWindow;
            Velocity = velocity;
            Color = color;
            Value = 10;
        }

        /// <summary>
        /// Defines the objects shape, localisation and color
        /// </summary>
        /// <returns></returns>
        public override Shape GetShape()
        {
            shape = new Ellipse();//określa kształt obiektu
            PosX = rand.Next(1, (int)(Window.Board.Width / MainWindow.SIZE) - 2);//określa pozycję w której kształt się pojawia
            PosY = 1;
            shape.Fill = Color;//przekazuje kolor
            return shape;
        }
    }
}
