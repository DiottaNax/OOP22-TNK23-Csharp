namespace Tnk23Game.common
{
    /// <summary>
    /// Represents a two-dimensional rectangle in space.
    /// </summary>
    public class Rect2D : Shape
    {
        private readonly double _width;
        private readonly double _height;
        private Point2D _pos;

        /// <summary>
        /// Creates a new Rect2D object with the specified width, height, and position.
        /// </summary>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
        /// <param name="pos">The position of the rectangle.</param>
        public Rect2D(double width, double height, Point2D pos)
        {
            _width = width;
            _height = height;
            _pos = pos;
        }

        /// <summary>
        /// Returns the width of the rectangle.
        /// </summary>
        /// <returns>The width of the rectangle.</returns>
        public double GetWidth() => _width;

        /// <summary>
        /// Returns the height of the rectangle.
        /// </summary>
        /// <returns>The height of the rectangle.</returns>
        public double GetHeight() => _height;

        /// <summary>
        /// Returns the position of the rectangle.
        /// </summary>
        /// <returns>The position of the rectangle.</returns>
        public Point2D GetPos() => new Point2D(_pos.X, _pos.Y);

        /// <summary>
        /// Sets the position of the rectangle.
        /// </summary>
        /// <param name="newPos">The new position of the rectangle.</param>
        public void SetPos(Point2D newPos)
        {
            _pos = new Point2D(newPos.X, newPos.Y); // Preserve a defensive copy of the newPos object
        }

        /// <summary>
        /// Checks if the rectangle is colliding with the provided shape.
        /// </summary>
        /// <param name="shape">The shape to check collision with.</param>
        /// <returns>True if the rectangle is colliding with the provided shape, false otherwise.</returns>
        public bool IsColliding(Shape shape)
        {
            if (shape is Rect2D)
            {
                return this.Intersects((Rect2D)shape);
            }
            return false;
        }

        private bool Intersects(Rect2D rectangle)
        {
            return Math.Abs(_pos.X - rectangle.GetPos().X) <= (_width + rectangle.GetWidth()) / 2
                && Math.Abs(_pos.Y - rectangle.GetPos().Y) <= (_height + rectangle.GetHeight()) / 2;
        }
    }
}
