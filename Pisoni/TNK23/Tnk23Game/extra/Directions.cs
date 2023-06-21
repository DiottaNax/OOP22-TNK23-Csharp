namespace Tnk23Game.extra
{
    public enum Directions
    {
        North,
        South,
        West,
        East,
        None
    }

    public static class DirectionsExtensions
    {
        public static Vector2D GetVel(this Directions direction)
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
        public static Directions FromAngle(int angle)
        {
            const int northAngle = 0;
            const int southAngle = 180;
            const int eastAngle = 90;
            const int westAngle = -eastAngle;

            switch (angle)
            {
                case northAngle:
                    return Directions.North;
                case eastAngle:
                    return Directions.East;
                case westAngle:
                    return Directions.West;
                case southAngle:
                    return Directions.South;
                default:
                    return Directions.None;
            }
        }
    }
}
