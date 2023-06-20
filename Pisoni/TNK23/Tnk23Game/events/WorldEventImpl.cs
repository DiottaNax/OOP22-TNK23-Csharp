using Tnk23Game.extra;

namespace Tnk23Game.Events
{
    /// <summary>
    /// Implementation of the <see cref="IWorldEvent"/> interface representing an event that occurs in the game world.
    /// </summary>
    public class WorldEventImpl : IWorldEvent
    {
        private readonly Point2D _position;
        private readonly IGameObject _actor;
        private readonly IWorldEventType _type;

        /// <summary>
        /// Constructs a new <see cref="WorldEventImpl"/> with the specified position, actor, and event type.
        /// </summary>
        /// <param name="position">The position associated with the event.</param>
        /// <param name="actor">The <see cref="IGameObject"/> associated with the event.</param>
        /// <param name="type">The <see cref="WorldEventType"/> representing the type of the event.</param>
        public WorldEventImpl(Point2D position, IGameObject actor, IWorldEventType type)
        {
            _position = new Point2D(position.X, position.Y);
            _actor = actor;
            _type = type;
        }

        /// <inheritdoc/>
        public Point2D GetPosition()
        {
            return new Point2D(_position.X, _position.Y);
        }

        /// <inheritdoc/>
        public IGameObject GetEventActor()
        {
            return _actor;
        }

        /// <inheritdoc/>
        public new IWorldEventType GetType() => _type;
    }
}
