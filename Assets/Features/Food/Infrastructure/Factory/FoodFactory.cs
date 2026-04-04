using Bug.Infrastructure;
using Food.Application;
using Food.Data;
using Shared.Services;
using UnityEngine;

namespace Food.Infrastructure
{
    public class FoodFactory : IFoodFactory
    {
        private readonly IGameObjectService _gameObjectService;

        public FoodFactory(IGameObjectService gameObjectService)
        {
            _gameObjectService = gameObjectService;
        }

        public Result<FactoryOutput> CreateFood(Vector3 position, ISpawnFoodUseCase useCase)
        {
            var obj = _gameObjectService.GetObject(ObjectType.Food);
            if (obj == null)
                return Result<FactoryOutput>.Failure("Failed to get a food object from the pool.");

            if (!obj.TryGetComponent<FoodView>(out var foodView))
                return Result<FactoryOutput>.Failure("The retrieved object does not have a FoodView component.");

            var food = new Domain.Food(position);
            var controller = new FoodController(food, foodView, useCase);
            controller.Spawn(position);

            return Result<FactoryOutput>.Success(new FactoryOutput(food, controller));
        }
        public void ReturnFood(IFoodView view)
        {
            _gameObjectService.ReturnObject(view.GetGameObject());
        }
    }
}