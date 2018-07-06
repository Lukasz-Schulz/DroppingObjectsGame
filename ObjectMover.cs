using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra2WPF
{
    /// <summary>
    /// Event called when objects are supposed to move
    /// </summary>
    public class ObjectMover
    {
        public event EventHandler<EventArgs> Moved;
        
        /// <summary>
        /// Calls the Moved method.
        /// </summary>
        public void MoveNow()
        {
            OnMoved();
        }

        /// <summary>
        /// Raises the Moved event.
        /// </summary>
        protected virtual void OnMoved()
        {
            if(Moved != null)
            {
                Moved(this, new EventArgs());
            }
        }
    }
}
