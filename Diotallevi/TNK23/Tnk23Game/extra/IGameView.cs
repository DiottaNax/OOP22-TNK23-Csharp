using Tnk23Game.Core;

namespace Tnk23Game.Extra
{
    /// <summary>
    /// The <see cref="IGameView"/> interface represents a view component of the game.
    /// It defines the methods for rendering the game view and set different game scenes.
    /// </summary>
    public interface IGameView
    {
        /// <summary>
        /// Renders the game view.
        /// </summary>
        void RenderView();

        /// <summary>
        /// Sets the menu scene.
        /// The menu should let the player decide game settings and start the game.
        /// </summary>
        void SetMenuScene();

        /// <summary>
        /// Sets the game scene.
        /// This scene should display the main gameplay area where the game takes place.
        /// </summary>
        void SetGameScene();

        /// <summary>
        /// Sets the game over scene.
        /// The game over scene should let the player decide whether to play another time or exit the game.
        /// </summary>
        void SetGameOverScene();

        /// <summary>
        /// Returns the game engine associated with the view.
        /// </summary>
        /// <returns>The game engine.</returns>
        IGameEngine GetGameEngine();
    }
}
