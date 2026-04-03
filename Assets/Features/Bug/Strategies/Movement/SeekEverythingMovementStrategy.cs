using Bug.Infrastructure;
using UnityEngine;

namespace Bug.Strategies
{
    public class SeekEverythingMovementStrategy : IMovementStrategy
    {
        //private readonly IFoodService _foodService;
        private readonly IColonyService _colonyService;

        public SeekEverythingMovementStrategy()
        {
            //_foodPerEat = foodPerEat;
        }

        public Vector3 GetTargetPosition(Domain.Bug bug)
        {
            //var foodPosition = _foodService.GetNearestFoodPosition(bug.Position);
            //var bugPosition = _colonyService.GetNearestBugPosition(bug.Position);

            //Vector3 target = bug.Position;
            //float bestDistance = float.MaxValue;

            /*if (foodPosition.HasValue)
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
                    target = bugPosition.Value;
                }
            }

            return target;
             */

            return Vector3.zero; // Placeholder
        }
    }
}