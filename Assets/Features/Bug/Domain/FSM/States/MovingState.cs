using Bug.Strategies;

namespace Bug.FSM
{
    public class MovingState : IBugState
    {
        private readonly IMovementStrategy _movementStrategy;
        private readonly float _distanceToEat = 0.5f;

        public MovingState(IMovementStrategy movementStrategy)
        {
            _movementStrategy = movementStrategy;
        }

        public void Enter(Domain.Bug bug) { }

        public void Execute(Domain.Bug bug, BugFSM fsm)
        {
            var strategyData = _movementStrategy.GetTargetPosition(bug);

            if (!strategyData.HasValue)
            {
                fsm.ChangeState(BugStateType.Idle);
                return;
            }

            if (strategyData.Value.Distance < _distanceToEat)
            {
                fsm.ChangeState(BugStateType.Eating);
                return;
            }

            fsm.NotifyTargetPositionChanged(strategyData.Value.TargetPosition);

        }

        public void Exit(Domain.Bug bug) { }
    }
}