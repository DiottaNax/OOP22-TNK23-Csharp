namespace Tnk23Game.extra
{
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