using Tnk23Game.Extra;

namespace Tnk23Game.Core
{
    /// <summary>
    /// A simple implementation of the <see cref="IGameEngine"/> interface.
    /// </summary>
    public class GameEngine : IGameEngine
    {
        private readonly SynchronizedGameLoop _loop;
        public IGameView GameView { get; }

        /// <summary>
        /// Constructs a <see cref="GameEngineImpl"/> with the specified world and game view.
        /// </summary>
        /// <param name="world">The game world.</param>
        /// <param name="view">The game view.</param>
        public GameEngine(/*World world,*/IGameView view)
        {
            _loop = new SynchronizedGameLoop(new GameLoop(this));
            //this.world.SetWorldEventListener(loop);
            GameView = view;
        }

        /// <inheritdoc/>
        public void StartEngine()
        {
            _loop.RunGameLoop();
            // _gameState.StartRound() would be here if there was GameState
        }
    }

}
