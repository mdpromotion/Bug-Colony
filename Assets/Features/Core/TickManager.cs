using Shared.Abstractions;
using UnityEngine;
using Zenject;

namespace Core.Tick
{
    public class TickManager : ITick, IFixedTickable
    {
        private readonly float _tickInterval = 0.1f; // 1 tick every 0.1 seconds
        private float _tickTimer;

        public event System.Action Tick;

        public void FixedTick()
        {
            _tickTimer += Time.fixedDeltaTime;

            if (_tickTimer < _tickInterval)
                return;

            Tick?.Invoke();
            _tickTimer -= _tickInterval;
        }
    }
}