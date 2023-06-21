using Tnk23Game.common;

namespace Tnk23Game.Input.Api
{
    /// <summary>
    /// The InputController interface represents an input controller that provides
    /// directional input.
    /// </summary>
    public interface InputController
    {
        /// <summary>
        /// Retrieves the direction input from the controller.
        /// </summary>
        /// <returns>The direction input.</returns>
        Directions GetDirection();
    }
}
