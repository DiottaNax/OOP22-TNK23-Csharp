using Tnk23Game.extra;


namespace Tnk23Game.Components.Impl
{
    /// <summary>
    /// A component representing the firing behavior of a player.
    /// Implements the <see cref="INotifiableComponent"/> interface for receiving messages.
    /// The PlayerFireComponent handles the firing logic based on a fixed time interval for the player GameObject.
    /// </summary>
    public class PlayerFireComponent : AbstractFireComponent, INotifiableComponent
    {
        private bool _canShoot;
        private int _currentFrame;
        private const int SHOOT_PERIOD = 1 * Configuration.FPS;

        /// <summary>
        /// Constructs a new <see cref="PlayerFireComponent"/> with the specified entity and world.
        /// </summary>
        /// <param name="entity">The GameObject associated with this fire component.</param>
        /// <param name="world">The World in which the player fire component exists.</param>
        public PlayerFireComponent(IGameObject entity, IWorld world)
            : base(entity, world)
        {
            _canShoot = false;
        }

        /// <summary>
        /// Receives a message and updates the value of the <see cref="canShoot"/> variable if the message contains a boolean value.
        /// </summary>
        /// <typeparam name="X">The type of the message.</typeparam>
        /// <param name="message">The message received.</param>
        public void Receive<X>(IMessage<X> message)
        {
            if (message.GetMessage() is bool)
            {
                _canShoot = message.GetMessage() as bool? ?? false;
            }
        }

        /// <summary>
        /// Updates the component's state.
        /// Increases the current frame count and calls the base class's update method.
        /// </summary>
        public override void Update()
        {
            _currentFrame = this.GetCurrentFrame();
            base.Update();
        }

        /// <summary>
        /// Determines whether the player can shoot based on the current frame count and the value of <see cref="canShoot"/>.
        /// </summary>
        /// <returns><c>true</c> if the player can shoot; otherwise, <c>false</c>.</returns>
        protected override bool CanShoot()
        {
            return _currentFrame >= SHOOT_PERIOD && _canShoot;
        }
    }
}
