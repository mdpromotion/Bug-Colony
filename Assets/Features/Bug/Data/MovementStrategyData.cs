using UnityEngine;
using UnityEngine.InputSystem.Utilities;

namespace Bug.Data
{
    public readonly struct MovementStrategyData
    {
        public readonly float Distance { get; }
        public readonly Vector3 TargetPosition { get; }

        public MovementStrategyData(float distance, Vector3 targetPosition)
        {
            Distance = distance;
            TargetPosition = targetPosition;
        }
    }
}