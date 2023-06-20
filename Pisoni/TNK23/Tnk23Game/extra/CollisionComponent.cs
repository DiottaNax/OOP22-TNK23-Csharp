using Tnk23Game.Components;

namespace Tnk23Game.extra
{
    public class CollisionComponent : AbstractComponent
    {
        
        public CollisionComponent(IGameObject entity, IWorld world) : base(entity, world)
        {
        }

        public override void Update() => throw new NotImplementedException();
    }
}
