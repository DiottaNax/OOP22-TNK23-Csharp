namespace Tnk23Game.Model.Api
{
    public interface IGameObjectType
    {
        /// <summary>
        /// Retrieves the width of the game object type.
        /// </summary>
        /// <returns>The width of the game object type.</returns>
        long GetWidth();

        /// <summary>
        /// Retrieves the height of the game object type.
        /// </summary>
        /// <returns>The height of the game object type.</returns>
        long GetHeight();

        /// <summary>
        /// Retrieves the speed of the game object type.
        /// </summary>
        /// <returns>The speed of the game object type.</returns>
        double GetSpeed();

        /// <summary>
        /// Retrieves the health of the game object type.
        /// </summary>
        /// <returns>The health of the game object type.</returns>
        long GetHealth();
    }
}
