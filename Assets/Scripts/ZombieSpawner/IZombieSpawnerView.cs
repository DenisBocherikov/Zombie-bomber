using Common;
using Common.Interfaces;
using SceneLogic;
using Zombie;

namespace ZombieSpawner
{
    public interface IZombieSpawnerView : IMonoBehaviorView
    {
        void Init(ObjectPool<IZombieView> pool, ITargetManager targetManager);
        void StartSpawnZombies();
    }
}