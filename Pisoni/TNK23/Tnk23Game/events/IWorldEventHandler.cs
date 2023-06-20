namespace Tnk23Game.Events
{
    /// <summary>
    /// The WorldEventHandler interface represents a handler for processing world events.
    /// </summary>
    public interface IWorldEventHandler
    {
        /// <summary>
        /// Handles the given world event.
        /// </summary>
        /// <param name="we">the world event to handle</param>
        void Handle(IWorldEvent we);
    }
}
