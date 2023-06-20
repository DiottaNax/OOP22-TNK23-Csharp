using Tnk23Game.extra;

namespace Tnk23Game.Model
{
    /// <summary>
    /// An interface representing a round in the game.
    /// A round consists of a list of enemies and manages the progression of the game.
    /// </summary>
    public interface IRound
    {
        /// <summary>
        /// Gets the list of enemies in the current round.
        /// </summary>
        /// <returns>The list of enemies.</returns>
        List<IGameObject> GetEnemies();

        /// <summary>
        /// Checks if the current round is over.
        /// </summary>
        /// <returns><c>true</c> if the round is over, <c>false</c> otherwise.</returns>
        bool IsOver();

        /// <summary>
        /// Gets the number of the current round.
        /// </summary>
        /// <returns>The round number.</returns>
        int GetRound();

        /// <summary>
        /// Gets the world associated with the round.
        /// </summary>
        /// <returns>The World object.</returns>
        IWorld GetWorld();

        /// <summary>
        /// Gets the number of randomly generated enemies in the current round.
        /// </summary>
        /// <returns>The number of random enemies.</returns>
        int GetRandomEnemiesNum();

        /// <summary>
        /// Gets the number of AI-controlled enemies in the current round.
        /// </summary>
        /// <returns>The number of AI enemies.</returns>
        int GetAIEnemiesNum();

        /// <summary>
        /// Gets the total number of alive enemies in the current round.
        /// </summary>
        /// <returns>The total number of alive enemies.</returns>
        int GetTotalEnemies();

        /// <summary>
        /// Updates the round state.
        /// </summary>
        void Update();

        /// <summary>
        /// Starts the current round.
        /// </summary>
        void StartRound();

        /// <summary>
        /// Notifies the round of an enemy's death.
        /// </summary>
        void NotifyEnemyDeath();
    }
}
