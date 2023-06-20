namespace Tnk23Game.Components
{
    /// <summary>
    /// An interface that represents a game component.
    /// A component provides specific functionalities that can be attached to game objects.
    /// </summary>
    public interface IComponent
    {
        /// <summary>
        /// Updates the component's state or carries out any required operations.
        /// Is typically invoked once per frame.
        /// </summary>
        void Update();
    }
}
