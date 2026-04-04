using UnityEngine;

namespace Food.Infrastructure
{
    public interface IFoodView
    {
        GameObject GetGameObject();
        void SetPosition(Vector3 position);
    }
}