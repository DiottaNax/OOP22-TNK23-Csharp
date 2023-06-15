using Tnk23Game.Extra;

namespace Tnk23Game.Core
{
    /// <summary>
    /// The <see cref="IGameLoop"/> interface represents the main game loop for TNK23.
    /// It defines the methods for processing input, updating the game state, rendering the game,
    /// and obtaining the game engine instance.
    /// The interface extends the <see cref="WorldEventListener"/> interface, allowing it to receive and handle world events.
    /// </summary>
    public interface IGameLoop : IWorldEventListener
    {
        /// <summary>
        /// Retrieves the game engine associated with the game loop.
        /// </summary>
        /// <returns>the game engine.</returns>
        IGameEngine GameEngine { get; }

        /// <summary>
        /// Processes events for the game.
        /// This method should handle all the events passed to the game loop.
        /// </summary>
        void ProcessInput();

        /// <summary>
        /// Updates the game state.
        /// This method should update the game state based on user input, AI behavior, physics, etc.
        /// </summary>
        void Update();

        /// <summary>
        /// Renders the game.
        /// This method should render the game view based on the current game state.
        /// </summary>
        void Render();

        /// <summary>
        /// Starts the game loop.
        /// </summary>
        void RunGameLoop();
    }
}
