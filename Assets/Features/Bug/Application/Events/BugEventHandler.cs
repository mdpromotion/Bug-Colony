using Bug.Domain;
using Bug.Infrastructure;
using System;
using UnityEngine;
using Zenject;

namespace Bug.Application
{
    public class BugEventHandler : IInitializable, IDisposable
    {
        private readonly IBugEventBus _eventBus;
        private readonly ISpawnBugUseCase _spawnBugUseCase;

        public BugEventHandler(IBugEventBus eventBus, ISpawnBugUseCase spawnBugUseCase)
        {
            _eventBus = eventBus;
            _spawnBugUseCase = spawnBugUseCase;
        }

        public void Initialize()
        {
            _eventBus.SpawnBugRequested += OnSpawnBugRequested;
            _eventBus.DespawnBugRequested += OnDespawnBugRequested;
        }

        private void OnSpawnBugRequested(BugType type, Vector3 position)
        {
            _spawnBugUseCase.SpawnBug(type, position);
        }

        private void OnDespawnBugRequested(Domain.Bug bug, IBugView bugView)
        {
            _spawnBugUseCase.DespawnBug(bug, bugView);
        }

        public void Dispose()
        {
            _eventBus.SpawnBugRequested -= OnSpawnBugRequested;
            _eventBus.DespawnBugRequested -= OnDespawnBugRequested;
        }
    }
}