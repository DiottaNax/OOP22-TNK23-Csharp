namespace Tnk23Game.extra
{
    // This class is made to avoid errors in others classes
    public class GameGraph : VisitableGraphDecorator<VisitableGridGraphNode>
    {
        private List<IGameObject> obstacles;
        public GameGraph(VisitableGridGraph toDecorate) : base(toDecorate)
        {
            obstacles = new List<IGameObject>();
        }
        public void Update()
        {
        }

    }
}
