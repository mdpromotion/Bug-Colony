namespace Bug.Strategies
{
    public class EatOnlyFoodStrategy : IEatingStrategy
    {
        public void Eat(Domain.Bug bug, object eaten)
        {
            switch (eaten)
            {
                //case Food food:
                //    bug.AddFood(food.Nutrition);
                //    break;
                case Domain.Bug otherBug:
                    // Do nothing, this strategy does not eat other bugs
                    break;
            }
        }
    }
}