namespace Tnk23Game.Events
{
    /// <summary>
    /// The WorldEventListener interface represents a listener for world events.
    /// </summary>
    public interface IWorldEventListener
    {
        /// <summary>
        /// Notifies the world about a world event.
        /// </summary>
        /// <param name="we">the world event to notify about</param>
        void NotifyEvent(IWorldEvent we);
    }
}
