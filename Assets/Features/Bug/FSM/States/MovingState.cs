using Bug.Strategies;

namespace Bug.FSM
{
    public class MovingState : IBugState
    {
        private readonly IMovementStrategy _movementStrategy;

        public MovingState(IMovementStrategy movementStrategy)
        {
            _movementStrategy = movementStrategy;
        }

        public void Enter(Domain.Bug bug) { }

        public void Execute(Domain.Bug bug, BugFSM fsm)
        {
            var newPosition = _movementStrategy.GetTargetPosition(bug);
            if (!newPosition.HasValue)
            {
                fsm.ChangeState(BugStateType.Idle);
                return;
            }

            fsm.NotifyTargetPositionChanged(newPosition.Value);

        }

        public void Exit(Domain.Bug bug) { }
    }
}