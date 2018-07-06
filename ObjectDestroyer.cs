using System;

namespace Gra2WPF
{
    /// <summary>
    /// an event called when objects are supposed to move
    /// </summary>
    public class ObjectDestroyer
    {
        public event EventHandler<EventArgs> Destroyed;

        /// <summary>
        /// Calls Destroyed event
        /// </summary>
        public void Destroy()
        {
            OnDestroyed();
        }

        /// <summary>
        /// Raises the Destroyed event
        /// </summary>
        protected virtual void OnDestroyed()
        {
            if (Destroyed != null)
            {
                Destroyed(this, new EventArgs());
            }
        }
    }
}
