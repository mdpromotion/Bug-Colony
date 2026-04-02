using UnityEngine;

namespace Bug.Domain
{
    public class Bug
    {
        public Vector3 Position { get; private set; } // If this was production code, I would make a special value-object for this, but for the sake of this demo, I think it's fine.
        public IMovementStrategy MovementStrategy { get; private set; }
        public IEatingStrategy EatingStrategy { get; private set; }
        public IReproductionStrategy ReproductionStrategy { get; private set; }

        public Bug(IMovementStrategy movementStrategy, IEatingStrategy eatingStrategy, IReproductionStrategy reproductionStrategy)
        {
            MovementStrategy = movementStrategy;
            EatingStrategy = eatingStrategy;
            ReproductionStrategy = reproductionStrategy;
        }

        public void SetPosition(Vector3 position)
        {
            Position = position;
        }
    }
}