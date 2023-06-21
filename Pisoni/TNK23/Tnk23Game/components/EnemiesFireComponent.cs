using Tnk23Game.extra;

namespace Tnk23Game.Components
{
    ///<summary>
    /// A component representing the firing behavior of enemies.
    /// The EnemiesFireComponent handles the firing logic based on a fixed time interval for enemies GameObject.
    ///</summary>
    public class EnemiesFireComponent : AbstractFireComponent
    {
        private int _currentFrame;
        private const int SHOOT_PERIOD = 2 * Configuration.FPS;

        ///<summary>
        /// Constructs a new EnemiesFireComponent with the specified entity and world.
        ///</summary>
        ///<param name="entity">The GameObject associated with this fire component.</param>
        ///<param name="world">The World in which the enemy fire component exists.</param>
        public EnemiesFireComponent(IGameObject entity, IWorld world) : base(entity, world)
        {
        }

        ///<summary>
        /// Overrides the update method of the base class.
        /// Increases the current frame count and calls the superclass update method.
        ///</summary>
        public override void Update()
        {
            _currentFrame = this.GetCurrentFrame();
            base.Update();
        }

        ///<summary>
        /// Determines whether the entity can shoot based on the current frame count.
        ///</summary>
        ///<returns>True if the entity can shoot, false otherwise.</returns>
        protected override bool CanShoot()
        {
            return _currentFrame >= SHOOT_PERIOD;
        }
    }
}
