using Bug.Strategies;

namespace Bug.FSM
{
    public class EatingState : IBugState
    {
        private readonly IEatingStrategy _eatingStrategy;
        private readonly IReproductionStrategy _reproductionStrategy;

        public EatingState(IEatingStrategy eatingStrategy, IReproductionStrategy reproductionStrategy)
        {
            _eatingStrategy = eatingStrategy;
            _reproductionStrategy = reproductionStrategy;
        }

        public void Enter(Domain.Bug bug) 
        {
            _eatingStrategy.Eat(bug);
        }
        public void Execute(Domain.Bug bug, BugFSM fsm)
        {
            bool canReproduce = _reproductionStrategy.CanReproduce(bug);
            if (canReproduce) 
            {
                fsm.ChangeState(BugStateType.Reproducing);
                return;
            }
            fsm.ChangeState(BugStateType.Moving);
        }
        public void Exit(Domain.Bug bug) { }
    }
}