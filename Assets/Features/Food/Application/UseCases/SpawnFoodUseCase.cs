using Food.Infrastructure;
using UnityEngine;
using UnityEngine.InputSystem.XR;

namespace Food.Application
{
    public class SpawnFoodUseCase : ISpawnFoodUseCase
    {
        public static readonly string LogTag = nameof(FoodFactory);

        private readonly IFoodFactory _foodFactory;
        private readonly IFoodService _foodService;
        private readonly ILogger _logger;

        public SpawnFoodUseCase(IFoodFactory foodFactory, IFoodService foodService, ILogger logger)
        {
            _foodFactory = foodFactory;
            _foodService = foodService;
            _logger = logger;
        }

        public void SpawnFood(Vector3 origin)
        {
            var spawnPosition = _foodService.GetFreeFoodPosition(origin);
            if (spawnPosition == null)
            {
                _logger.LogWarning(LogTag, "Failed to find free position to spawn food");
                return;
            }

            var factoryOutput = _foodFactory.CreateFood(spawnPosition.Value, this);
            if (!factoryOutput.IsSuccess)
            {
                _logger.LogWarning(LogTag, $"Failed to spawn food: {factoryOutput.Error}");
                return;
            }

            _foodService.AddFood(factoryOutput.Value.Food);
        }

        public void DespawnFood(Domain.Food food, IFoodView foodView)
        {
            _foodFactory.ReturnFood(foodView);
            _foodService.RemoveFood(food);
        }
    }
}