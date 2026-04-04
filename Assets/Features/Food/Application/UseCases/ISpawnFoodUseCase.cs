using Food.Infrastructure;
using UnityEngine;

namespace Food.Application
{
    public interface ISpawnFoodUseCase
    {
        void SpawnFood(Vector3 position = default);
        void DespawnFood(Domain.Food food, IFoodView foodView);
    }
}