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

        public FactoryOutput? CreateFood(Vector3 position)
        {
            var obj = _gameObjectService.GetObject(ObjectType.Food);
            if (obj == null)
                return null;

            if (!obj.TryGetComponent<IFoodTransformService>(out var transformService))
                return null;

            var food = new Domain.Food(position);
            var controller = new FoodController(food, transformService);
            controller.Spawn(position);
            return new FactoryOutput(food, controller);
        }
    }
}