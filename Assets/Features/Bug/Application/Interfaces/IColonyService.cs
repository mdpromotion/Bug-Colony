using UnityEngine;

namespace Bug.Infrastructure
{
    public interface IColonyService
    {
        void AddBug(Domain.Bug bug);
        void RemoveBug(Domain.Bug bug);
        int GetBugCount();
        bool ConsumeNearestBug(Vector3 position, System.Func<Domain.Bug, bool> filter, float distance = 0.3f);
        Vector3? GetNearestBug(Vector3 position, System.Func<Domain.Bug, bool> filter);
        Vector3? GetFreePosition(Vector3 origin, float offset = 1f, int maxAttempts = 100);
    }
}