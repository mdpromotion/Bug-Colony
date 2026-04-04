#nullable enable
using UnityEngine;

namespace Food.Infrastructure
{
    public interface IFoodService
    {
        void AddFood(Domain.Food food);
        void RemoveFood(Domain.Food food);
        Vector3? GetFreeFoodPosition(Vector3 origin, float offset = 1f, int maxAttempts = 100);
        int GetFoodCount();
        bool ConsumeNearestFood(Vector3 position, float distance = 0.25f);
        Vector3? GetNearestFood(Vector3 position);
    }
}