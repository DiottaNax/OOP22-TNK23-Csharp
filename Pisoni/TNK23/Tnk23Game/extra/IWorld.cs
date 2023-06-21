using Tnk23Game.Events;

namespace Tnk23Game.extra
{
    // This interface is made to avoid errors in others classes
    public interface IWorld
    {
        void AddEntity(IGameObject obj);
        void RemoveEntity(IGameObject obj);
        void NotifyEvent(IWorldEvent we);
        List<IGameObject> GetPlayers();
        HashSet<IGameObject> GetEntities();

    }
}
