using UnityEngine;

namespace Food.Infrastructure
{
    public interface IFoodService
    {
        Vector3? GetNearestFood(Vector3 position);
    }
}