namespace Tnk23Game.extra
{
    // This class is made to avoid errors in others classes
    public interface AiControllerFactory
    {
        InputController GetFollowMovingTargetAi(IGameObject enemy, IGameObject gameObject);
        InputController GetFollowTowerAi(IGameObject enemy);
        InputController GetRandomAi();
    }
}
