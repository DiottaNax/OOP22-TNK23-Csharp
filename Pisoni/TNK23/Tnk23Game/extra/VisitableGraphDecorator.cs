namespace Tnk23Game.extra
{
    // This class is made to avoid errors in others classes
    public abstract class VisitableGraphDecorator<N> : GraphDecorator<N>, VisitableGraph<N> where N : VisitableNode<N>
    {
        protected VisitableGraphDecorator(VisitableGridGraph toDecorate)
        {
        }
    }
}
