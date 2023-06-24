using Tnk23Game.extra;
using Tnk23Game.common;

namespace Tnk23Game.model
{
    /// <summary>
    /// The GameMap interface represents a game map that provides information about the game's walls and destroyable walls.
    /// </summary>
    public interface IGameMap
    {
        /// <summary>
        /// Retrieves the set of destroyable walls in the game map.
        /// </summary>
        /// <returns>The set of destroyable walls as a set of Point2D coordinates.</returns>
        ISet<Point2D> GetDestroyableWalls();

        /// <summary>
        /// Retrieves the set of walls in the game map.
        /// </summary>
        /// <returns>The set of walls as a set of Point2D coordinates.</returns>
        ISet<Point2D> GetWalls();
    }
}
