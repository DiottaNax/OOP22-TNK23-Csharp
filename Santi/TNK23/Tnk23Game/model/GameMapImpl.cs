using Tnk23Game.extra;
using Tnk23Game.common;

namespace Tnk23Game.model
{
    /// <summary>
    /// Implementation of the <see cref="IGameMap"/> interface representing a game map with walls and destructible walls.
    /// </summary>
    public class GameMapImpl : IGameMap
    {
        private readonly Stream _mapfile;
        private readonly HashSet<Point2D> _destroyableWalls;
        private readonly HashSet<Point2D> _walls;
        private const int _MAP_SIZE = Configuration.GRID_SIZE * 2;

        /// <summary>
        /// Constructs a GameMapImpl object with the provided map file.
        /// </summary>
        /// <param name="file">The stream of the map file.</param>
        public GameMapImpl(Stream file)
        {
            _mapfile = file;
            _walls = new HashSet<Point2D>();
            _destroyableWalls = new HashSet<Point2D>();
            GenerateWalls();
        }

        /// <summary>
        /// Gets the destructible walls of the map.
        /// </summary>
        /// <returns>The set of points corresponding to the destructible walls.</returns>
        public ISet<Point2D> GetDestroyableWalls() => new HashSet<Point2D>(_destroyableWalls);
        
        /// <summary>
        /// Gets the walls of the map.
        /// </summary>
        /// <returns>The set of points corresponding to the walls.</returns>
        public ISet<Point2D> GetWalls() => new HashSet<Point2D>(_walls);

        /// <summary>
        /// Generates the walls and destructible walls based on the provided map file.
        /// </summary>
        private void GenerateWalls()
        {
            using (StreamReader _mapReader = new StreamReader(_mapfile))
            {
                for (int l = 0; l < _MAP_SIZE; l++)
                {
                    string _line = _mapReader.ReadLine();
                    if (_line != null)
                    {
                        char[] _chars = _line.ToCharArray();
                        for (int c = 0; c < _MAP_SIZE; c++)
                        {
                            char _ch = _chars[c];
                            switch (_ch)
                            {
                                case 'D':
                                    _destroyableWalls.Add(new Point2D(c * Configuration.ORIGINAL_TILE_SIZE / 2.0, l * Configuration.ORIGINAL_TILE_SIZE / 2.0));
                                    break;
                                case 'U':
                                    _walls.Add(new Point2D(c * Configuration.ORIGINAL_TILE_SIZE / 2.0, l * Configuration.ORIGINAL_TILE_SIZE / 2.0));
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
