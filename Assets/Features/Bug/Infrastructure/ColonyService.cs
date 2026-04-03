using R3;
using UnityEngine;
using System.Collections.Generic;

namespace Bug.Infrastructure
{
    public class ColonyService : IColonyService
    {
        private readonly List<Domain.Bug> _bugs = new();
        private readonly Subject<Domain.Bug> _onBugDied = new();

        public Subject<Domain.Bug> OnBugDied => _onBugDied;

        public void AddBug(Domain.Bug bug)
        {
            if (_bugs.Contains(bug)) return;

            _bugs.Add(bug);

            bug.OnDied.Subscribe(d =>
            {
                RemoveBug(d);
                _onBugDied.OnNext(d);
            }).AddTo(bug.Disposables);
        }

        public void RemoveBug(Domain.Bug bug) => _bugs.Remove(bug);

        public Vector3? GetNearestBug(Vector3 position, System.Func<Domain.Bug, bool> filter)
        {
            Domain.Bug? bestBug = null;
            float bestDistanceSqr = float.MaxValue;

            foreach (var bug in _bugs)
            {
                if (!filter(bug)) continue;

                var distanceSqr = (position - bug.Position).sqrMagnitude;
                if (distanceSqr < bestDistanceSqr)
                {
                    bestBug = bug;
                    bestDistanceSqr = distanceSqr;
                }
            }

            return bestBug?.Position;
        }
    }
}