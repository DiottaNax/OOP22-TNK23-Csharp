namespace Tnk23Game.Components
{
    /// <summary>
    /// An interface representing a message.
    /// </summary>
    /// <typeparam name="X">The type of the message content.</typeparam>
    public interface IMessage<X>
    {
        /// <summary>
        /// Retrieves the message content.
        /// </summary>
        /// <returns>The message content.</returns>
        X GetMessage();
    }
}
