using Tnk23Game.Model.Api;

namespace Tnk23Game.Components
{
    /// <summary>
    /// An abstract base class implementing the <see cref="IComponent"/> interface.
    /// It provides common functionality and fields for components.
    /// </summary>
    public abstract class AbstractComponent : IComponent
    {
        private readonly IGameObject entity;
        private readonly IWorld world;

        /// <summary>
        /// Constructs a new <see cref="AbstractComponent"/> with the specified entity and world.
        /// </summary>
        /// <param name="entity">The GameObject associated with this component.</param>
        /// <param name="world">The game World in which the component resides.</param>
        public AbstractComponent(IGameObject entity, IWorld world)
        {
            this.entity = entity;
            this.world = world;
        }

        /// <summary>
        /// Retrieves the GameObject associated with this instance.
        /// </summary>
        /// <returns>The GameObject associated with this instance.</returns>
        public IGameObject GetEntity()
        {
            return entity;
        }

        /// <summary>
        /// Retrieves the World instance associated with this instance.
        /// </summary>
        /// <returns>The World instance associated with this instance.</returns>
        public IWorld GetWorld()
        {
            return world;
        }

        /// <inheritdoc/>
        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
