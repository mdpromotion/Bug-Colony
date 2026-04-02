using UnityEngine;

namespace Bug.Domain
{
    public interface IReproductionStrategy
    {
        Vector3 GetReproductionPosition(Bug bug);
    }
}