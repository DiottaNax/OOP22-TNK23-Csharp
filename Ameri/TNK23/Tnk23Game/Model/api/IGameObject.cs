using Tnk23Game.Common;
using Tnk23Game.Components;

namespace Tnk23Game.Model.Api
{
    /// <summary>
    /// The GameObject interface represents an object within the game.
    /// </summary>
    public interface IGameObject
    {
        /// <summary>
        /// Updates the state of the game object.
        /// </summary>
        void Update();

        /// <summary>
        /// Retrieves the components associated with the game object.
        /// </summary>
        /// <returns>A stream of components.</returns>
        IEnumerable<IComponent> GetComponents();

        /// <summary>
        /// Retrieves the type of the game object.
        /// </summary>
        /// <returns>The type of the game object.</returns>
        IGameObjectType GetType();

        /// <summary>
        /// Notifies the components of the game object with a message.
        /// </summary>
        /// <typeparam name="X">The type of the message.</typeparam>
        /// <param name="message">The message to notify.</param>
        /// <param name="nc">The class of the notifiable component.</param>
        void NotifyComponents<X, TComponent>(IMessage<X> message, TComponent nc) where TComponent : INotifiableComponent;

        /// <summary>
        /// Retrieves the position of the game object.
        /// </summary>
        /// <returns>The position of the game object.</returns>
        Point2D GetPosition();

        /// <summary>
        /// Sets the position of the game object.
        /// </summary>
        /// <param name="position">The new position of the game object.</param>
        void SetPosition(Point2D position);

        /// <summary>
        /// Retrieves the direction of the game object.
        /// </summary>
        /// <returns>The direction of the game object.</returns>
        Directions GetDirection();

        /// <summary>
        /// Sets the direction of the game object.
        /// </summary>
        /// <param name="direction">The new direction of the game object.</param>
        void SetDirection(Directions direction);

        /// <summary>
        /// Retrieves the power of the game object.
        /// </summary>
        /// <returns>The power of the game object.</returns>
        int GetPower();

        /// <summary>
        /// Sets the power of the game object.
        /// </summary>
        /// <param name="power">The new power of the game object.</param>
        void SetPower(int power);

        /// <summary>
        /// Adds a component to the game object.
        /// </summary>
        /// <param name="comp">The component to add.</param>
        void AddComponent(IComponent comp);

        /// <summary>
        /// Retrieves a component of the specified class from the game object.
        /// </summary>
        /// <typeparam name="C">The type of the component.</typeparam>
        /// <param name="compClass">The class of the component to retrieve.</param>
        /// <returns>An optional containing the component, or empty if not found.</returns>
        C? GetComponent<C>(Type compClass) where C : IComponent;

        /// <summary>
        /// Sets the rotation of the game object.
        /// </summary>
        /// <param name="rotation">The new rotation of the game object.</param>
        void SetRotation(double rotation);

        /// <summary>
        /// Retrieves the rotation of the game object.
        /// </summary>
        /// <returns>The rotation of the game object.</returns>
        double GetRotation();
    }
}
