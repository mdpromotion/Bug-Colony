using UnityEngine;

namespace Bug.Strategies
{
    public class SeekFoodMovementStrategy : IMovementStrategy
    {
        //private readonly IFoodService _foodService;

        public SeekFoodMovementStrategy()
        {
            //_foodPerEat = foodPerEat;
        }

        public Vector3? GetTargetPosition(Domain.Bug bug)
        {
            //var foodPosition = _foodService.GetNearestFoodPosition(bug.Position);
            //return foodPosition;
            return null; // Placeholder
        }
    }
}