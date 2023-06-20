using Tnk23Game.extra;

namespace Tnk23Game.Components
{
    /// <summary>
    /// Represents a component for a bullet entity.
    /// Implements the <see cref="INotifiableComponent"/> interface for receiving messages.
    /// The BulletComponent handles the behavior of a bullet GameObject.
    /// </summary>
    public class BulletComponent : AbstractComponent, INotifiableComponent
    {
        private String _shooterType;

        /// <summary>
        /// Constructs a new BulletComponent with the specified entity and world.
        /// </summary>
        /// <param name="entity">The GameObject associated with this bullet component.</param>
        /// <param name="world">The World in which the bullet component exists.</param>
        public BulletComponent(IGameObject entity, IWorld world) : base(entity, world)
        {
            _shooterType = GameObjectTypeManager.GetBulletType();
        }

        /// <summary>
        /// This method is empty as the bullet component does not require specific update logic.
        /// </summary>
        public override void Update()
        {
        }

        /// <summary>
        /// Save in shooterType the type of the sender.
        /// </summary>
        /// <typeparam name="X"></typeparam>
        /// <param name="x"></param>
        public void Receive<X>(IMessage<X> x)
        {
            var _message = x.GetMessage();
            if (_message is IGameObject obj)
            {
                _shooterType = obj.GetType().ToString();
            }
        }

        /// <summary>
        /// Retrieves the type of the shooter that fired this bullet.
        /// </summary>
        /// <returns>The type of the shooter.</returns>
        public String GetShooter()
        {
            return _shooterType;
        }
    }
}
