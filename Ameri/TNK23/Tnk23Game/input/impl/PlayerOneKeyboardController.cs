using Tnk23Game.Input.Api;
using Tnk23Game.Common;

namespace Tnk23Game.Input.Impl
{
    /// <summary>
    /// The PlayerOneKeyboardController class implements the KeyboardInputController interface
    /// and represents a keyboard controller for player one that provides directional input
    /// and shooting functionality.
    /// </summary>
    public class PlayerOneKeyboardController : IKeyboardInputController
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
                case 1:
                    direction = Directions.NORTH;
                    break;
                case 2:
                    direction = Directions.SOUTH;
                    break;
                case 3:
                    direction = Directions.WEST;
                    break;
                case 4:
                    direction = Directions.EAST;
                    break;
                case 5:
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
                case 1:
                case 2:
                case 3:
                case 4:
                    direction = Directions.NONE;
                    break;
                case 5:
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
