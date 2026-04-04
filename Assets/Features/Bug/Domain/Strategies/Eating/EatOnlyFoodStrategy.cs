using Food.Infrastructure;

namespace Bug.Strategies
{
    public class EatOnlyFoodStrategy : IEatingStrategy
    {
        private readonly IFoodService _foodService;

        public EatOnlyFoodStrategy(IFoodService foodService)
        {
            _foodService = foodService;
        }

        public void Eat(Domain.Bug bug)
        {
            if (_foodService.ConsumeNearestFood(bug.Position))
                bug.AddFood(1);
        }
    }
}