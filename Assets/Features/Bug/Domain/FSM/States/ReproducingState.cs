using Bug.Strategies;

namespace Bug.FSM
{
    public class ReproducingState : IBugState
    {
        private readonly IReproductionStrategy _reproductionStrategy;

        public ReproducingState(IReproductionStrategy reproductionStrategy)
        {
            _reproductionStrategy = reproductionStrategy;
        }

        public void Enter(Domain.Bug bug) { }
        public void Execute(Domain.Bug bug, BugFSM fsm)
        {
            if (_reproductionStrategy.CanReproduce(bug))
            {
                _reproductionStrategy.TryReproduce(bug);
                fsm.ChangeState(BugStateType.Idle);
            }
        }

        public void Exit(Domain.Bug bug) { }
    }
}
