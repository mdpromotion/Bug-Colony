using Bug.Data;

namespace Bug.Strategies
{
    public interface IMovementStrategy
    {
        MovementStrategyData? GetTargetPosition(Domain.Bug bug);
    }
}