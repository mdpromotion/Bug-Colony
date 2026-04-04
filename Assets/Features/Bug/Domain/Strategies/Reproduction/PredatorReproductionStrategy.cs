using Bug.Application;
using Bug.Infrastructure;
using Shared.Provider;

namespace Bug.Strategies
{
    public class PredatorReproductionStrategy : IReproductionStrategy
    {
        private readonly IColonyService _colonyService;
        private readonly IBugEventBus _eventBus;

        private const int FoodRequiredToReproduce = 3;

        public PredatorReproductionStrategy(
            IColonyService colonyService,
            IBugEventBus eventBus)
        {
            _colonyService = colonyService;
            _eventBus = eventBus;
        }

        public bool CanReproduce(Domain.Bug bug) => bug.FoodEaten >= FoodRequiredToReproduce;

        public bool TryReproduce(Domain.Bug bug)
        {
            var spawnPosition = _colonyService.GetFreePosition(bug.Position);
            if (!spawnPosition.HasValue)
                return false;

            bug.SetFood(0);
            bug.ResetLifeTime();

            _eventBus.RaiseSpawnBugRequested(Domain.BugType.Predator, spawnPosition.Value);

            return true;
        }
    }
}