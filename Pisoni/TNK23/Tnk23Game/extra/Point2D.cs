namespace Tnk23Game.extra
{
    // This class is made to avoid errors in others classes
    public class Point2D
    {
        private double x;
        private double y;
        public Point2D(double x, double y)
        {
        }

        public double X
        {
            get { return x; }
            set { x = value; }
        }

        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        internal Point2D Sum(Vector2D vector2D) =>  throw new NotImplementedException();
    }
}
