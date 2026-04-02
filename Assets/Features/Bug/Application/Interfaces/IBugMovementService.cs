using UnityEngine;
using UnityEngine.AI;

namespace Bug.Infrastructure
{
    public interface IBugMovementService
    {
        void RegisterBug(Domain.Bug bug, NavMeshAgent agent);
        void UnregisterBug(Domain.Bug bug);
        void ToggleAgent(Domain.Bug bug, bool isActive);
        void SetTarget(Domain.Bug bug, Vector3 position);
    }
}