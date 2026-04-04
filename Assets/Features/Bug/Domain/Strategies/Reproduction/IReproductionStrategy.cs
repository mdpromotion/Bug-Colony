using UnityEngine;

namespace Bug.Strategies
{
    public interface IReproductionStrategy
    {
        bool CanReproduce(Domain.Bug bug);
        bool TryReproduce(Domain.Bug bug);
    }
}