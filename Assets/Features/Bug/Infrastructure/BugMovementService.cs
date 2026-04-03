using UnityEngine;
using UnityEngine.AI;

namespace Bug.Infrastructure
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(Transform))]
    public class BugMovementService : MonoBehaviour, IBugMovementService
    {
        private NavMeshAgent _agent;
        private Transform _transform;

        void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _transform = GetComponent<Transform>();
        }

        public Vector3 GetPosition() => _transform.position;

        public void ToggleAgent(bool isActive)
        {
            _agent.isStopped = isActive;
        }

        public void SetTarget(Vector3 position)
        {
            _agent.SetDestination(position);
        }

    }
}