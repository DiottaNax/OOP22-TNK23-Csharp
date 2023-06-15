namespace Tnk23Game.Core
{
    /// <summary>
    /// The <see cref="SynchronizedGameLoop"/> class extends the <see cref="GameLoopDecorator"/> class and provides a synchronized game loop implementation.
    /// It ensures that the game updates and rendering occur at a fixed frame rate defined by the configuration.
    /// </summary>
    public class SynchronizedGameLoop : GameLoopDecorator
    {
        private const int Fps = 120;
        private const long UpdatePeriod = (long)(1000.0 / Fps);
        private long _lag;
        private long _currentTime;
        private long _lastUpdateTime;

        /// <summary>
        /// Constructs a new instance of the <see cref="SynchronizedGameLoop"/> class with the given game loop to decorate.
        /// </summary>
        /// <param name="toDecorate">The game loop to decorate.</param>
        public SynchronizedGameLoop(GameLoop toDecorate) : base(toDecorate)
        {
            _lastUpdateTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        }

        /// <inheritdoc/>
        public override void Update()
        {
            _currentTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            _lag += _currentTime - _lastUpdateTime;
            _lastUpdateTime = _currentTime;

            while (_lag >= UpdatePeriod)
            {
                base.Update();
                _lag -= UpdatePeriod;
            }
        }

        private void WaitForNextFrame(long _currentTime)
        {
            long remainingTime = DateTimeOffset.Now.ToUnixTimeMilliseconds() - _currentTime;
            if (remainingTime < UpdatePeriod)
            {
                try
                {
                    System.Threading.Thread.Sleep((int)(UpdatePeriod - remainingTime));
                }
                catch (System.Threading.ThreadInterruptedException)
                {
                    System.Threading.Thread.CurrentThread.Interrupt();
                }
            }
        }

        /// <inheritdoc/>
        public override void Render()
        {
            base.Render();
            WaitForNextFrame(_currentTime);
        }
    }
}
