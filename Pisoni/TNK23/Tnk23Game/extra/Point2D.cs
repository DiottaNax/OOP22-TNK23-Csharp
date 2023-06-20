namespace Tnk23Game.extra
{
    /// <summary>
    /// Represents a point in a two-dimensional space.
    /// </summary>
    public class Point2D
    {
        private double x;
        private double y;
        public Point2D(double x, double y)
        {
        }
        public double GetX()
        {
            return x;
        }
        public double GetY()
        {
            return y;
        }

        internal Point2D Sum(Vector2D vector2D)
        {
            throw new NotImplementedException();
        }
    }
}
