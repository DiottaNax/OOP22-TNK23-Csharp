using Tnk23Game.extra;

namespace Tnk23Game.Model
{
    /// <summary>
    /// Implementation of the Round interface that represents a game round.
    /// The RoundImpl class contains the implementation of the logic that manages the behavior and progression of a game round.
    /// </summary>
    public class RoundImpl : IRound
    {
        private int _totalEnemies;
        private int _round;
        private long spawnDelay;
        private int _numRandomEnemies;
        private int _numFollowTargetEnemies;
        private int _numTowerEnemies;
        private readonly List<IGameObject> _enemies;
        private readonly IWorld _world;
        private readonly ISpawn _spawn;
        private readonly AiControllerFactory _aiFactory;
        private readonly GameGraph _graph;
        private readonly Random _random;

        /// <summary>
        /// Constructs a new instance of RoundImpl with the specified world.
        /// </summary>
        /// <param name="world">The game world associated with this round.</param>
        public RoundImpl(IWorld world)
        {
            _totalEnemies = 0;
            _round = 1;
            _numRandomEnemies = 0;
            _numFollowTargetEnemies = 0;
            _numTowerEnemies = 0;
            _enemies = new List<IGameObject>();
            _world = world;
            SetDelay();
            _spawn = new SpawnImpl(spawnDelay, this);
            _graph = new GameGraph(new VisitableGridGraphImpl(Configuration.GRID_SIZE * 2));
            _aiFactory = new AiControllerFactoryImpl(_graph, world);
            _random = new Random();
            FillEnemiesList();
            _totalEnemies = _enemies.Count;
        }

        /// <summary>
        /// Gets the list of enemies in the current round.
        /// </summary>
        /// <returns>The list of enemies.</returns>
        public List<IGameObject> GetEnemies() => _enemies;

        /// <summary>
        /// Checks if the current round has ended.
        /// </summary>
        /// <returns><c>true</c> if the round has ended, <c>false</c> otherwise.</returns>
        public bool IsOver() => _totalEnemies == 0;

        /// <summary>
        /// Gets the number of the current round.
        /// </summary>
        /// <returns>The round number.</returns>
        public int GetRound() => _round;

        /// <summary>
        /// Gets the world associated with the round.
        /// </summary>
        /// <returns>The World object.</returns>
        public IWorld GetWorld() => _world;

        /// <summary>
        /// Gets the number of randomly generated enemies in the current round.
        /// </summary>
        /// <returns>The number of random enemies.</returns>
        public int GetRandomEnemiesNum() => _numRandomEnemies;

        /// <summary>
        /// Gets the number of enemies controlled by artificial intelligence in the current round.
        /// </summary>
        /// <returns>The number of AI-controlled enemies.</returns>
        public int GetAIEnemiesNum() => _numFollowTargetEnemies + _numTowerEnemies;

        /// <summary>
        /// Gets the total number of alive enemies in the current round.
        /// </summary>
        /// <returns>The total number of alive enemies.</returns>
        public int GetTotalEnemies() => _totalEnemies;

        /// <summary>
        /// Updates the state of the round.
        /// This method is called to update the logic and progression of the round.
        /// </summary>
        public void Update()
        {
            _spawn.Update();
            _graph.Update();
            if (IsOver())
            {
                _round++;
                this.SetDelay();
                this.StartRound();
                this.FillEnemiesList();
                _totalEnemies = _enemies.Count;
            }
        }

        /// <summary>
        /// Starts the current round.
        /// This method is called to begin a new round when the previous one ends.
        /// </summary>
        public void StartRound() => _spawn.StartSpawn();

        /// <summary>
        /// Notifies the round of an enemy's death.
        /// This method is called to inform the round that an enemy has been killed.
        /// </summary>
        public void NotifyEnemyDeath() => _totalEnemies--;

        private void FillEnemiesList()
        {
            _enemies.Clear();
            _numRandomEnemies = 0;
            _numFollowTargetEnemies = 0;
            _numTowerEnemies = 0;
            const int firstRoundRdmEnemies = 6;
            const double rateFollowTargetEnemies = 2.0;
            const int rateRandomEnemies = 3;

            if (_round == 1)
            {
                _numRandomEnemies = firstRoundRdmEnemies;
            }
            else
            {
                _numRandomEnemies = _round * rateRandomEnemies;
                _numFollowTargetEnemies = (int)(_round / rateFollowTargetEnemies);
                _numTowerEnemies = (int)(_round / rateFollowTargetEnemies);
            }

            AddEnemies(_numRandomEnemies, GenerateRandomMovingEnemies);
            AddEnemies(_numFollowTargetEnemies, GenerateFollowMovingTargetEnemies);
            AddEnemies(_numTowerEnemies, GenerateFollowTowerEnemies);
        }

        private void SetDelay()
        {
            const int hardRound = 5;
            const long simpleDelay = 4000;
            const long hardDelay = 3000;

            spawnDelay = simpleDelay;
            if (_round >= hardRound)
            {
                spawnDelay = hardDelay;
            }
        }

        private IGameObject GenerateRandomMovingEnemies()
        {
            var enemy = new GameObjectFactoryImpl(_world).GetEnemy(new Point2D(0, 0));
            enemy.AddComponent(new AiComponent(enemy, _aiFactory.GetRandomAi()));
            enemy.AddComponent(new GraphicComponent("brownEnemy"));
            return enemy;
        }

        private IGameObject GenerateFollowMovingTargetEnemies()
        {
            var enemy = new GameObjectFactoryImpl(_world).GetEnemy(new Point2D(0, 0));
            var players = _world.GetPlayers().FindAll(p => _world.GetEntities().Contains(p));
            enemy.AddComponent(new AiComponent(enemy,
                _aiFactory.GetFollowMovingTargetAi(enemy, players[_random.Next(players.Count)])));
            enemy.AddComponent(new GraphicComponent("greyEnemy"));
            return enemy;
        }

        private IGameObject GenerateFollowTowerEnemies()
        {
            var enemy = new GameObjectFactoryImpl(_world).GetEnemy(new Point2D(0, 0));
            enemy.AddComponent(new AiComponent(enemy, _aiFactory.GetFollowTowerAi(enemy)));
            enemy.AddComponent(new GraphicComponent("greyEnemy"));
            return enemy;
        }

        private void AddEnemies(int numEnemies, Func<IGameObject> enemyGenerator)
        {
            for (int i = 0; i < numEnemies; i++)
            {
                _enemies.Add(enemyGenerator());
            }
        }
    }
}
