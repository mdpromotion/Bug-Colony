using UnityEngine;

namespace Food.Infrastructure
{
    public interface IFoodService
    {
        void AddFood(Domain.Food food);
        void RemoveFood(Domain.Food food);
        Vector3? GetNearestFood(Vector3 position);
    }
}