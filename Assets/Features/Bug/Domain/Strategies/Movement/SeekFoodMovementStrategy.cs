using Bug.Data;
using Food.Infrastructure;

namespace Bug.Strategies
{
    public class SeekFoodMovementStrategy : IMovementStrategy
    {
        private readonly IFoodService _foodService;

        public SeekFoodMovementStrategy(IFoodService foodService)
        {
            _foodService = foodService;
        }

        public MovementStrategyData? GetTargetPosition(Domain.Bug bug)
        {
            var foodPosition = _foodService.GetNearestFood(bug.Position);
            if (!foodPosition.HasValue)
                return null;

            float distanceSqr = (bug.Position - foodPosition.Value).sqrMagnitude;
            return new MovementStrategyData(distanceSqr, foodPosition.Value);
        }
    }
}