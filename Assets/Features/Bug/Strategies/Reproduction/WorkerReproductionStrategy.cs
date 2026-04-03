using UnityEngine;

namespace Bug.Strategies
{
    public class WorkerReproductionStrategy : IReproductionStrategy
    {
        public bool CanReproduce(Domain.Bug bug)
        {
            return bug.FoodEaten >= 2;
        }
    }
}