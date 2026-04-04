using Bug.Domain;
using Bug.Infrastructure;
using Shared.Abstractions;
using System;
using UnityEngine;
using Zenject;

namespace Bug.Application
{
    public class ColonyController : IInitializable, IDisposable
    {
        private readonly IBugEventBus _eventBus;
        private readonly IColonyService _colonyService;
        private readonly ITick _tick;

        public ColonyController(IBugEventBus eventBus, IColonyService colonyService, ITick tick)
        {
            _eventBus = eventBus;
            _colonyService = colonyService;
            _tick = tick;
        }

        public void Initialize()
        {
            _tick.Tick += Tick;
        }

        public void Tick()
        {
            if (_colonyService.GetBugCount() <= 0)
            {
                _eventBus.RaiseSpawnBugRequested(BugType.Worker, Vector3.zero);
            }
        }

        public void Dispose() 
        {
            _tick.Tick -= Tick;
        }


    }
}