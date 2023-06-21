using Tnk23Game.Components;

namespace Tnk23Game.extra
{
    // This class is made to avoid errors in others classes
    public class CollisionComponent : AbstractComponent
    {
        
        public CollisionComponent(IGameObject entity, IWorld world) : base(entity, world)
        {
        }

        public override void Update() => throw new NotImplementedException();
    }
}
