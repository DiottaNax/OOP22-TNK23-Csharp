using Tnk23Game.Extra;

namespace Tnk23Game.Core
{
    /// <summary>
    /// The <see cref="GameLoopDecorator"/> class is an abstract class that implements the <see cref="IGameLoop"/> interface.
    /// It serves as a base class for implementing decorators for the game loop.
    /// Decorators can extend this class to add additional behavior or modify the behavior of the decorated game loop.
    /// </summary>
    public abstract class GameLoopDecorator : IGameLoop
    {
        public IGameEngine GameEngine { get; }
        /// <summary>
        /// The game loop instance to decorate.
        /// </summary>
        protected readonly GameLoop _toDecorate;

        /// <summary>
        /// Constructs a new <see cref="GameLoopDecorator"/> instance with the specified game loop to decorate.
        /// </summary>
        /// <param name="_toDecorate">The game loop instance to decorate.</param>
        protected GameLoopDecorator(GameLoop toDecorate)
        {
            GameEngine = toDecorate.GameEngine;
            this._toDecorate = toDecorate;
        }

        /// <inheritdoc/>
        public virtual void ProcessInput() => _toDecorate.ProcessInput();

        /// <inheritdoc/>
        public virtual void Update() => _toDecorate.Update();

        /// <inheritdoc/>
        public virtual void Render() => _toDecorate.Render();


        /// <inheritdoc/>
        public virtual void NotifyEvent(IWorldEvent e) => _toDecorate.NotifyEvent(e);

        /// <inheritdoc/>
        public virtual void RunGameLoop() => _toDecorate.RunGameLoop();

    }
}
