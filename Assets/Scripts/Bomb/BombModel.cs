using System;
using UnityEngine;

namespace Bomb
{
    [Serializable]
    public class BombModel
    {
        private readonly BombParameters _defaultParameters;
        
        private float _maxExplosionForce;
        public float MaxExplosionForce => _maxExplosionForce;
        private float _minExplosionForce;
        public float MinExplosionForce => _minExplosionForce;
        private float _damageDistance;
        public float DamageDistance => _damageDistance;

        private LayerMask _damageObstacleMask;
        public LayerMask DamageObstacleMask => _damageObstacleMask;

        public BombModel(BombParameters defaultParameters)
        {
            _defaultParameters = defaultParameters;
            ResetParameters();
        }

        public void ResetParameters()
        {
            _maxExplosionForce = _defaultParameters.MaxExplosionForce;
            _minExplosionForce = _defaultParameters.MinExplosionForce;
            _damageDistance = _defaultParameters.Distance;
            _damageObstacleMask = _defaultParameters.DamageObstacleMask;
        }
    }
}