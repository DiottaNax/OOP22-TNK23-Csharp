using Tnk23Game.extra;
using Tnk23Game.Events;

namespace Tnk23Game.Components
{
    /// <summary>
    /// An abstract base class for fire components.
    /// Fire components represent a component that handles shooting behavior.
    /// It provides common functionality and variables for fire components.
    /// </summary>
    public abstract class AbstractFireComponent : AbstractComponent
    {
        /// <summary>
        /// The current frame for shooting.
        /// </summary>
        private int currentFrame;

        /// <summary>
        /// Constructs a new <see cref="AbstractFireComponent"/> with the specified entity and world.
        /// </summary>
        /// <param name="entity">The <see cref="IGameObject"/> that owns this component.</param>
        /// <param name="world">The <see cref="IWorld"/> in which the component exists.</param>
        public AbstractFireComponent(IGameObject entity, IWorld world)
            : base(entity, world)
        {
            currentFrame = 0;
        }

        /// <inheritdoc/>
        public override void Update()
        {
            currentFrame++;
            if (CanShoot())
            {
                currentFrame = 0;
                this.GetWorld().NotifyEvent(
                    new WorldEventImpl(this.GetEntity().GetPosition(), this.GetEntity(), IWorldEventType.Shoot_event));
            }
        }

        /// <summary>
        /// Retrieves the current frame number.
        /// </summary>
        /// <returns>The current frame number.</returns>
        public int GetCurrentFrame()
        {
            return currentFrame;
        }

        /// <summary>
        /// Checks if the entity can shoot.
        /// </summary>
        /// <returns><c>true</c> if the entity can shoot, <c>false</c> otherwise.</returns>
        protected abstract bool CanShoot();
    }
}
