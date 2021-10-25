using System.Collections;
using Bomb;
using Common;
using SceneLogic;
using UnityEngine;

namespace BombSpawner
{
    public class BombSpawnerPresenter : IBombSpawnerPresenter
    {
        private BombSpawnerModel _model;
        private IBombSpawnerView _view;
        private BombSpawnerParameters _parameters;
        private ObjectPool<IBombView> _bombPool;
        private Coroutine _spawnCoroutine;
        private WaitForSeconds _spawnDelay;
        private ITargetManager _targetManager;
        private bool _isRunning;

        public BombSpawnerPresenter(IBombSpawnerView view, BombSpawnerModel model, BombSpawnerParameters parameters)
        {
            _parameters = parameters;
            _view = view;
            _model = model;
            _spawnDelay = new WaitForSeconds(parameters.SpawnDelay);
        }

        public void Init(ObjectPool<IBombView> bombPool, ITargetManager targetManager)
        {
            _bombPool = bombPool;
            _targetManager = targetManager;
        }

        public void StartSpawnBombs()
        {
            _isRunning = true;
            _spawnCoroutine = _view.StartCoroutine(SpawnBomb());
        }

        private IEnumerator SpawnBomb()
        {
            while (_isRunning)
            {
                var bomb = _bombPool.GetGameObject();
                bomb.OnBombExplode.AddListener(bombView => _targetManager.BombExplode(bombView));
                bomb.SetWorldPosition(GetRandomXZPoint(_parameters));
                bomb.Fall();

                yield return _spawnDelay;
            }
        }

        private Vector3 GetRandomXZPoint(BombSpawnerParameters parameters)
        {
            var halfWidth = parameters.Width / 2;
            var halfHeight = parameters.Height / 2;
            return _view.WorldPosition + new Vector3(Random.Range(-halfWidth, halfWidth), 0,
                Random.Range(-halfHeight, halfHeight));
        }
    }
}