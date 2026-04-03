using Bug.Strategies;

namespace Bug.FSM
{
    public class IdleState : IBugState
    {
        private readonly IMovementStrategy _movementStrategy;

        public IdleState(IMovementStrategy movementStrategy)
        {
            _movementStrategy = movementStrategy;
        }

        public void Enter(Domain.Bug bug) { }
        public void Execute(Domain.Bug bug, BugFSM fsm)
        {
            var targetPosition = _movementStrategy.GetTargetPosition(bug);
            if (!targetPosition.HasValue)
            {
                fsm.ChangeState(BugStateType.Moving);
                return;
            }
            fsm.NotifyTargetPositionChanged(targetPosition.Value);
        }
        public void Exit(Domain.Bug bug) { }
    }
}