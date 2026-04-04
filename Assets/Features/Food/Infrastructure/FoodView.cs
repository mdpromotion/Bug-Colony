using UnityEngine;

namespace Food.Infrastructure
{
    public class FoodView : MonoBehaviour, IFoodView
    {
        public Transform Transform => transform;
        public Vector3 Position => Transform.position;

        public GameObject GetGameObject() => gameObject;

        public void SetPosition(Vector3 position)
        {
            Transform.position = position;
        }
    }
}