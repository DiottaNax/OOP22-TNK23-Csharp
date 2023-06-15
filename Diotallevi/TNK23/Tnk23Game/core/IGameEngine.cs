using Tnk23Game.Extra;

namespace Tnk23Game.Core
{
    /// <summary>
    /// The <see cref="IGameEnginee"/> interface represents the game engine responsible for managing the game state,
    /// updating the game world, and coordinating with the game view for rendering and user interaction.
    /// </summary>
    public interface IGameEngine
    {
        /// <summary>
        /// Retrieves the game view associated with the game engine.
        /// </summary>
        /// <returns>the game view.</returns>
        IGameView GameView { get; }

        /// <summary>
        /// Starts the game engine, initiating the game loop and updating the game world.
        /// </summary>
        void StartEngine();
    }
}