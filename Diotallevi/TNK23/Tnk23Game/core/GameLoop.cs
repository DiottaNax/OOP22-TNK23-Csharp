using Tnk23Game.Extra;

namespace Tnk23Game.Core
{
    /// <summary>
    /// The <see cref="GameLoopImpl"/> class implements the <see cref="GameLoop"/> interface to provide the main game loop functionality for TNK23.
    /// It updates the game state, renders the game view, and handles world events.
    /// </summary>
    public class GameLoop : IGameLoop
    {
        /// <inheritdoc/>
        public IGameEngine GameEngine { get; }
        //private readonly World _wrld;
        private readonly IWorldEventHandler _eventHandler;
        private readonly List<IWorldEvent> _eventList = new List<IWorldEvent>();

        /// <summary>
        /// Constructs a <see cref="GameLoopImpl"/> instance with the given game engine.
        /// Initializes the world, event handler, and event queue.
        /// </summary>
        /// <param name="engine">The game engine associated with the game loop.</param>
        public GameLoop(IGameEngine engine)
        {
            _eventHandler = new WorldEventHandler();
            GameEngine = engine;
            //_wrld = engine.GetWorld();
        }

        /// <inheritdoc/>
        public void ProcessInput() => _eventList.ForEach(_eventHandler.Handle);

        /// <inheritdoc/>
        public void Update()
        {
            //GameEngine.GetGameState().Update();
            //_wrld.Update();
        }

        /// <inheritdoc/>
        public void Render() => GameEngine.GameView.RenderView();

        /// <inheritdoc/>
        public void NotifyEvent(IWorldEvent e) => _eventList.Add(e);

        /// <inheritdoc/>
        public void RunGameLoop()
        {
            while(true) // Should be while(!GameState.isOver())
            {
                ProcessInput();
                Update();
                Render();
            }
        }
    }
}
