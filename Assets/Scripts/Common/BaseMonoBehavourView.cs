using System;
using Common.Interfaces;
using UnityEngine;

namespace Common
{
    public class BaseMonoBehaviourView : MonoBehaviour, IMonoBehaviorView
    {
        private Rigidbody _rigidbody;

        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        public bool activeSelf => gameObject.activeSelf;
        public Vector3 WorldPosition => transform.position;
        public void SetActive(bool isActive)
        {
            gameObject.SetActive(isActive);
        }

        public void SetVelocity(Vector3 velocity)
        {
            _rigidbody.velocity = velocity;
        }

        public void SetWorldPosition(Vector3 worldPosition)
        {
            transform.position = worldPosition;
        }
    }
}