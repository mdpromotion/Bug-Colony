using UnityEngine;

namespace Shared.Provider
{
    public class RandomProvider : IRandomProvider
    {
        public float GetRandom() => Random.value;
        public Vector3 GetRandomVector(float range, bool freezeY = true)
        {
            return new Vector3(
                Random.Range(-range, range),
                freezeY ? 0 : Random.Range(-range, range),
                Random.Range(-range, range)
            );
        }
    }
}