using UnityEngine;
using UnityEngine.AI;

namespace Bug.Infrastructure
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class BugMovementService : MonoBehaviour, IBugMovementService
    {
        private NavMeshAgent _agent;

        void Awake() => _agent = GetComponent<NavMeshAgent>();

        public void ToggleAgent(bool isActive)
        {
            _agent.enabled = isActive;
        }

        public void SetTarget(Vector3 position)
        {
            _agent.SetDestination(position);
        }

    }
}