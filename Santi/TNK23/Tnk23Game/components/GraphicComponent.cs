using Tnk23Game.extra;

namespace Tnk23Game.components
{
    /// <summary>
    /// Represents a graphical component for game entities.
    /// Handles rendering and sprite management for entities.
    /// </summary>
    public class GraphicComponent : IComponent
    {
        private string _spriteName;

        /// <summary>
        /// Constructs a GraphicComponent for the specified entity with the given sprite name.
        /// </summary>
        /// <param name="spriteName">The name of the sprite associated with the entity.</param>
        public GraphicComponent(string spriteName)
        {
           _spriteName = spriteName;
        }

        /// <summary>
        /// {@inheritDoc}
        /// </summary>
        public void Update()
        {
        }

        /// <summary>
        /// Gets the name of the sprite associated with the entity.
        /// </summary>
        /// <returns>The sprite name.</returns>
        public string GetSpriteName() => _spriteName;

        /// <summary>
        /// Sets the name of the sprite associated with the entity.
        /// </summary>
        /// <param name="spriteName">The sprite name to set.</param>
        public void SetSpriteName(string spriteName)
        {
            _spriteName = spriteName;
        }
    }
}
