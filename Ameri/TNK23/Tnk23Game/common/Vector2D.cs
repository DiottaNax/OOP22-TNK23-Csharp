namespace Tnk23Game.Common
{
    // This class is made to avoid errors in others classes
    public class Vector2D
    {
        private double _x;
        private double _y;
        public Vector2D(double x, double y)
        {
            _x = x;
            _y = y;
        }
        public double X
        {
            get => _x;
            set => _x = value;
        }

        public double Y
        {
            get => _y;
            set => _y = value;
        }
        public Vector2D Mul(double mul) => new Vector2D(_x * mul, _y * mul);
    }
}