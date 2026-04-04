using Bug.Application;
using Bug.Infrastructure;
using System;
using UnityEngine;
using Zenject;

namespace Bug.Presentation
{
    public class Presenter : IInitializable, IDisposable
    {
        private readonly BugsData _data;
        private readonly IView _view;
        private readonly IBugEventBus _eventBus;

        public Presenter(BugsData data, IView view, IBugEventBus eventBus)
        {
            _view = view;
            _eventBus = eventBus;
        }

        public void Initialize()
        {
            _eventBus.DespawnBugRequested += OnBugDespawned;
            _view.UpdatePredatorsDeaths(0);
            _view.UpdateWorkersDeaths(0);
        }

        public void Dispose()
        {
            _eventBus.DespawnBugRequested -= OnBugDespawned;
        }

        private void OnBugDespawned(Domain.Bug bug, IBugView view)
        {
            _data.AddDeath(bug.Type);
            switch (bug.Type) 
            {
                case Domain.BugType.Worker:
                    _view.UpdateWorkersDeaths(_data.GetDeathCount(Domain.BugType.Worker));
                    break;
                case Domain.BugType.Predator:
                    _view.UpdatePredatorsDeaths(_data.GetDeathCount(Domain.BugType.Predator));
                    break;
            }
        }
    }
}