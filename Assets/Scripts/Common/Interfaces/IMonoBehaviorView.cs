using System.Collections;
using UnityEngine;

namespace Common.Interfaces
{
    public interface IMonoBehaviorView
    {
        bool activeSelf { get; }
        Vector3 WorldPosition { get; }
        void SetActive(bool isActive);
        void SetVelocity(Vector3 velocity);
        void SetWorldPosition(Vector3 worldPosition);
        Coroutine StartCoroutine(IEnumerator routine);
    }
}