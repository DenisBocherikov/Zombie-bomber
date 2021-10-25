using BombSpawner;
using Common;
using SceneLogic;
using UnityEngine;
using Zombie;

namespace ZombieSpawner
{
    public class ZombieSpawnerView : BaseMonoBehaviourView, IZombieSpawnerView
    {
        [SerializeField] private ZombieSpawnerParameters _parameters;
        private IZombieSpawnerPresenter _presenter;

        private void Awake()
        {
            _presenter = new ZombieSpawnerPresenter(this, new ZombieSpawnerModel(_parameters));
        }

        public void Init(ObjectPool<IZombieView> pool, ITargetManager targetManager)
        {
            _presenter.Init(pool, targetManager);
        }

        public void StartSpawnZombies()
        {
            _presenter.StartSpawnZombies();
        }

        private void OnDrawGizmos()
        {
            if (_parameters != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireCube(transform.position, new Vector3(_parameters.Width, 0.5f, _parameters.Height));
            }
        }

        private void OnDestroy()
        {
            _presenter = null;
        }
    }
}