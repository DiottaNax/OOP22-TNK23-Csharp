namespace Tnk23Game.extra
{
    public interface IComponent
    {
        bool IsCollidingWith(Rect2D s);
        void Update();
    }
}
