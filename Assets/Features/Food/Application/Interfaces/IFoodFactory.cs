using Food.Data;
using UnityEngine;

namespace Food.Infrastructure
{
    public interface IFoodFactory
    {
        FactoryOutput? CreateFood(Vector3 position);
    }
}