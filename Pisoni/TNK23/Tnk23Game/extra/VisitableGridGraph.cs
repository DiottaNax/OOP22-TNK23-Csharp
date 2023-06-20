namespace Tnk23Game.extra
{
    public abstract class  VisitableGridGraph : VisitableGraph<VisitableGridGraphNode>
    {
        private readonly int _gridSize;

        public VisitableGridGraph(int gridSize)
        {
            _gridSize = gridSize;
        }
    }
}