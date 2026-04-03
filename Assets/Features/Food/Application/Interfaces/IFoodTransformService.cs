using UnityEngine;

namespace Food.Infrastructure
{
    public interface IFoodTransformService
    {
        void SetPosition(Vector3 position);
    }
}