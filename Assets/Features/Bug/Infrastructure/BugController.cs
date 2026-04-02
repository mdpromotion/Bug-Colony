using UnityEngine;
using UnityEngine.AI;

namespace Bug.Infrastructure
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class BugController : MonoBehaviour, IBugController
    {
        private NavMeshAgent agent;

        void Awake() => agent = GetComponent<NavMeshAgent>();

        public void ToggleAgent(bool isActive) 
            => agent.enabled = isActive;

        public void SetTarget(Vector3 position) 
            => agent.SetDestination(position);
    }
}