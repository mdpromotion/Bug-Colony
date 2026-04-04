using Bug.Domain;
using Bug.Infrastructure;
using System;
using UnityEngine;

namespace Bug.Application
{
    public interface IBugEventBus
    {
        event Action<BugType, Vector3> SpawnBugRequested;
        event Action<Domain.Bug, IBugView> DespawnBugRequested;
        void RaiseSpawnBugRequested(BugType bugType, Vector3 position);
        void RaiseDespawnBugRequested(Domain.Bug bug, IBugView view);
    }
}