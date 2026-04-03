using UnityEngine;

namespace Bug.Infrastructure
{
    public interface IColonyService
    {
        void AddBug(Domain.Bug bug);
        void RemoveBug(Domain.Bug bug);
        Vector3? GetNearestBug(Vector3 position, System.Func<Domain.Bug, bool> filter);
    }
}