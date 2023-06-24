namespace Tnk23Game.Input.Api
{
    /// <summary>
    /// The KeyboardInputController interface extends the InputController interface
    /// and represents a keyboard input controller that provides directional input
    /// and shooting functionality.
    /// </summary>
    public interface IKeyboardInputController : IInputController
    {
        /// <summary>
        /// Checks if the game object is shooting.
        /// </summary>
        /// <returns>true if shooting action is triggered, false otherwise</returns>
        bool IsShooting();

        /// since the absence of a corrispondent C# type for javafx KeyEvent, this one has been changed into an int-type to avoid complications
        /// <summary>
        /// Sets the event handler for a key press event.
        /// </summary>
        /// <param name="e">The key press event handler</param>
        void SetOnKeyPressed(int e);

        /// since the absence of a corrispondent C# type for javafx KeyEvent, this one has been changed into an int-type to avoid complications
        /// <summary>
        /// Sets the event handler for a key release event.
        /// </summary>
        /// <param name="e">The key release event handler</param>
        void SetOnKeyReleased(int e);
    }
}
