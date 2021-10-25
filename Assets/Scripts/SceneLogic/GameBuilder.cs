using System;
using System.Threading.Tasks;
using Bomb;
using Common;
using UnityEngine;
using Zombie;
using ZombieSpawner;

namespace SceneLogic
{
    public class GameBuilder : MonoBehaviour
    {
        [SerializeField] private int _defaultZombiePoolSize;
        [SerializeField] private int _defaultBombPoolSize;
        [SerializeField] private PrefabTypeWrapper<IBombView> _bombPrefab;
        [SerializeField] private PrefabTypeWrapper<IZombieView> _zombiePrefab;
        [SerializeField] private PrefabTypeWrapper<IBombSpawnerView> BombSpawner;
        [SerializeField] private PrefabTypeWrapper<IZombieSpawnerView> ZombieSpawner;
        [SerializeField] private Transform ZombiePool;
        [SerializeField] private Transform BombPool;
        private readonly ITargetManager _targetManager = new TargetManager();
        private void Start()
        {
            var zombiePool = new ObjectPool<IZombieView>();
            var zombie = _zombiePrefab.Prefab;
            
            zombiePool.InitPool(zombie, ZombiePool, _defaultZombiePoolSize);
            ZombieSpawner.Prefab.Init(zombiePool, _targetManager);

            var bombPool = new ObjectPool<IBombView>();
            bombPool.InitPool(_bombPrefab.Prefab, BombPool, _defaultBombPoolSize);
            BombSpawner.Prefab.Init(bombPool, _targetManager);

            BombSpawner.Prefab.StartSpawnBombs();
            ZombieSpawner.Prefab.StartSpawnZombies();
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            _bombPrefab.Validate();
            _zombiePrefab.Validate();
            BombSpawner.Validate();
            ZombieSpawner.Validate();
        }
#endif
    }
}