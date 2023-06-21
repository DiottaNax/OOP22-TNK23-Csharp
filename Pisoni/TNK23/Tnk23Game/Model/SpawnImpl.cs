using Tnk23Game.Events;
using Tnk23Game.extra;
using Timer = System.Timers.Timer;

namespace Tnk23Game.Model
{
    /// <summary>
    /// The implementation of the spawn functionality during a game round.
    /// It manages the spawning position, timing, and updates of enemies in the game world.
    /// </summary>
    public class SpawnImpl : ISpawn
    {
        private List<IGameObject> _roundEnemies;
        private readonly IRound _round;
        private readonly long _delay;
        private readonly List<IGameObject> _activeEnemies;
        private readonly List<Rect2D> _spawns;
        private readonly Timer _timer = new Timer();
        private readonly Random _random = new Random();

        /// <summary>
        /// Constructs a new instance of the <see cref="SpawnImpl"/> class with the specified delay and game round.
        /// </summary>
        /// <param name="delay">The delay between enemy spawns in milliseconds.</param>
        /// <param name="round">The game round.</param>
        public SpawnImpl(long delay, IRound round)
        {
            _round = round;
            _delay = delay;
            _spawns = new List<Rect2D>
            {
                new Rect2D(Configuration.ORIGINAL_TILE_SIZE, Configuration.ORIGINAL_TILE_SIZE,
                        new Point2D(Configuration.ORIGINAL_TILE_SIZE / 2.0, Configuration.ORIGINAL_TILE_SIZE / 2.0)),
                new Rect2D(Configuration.ORIGINAL_TILE_SIZE, Configuration.ORIGINAL_TILE_SIZE,
                        new Point2D((Configuration.GRID_SIZE / 2.0) * Configuration.ORIGINAL_TILE_SIZE, Configuration.ORIGINAL_TILE_SIZE / 2.0)),
                new Rect2D(Configuration.ORIGINAL_TILE_SIZE, Configuration.ORIGINAL_TILE_SIZE,
                        new Point2D((Configuration.GRID_SIZE - 1) * Configuration.ORIGINAL_TILE_SIZE, Configuration.ORIGINAL_TILE_SIZE / 2.0))
            };
            _activeEnemies = new List<IGameObject>();
            _roundEnemies = _round.GetEnemies() ?? new List<IGameObject>();
        }

        /// <summary>
        /// Starts the enemy spawn process.
        /// </summary>
        public void StartSpawn()
        {
            _timer.Elapsed += (sender, e) =>
            {
                if (_roundEnemies != null && _roundEnemies.Any())
                {
                    var enemy = _roundEnemies[0];
                    var spawnPos = GetSpawnPos();
                    if (spawnPos != null)
                    {
                        _roundEnemies.RemoveAt(0);
                        _round.GetWorld().NotifyEvent(new WorldEventImpl(spawnPos, enemy, IWorldEventType.Spawn_event));
                        _activeEnemies.Add(enemy);
                    }
                }
            };
    }

        /// <summary>
        /// Updates the state of enemy spawns and removes defeated enemies from the list of enemies.
        /// </summary>
        public void Update()
        {
            if (_roundEnemies.Count == 0 && _round.IsOver())
            {
                _timer.Enabled = false;
                _roundEnemies = new List<IGameObject>(_round.GetEnemies());
            }

            lock (_activeEnemies)
            {
                var diedEnemies = new List<IGameObject>(_activeEnemies)
                    .Where(this.IsEnemyDead)
                    .ToList();
                
                lock (diedEnemies)
                {
                    _round.GetEnemies().RemoveAll(enemy => diedEnemies.Contains(enemy));
                    _activeEnemies.RemoveAll(enemy => diedEnemies.Contains(enemy));
                    diedEnemies.ForEach(d => _round.NotifyEnemyDeath());
                }
            }
        }

        /// <summary>
        /// Retrieves a valid spawn position for an enemy.
        /// </summary>
        /// <returns>An optional <see cref="Point2D"/> representing the spawn position, or an empty optional if there isn't a position available.</returns>
        private Point2D? GetSpawnPos()
        {
            var worldEntities = new HashSet<IGameObject>(_round.GetWorld().GetEntities());
            var colidableEntities = worldEntities
                .Where(e => !GameObjectTypeManager.IsObstacle(e.GetType()))
                .Where(e => e.GetComponent<CollisionComponent>() != null)
                .Select(e => e.GetComponent<CollisionComponent>())
                .ToList();
            
            var pos = _spawns
                .Where(s => !colidableEntities.Any(c => c != null && c.IsCollidingWith(s)))
                .Select(s => s.Pos)
                .ToList();
            
            return pos.Count > 0 ? (Point2D?)pos[_random.Next(pos.Count)] : null;
        }

        private bool IsEnemyDead(IGameObject enemy)
        {
            lock (_activeEnemies)
            {
                return !_round.GetWorld().GetEntities().Contains(enemy);
            }
        }
    }
}
