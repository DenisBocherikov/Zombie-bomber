using Common;
using SceneLogic;
using Zombie;

namespace ZombieSpawner
{
    public interface IZombieSpawnerPresenter
    {
        void StartSpawnZombies();
        void Init(ObjectPool<IZombieView> pool, ITargetManager targetManager);
    }
}