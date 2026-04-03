using Bug.Application;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Bug.Infrastructure
{
    public class BugAIController : ITickable
    {
        private List<IBugController> _controllers = new();

        private float _timer;
        private readonly float _interval;

        public BugAIController(float aiUpdateInterval = 0.2f)
        {
            _interval = aiUpdateInterval;
        }

        public void RegisterController(IBugController controller)
        {
            if (_controllers == null || _controllers.Contains(controller))
                return;

            _controllers.Add(controller);
        }

        public void UnregisterController(IBugController controller)
        {
            _controllers.Remove(controller);
        }

        public void Tick()
        {
            _timer += Time.deltaTime;

            if (_timer < _interval)
                return;

            _timer = 0;

            foreach (var controller in _controllers)
            {
                controller.Tick();
            }
        }
    }
}