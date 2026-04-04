using UnityEngine;

namespace Bug.Infrastructure
{
    public interface IBugView
    {
        Vector3 GetPosition();
        GameObject GetGameObject();
        void SetPosition(Vector3 position);
        void ToggleAgent(bool isActive);
        void SetTarget(Vector3 position);
    }
}