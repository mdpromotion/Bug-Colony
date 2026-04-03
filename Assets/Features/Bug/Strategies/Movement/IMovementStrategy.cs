using UnityEngine;

namespace Bug.Strategies
{
    public interface IMovementStrategy
    {
        Vector3 GetTargetPosition(Domain.Bug bug);
    }
}