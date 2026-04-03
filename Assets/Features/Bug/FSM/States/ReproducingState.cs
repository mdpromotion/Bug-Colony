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

        public void Enter(Domain.Bug bug)
        {
            
        }
        public void Execute(Domain.Bug bug)
        {
            // Reproduction logic here
        }

        public void Exit(Domain.Bug bug)
        {

        }

    }
}
