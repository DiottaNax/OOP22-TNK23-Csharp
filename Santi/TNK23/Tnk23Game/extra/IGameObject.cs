using Tnk23Game.common;

namespace Tnk23Game.extra
{
    // This interface is made to avoid errors in others classes
    public interface IGameObject
    {
        object Power { get; set; }
        object Direction { get; set; }
        Point2D Position { get; set; }
        IGameObjectType Type { get; set; }

        Point2D GetPosition();
        object GetPower();
        int GetRotation();
        void NotifyComponents<X>(IMessage<X> message, Type nc) where X : class;
        void AddComponent(IComponent comp);
        IComponent? GetComponent<T>();
    }
}
