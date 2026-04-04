using Bug.Infrastructure;
using Food.Infrastructure;

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
            bool foodEaten = _foodService.ConsumeNearestFood(bug.Position);
            if (foodEaten) // if there is no food, eat the nearest bug of a different type
                return;


            _colonyService.ConsumeNearestBug(bug.Position, f => f.Type != bug.Type);
        }

    }
}