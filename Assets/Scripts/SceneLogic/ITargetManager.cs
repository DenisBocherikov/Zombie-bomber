using Bomb;

namespace SceneLogic
{
    public interface ITargetManager
    {
        void AddObserver(IBombExplosionObserver observer);
        void RemoveObserver(IBombExplosionObserver observer);
        void BombExplode(IBombView bombView);
    }
}