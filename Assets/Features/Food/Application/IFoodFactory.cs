using UnityEngine;

namespace Food.Application
{
    public interface IFoodFactory
    {
        void CreateFood(Vector3 position);
    }
}