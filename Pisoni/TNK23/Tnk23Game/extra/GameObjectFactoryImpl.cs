namespace Tnk23Game.extra
{
    // This class is made to avoid errors in others classes
    public class GameObjectFactoryImpl :  IGameObjectFactory
{
    private readonly IWorld _world;
    public GameObjectFactoryImpl(IWorld world)
    {
        _world = world;
    }
    public IGameObject GetEnemy(Point2D pos)
    {
        var enemy = new GameObjectImpl(GameObjectTypeManager.GetEnemyType(), pos);
        return enemy;
    }

    public IGameObject GetBullet(Point2D pos)
    {
        var _bullet = new GameObjectImpl(GameObjectTypeManager.GetBulletType(), pos);
        return _bullet;
    }
}
}
