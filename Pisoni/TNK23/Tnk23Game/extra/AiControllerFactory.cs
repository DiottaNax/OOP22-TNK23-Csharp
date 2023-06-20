namespace Tnk23Game.extra
{
    public interface AiControllerFactory
    {
        InputController GetFollowMovingTargetAi(IGameObject enemy, IGameObject gameObject);
        InputController GetFollowTowerAi(IGameObject enemy);
        InputController GetRandomAi();
    }
}
