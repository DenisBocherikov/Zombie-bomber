using Common.Interfaces;

namespace SceneLogic
{
    public interface IBombExplosionObserver : IMonoBehaviorView
    {
        void BombDamage(float value);
    }
}