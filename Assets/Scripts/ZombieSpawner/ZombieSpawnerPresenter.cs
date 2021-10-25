using System.Collections;
using Common;
using SceneLogic;
using UnityEngine;
using Zombie;

namespace ZombieSpawner
{
    public class ZombieSpawnerPresenter : IZombieSpawnerPresenter
    {
        private readonly ZombieSpawnerModel _model;
        private readonly IZombieSpawnerView _view;
        private readonly WaitForSeconds _spawnDelay;
        private ObjectPool<IZombieView> _zombiePool;
        private Coroutine _coroutine;
        private ITargetManager _targetManager;
        private bool _isRunning;

        public ZombieSpawnerPresenter(IZombieSpawnerView view, ZombieSpawnerModel model)
        {
            _view = view;
            _model = model;
            _spawnDelay = new WaitForSeconds(model.SpawnDelay);
        }

        public void Init(ObjectPool<IZombieView> bombPool, ITargetManager targetManager)
        {
            _zombiePool = bombPool;
            _targetManager = targetManager;
        }
        public void StartSpawnZombies()
        {
            _isRunning = true;
            _coroutine = _view.StartCoroutine(SpawnZombie());
        }
        
        private IEnumerator SpawnZombie()
        {
            while(_isRunning)
            {
                var zombie = _zombiePool.GetGameObject();
                Vector3 worldPosition;
                var x = 0;
                do
                {
                    x++;
                    worldPosition = GetRandomXZPoint(_model);
                } while (!zombie.IsSafePlace(worldPosition) && x <= _model.MaxCreateAttempts);

                zombie.SetWorldPosition(worldPosition);
                zombie.ResetState();
                _targetManager.AddObserver(zombie);
                zombie.OnDie += ZombieOnDie;

                yield return _spawnDelay;
            }
        }

        private void ZombieOnDie(IZombieView zombieView)
        {
            _targetManager.RemoveObserver(zombieView);
        }

        private Vector3 GetRandomXZPoint(ZombieSpawnerModel model)
        {
            var halfWidth = model.Width / 2;
            var halfHeight = model.Height / 2;
            return _view.WorldPosition + new Vector3(Random.Range(-halfWidth, halfWidth), 0,
                Random.Range(-halfHeight, halfHeight));
        }
    }
}