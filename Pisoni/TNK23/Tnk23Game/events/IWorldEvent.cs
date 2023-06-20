using Tnk23Game.extra;

namespace Tnk23Game.Events
{
    /// <summary>
    /// The WorldEvent interface represents an event that occurs within the game world.
    /// </summary>
    public interface IWorldEvent
    {
        /// <summary>
        /// Retrieves the position associated with the event.
        /// </summary>
        /// <returns>The position of the event.</returns>
        Point2D GetPosition();

        /// <summary>
        /// Retrieves the game object that triggered the event.
        /// </summary>
        /// <returns>The game object associated with the event.</returns>
        IGameObject GetEventActor();

        /// <summary>
        /// Retrieves the type of the event.
        /// </summary>
        /// <returns>The type of the event.</returns>
        IWorldEventType GetType();
    }
}
