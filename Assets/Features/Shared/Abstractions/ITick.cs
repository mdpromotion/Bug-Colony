namespace Shared.Abstractions
{
    public interface ITick
    {
        event System.Action Tick;
    }
}