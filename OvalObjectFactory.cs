using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Gra2WPF
{
    /// <summary>
    /// Concrete factory returning oval falling objects.
    /// </summary>
    public class OvalObjectFactory : ObjectFactory//podfabryka zwracająca okrągłe obiekty
    {
        /// <summary>
        /// Returns a new oval falling object.
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        public override FallingObject GetObject(MainWindow window)
        {
            return new OvalObject(window,VelocitySettings,Color());
        }
    }
}
