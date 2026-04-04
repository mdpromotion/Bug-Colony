#nullable enable
using Bug.Domain;
using System.Collections.Generic;
using System.Linq;
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

        public int GetFoodCount() => _foodList.Count;

        public Vector3? GetFreeFoodPosition(Vector3 origin, float offset = 1f, int maxAttempts = 100)
        {
            for (int i = 0; i < maxAttempts; i++)
            {
                var randomOffset = new Vector3(
                    Random.Range(-offset, offset),
                    0,
                    Random.Range(-offset, offset)
                );

                var candidate = origin + randomOffset;

                bool isOccupied = false;
                foreach (var food in _foodList)
                {
                    if ((food.Position - candidate).sqrMagnitude < offset * offset)
                    {
                        isOccupied = true;
                        break;
                    }
                }

                if (!isOccupied)
                    return candidate;
            }

            return null;
        }

        public bool ConsumeNearestFood(Vector3 position, float distance = 0.25f)
        {
            var food = GetNearestFoodInternal(position, distance);
            if (food == null)
                return false;

            food.Eat();
            _foodList.Remove(food);
            return true;
        }

        public Vector3? GetNearestFood(Vector3 position)
        {
            return GetNearestFoodInternal(position)?.Position;
        }

        private Domain.Food? GetNearestFoodInternal(Vector3 position, float distance = float.MaxValue)
        {
            Domain.Food? bestFood = null;
            float bestDistance = float.MaxValue;

            foreach (var food in _foodList)
            {
                var distanceSqr = (position - food.Position).sqrMagnitude;

                if (distanceSqr > distance)
                    continue;

                if (distanceSqr < bestDistance)
                {
                    bestDistance = distanceSqr;
                    bestFood = food;
                }
            }

            return bestFood;
        }

    }
}