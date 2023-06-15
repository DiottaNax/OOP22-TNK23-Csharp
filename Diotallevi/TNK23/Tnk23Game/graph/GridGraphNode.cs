namespace Tnk23Game.Graph
{
    /// <summary>
    /// The <see cref="GridGraphNode"/> class represents a node in a grid-based graph.
    /// </summary>
    public class GridGraphNode
    {
        private readonly Tuple<int, int> _gridPos;

        /// <summary>
        /// Constructs a new <see cref="GridGraphNode"/> with the specified grid position.
        /// </summary>
        /// <param name="gridPos">The grid position of the node.</param>
        public GridGraphNode(Tuple<int, int> gridPos) => _gridPos = gridPos;

        /// <summary>
        /// Retrieves the grid index of the node.
        /// </summary>
        /// <returns>The grid index of the node.</returns>
        public Tuple<int, int> GetGraphIndex() => _gridPos;

        /// <summary>
        /// Retrieves the list of adjacent grid indexes to the node.
        /// </summary>
        /// <returns>A list of adjacent grid indexes.</returns>
        public List<Tuple<int, int>> GetAdjacentIndexes()
        {
            return new List<Tuple<int, int>>
            {
                new Tuple<int, int>(_gridPos.Item1 + 1, _gridPos.Item2),
                new Tuple<int, int>(_gridPos.Item1, _gridPos.Item2 + 1),
                new Tuple<int, int>(_gridPos.Item1 - 1, _gridPos.Item2),
                new Tuple<int, int>(_gridPos.Item1, _gridPos.Item2 - 1)
            };
        }

        /// <summary>
        /// Checks if this node is equal to the specified object.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>True if the objects are equal, false otherwise.</returns>
        public override bool Equals(object? obj) => obj == null || GetType() != obj.GetType() ? false 
                : _gridPos.Equals(((GridGraphNode)obj)._gridPos);

        /// <summary>
        /// Computes the hash code of this node.
        /// </summary>
        /// <returns>The hash code of the node.</returns>
        public override int GetHashCode() => 17 * _gridPos.GetHashCode();

        /// <summary>
        /// Returns a string representation of the node.
        /// </summary>
        /// <returns>A string representation of the node.</returns>
        public override string ToString() => $"GridGraphNode [{_gridPos}]";
    }
}
