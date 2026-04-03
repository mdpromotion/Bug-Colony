using System.Collections.Generic;
using UnityEngine;

namespace Food.Infrastructure
{
    public class FoodService : IFoodService
    {
        private readonly List<Domain.Food> _foodList = new();

        public void AddFood(Domain.Food food)
        {
            if (_foodList.Contains(food))
                return;

            _foodList.Add(food);
        }

        public void RemoveFood(Domain.Food food)
        {
            _foodList.Remove(food);
        }

        public Vector3? GetNearestFood(Vector3 position)
        {
            Domain.Food bestFood = null;
            float bestDistance = float.MaxValue;

            foreach (var food in _foodList) 
            {
                var distanceSqr = (position - food.Position).sqrMagnitude;
                if (distanceSqr > bestDistance) 
                {
                    bestDistance = distanceSqr;
                    bestFood = food;
                }
            }
            return bestFood?.Position;
        }
    }
}