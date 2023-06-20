using Tnk23Game.Components;
using Tnk23Game.extra;

namespace Tnk23Game.Events
{
    /// <summary>
    /// Implementation of the <see cref="IWorldEventHandler"/> interface that handles various events
    /// and performs corresponding actions in the world.
    /// </summary>
    public class WorldEventHandlerImpl : IWorldEventHandler
    {

        private readonly IWorld _world;

        /// <summary>
        /// Constructs a new <see cref="WorldEventHandlerImpl"/> with the specified world.
        /// </summary>
        /// <param name="world">The <see cref="IWorld"/> instance to handle events in.</param>
        public WorldEventHandlerImpl(IWorld world)
        {
            _world = world;
        }

        /// <inheritdoc/>
        public void Handle(IWorldEvent we)
        {
            IWorldEventType type = we.GetType();
            var actor = we.GetEventActor();
            switch (type)
            {
                case IWorldEventType.Death_event:
                    /// <summary>
                    /// Remove the entity from the world.
                    /// <summary>
                    _world.RemoveEntity(actor);
                    break;

                case IWorldEventType.Shoot_event:
                    /// <summary>
                    ///Create a bullet entity and add it to the world.
                    /// <summary>
                    var pos = actor.GetPosition();
                    /// <summary>
                    /// I just use GetWidth because the shooter is square.
                    /// <summary>
                    var actorType = actor.GetType();
                    var actorEdge = GameObjectTypeManager.GetWidth(actorType) * Configuration.SCALE_FACTOR;
                    var bulletPos = pos;
                    /// <summary>
                    /// I need just a bit more than the size of the tile size.
                    /// <summary>
                    double rateCalculationBulletPos = 0.7;
                    bulletPos = bulletPos.Sum(DirectionsExtensions.FromAngle((int)actor.GetRotation()).GetVel()
                        .Mul(actorEdge * rateCalculationBulletPos));
                    var bullet = new GameObjectFactoryImpl(_world).GetBullet(bulletPos);
                    bullet.Power = actor.GetPower();
                    bullet.Direction = DirectionsExtensions.FromAngle((int)actor.GetRotation());
                    bullet.NotifyComponents<IMessage<object>>((IMessage<IMessage<object>>)we.GetEventActor(), typeof(BulletComponent));
                    _world.AddEntity(bullet);
                    break;

                case IWorldEventType.Spawn_event:
                    /// <summary>
                    /// Set the actor's position and add it to the world.
                    /// <summary>
                    actor.Position = we.GetPosition();
                    _world.AddEntity(actor);
                    break;

                default:
                    /// <summary>
                    /// No action needed for the other event types.
                    /// <summary>
                    break;
            }
        }
    }
}
