using Tnk23Game.Common;

namespace Tnk23Game.Graph
{
    public class VisitableGridGraphNode : AbstractVisitableNode<GridGraphNode>
    {
        private Directions _dirToParent;

        public VisitableGridGraphNode(Tuple<int, int> gridPos) : this(new GridGraphNode(gridPos))
        {
        }

        public VisitableGridGraphNode(GridGraphNode node) : base(node)
        {
            Reset();
            _dirToParent = Directions.None;
        }

        public Directions DirectionToParent
        {
            get => _dirToParent;
            set => _dirToParent = value;
        }

        /// <summary>
        /// <inheritdoc/>
        /// Plus sets direction to parent to None.
        /// </summary>
        public override void Reset()
        {
            base.Reset();
            _dirToParent = Directions.None;
        }

        /// <inheritdoc/>
        public override int GetHashCode() => 37 * base.GetNode().GetHashCode();

        /// <inheritdoc/>
        public override bool Equals(object? obj) => obj == null || GetType() != obj.GetType() ? false 
                : base.Equals(((VisitableGridGraphNode)obj).GetNode());
    }
}
