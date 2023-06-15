namespace Tnk23Game.Graph
{
    /// <summary>
    /// The <c>VisitableNode</c> interface represents a node in a visitable graph.
    /// It provides methods to track the node's visited state, parent node, distance, and allows resetting of its state.
    /// </summary>
    /// <typeparam name="N">The type of the node.</typeparam>
    public interface IVisitableNode<N>
    {
        /// <summary>
        /// Retrieves the underlying node object.
        /// </summary>
        /// <returns>The underlying node object.</returns>
        N GetNode();

        /// <summary>
        /// Checks if the node has been visited.
        /// </summary>
        /// <returns><c>true</c> if the node has been visited, <c>false</c> otherwise.</returns>
        bool IsVisited();

        /// <summary>
        /// Sets the node as visited.
        /// </summary>
        void SetVisited();

        /// <summary>
        /// Retrieves the parent node of the current node.
        /// </summary>
        /// <returns>The parent node, or <c>null</c> if no parent is set.</returns>
        IVisitableNode<N>? GetParent();

        /// <summary>
        /// Sets the parent node of the current node.
        /// </summary>
        /// <param name="parent">The parent node to set.</param>
        void SetParent(IVisitableNode<N>? parent);

        /// <summary>
        /// Retrieves the distance of the node from the goal.
        /// </summary>
        /// <returns>The distance of the node from the goal or <c>-1</c> if not reachable.</returns>
        int GetDistance();

        /// <summary>
        /// Sets the distance of the node from the goal.
        /// </summary>
        /// <param name="distance">The distance to set.</param>
        void SetDistance(int distance);

        /// <summary>
        /// Resets the state of the node, clearing visited state, parent node, and distance.
        /// </summary>
        void Reset();
    }
}
