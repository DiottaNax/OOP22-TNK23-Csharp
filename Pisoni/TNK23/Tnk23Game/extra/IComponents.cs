namespace Tnk23Game.extra
{
    // This interface is made to avoid errors in others classes
    public interface IComponent
    {
        bool IsCollidingWith(Rect2D s);
        void Update();
    }
}
