using Bug.Application;
using Bug.Infrastructure;
using Shared.Provider;
using UnityEngine;

namespace Bug.Strategies
{
    public class PredatorReproductionStrategy : IReproductionStrategy
    {
        private readonly IRandomProvider _randomProvider;
        private readonly IColonyService _colonyService;
        private readonly IBugEventBus _eventBus;

        private const int FoodRequiredToReproduce = 2;
        private const int BugsToMutate = 10;
        private const float MutationChance = 0.1f;

        public PredatorReproductionStrategy(
            IRandomProvider randomProvider,
            IColonyService colonyService,
            IBugEventBus eventBus)
        {
            _randomProvider = randomProvider;
            _colonyService = colonyService;
            _eventBus = eventBus;
        }

        public bool CanReproduce(Domain.Bug bug) => bug.FoodEaten >= FoodRequiredToReproduce;

        public bool TryReproduce(Domain.Bug bug)
        {
            var spawnPosition = _colonyService.GetFreePosition(bug.Position);
            if (!spawnPosition.HasValue)
                return false;

            Debug.LogError(bug.FoodEaten);

            bug.SetFood(0);

            Debug.LogWarning($"Found free position for reproduction at {spawnPosition.Value}");

            if (_colonyService.GetBugCount() > BugsToMutate)
            {
                var randomValue = _randomProvider.GetRandom();

                if (randomValue < MutationChance)
                {
                    _eventBus.RaiseSpawnBugRequested(Domain.BugType.Predator, spawnPosition.Value);
                    return true;
                }
            }

            _eventBus.RaiseSpawnBugRequested(Domain.BugType.Worker, spawnPosition.Value);

            Debug.LogWarning($"Spawned new Worker bug at position {spawnPosition.Value}");

            Debug.LogWarning("Reproduction process finished successfully.");
            return true;
        }
    }
}