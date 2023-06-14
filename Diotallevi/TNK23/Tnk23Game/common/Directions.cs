using System;

namespace Tnk23Game.common
{
    /// <summary>
    /// The <see cref="Directions"/> enum represents different directions in a two-dimensional space.
    /// Each direction is associated with a velocity vector represented by the <see cref="Vector2D"/> class.
    /// </summary>
    public enum Directions
    {
        /// <summary>
        /// The north direction (up).
        /// </summary>
        North,

        /// <summary>
        /// The south direction (down).
        /// </summary>
        South,

        /// <summary>
        /// The west direction (left).
        /// </summary>
        West,

        /// <summary>
        /// The east direction (right).
        /// </summary>
        East,

        /// <summary>
        /// No direction (stationary).
        /// </summary>
        None
    }

    /// <summary>
    /// Extension methods for the <see cref="Directions"/> enum.
    /// </summary>
    public static class DirectionsExtensions
    {
        /// <summary>
        /// Return a list containing all <see cref="Directions"/> values.
        /// </summary>
        /// <returns></returns> The list containing all directions.
        public static List<Directions> GetValues() =>
                new List<Directions>() { Directions.East, Directions.North, Directions.South, Directions.West, Directions.None };

        /// <summary>
        /// Retrieves the velocity vector associated with the direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns>The velocity vector of the direction.</returns>
        public static Vector2D GetVelocity(this Directions direction)
        {
            switch (direction)
            {
                case Directions.North:
                    return new Vector2D(0, -1);
                case Directions.South:
                    return new Vector2D(0, 1);
                case Directions.West:
                    return new Vector2D(-1, 0);
                case Directions.East:
                    return new Vector2D(1, 0);
                default:
                    return new Vector2D(0, 0);
            }
        }

        /// <summary>
        /// Converts a <see cref="Vector2D"/> object into the corresponding <see cref="Directions"/> enum value.
        /// If the provided vector does not match any predefined direction, <see cref="Directions.None"/> is returned.
        /// </summary>
        /// <param name="vector">The vector to convert into a direction.</param>
        /// <returns>The <see cref="Directions"/> enum value corresponding to the provided vector.</returns>
        public static Directions FromVector(this Vector2D vector)
        {
            if (vector.Equals(new Vector2D(0, -1)))
                return Directions.North;
            if (vector.Equals(new Vector2D(0, 1)))
                return Directions.South;
            if (vector.Equals(new Vector2D(-1, 0)))
                return Directions.West;
            if (vector.Equals(new Vector2D(1, 0)))
                return Directions.East;
            return Directions.None;
        }
        

        /// <summary>
        /// Returns the opposite direction of the current direction.
        /// </summary>
        /// <param name="direction">The direction.</param>
        /// <returns>The opposite direction of the current direction.</returns>
        public static Directions Flipped(this Directions direction)
        {
            foreach(var dir in GetValues())
            {
                if (direction.GetVelocity().Equals(dir.GetVelocity().Mul(-1)))
                    return dir;
            }

            return Directions.None;
        }

        /// <summary>
        /// Converts an angle (in degrees) into the corresponding <see cref="Directions"/> enum value.
        /// It maps specific angles to the predefined directions (0 degrees - <see cref="Directions.North"/>,
        /// 90 degrees - <see cref="Directions.East"/>, -90 degrees - <see cref="Directions.West"/>,
        /// 180 degrees - <see cref="Directions.South"/>).
        /// </summary>
        /// <param name="angle">The angle to convert into a direction.</param>
        /// <returns>The <see cref="Directions"/> enum value corresponding to the provided angle.</returns>
        public static Directions FromAngle(int angle)
        {
            switch (angle)
            {
                case 0:
                    return Directions.North;
                case 90:
                    return Directions.East;
                case -90:
                    return Directions.West;
                case 180:
                    return Directions.South;
                default:
                    return Directions.None;
            }
        }
    }
}
