using Tnk23Game.extra;

namespace Tnk23Game.common
{
    /// <summary>
    /// Represents a two-dimensional point in space.
    /// </summary>
    public class Point2D
    {
        private double _x; // X coordinate of the point
        private double _y; // Y coordinate of the point
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Point2D"/> class with the specified coordinates.
        /// </summary>
        /// <param name="x">The X coordinate of the point.</param>
        /// <param name="y">The Y coordinate of the point.</param>
        public Point2D(double x, double y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Gets or sets the X coordinate of the point.
        /// </summary>
        public double X
        {
            get => _x;
            set => _x = value;
        }

        /// <summary>
        /// Gets or sets the Y coordinate of the point.
        /// </summary>
        public double Y
        {
            get => _y;
            set => _y = value;
        }

        /// <summary>
        /// Returns a new point obtained by adding a vector to the current point.
        /// </summary>
        /// <param name="v">The vector to add.</param>
        /// <returns>A new <see cref="Point2D"/> representing the sum of the current point and the vector.</returns>
        public Point2D Sum(Vector2D v) => new Point2D(_x + v.X, _y + v.Y);

        /// <summary>
        /// Returns a new point obtained by subtracting a vector from the current point.
        /// </summary>
        /// <param name="v">The vector to subtract.</param>
        /// <returns>A new <see cref="Point2D"/> representing the difference between the current point and the vector.</returns>
        public Point2D Sub(Vector2D v) => Sum(new Vector2D(-v.X, -v.Y));

        /// <summary>
        /// Returns a string representation of the point in the format "Point2D [x=<x coordinate>, y=<y coordinate>]".
        /// </summary>
        /// <returns>A string representation of the point.</returns>
        public override string ToString() => "Point2D [x=" + _x + ", y=" + _y + "]";

        /// <summary>
        /// Serves as a hash function for the point.
        /// </summary>
        /// <returns>A hash code for the current <see cref="Point2D"/> object.</returns>
        public override int GetHashCode() => HashCode.Combine(_x, _y);

        /// <summary>
        /// Determines whether the specified object is equal to the current point.
        /// </summary>
        /// <param name="obj">The object to compare with the current point.</param>
        /// <returns><c>true</c> if the specified object is equal to the current point; otherwise, <c>false</c>.</returns>
        public override bool Equals(object? obj) => obj is Point2D _p2d ? X.Equals(_p2d.X) && Y.Equals(_p2d.Y) : false;
    }
}
