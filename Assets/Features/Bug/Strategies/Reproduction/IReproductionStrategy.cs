using UnityEngine;

namespace Bug.Strategies
{
    public interface IReproductionStrategy
    {
        Vector3 GetReproductionPosition(Domain.Bug bug);
    }
}