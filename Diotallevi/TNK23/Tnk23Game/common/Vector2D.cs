using System;

namespace Tnk23Game.common
{
    /// <summary>
    /// Represents a two-dimensional vector.
    /// </summary>
    public class Vector2D
    {
        private double _x;
        private double _y;

        /// <summary>
        /// Constructs a new Vector2D object with the specified coordinates.
        /// </summary>
        /// <param name="_x">The _x-component of the vector.</param>
        /// <param name="_y">The _y-component of the vector.</param>
        public Vector2D(double x, double y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Gets or sets the _x-component of the vector.
        /// </summary>
        public double X
        {
            get => _x;
            set => _x = value;
        }

        /// <summary>
        /// Gets or sets the _y-component of the vector.
        /// </summary>
        public double Y
        {
            get => _y;
            set => _y = value;
        }

        /// <summary>
        /// Computes the sum of this vector and another vector.
        /// </summary>
        /// <param name="v">The vector to add.</param>
        /// <returns>A new Vector2D representing the sum of this vector and the other vector.</returns>
        public Vector2D Sum(Vector2D v) => new Vector2D(_x + v.X, _y + v.Y);

        /// <summary>
        /// Computes the magnitude (length) of the vector.
        /// </summary>
        /// <returns>The magnitude of the vector.</returns>
        public double Module() => Math.Sqrt(_x * _x + _y * _y);

        /// <summary>
        /// Computes the scalar multiplication of the vector with a constant value.
        /// </summary>
        /// <param name="mul">The scalar value to multipl_y the vector b_y.</param>
        /// <returns>A new Vector2D representing the scalar multiplication of the vector.</returns>
        public Vector2D Mul(double mul) => new Vector2D(_x * mul, _y * mul);

        /// <summary>
        /// Returns a string representation of the Vector2D object.
        /// </summary>
        /// <returns>A string representation of the Vector2D object.</returns>
        public override string ToString() => $"Vector2D [{_x}, {_y}]";

        /// <summary>
        /// Computes the hash code for the Vector2D object.
        /// </summary>
        /// <returns>The computed hash code.</returns>
        public override int GetHashCode() => HashCode.Combine(_x, _y);

        /// <summary>
        /// Checks if this Vector2D object is equal to another object.
        /// Two Vector2D objects are considered equal if their _x and _y components are equal.
        /// </summary>
        /// <param name="obj">The object to compare.</param>
        /// <returns>True if the objects are equal, false otherwise.</returns>
        public override bool Equals(object? obj) => obj is Vector2D v2d ? X.Equals(v2d.X) && Y.Equals(v2d.Y) : false;
    }
}
