using Tnk23Game.extra;

namespace Tnk23Game.Components
{
    /// <summary>
    /// An abstract base class implementing the <see cref="IComponent"/> interface.
    /// It provides common functionality and fields for components.
    /// </summary>
    public abstract class AbstractComponent : IComponent
    {
        /// <summary>
        /// The GameObject associated with this component.
        /// </summary>
        private readonly IGameObject _entity;
        
        /// <summary>
        /// The game World in which the component exists.
        /// </summary>
        private readonly IWorld _world;

        /// <summary>
        /// Constructs a new <see cref="AbstractComponent"/> with the specified entity and world.
        /// </summary>
        /// <param name="entity">The GameObject associated with this component.</param>
        /// <param name="world">The game World in which the component resides.</param>
        public AbstractComponent(IGameObject entity, IWorld world)
        {
            _entity = entity ?? throw new ArgumentNullException(nameof(entity));
            _world = world ?? throw new ArgumentNullException(nameof(world));
        }

        /// <summary>
        /// Retrieves the GameObject associated with this instance.
        /// </summary>
        /// <returns>The GameObject associated with this instance.</returns>
        public IGameObject GetEntity() => _entity;

        /// <summary>
        /// Retrieves the World instance associated with this instance.
        /// </summary>
        /// <returns>The World instance associated with this instance.</returns>
        public IWorld GetWorld() => _world;
        public bool IsCollidingWith(Rect2D s) => throw new NotImplementedException();
        public abstract void Update();
    }
}
