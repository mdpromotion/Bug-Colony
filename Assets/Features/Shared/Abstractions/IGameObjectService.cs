#nullable enable

using UnityEngine;

namespace Shared.Services
{
    public interface IGameObjectService
    {
        GameObject? GetObject(ObjectType type);
        void ReturnObject(GameObject obj);
    }
}
