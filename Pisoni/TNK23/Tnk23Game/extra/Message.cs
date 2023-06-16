namespace it.unibo.tnk23.game.components.api
{
    /// <summary>
    /// An interface representing a message.
    /// </summary>
    /// <typeparam name="X">the type of the message content.</typeparam>
    public interface Message<X>
    {
        /// <summary>
        /// Retrieves the message content.
        /// </summary>
        /// <returns>the message content.</returns>
        X GetMessage();
    }
}