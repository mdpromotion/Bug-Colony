using Bug.Strategies;

namespace Bug.FSM
{
    public class MovingState : IBugState
    {
        private readonly IMovementStrategy _movementStrategy;
        private readonly IEatingStrategy _eatingStrategy;

        public MovingState(IMovementStrategy movementStrategy, IEatingStrategy eatingStrategy)
        {
            _movementStrategy = movementStrategy;
            _eatingStrategy = eatingStrategy;
        }

        public void Enter(Domain.Bug bug)
        {
            
        }

        public void Execute(Domain.Bug bug)
        {
            
        }

        public void Exit(Domain.Bug bug)
        {
        }
    }
}