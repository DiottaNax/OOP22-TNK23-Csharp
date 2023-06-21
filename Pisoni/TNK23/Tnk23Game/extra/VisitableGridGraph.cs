namespace Tnk23Game.extra
{
    // This class is made to avoid errors in others classes
    public abstract class  VisitableGridGraph : VisitableGraph<VisitableGridGraphNode>
    {
        private readonly int _gridSize;

        public VisitableGridGraph(int gridSize)
        {
            _gridSize = gridSize;
        }
    }
}