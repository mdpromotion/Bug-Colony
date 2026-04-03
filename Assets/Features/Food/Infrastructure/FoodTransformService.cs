using UnityEngine;

namespace Food.Infrastructure
{
    public class FoodTransformService : MonoBehaviour
    {
        public Transform Transform => transform;
        public Vector3 Position => Transform.position;

        public void SetPosition(Vector3 position)
        {
            Transform.position = position;
        }
    }
}