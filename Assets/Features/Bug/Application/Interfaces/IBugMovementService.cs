using UnityEngine;

namespace Bug.Infrastructure
{
    public interface IBugMovementService
    {
        void ToggleAgent(bool isActive);
        void SetTarget(Vector3 position);
    }
}