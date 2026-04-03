using Food.Infrastructure;
using UnityEngine;

namespace Food.Application
{
    public class FoodController
    {
        public Domain.Food Food { get; private set; }
        private readonly IFoodTransformService TransformService;

        public FoodController(Domain.Food food, IFoodTransformService transformService)
        {
            Food = food;
            TransformService = transformService;
        }

        public void Spawn(Vector3 position)
        {
            TransformService.SetPosition(position);
        }
    }
}