using Tnk23Game.Events;

namespace Tnk23Game.extra
{
    public interface IWorld
    {
        void AddEntity(IGameObject obj);
        void RemoveEntity(IGameObject obj);
    }
}
