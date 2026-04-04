#nullable enable
using UnityEngine;
using System.Collections.Generic;

namespace Bug.Infrastructure
{
    public class ColonyService : IColonyService
    {
        private readonly List<Domain.Bug> _bugs = new();

        public void AddBug(Domain.Bug bug)
        {
            if (_bugs.Contains(bug)) return;

            _bugs.Add(bug);
        }

        public void RemoveBug(Domain.Bug bug) => _bugs.Remove(bug);

        public int GetBugCount() => _bugs.Count;

        public bool ConsumeNearestBug(Vector3 position, System.Func<Domain.Bug, bool> filter, float distance = 0.3f)
        {
            var bug = GetNearestBugInternal(position, filter, distance);
            if (bug == null)
                return false;

            Debug.Log($"Consumed bug at {bug.Position}");

            bug.Die();
            return true;
        }

        public Vector3? GetNearestBug(Vector3 position, System.Func<Domain.Bug, bool> filter)
        {
            return GetNearestBugInternal(position, filter)?.Position;
        }

        private Domain.Bug? GetNearestBugInternal(Vector3 position, System.Func<Domain.Bug, bool> filter, float distance = 100f)
        {
            Domain.Bug? bestBug = null;
            float bestDistance = float.MaxValue;

            foreach (var bug in _bugs)
            {
                if (!filter(bug))
                    continue;

                var distanceSqr = (position - bug.Position).sqrMagnitude;
                if (distanceSqr > distance)
                    continue;

                if (distanceSqr < bestDistance)
                {
                    bestBug = bug;
                    bestDistance = distanceSqr;
                }
            }
            return bestBug;
        }

        public Vector3? GetFreePosition(Vector3 origin, float offset = 1f, int maxAttempts = 100)
        {
            for (int i = 0; i < maxAttempts; i++)
            {
                var randomOffset = new Vector3(
                    Random.Range(-offset, offset),
                    0,
                    Random.Range(-offset, offset)
                );

                var candidate = origin + randomOffset;

                bool isOccupied = false;
                foreach (var bug in _bugs)
                {
                    if ((bug.Position - candidate).sqrMagnitude < offset * offset)
                    {
                        isOccupied = true;
                        break;
                    }
                }

                if (!isOccupied)
                    return candidate;
            }

            return null;
        }
    }
}