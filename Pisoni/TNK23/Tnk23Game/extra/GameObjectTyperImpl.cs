namespace Tnk23Game.extra
{
    public sealed class IGameObjectTypeImpl : IGameObjectType
    {
        private readonly long _width;
        private readonly long _height;
        private readonly double _speed;
        private readonly long _health;

        public IGameObjectTypeImpl(long width, long height, double speed, long health)
        {
            _width = width;
            _height = height;
            _speed = speed;
            _health = health;
        }
    }
}
