using Tnk23Game.Common;

namespace Tnk23Game.Input.Api
{
    /// <summary>
    /// The InputController interface represents an input controller that provides
    /// directional input.
    /// </summary>
    public interface IInputController
    {
        /// <summary>
        /// Retrieves the direction input from the controller.
        /// </summary>
        /// <returns>The direction input.</returns>
        Directions GetDirection();
    }
}
