using Tnk23Game.extra;

namespace Tnk23Game.Model
{
    /// <summary>
    /// Implementazione dell'interfaccia Round che rappresenta un turno di gioco.
    /// La classe RoundImpl contiene l'implementazione della logica che gestisce il comportamento e la progressione di un turno di gioco.
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
        /// Costruisce una nuova istanza di RoundImpl con il mondo specificato.
        /// </summary>
        /// <param name="world">Il mondo di gioco associato a questo turno.</param>
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
        /// Ottiene la lista di nemici nel turno corrente.
        /// </summary>
        /// <returns>La lista di nemici.</returns>
        public List<IGameObject> GetEnemies() => _enemies;

        /// <summary>
        /// Verifica se il turno corrente è terminato.
        /// </summary>
        /// <returns><c>true</c> se il turno è terminato, <c>false</c> altrimenti.</returns>
        public bool IsOver() => _totalEnemies == 0;

        /// <summary>
        /// Ottiene il numero del turno corrente.
        /// </summary>
        /// <returns>Il numero del turno.</returns>
        public int GetRound() => _round;

        /// <summary>
        /// Ottiene il mondo associato al turno.
        /// </summary>
        /// <returns>L'oggetto World.</returns>
        public IWorld GetWorld() => _world;

        /// <summary>
        /// Ottiene il numero di nemici generati casualmente nel turno corrente.
        /// </summary>
        /// <returns>Il numero di nemici casuali.</returns>
        public int GetRandomEnemiesNum() => _numRandomEnemies;

        /// <summary>
        /// Ottiene il numero di nemici controllati dall'intelligenza artificiale nel turno corrente.
        /// </summary>
        /// <returns>Il numero di nemici controllati dall'IA.</returns>
        public int GetAIEnemiesNum() => _numFollowTargetEnemies + _numTowerEnemies;

        /// <summary>
        /// Ottiene il numero totale di nemici vivi nel turno corrente.
        /// </summary>
        /// <returns>Il numero totale di nemici vivi.</returns>
        public int GetTotalEnemies() => _totalEnemies;

        /// <summary>
        /// Aggiorna lo stato del turno.
        /// Questo metodo viene chiamato per aggiornare la logica e la progressione del turno.
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
        /// Avvia il turno corrente.
        /// Questo metodo viene chiamato per iniziare un nuovo turno quando quello precedente termina.
        /// </summary>
        public void StartRound() => _spawn.StartSpawn();

        /// <summary>
        /// Notifica al turno la morte di un nemico.
        /// Questo metodo viene chiamato per informare il turno che un nemico è stato ucciso.
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
