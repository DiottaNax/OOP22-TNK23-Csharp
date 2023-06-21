namespace Tnk23Game.extra
{
    // This class is made to avoid errors in others classes
    public class AiComponent : IComponent
    {
        private readonly IGameObject _entity;
        private readonly InputController _ai;

        public AiComponent(IGameObject entity, InputController ai)
        {
            _entity = entity;
            _ai = ai;
        }

        public bool IsCollidingWith(Rect2D s) =>  throw new NotImplementedException();

        void IComponent.Update() =>  throw new NotImplementedException();

    }
}
