using Food.Infrastructure;
using UnityEngine;

namespace Food.Application
{
    public class FoodController
    {
        private readonly Domain.Food _food;
        private readonly IFoodView _foodView;
        private readonly ISpawnFoodUseCase _spawnUseCase;

        public FoodController(Domain.Food food, FoodView transformService, ISpawnFoodUseCase useCase)
        {
            _food = food;
            _foodView = transformService;
            _spawnUseCase = useCase;

            food.FoodEaten += FoodEaten;
        }

        public void Spawn(Vector3 position)
        {
            _foodView.SetPosition(position);
        }
        public void FoodEaten()
        {
            _spawnUseCase.DespawnFood(_food, _foodView);
        }
    }
}