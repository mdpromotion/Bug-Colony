using UnityEngine;

namespace Shared.Provider
{
    public interface IRandomProvider
    {
        float GetRandom();
        Vector3 GetRandomVector(float range, bool freezeY = true);
    }
}