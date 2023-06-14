

namespace Tnk23Test
{
    [TestClass]
    public class Vector2DTest
    {
        [TestMethod]
        public void TestConstructorAndGetters()
        {
            // Test the constructor and getters

            double x = 1.0;
            double y = 2.0;

            Vector2D vector = new Vector2D(x, y);

            // Assert that the getX and getY methods return the expected values
            Assert.AreEqual(x, vector.X);
            Assert.AreEqual(y, vector.Y);
        }

        [TestMethod]
        public void TestSetters()
        {
            // Test the setters

            double x = 1.0;
            double y = 2.0;

            Vector2D vector = new Vector2D(0, 0);

            // Set the x and y values using the setters
            vector.X = x;
            vector.Y = y;

            // Assert that the getX and getY methods return the expected values
            Assert.AreEqual(x, vector.X);
            Assert.AreEqual(y, vector.Y);
        }

        [TestMethod]
        public void TestSum()
        {
            double x = 4.0;
            double y = 6.0;

            Vector2D vector1 = new Vector2D(1.0, 2.0);
            Vector2D vector2 = new Vector2D(3.0, 4.0);

            // Compute the sum of vector1 and vector2
            Vector2D result = vector1.Sum(vector2);

            // Assert that the sum has the expected x and y values
            Assert.AreEqual(x, result.X);
            Assert.AreEqual(y, result.Y);
        }

        [TestMethod]
        public void TestModule()
        {
            double x = 5.0;

            Vector2D vector = new Vector2D(3.0, 4.0);

            // Compute the module of the vector
            double result = vector.Module();

            // Assert that the module has the expected value
            Assert.AreEqual(x, result);
        }

        [TestMethod]
        public void TestMul()
        {
            double x = 5.0;
            double y = 7.5;

            Vector2D vector = new Vector2D(2.0, 3.0);

            // Multiply the vector by a scalar value
            Vector2D result = vector.Mul(2.5);

            // Assert that the resulting vector has the expected x and y values
            Assert.AreEqual(x, result.X);
            Assert.AreEqual(y, result.Y);
        }

        [TestMethod]
        public void TestHashCode()
        {
            Vector2D vector1 = new Vector2D(1.0, 2.0);
            Vector2D vector2 = new Vector2D(1.0, 2.0);

            // Assert that the hash codes of vector1 and vector2 are equal
            Assert.AreEqual(vector1.GetHashCode(), vector2.GetHashCode());
        }

        [TestMethod]
        public void TestEquals()
        {
            Vector2D vector1 = new Vector2D(1.0, 2.0);
            Vector2D vector2 = new Vector2D(1.0, 2.0);
            Vector2D vector3 = new Vector2D(3.0, 4.0);

            // Assert that vector1 is equal to vector2 and not equal to vector3
            Assert.AreEqual(vector1, vector2);
            Assert.AreNotEqual(vector1, vector3);
        }
    }
}
