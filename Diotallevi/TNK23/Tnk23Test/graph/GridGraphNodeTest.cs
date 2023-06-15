
namespace Tnk23Test.Graph
{
    [TestClass]
    public class GridGraphNodeTests
    {
        [TestMethod]
        public void TestGetGraphIndex()
        {
            // Create a grid position pair (2, 3)
            var gridPos = new Tuple<int, int>(2, 3);

            // Create a GridGraphNode with the grid position
            var node = new GridGraphNode(gridPos);

            // Assert that the graph index is the same as the grid position
            Assert.AreEqual(gridPos, node.GetGraphIndex());
        }

        [TestMethod]
        public void TestGetAdjacentIndexes()
        {
            // Create a grid position pair (2, 3)
            var gridPos = new Tuple<int, int>(2, 3);

            // Create a GridGraphNode with the grid position
            var node = new GridGraphNode(gridPos);

            // Get the list of adjacent indexes
            var adjacentIndexes = node.GetAdjacentIndexes();

            // Assert that the list contains the correct adjacent indexes
            Assert.AreEqual(4, adjacentIndexes.Count);
            CollectionAssert.Contains(adjacentIndexes, new Tuple<int, int>(3, 3));
            CollectionAssert.Contains(adjacentIndexes, new Tuple<int, int>(2, 4));
            CollectionAssert.Contains(adjacentIndexes, new Tuple<int, int>(1, 3));
            CollectionAssert.Contains(adjacentIndexes, new Tuple<int, int>(2, 2));
        }

        [TestMethod]
        public void TestEqualsAndHashCode()
        {
            // Create two grid position pairs (2, 3)
            var gridPos1 = new Tuple<int, int>(2, 3);
            var gridPos2 = new Tuple<int, int>(2, 3);

            // Create two GridGraphNode objects with the same grid position
            var node1 = new GridGraphNode(gridPos1);
            var node2 = new GridGraphNode(gridPos2);

            // Assert that the nodes are equal and have the same hash code
            Assert.AreEqual(node1, node2);
            Assert.AreEqual(node1.GetHashCode(), node2.GetHashCode());
        }

        [TestMethod]
        public void TestNotEquals()
        {
            // Create two grid position pairs (2, 3) and (4, 5)
            var gridPos1 = new Tuple<int, int>(2, 3);
            var gridPos2 = new Tuple<int, int>(4, 5);

            // Create two GridGraphNode objects with different grid positions
            var node1 = new GridGraphNode(gridPos1);
            var node2 = new GridGraphNode(gridPos2);
            var node3 = new GridGraphNode(gridPos2);

            // Assert that the nodes are not equal and have different hash codes
            Assert.AreNotEqual(node1, node2);
            Assert.AreNotEqual(node1.GetHashCode(), node2.GetHashCode());
            Assert.AreEqual(node3, node2);
            Assert.AreEqual(node2.GetHashCode(), node3.GetHashCode());
        }
    }
}
