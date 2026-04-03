using UnityEngine;

namespace Bug.Strategies
{
    public class PredatorReproductionStrategy : IReproductionStrategy
    {
        public Vector3 GetReproductionPosition(Domain.Bug bug)
        {
            return Vector3.zero;
        }
    }
}