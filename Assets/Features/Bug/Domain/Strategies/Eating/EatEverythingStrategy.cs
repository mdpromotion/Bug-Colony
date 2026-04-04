using Bug.Infrastructure;
using Food.Infrastructure;
using Bug.Domain;
using UnityEngine;

namespace Bug.Strategies
{
    public class EatEverythingStrategy : IEatingStrategy
    {
        private readonly IFoodService _foodService;
        private readonly IColonyService _colonyService;

        public EatEverythingStrategy(IFoodService foodService, IColonyService colonyService)
        {
            _foodService = foodService;
            _colonyService = colonyService;
        }

        public void Eat(Domain.Bug bug)
        {
            Debug.LogWarning($"Bug at {bug.Position} is trying to eat.");
            bool foodEaten = _foodService.ConsumeNearestFood(bug.Position);
            Debug.LogWarning(foodEaten); 
            if (foodEaten) // if there is no food, eat the nearest bug of a different type
                return;

            Debug.LogWarning($"Bug at {bug.Position} ate food.");

            _colonyService.ConsumeNearestBug(bug.Position, f => f.Type != bug.Type);
        }

    }
}