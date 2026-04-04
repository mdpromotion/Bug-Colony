using Bug.Domain;
using Bug.Infrastructure;
using UnityEngine;
using System;

namespace Bug.Application
{
    public class BugEventBus : IBugEventBus
    {
        public event Action<BugType, Vector3> SpawnBugRequested;
        public event Action<Domain.Bug, IBugView> DespawnBugRequested;

        public void RaiseSpawnBugRequested(BugType bugType, Vector3 position)
        {
            SpawnBugRequested?.Invoke(bugType, position);
        }

        public void RaiseDespawnBugRequested(Domain.Bug bug, IBugView view)
        {
            DespawnBugRequested?.Invoke(bug, view);
        }
    }
}