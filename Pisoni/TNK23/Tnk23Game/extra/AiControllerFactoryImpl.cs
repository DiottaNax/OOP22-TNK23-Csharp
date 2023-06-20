namespace Tnk23Game.extra
{
    public class AiControllerFactoryImpl : AiControllerFactory
    {
        private readonly GameGraph _graph;
        private readonly IWorld _world;

        public AiControllerFactoryImpl(GameGraph graph, IWorld world)
        {
            _graph = graph;
            _world = world;
        }

        public InputController GetFollowMovingTargetAi(IGameObject enemy, IGameObject gameObject)
            => throw new NotImplementedException();

        public InputController GetRandomAi() => throw new NotImplementedException();
        
        InputController AiControllerFactory.GetFollowTowerAi(IGameObject enemy)
             => throw new NotImplementedException();
    }
}
