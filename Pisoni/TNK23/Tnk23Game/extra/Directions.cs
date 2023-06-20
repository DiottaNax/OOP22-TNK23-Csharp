namespace Tnk23Game.extra
{
    public enum Directions
    {
        NORTH,
        SOUTH,
        WEST,
        EAST,
        NONE
    }

    public static class DirectionsExtensions
    {
        public static Vector2D GetVel(this Directions direction)
        {
            switch (direction)
            {
                case Directions.NORTH:
                    return new Vector2D(0, -1);
                case Directions.SOUTH:
                    return new Vector2D(0, 1);
                case Directions.WEST:
                    return new Vector2D(-1, 0);
                case Directions.EAST:
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
                    return Directions.NORTH;
                case eastAngle:
                    return Directions.EAST;
                case westAngle:
                    return Directions.WEST;
                case southAngle:
                    return Directions.SOUTH;
                default:
                    return Directions.NONE;
            }
        }
    }
}
