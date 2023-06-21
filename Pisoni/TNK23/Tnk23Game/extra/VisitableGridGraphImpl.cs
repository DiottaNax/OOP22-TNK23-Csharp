namespace Tnk23Game.extra
{
    // This class is made to avoid errors in others classes
    public class VisitableGridGraphImpl : VisitableGridGraph
    {
        private Dictionary<VisitableGridGraphNode, HashSet<VisitableGridGraphNode>> graph;
        private Dictionary<VisitableGridGraphNode, VisitableGridGraphNode> graphNodes;

        public VisitableGridGraphImpl(int gridSize) : base(gridSize)
        {
            graph = new Dictionary<VisitableGridGraphNode, HashSet<VisitableGridGraphNode>>();
            graphNodes = new Dictionary<VisitableGridGraphNode, VisitableGridGraphNode>();
        }

    }
}