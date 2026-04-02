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

    public class PooledObject : MonoBehaviour
    {
        public ObjectType Type;
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
                var pooled = child.GetComponent<PooledObject>();

                if (pooled == null || pooled.Type == ObjectType.None)
                    continue;

                child.gameObject.SetActive(false);
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

        public void ReturnObject(GameObject obj, ObjectType type)
        {
            obj.SetActive(false);
            _pools[type].Enqueue(obj);
        }
    }
}