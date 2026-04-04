using Bug.Application;
using Shared.Abstractions;
using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Bug.Infrastructure
{
    public class BugAIController : IInitializable, IDisposable, IBugAIController
    {
        private readonly Dictionary<Domain.Bug, IBugController> _controllers = new();
        private readonly List<IBugController> _controllerCache = new();

        private readonly ITick _tickManager;

        public BugAIController(ITick tickManager)
        {
            _tickManager = tickManager;
        }

        public void Initialize()
        {
            _tickManager.Tick += Tick;
        }

        public void Dispose()
        {
            _tickManager.Tick -= Tick;
            foreach (var controller in _controllers.Values)
            {
                controller.Dispose();
            }
            _controllers.Clear();
        }

        public void RegisterController(Domain.Bug bug, IBugController controller)
        {
            if (_controllers.ContainsKey(bug))
                return;

            _controllers.Add(bug, controller);
        }

        public void UnregisterController(Domain.Bug bug)
        {
            var controller = _controllers[bug];
            if (controller == null)
                return;

            controller.Dispose();
            _controllers.Remove(bug);
        }

        public void Tick()
        {
            _controllerCache.Clear();
            _controllerCache.AddRange(_controllers.Values);

            foreach (var controller in _controllerCache)
            {
                controller.Tick();
            }
        }
    }
}