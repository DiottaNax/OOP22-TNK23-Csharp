namespace Tnk23Game.extra
{
    /// <summary>
    /// Rappresenta un rettangolo bidimensionale nello spazio.
    /// </summary>
    public class Rect2D : Shape
    {
        private int _original_tile_size1;
        private int _original_tile_size2;
        private Point2D _point2D;
        public Rect2D(int original_tile_size1, int original_tile_size2, Point2D point2D)
        {
            _original_tile_size1 = original_tile_size1;
            _original_tile_size2 = original_tile_size2;
            _point2D = point2D;
        }

        public object? Pos { get; internal set; }
    }


}
