using Bug.Domain;
using Bug.FSM;
using Bug.Strategies;
using System.Collections.Generic;

namespace Bug.Application.Factories
{
    public class BugFSMFactory
    {
        private readonly Dictionary<BugType, IMovementStrategy> _movementStrategies;
        private readonly Dictionary<BugType, IEatingStrategy> _eatingStrategies;
        private readonly Dictionary<BugType, IReproductionStrategy> _reproductionStrategies;

        public BugFSMFactory(
            Dictionary<BugType, IMovementStrategy> movementStrategies,
            Dictionary<BugType, IEatingStrategy> eatingStrategies,
            Dictionary<BugType, IReproductionStrategy> reproductionStrategies)
        {
            _movementStrategies = movementStrategies;
            _eatingStrategies = eatingStrategies;
            _reproductionStrategies = reproductionStrategies;
        }

        public BugFSM CreateBugFSM(Domain.Bug bug)
        {
            var movementStrategy = _movementStrategies[bug.Type];
            var eatingStrategy = _eatingStrategies[bug.Type];
            var reproductionStrategy = _reproductionStrategies[bug.Type];
            var states = new Dictionary<BugStateType, IBugState>
            {
                { BugStateType.Idle, new IdleState(movementStrategy, eatingStrategy) },
                { BugStateType.Moving, new MovingState(movementStrategy, eatingStrategy) },
                { BugStateType.Reproducing, new ReproducingState(reproductionStrategy) }
            };
            var fsm = new BugFSM(bug, states);
            fsm.ChangeState(BugStateType.Idle);
            return fsm;
        }
    }
}