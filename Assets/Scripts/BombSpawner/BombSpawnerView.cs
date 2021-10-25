using System;
using Bomb;
using Common;
using SceneLogic;
using UnityEngine;

namespace BombSpawner
{
    public class BombSpawnerView : BaseMonoBehaviourView, IBombSpawnerView
    {
        
        [SerializeField] private BombSpawnerParameters _parameters;
        private IBombSpawnerPresenter _presenter;

        private void Awake()
        {
            _presenter = new BombSpawnerPresenter(this, new BombSpawnerModel(), _parameters);
        }

        public void Init(ObjectPool<IBombView> pool, ITargetManager targetManager)
        {
            _presenter.Init(pool, targetManager);
        }

        public void StartSpawnBombs()
        {
            _presenter.StartSpawnBombs();
        }

        private void OnDrawGizmos()
        {
            if (_parameters != null)
            {
                Gizmos.color = Color.black;
                Gizmos.DrawWireCube(transform.position, new Vector3(_parameters.Width, 0.5f, _parameters.Height));
            }
        }

        private void OnDestroy()
        {
            _presenter = null;
        }
    }
}