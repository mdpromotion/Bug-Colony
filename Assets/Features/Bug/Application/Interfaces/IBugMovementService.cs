using UnityEngine;

namespace Bug.Infrastructure
{
    public interface IBugMovementService
    {
        Vector3 GetPosition();
        void ToggleAgent(bool isActive);
        void SetTarget(Vector3 position);
    }
}