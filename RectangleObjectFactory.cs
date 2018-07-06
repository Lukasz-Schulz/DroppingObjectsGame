using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra2WPF
{
    /// <summary>
    /// Concrete factory returning oval falling objects.
    /// </summary>
    public class RectangleObjectFactory : ObjectFactory//podfabryka zwracająca kwadraty
    {
        /// <summary>
        /// Concrete factory returning oval falling objects.
        /// </summary>
        public override FallingObject GetObject(MainWindow window)
        {
            return new RectangleObject(window, VelocitySettings, Color());
        }
    }
}
