using Tnk23Game.Components;

namespace Tnk23Game.extra
{
    public class GraphicComponent : IComponent
    {
        private string _spriteName;

        public GraphicComponent(string spriteName)
        {
            _spriteName = spriteName;
        }

        public bool IsCollidingWith(Rect2D s) =>  throw new NotImplementedException();

        public void Update()
        {
        }
    }
}
