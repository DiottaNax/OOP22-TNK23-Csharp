namespace Tnk23Game.Graph
{
    public interface IGraph<N>
    {
        /// <summary>
        /// Retrieves a set of all nodes in the graph.
        /// </summary>
        /// <returns>A set of nodes.</returns>
        HashSet<N> GetNodes();

        /// <summary>
        /// Retrieves a set of adjacent nodes to the specified node.
        /// </summary>
        /// <param name="node">The node to get the adjacencies for.</param>
        /// <returns>A set of adjacent nodes.</returns>
        HashSet<N> GetAdjacencies(N node);

        /// <summary>
        /// Adds a node to the graph.
        /// </summary>
        /// <param name="node">The node to add.</param>
        /// <returns>The added node.</returns>
        N AddNode(N node);

        /// <summary>
        /// Removes a node from the graph.
        /// </summary>
        /// <param name="node">The node to remove.</param>
        void RemoveNode(N node);
    }
}
