#nullable enable
using System.Collections.Generic;
using UnityEngine;

namespace Shared.Services
{
    public enum ObjectType
    {
        None,
        Bugs,
        Food
    }

    public class GameObjectService : MonoBehaviour, IGameObjectService
    {
        private readonly Dictionary<ObjectType, Queue<GameObject>> _pools = new();

        private void Awake()
        {
            foreach (ObjectType type in System.Enum.GetValues(typeof(ObjectType)))
            {
                if (type == ObjectType.None) continue;
                _pools[type] = new Queue<GameObject>();
            }

            foreach (Transform child in transform)
            {
                if (!child.TryGetComponent<PooledObject>(out var pooled) || pooled.Type == ObjectType.None)
                    continue;

                child.gameObject.SetActive(false);
                if (!_pools.ContainsKey(pooled.Type))
                    continue;

                _pools[pooled.Type].Enqueue(child.gameObject);
            }
        }

        public GameObject? GetObject(ObjectType type)
        {
            if (!_pools.ContainsKey(type))
                return null;

            if (_pools[type].Count == 0)
            {
                Debug.LogWarning($"Pool for {type} is empty!");
                return null;
            }

            var obj = _pools[type].Dequeue();
            obj.SetActive(true);
            return obj;
        }

        public void ReturnObject(GameObject obj)
        {
            if (!obj.TryGetComponent<PooledObject>(out var pooled))
                return;

            obj.SetActive(false);
            _pools[pooled.Type].Enqueue(obj);
        }
    }
}