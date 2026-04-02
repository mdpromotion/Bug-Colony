using UnityEngine;

namespace Bug.Domain
{
    public interface IMovementStrategy
    {
        Vector3 GetTargetPosition(Bug bug);
    }
}