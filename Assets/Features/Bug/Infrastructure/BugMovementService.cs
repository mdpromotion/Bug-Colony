using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Bug.Infrastructure
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class BugMovementService : IBugMovementService
    {
        private Dictionary<Domain.Bug, NavMeshAgent> _bugAgents = new();

        public void RegisterBug(Domain.Bug bug, NavMeshAgent agent)
        {
            if (!_bugAgents.ContainsKey(bug))
            {
                _bugAgents.Add(bug, agent);
            }
        }

        public void UnregisterBug(Domain.Bug bug)
        {
            _bugAgents.Remove(bug);
        }

        public void ToggleAgent(Domain.Bug bug, bool isActive)
        {
            if (TryGetAgent(bug, out var agent)) 
            {
                agent.enabled = isActive;
            }
        }

        public void SetTarget(Domain.Bug bug, Vector3 position)
        {
            if (TryGetAgent(bug, out var agent))
                agent.SetDestination(position);
        }

        private bool TryGetAgent(Domain.Bug bug, out NavMeshAgent agent)
        {
            return _bugAgents.TryGetValue(bug, out agent);
        }
    }
}