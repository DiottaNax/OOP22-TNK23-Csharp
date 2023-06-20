namespace Tnk23Game.extra
{
    public class GameObjectFactoryImpl :  IGameObjectFactory
{
    private readonly IWorld _world;
    public GameObjectFactoryImpl(IWorld world)
    {
        _world = world;
    }
    public IGameObject GetBullet(Point2D pos)
    {
        var _bullet = new GameObjectImpl(GameObjectTypeManager.GetBulletType(), pos);
        return _bullet;
    }
}
}
