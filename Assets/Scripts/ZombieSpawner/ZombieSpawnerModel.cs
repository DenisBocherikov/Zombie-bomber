using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ZombieSpawner
{
    [Serializable]
    public class ZombieSpawnerModel
    {
        [SerializeField] private int _maxCreateAttempts;
        public int MaxCreateAttempts => _maxCreateAttempts;
        [SerializeField] private float _spawnDelay;
        public float SpawnDelay => _spawnDelay;
        [SerializeField] private float _width;
        public float Width => _width;
        [SerializeField] private float _height;
        public float Height => _height;
        
        private readonly ZombieSpawnerParameters _defaultParameters;

        public ZombieSpawnerModel(ZombieSpawnerParameters parameters)
        {
            _defaultParameters = parameters;
            ResetParameters();
        }

        private void ResetParameters()
        {
            _spawnDelay = _defaultParameters.SpawnDelay;
            _width = _defaultParameters.Width;
            _height = _defaultParameters.Height;
        }
    }
}