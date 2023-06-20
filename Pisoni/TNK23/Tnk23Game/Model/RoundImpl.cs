using Tnk23Game.extra;

namespace Tnk23Game.Model
{
    /// <summary>
    /// Implementazione dell'interfaccia Round che rappresenta un turno di gioco.
    /// La classe RoundImpl contiene l'implementazione della logica che gestisce il comportamento e la progressione di un turno di gioco.
    /// </summary>
    public class RoundImpl : IRound
    {
        private int totalEnemies;
        private int round;
        private long spawnDelay;
        private int numRandomEnemies;
        private int numFollowTargetEnemies;
        private int numTowerEnemies;
        private readonly List<IGameObject> enemies;
        private readonly IWorld world;
        private readonly ISpawn spawn;
        private readonly AiControllerFactory aiFactory;
        private readonly GameGraph graph;
        private readonly Random random;

        /// <summary>
        /// Costruisce una nuova istanza di RoundImpl con il mondo specificato.
        /// </summary>
        /// <param name="world">Il mondo di gioco associato a questo turno.</param>
        public RoundImpl(IWorld world)
        {
            totalEnemies = 0;
            round = 1;
            numRandomEnemies = 0;
            numFollowTargetEnemies = 0;
            numTowerEnemies = 0;
            enemies = new List<IGameObject>();
            this.world = world;
            SetDelay();
            spawn = new SpawnImpl(spawnDelay, this);
            graph = new GameGraph(new VisitableGridGraphImpl(Configuration.GRID_SIZE * 2));
            aiFactory = new AiControllerFactoryImpl(graph, world);
            random = new Random();
            FillEnemiesList();
            totalEnemies = enemies.Count;
        }

        /// <summary>
        /// Ottiene la lista di nemici nel turno corrente.
        /// </summary>
        /// <returns>La lista di nemici.</returns>
        public List<IGameObject> GetEnemies()
        {
            return enemies;
        }

        /// <summary>
        /// Verifica se il turno corrente è terminato.
        /// </summary>
        /// <returns><c>true</c> se il turno è terminato, <c>false</c> altrimenti.</returns>
        public bool IsOver()
        {
            return totalEnemies == 0;
        }

        /// <summary>
        /// Ottiene il numero del turno corrente.
        /// </summary>
        /// <returns>Il numero del turno.</returns>
        public int GetRound()
        {
            return round;
        }

        /// <summary>
        /// Ottiene il mondo associato al turno.
        /// </summary>
        /// <returns>L'oggetto World.</returns>
        public IWorld GetWorld()
        {
            return world;
        }

        /// <summary>
        /// Ottiene il numero di nemici generati casualmente nel turno corrente.
        /// </summary>
        /// <returns>Il numero di nemici casuali.</returns>
        public int GetRandomEnemiesNum()
        {
            return numRandomEnemies;
        }

        /// <summary>
        /// Ottiene il numero di nemici controllati dall'intelligenza artificiale nel turno corrente.
        /// </summary>
        /// <returns>Il numero di nemici controllati dall'IA.</returns>
        public int GetAIEnemiesNum()
        {
            return numFollowTargetEnemies + numTowerEnemies;
        }

        /// <summary>
        /// Ottiene il numero totale di nemici vivi nel turno corrente.
        /// </summary>
        /// <returns>Il numero totale di nemici vivi.</returns>
        public int GetTotalEnemies()
        {
            return totalEnemies;
        }

        /// <summary>
        /// Aggiorna lo stato del turno.
        /// Questo metodo viene chiamato per aggiornare la logica e la progressione del turno.
        /// </summary>
        public void Update()
        {
            spawn.Update();
            graph.Update();
            if (IsOver())
            {
                round++;
                SetDelay();
                StartRound();
                FillEnemiesList();
                totalEnemies = enemies.Count;
            }
        }

        /// <summary>
        /// Avvia il turno corrente.
        /// Questo metodo viene chiamato per iniziare un nuovo turno quando quello precedente termina.
        /// </summary>
        public void StartRound()
        {
            spawn.StartSpawn();
        }

        /// <summary>
        /// Notifica al turno la morte di un nemico.
        /// Questo metodo viene chiamato per informare il turno che un nemico è stato ucciso.
        /// </summary>
        public void NotifyEnemyDeath()
        {
            totalEnemies--;
        }

        private void FillEnemiesList()
        {
            enemies.Clear();
            numRandomEnemies = 0;
            numFollowTargetEnemies = 0;
            numTowerEnemies = 0;
            const int firstRoundRdmEnemies = 6;
            const double rateFollowTargetEnemies = 2.0;
            const int rateRandomEnemies = 3;

            if (round == 1)
            {
                numRandomEnemies = firstRoundRdmEnemies;
            }
            else
            {
                numRandomEnemies = round * rateRandomEnemies;
                numFollowTargetEnemies = (int)(round / rateFollowTargetEnemies);
                numTowerEnemies = (int)(round / rateFollowTargetEnemies);
            }

            AddEnemies(numRandomEnemies, GenerateRandomMovingEnemies);
            AddEnemies(numFollowTargetEnemies, GenerateFollowMovingTargetEnemies);
            AddEnemies(numTowerEnemies, GenerateFollowTowerEnemies);
        }

        private void SetDelay()
        {
            const int hardRound = 5;
            const long simpleDelay = 4000;
            const long hardDelay = 3000;

            spawnDelay = simpleDelay;
            if (round >= hardRound)
            {
                spawnDelay = hardDelay;
            }
        }

        private IGameObject GenerateRandomMovingEnemies()
        {
            var enemy = new GameObjectFactoryImpl(world).GetEnemy(new Point2D(0, 0));
            enemy.AddComponent(new AiComponent(enemy, aiFactory.GetRandomAi()));
            enemy.AddComponent(new GraphicComponent("brownEnemy"));
            return enemy;
        }

        private IGameObject GenerateFollowMovingTargetEnemies()
        {
            var enemy = new GameObjectFactoryImpl(world).GetEnemy(new Point2D(0, 0));
            var players = world.GetPlayers().FindAll(p => world.GetEntities().Contains(p));
            enemy.AddComponent(new AiComponent(enemy,
                aiFactory.GetFollowMovingTargetAi(enemy, players[random.Next(players.Count)])));
            enemy.AddComponent(new GraphicComponent("greyEnemy"));
            return enemy;
        }

        private IGameObject GenerateFollowTowerEnemies()
        {
            var enemy = new GameObjectFactoryImpl(world).GetEnemy(new Point2D(0, 0));
            enemy.AddComponent(new AiComponent(enemy, aiFactory.GetFollowTowerAi(enemy)));
            enemy.AddComponent(new GraphicComponent("greyEnemy"));
            return enemy;
        }

        private void AddEnemies(int numEnemies, Func<IGameObject> enemyGenerator)
        {
            for (int i = 0; i < numEnemies; i++)
            {
                enemies.Add(enemyGenerator());
            }
        }
    }
}
