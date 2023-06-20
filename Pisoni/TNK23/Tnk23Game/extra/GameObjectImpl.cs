using Tnk23Game.Components;

namespace Tnk23Game.extra
{
    public class GameObjectImpl : IGameObject
    {
        private readonly String _type;
        private Point2D _position;
        public GameObjectImpl(String type, Point2D position)
        {
            _type = type;
            _position = new Point2D(position.X, position.Y);
        }
        public object Power { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public object Direction { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Point2D Position { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public void AddComponent(IComponent comp) =>  throw new NotImplementedException();
        public IComponent? GetComponent<T>() =>  throw new NotImplementedException();
        public Point2D GetPosition() => throw new NotImplementedException();
        public object GetPower() => throw new NotImplementedException();
        public int GetRotation() => throw new NotImplementedException();
        public void NotifyComponents<X>(IMessage<X> message, Type nc) where X : class 
                => throw new NotImplementedException();

    }
}
