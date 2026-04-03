using Food.Infrastructure;
using UnityEngine;

namespace Food.Application
{
    public class SpawnFoodUseCase : ISpawnFoodUseCase
    {
        public static readonly string LogPrefix = nameof(FoodFactory);

        private readonly IFoodFactory _foodFactory;
        private readonly IFoodService _foodService;
        private readonly ILogger _logger;

        public SpawnFoodUseCase(IFoodFactory foodFactory, IFoodService foodService, ILogger logger)
        {
            _foodFactory = foodFactory;
            _foodService = foodService;
            _logger = logger;
        }

        public void SpawnFood()
        {
            var factoryOutput = _foodFactory.CreateFood(Vector3.zero);
            if (!factoryOutput.HasValue)
            {
                _logger.LogWarning(LogPrefix, "Failed to spawn food.");
                return;
            }
            _foodService.AddFood(factoryOutput.Value.Food);
        }
    }
}