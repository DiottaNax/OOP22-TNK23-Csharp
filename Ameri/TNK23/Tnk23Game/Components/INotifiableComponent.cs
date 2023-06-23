namespace Tnk23Game.Components
{
    /// <summary>
    /// An interface that represents a notifiable game component.
    /// Notifiable components extend the basic functionality of <see cref="Component"/> by allowing them to receive messages.
    /// </summary>
    public interface INotifiableComponent : IComponent
    {
        /// <summary>
        /// Receives a message of type <typeparamref name="X"/>.
        /// </summary>
        /// <typeparam name="X">The type of the message.</typeparam>
        /// <param name="x">The message to be received.</param>
        void Receive<X>(IMessage<X> x);
    }
}
