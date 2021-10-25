using Bomb;
using Common;
using SceneLogic;
using UnityEngine.PlayerLoop;

namespace BombSpawner
{
    public interface IBombSpawnerPresenter
    {
        void Init(ObjectPool<IBombView> bombPool, ITargetManager targetManager);
        void StartSpawnBombs();
    }
}