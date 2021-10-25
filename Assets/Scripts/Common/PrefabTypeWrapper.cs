using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Common
{
    [Serializable]
    public class PrefabTypeWrapper<T> where T : class
    {
        public GameObject PrefabGameObject;
        private T _prefab;
        public T Prefab
        {
            get { return _prefab ??= PrefabGameObject.GetComponent<T>(); }
        }

        public T GetNewInstance(Transform parent)
        {
            return Object.Instantiate(PrefabGameObject, parent).GetComponent<T>();
        }
#if UNITY_EDITOR
        public void Validate()
        {
            if (Application.isEditor)
            {
                if (PrefabGameObject && PrefabGameObject.GetComponent<T>() == null)
                {
                    PrefabGameObject = null;
                }
            }
        }
#endif
    }
}