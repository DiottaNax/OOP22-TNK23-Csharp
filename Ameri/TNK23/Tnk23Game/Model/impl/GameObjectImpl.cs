using Tnk23Game.Common;
using Tnk23Game.Components;
using Tnk23Game.Model.Api;

namespace Tnk23Game.Model.Impl
{
    /// <summary>
    /// The GameObjectImpl class implements the GameObject interface and represents a game object
    /// in the game model.
    /// </summary>
    public class GameObjectImpl : IGameObject
    {
        private readonly IGameObjectType type;
        private Point2D position;
        private Directions direction;
        private int power = 1;
        private double rotation;
        private readonly HashSet<IComponent> components;

        /// <summary>
        /// Creates a new GameObjectImpl instance with the specified type and position.
        /// </summary>
        /// <param name="type">The type of the game object.</param>
        /// <param name="position">The position of the game object.</param>
        public GameObjectImpl(IGameObjectType type, Point2D position)
        {
            this.type = type;
            this.position = new Point2D(position.X, position.Y);
            this.direction = Directions.NONE;
            this.components = new HashSet<IComponent>();
        }

        /// <inheritdoc/>
        public void Update()
        {
            foreach (var component in components)
            {
                component.Update();
            }
        }

        /// <inheritdoc/>
        public IEnumerable<IComponent> GetComponents()
        {
            return components.AsEnumerable();
        }

        /// <inheritdoc/>
        public new IGameObjectType GetType()
        {
            return type;
        }

        /// <inheritdoc/>
        public void NotifyComponents<X>(IMessage<X> message, Type nc)
            where X : class
        {
            foreach (var component in components.Where(c => nc.IsInstanceOfType(c)))
            {
                ((INotifiableComponent)component).Receive(message);
            }
        }

        /// <summary>
        /// Retrieves the position of the game object.
        /// </summary>
        /// <returns>The position of the game object.</returns>
        public Point2D GetPosition()
        {
            return new Point2D(position.X, position.Y);
        }

        /// <inheritdoc/>
        public int GetPower()
        {
            return power;
        }

        /// <inheritdoc/>
        public void SetPower(int power)
        {
            this.power = power;
        }

        /// <inheritdoc/>
        public C? GetComponent<C>(Type clas) where C : IComponent
        {
            return components.OfType<C>().FirstOrDefault();
        }

        /// <inheritdoc/>
        public void SetPosition(Point2D position)
        {
            this.position = new Point2D(position.X, position.Y);
        }

        /// <inheritdoc/>
        public Directions GetDirection()
        {
            return direction;
        }

        /// <inheritdoc/>
        public void SetDirection(Directions direction)
        {
            this.direction = direction;
        }

        /// <inheritdoc/>
        public void AddComponent(IComponent comp)
        {
            components.Add(comp);
        }

        /// <inheritdoc/>
        public void SetRotation(double rotation)
        {
            this.rotation = rotation;
        }

        /// <inheritdoc/>
        public double GetRotation()
        {
            return rotation;
        }

        public void NotifyComponents<T, C>(IMessage<T> message, C nc) where C : INotifiableComponent
        {
            throw new NotImplementedException();
        }

        C? IGameObject.GetComponent<C>(Type compClass) where C : default
        {
            throw new NotImplementedException();
        }

        Point2D IGameObject.GetPosition()
        {
            throw new NotImplementedException();
        }
    }
}
