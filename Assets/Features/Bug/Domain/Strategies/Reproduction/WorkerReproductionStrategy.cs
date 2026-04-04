using Bug.Application;
using Bug.Infrastructure;
using Shared.Provider;
using System;
using UnityEngine;

namespace Bug.Strategies
{
    public class WorkerReproductionStrategy : IReproductionStrategy
    {
        private readonly IRandomProvider _randomProvider;
        private readonly IColonyService _colonyService;
        private readonly IBugEventBus _eventBus;

        private const int FoodRequiredToReproduce = 2;
        private const int BugsToMutate = 10;
        private const float MutationChance = 0.1f;

        public WorkerReproductionStrategy(
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

            bug.SetFood(0);

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

            return true;
        }
    }
}