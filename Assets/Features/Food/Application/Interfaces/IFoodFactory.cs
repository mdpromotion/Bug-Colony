using Bug.Infrastructure;
using Food.Application;
using Food.Data;
using UnityEngine;

namespace Food.Infrastructure
{
    public interface IFoodFactory
    {
        Result<FactoryOutput> CreateFood(Vector3 position, ISpawnFoodUseCase useCase);
        void ReturnFood(IFoodView view);
    }
}