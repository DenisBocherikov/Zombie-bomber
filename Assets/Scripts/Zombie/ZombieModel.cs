using System;
using UnityEngine;

namespace Zombie
{
    [Serializable]
    public class ZombieModel
    {
        [SerializeField]private float _health;
        private readonly ZombieParameters _defaultParamters;
        public float Health => _health;

        public ZombieModel(ZombieParameters paramters)
        {
            _defaultParamters = paramters;
            ResetParameters();
        }

        public void ResetParameters()
        {
            _health = _defaultParamters.Health;
        }

        public void AddDamage(float value)
        {
            _health -= value;
        }
    }
}