
namespace Tnk23Test.Common
{
    /// <summary>
    /// Unit tests for the <see cref="Directions"/> class.
    /// </summary>
    [TestClass]
    public class DirectionsTest
    {
        /// Tests the <see cref="Directions.GetValues"/> method.
        /// </summary>
        [TestMethod]
        public void TestGetValues()
        {
            var expected = new List<Directions> { Directions.East, Directions.North, Directions.South, Directions.West, Directions.None };
            var actual = DirectionsExtensions.GetValues();
            CollectionAssert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the <see cref="Directions.FromVector(Vector2D)"/> method.
        /// </summary>
        [TestMethod]
        public void TestFromVector()
        {
            var vector = new Vector2D(0, -1);
            var expected = Directions.North;
            var actual = vector.FromVector();
            Assert.AreEqual(expected, actual);

            vector = new Vector2D(0, 1);
            expected = Directions.South;
            actual = vector.FromVector();
            Assert.AreEqual(expected, actual);

            vector = new Vector2D(-1, 0);
            expected = Directions.West;
            actual = vector.FromVector();
            Assert.AreEqual(expected, actual);

            vector = new Vector2D(1, 0);
            expected = Directions.East;
            actual = vector.FromVector();
            Assert.AreEqual(expected, actual);

            vector = new Vector2D(0, 0);
            expected = Directions.None;
            actual = vector.FromVector();
            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        /// Tests the <see cref="Directions.Flipped"/> method.
        /// </summary>
        [TestMethod]
        public void TestFlipped()
        {
            var expected = Directions.North;
            Assert.AreEqual(expected, Directions.South.Flipped());

            expected = Directions.South;
            Assert.AreEqual(expected, Directions.North.Flipped());

            expected = Directions.West;
            Assert.AreEqual(expected, Directions.East.Flipped());

            expected = Directions.East;
            Assert.AreEqual(expected, Directions.West.Flipped());

            expected = Directions.None;
            Assert.AreEqual(expected, Directions.None.Flipped());
        }

        /// <summary>
        /// Tests the <see cref="Directions.FromAngle"/> method.
        /// </summary>
        [TestMethod]
        public void TestFromAngle()
        {
            var expected = new List<Directions> { Directions.North, Directions.South, Directions.East, Directions.West };

            var actual = new List<int> { 0, 180, 90, -90 };

            CollectionAssert.AreEqual(expected, actual.ConvertAll(DirectionsExtensions.FromAngle));
        }
    }
}
