using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra2WPF
{
    /// <summary>
    /// Handles pausing and unpausing game
    /// </summary>
    public class GamePauser//klasa z wydarzeniami do pauzowania i wznawiania gry
    {
        public event EventHandler<EventArgs> Paused;
        public event EventHandler<EventArgs> UnPaused;

        /// <summary>
        /// Calls the Paused event.
        /// </summary>
        public void Pause()
        {
            OnPaused();
        }

        /// <summary>
        /// Calls the UnPaused event.
        /// </summary>
        public void UnPause()
        {
            OnUnPaused();
        }

        /// <summary>
        /// Raises the Paused event whenever called.
        /// </summary>
        protected virtual void OnPaused()
        {
            if (Paused != null)
            {
                Paused(this, new EventArgs());
            }
        }

        /// <summary>
        /// Raises the UnPaused event whenever called.
        /// </summary>
        protected virtual void OnUnPaused()
        {
            if (UnPaused != null)
            {
                UnPaused(this, new EventArgs());
            }
        }
    }
}
