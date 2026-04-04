using Food.Infrastructure;
using Shared.Abstractions;
using Shared.Provider;
using System;
using Zenject;

namespace Food.Application
{
    public class FoodSpawnerController : IInitializable, IDisposable
    {
        private readonly IFoodService _foodService;
        private readonly ISpawnFoodUseCase _spawnUseCase;
        private readonly IRandomProvider _randomProvider;
        private readonly ITick _tick;

        private const int MaxFoodCount = 20;
        private const float playRange = 5f;

        private const float FoodSpawnRate = 20f; // in ticks
        private float _spawnTimer = 0f;

        public FoodSpawnerController(IFoodService foodService, ISpawnFoodUseCase spawnUseCase, IRandomProvider randomProvider, ITick tick)
        {
            _foodService = foodService;
            _spawnUseCase = spawnUseCase;
            _randomProvider = randomProvider;
            _tick = tick;
        }

        public void Initialize()
        {
            _tick.Tick += OnTick;
        }

        private void OnTick()
        {
            if (_foodService.GetFoodCount() >= MaxFoodCount)
                return;

            _spawnTimer++;
            if (_spawnTimer < FoodSpawnRate)
                return;

            _spawnTimer = 0f;
            var randomPosition = _randomProvider.GetRandomVector(playRange);

            _spawnUseCase.SpawnFood(randomPosition);
        }

        public void Dispose() 
        {
            _tick.Tick -= OnTick;
        }
    }
}