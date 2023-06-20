namespace Tnk23Game.Model
{
    /// <summary>
    /// An interface representing a spawn mechanism in the game.
    /// The Spawn interface provides methods to start and update the spawning process.
    /// </summary>
    public interface ISpawn
    {
        /// <summary>
        /// Starts the spawning process.
        /// This method is called to initiate the spawning of new game objects.
        /// </summary>
        void StartSpawn();

        /// <summary>
        /// Updates the spawning process.
        /// This method is called to update the spawning logic.
        /// </summary>
        void Update();
    }
}
