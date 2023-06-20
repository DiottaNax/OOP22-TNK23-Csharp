namespace Tnk23Game.extra
{
    public interface IGameObject
    {
        object Power { get; set; }
        object Direction { get; set; }
        Point2D Position { get; set; }

        Point2D GetPosition();
        object GetPower();
        int GetRotation();
        void NotifyComponents<X>(IMessage<X> message, Type nc) where X : class;
    }
}
