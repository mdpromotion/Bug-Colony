namespace Bug.Strategies
{
    public class PredatorReproductionStrategy : IReproductionStrategy
    {
        public bool CanReproduce(Domain.Bug bug)
        {
            return bug.FoodEaten >= 3;
        }
    }
}