using Bug.Domain;
using Bug.Infrastructure;
using UnityEngine;

namespace Bug.Application
{
    public interface ISpawnBugUseCase
    {
        void SpawnBug(BugType type, Vector3 position = default);
        void DespawnBug(Domain.Bug bug, IBugView bugView);
    }
}