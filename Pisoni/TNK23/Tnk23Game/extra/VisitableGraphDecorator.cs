namespace Tnk23Game.extra
{
    public abstract class VisitableGraphDecorator<N> : GraphDecorator<N>, VisitableGraph<N> where N : VisitableNode<N>
    {
        protected VisitableGraphDecorator(VisitableGridGraph toDecorate)
        {
        }
    }
}
