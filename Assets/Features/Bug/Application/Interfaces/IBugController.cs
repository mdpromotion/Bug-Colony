using UnityEngine;

namespace Bug.Infrastructure
{
    public interface IBugController
    {
        void ToggleAgent(bool isActive);
        void SetTarget(Vector3 position);
    }
}