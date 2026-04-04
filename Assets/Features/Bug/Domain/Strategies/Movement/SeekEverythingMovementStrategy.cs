using Bug.Data;
using Bug.Infrastructure;
using Food.Infrastructure;
using UnityEngine;

namespace Bug.Strategies
{
    public class SeekEverythingMovementStrategy : IMovementStrategy
    {
        private readonly IFoodService _foodService;
        private readonly IColonyService _colonyService;

        public SeekEverythingMovementStrategy(IFoodService foodService, IColonyService colonyService)
        {
            _foodService = foodService;
            _colonyService = colonyService;
        }

        public MovementStrategyData? GetTargetPosition(Domain.Bug bug)
        {
            var foodPosition = _foodService.GetNearestFood(bug.Position);
            var bugPosition = _colonyService.GetNearestBug(bug.Position);

            Vector3? target = null;
            float bestDistanceSqr = float.MaxValue;

            if (foodPosition.HasValue)
            {
                float distSqr = (foodPosition.Value - bug.Position).sqrMagnitude;
                if (distSqr < bestDistanceSqr)
                {
                    bestDistanceSqr = distSqr;
                    target = foodPosition.Value;
                }
            }

            if (bugPosition.HasValue)
            {
                float distSqr = (bugPosition.Value - bug.Position).sqrMagnitude;
                if (distSqr < bestDistanceSqr)
                {
                    bestDistanceSqr = distSqr;
                    target = bugPosition.Value;
                }
            }

            return target != null ? new MovementStrategyData(bestDistanceSqr, target.Value) : null;
        }
    }
}