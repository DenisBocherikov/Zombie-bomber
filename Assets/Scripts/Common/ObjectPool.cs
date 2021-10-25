using System;
using System.Collections.Generic;
using Common.Interfaces;
using UnityEngine;

namespace Common
{
    public class ObjectPool<T> where T : IMonoBehaviorView
    {
        private List<T> _pool;
        private int _capacity;
        private T _originalGameObject;
        private Transform _parent;
        
        public void InitPool(T gameObject, Transform parent, int capacity)
        {
            _originalGameObject = gameObject;
            _parent = parent;
            _capacity = capacity;
            _pool = new List<T>(capacity);
            for (var i = 0; i < capacity; i++)
            {
                var newGameObject = InstantiateNewGameObject(gameObject, parent);
                newGameObject.SetActive(false);
                _pool.Add(newGameObject);
            }
        }

        public T GetGameObject()
        {
            for (var i = 0; i < _capacity; i++)
            {
                if (!_pool[i].activeSelf)
                {
                    var result = _pool[i];
                    return result;
                }
            }

            return AddNewObjectToPool();
        }

        private T AddNewObjectToPool()
        {
            _capacity++;
            var result = InstantiateNewGameObject(_originalGameObject, _parent);
            _pool.Add(result);
            return result;
        }

        private T InstantiateNewGameObject(T gameObject, Transform parent)
        {
            if (!(gameObject is MonoBehaviour monoBehaviorView))
            {
                throw new Exception($"Can't instantiate object of type {gameObject.GetType()}");
            }

            return GameObject.Instantiate(monoBehaviorView, parent).gameObject.GetComponent<T>();
        }
    }
}