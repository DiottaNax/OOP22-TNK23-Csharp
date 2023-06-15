namespace Tnk23Game.Graph
{
    /// <summary>
    /// An abstract implementation of the VisitableNode interface.
    /// </summary>
    /// <typeparam name="N">The type of the node.</typeparam>
    public abstract class AbstractVisitableNode<N> : IVisitableNode<N>
    {
        private readonly N _node;
        private bool _visited;
        private IVisitableNode<N>? _parent;
        private int _distance;

        /// <summary>
        /// Constructs an AbstractVisitableNode with the specified node.
        /// </summary>
        /// <param name="node">The node.</param>
        public AbstractVisitableNode(N node)
        {
            _node = node;
            _visited = false;
            _parent = null;
            _distance = -1;
        }

        /// <inheritdoc/>
        public N GetNode() => _node;

        /// <inheritdoc/>
        public bool IsVisited() => _visited;

        /// <inheritdoc/>
        public void SetVisited() => _visited = true;

        /// <inheritdoc/>
        public IVisitableNode<N>? GetParent() => _parent;

        /// <inheritdoc/>
        public void SetParent(IVisitableNode<N>? parent) => _parent = parent;

        /// <inheritdoc/>
        public int GetDistance() => _distance;

        /// <inheritdoc/>
        public void SetDistance(int distance) => _distance = distance;

        /// <inheritdoc/>
        public virtual void Reset()
        {
            _visited = false;
            _parent = null;
            _distance = -1;
        }

        /// <inheritdoc/>
        public override string ToString() => _node?.ToString() ?? string.Empty;
    }
}
