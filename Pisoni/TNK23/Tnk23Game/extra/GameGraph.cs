namespace Tnk23Game.extra
{
    /// <summary>
    /// The <c>GameGraph</c> class represents a graph specifically designed for the game environment.
    /// It extends the functionality of the underlying graph implementation by adding game-specific features.
    /// </summary>
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
