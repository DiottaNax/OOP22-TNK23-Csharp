namespace Tnk23Game.extra
{
    // This interface is made to avoid errors in others classes
    public interface IMessage<X>
    {
        X GetMessage();
    }
}