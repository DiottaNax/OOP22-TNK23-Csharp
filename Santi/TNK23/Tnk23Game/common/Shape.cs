namespace Tnk23Game.common
{
    /// <summary>
    /// Represents a two-dimensional shape.
    /// </summary>
    public interface Shape
    {
        /// <summary>
        /// Returns the width of the shape.
        /// </summary>
        /// <returns>The width of the shape.</returns>
        double GetWidth();

        /// <summary>
        /// Returns the height of the shape.
        /// </summary>
        /// <returns>The height of the shape.</returns>
        double GetHeight();

        /// <summary>
        /// Returns the position of the shape.
        /// </summary>
        /// <returns>The position of the shape.</returns>
        Point2D GetPos();

        /// <summary>
        /// Sets the position of the shape.
        /// </summary>
        /// <param name="newPos">The new position of the shape.</param>
        void SetPos(Point2D newPos);

        /// <summary>
        /// Checks if the shape is colliding with the provided shape.
        /// </summary>
        /// <param name="shape">The shape to check collision with.</param>
        /// <returns>True if the shape is colliding with the provided shape, false otherwise.</returns>
        bool IsColliding(Shape shape);
    }
}
