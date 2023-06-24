using Tnk23Game.Input.Api;
using Tnk23Game.Common;

namespace Tnk23Game.Input.Impl
{
    /// <summary>
    /// The PlayerOneKeyboardController class implements the KeyboardInputController interface
    /// and represents a keyboard controller for player one that provides directional input
    /// and shooting functionality.
    /// </summary>
    public class PlayerTwoKeyboardController : IKeyboardInputController
    {
        private Directions direction = Directions.NONE;
        private bool isShooting;

        /// <inheritdoc/>
        public Directions GetDirection()
        {
            return direction;
        }

        /// <inheritdoc/>
        public void SetOnKeyPressed(int e)
        {
            switch (e)
            {
                case 6:
                    direction = Directions.NORTH;
                    break;
                case 7:
                    direction = Directions.SOUTH;
                    break;
                case 8:
                    direction = Directions.WEST;
                    break;
                case 9:
                    direction = Directions.EAST;
                    break;
                case 0:
                    isShooting = true;
                    break;
                default:
                    break;
            }
        }

        /// <inheritdoc/>
        public void SetOnKeyReleased(int e)
        {
            switch (e)
            {
                case 6:
                case 7:
                case 8:
                case 9:
                    direction = Directions.NONE;
                    break;
                case 0:
                    isShooting = false;
                    break;
                default:
                    break;
            }
        }

        /// <inheritdoc/>
        public bool IsShooting()
        {
            return isShooting;
        }
    }
}
