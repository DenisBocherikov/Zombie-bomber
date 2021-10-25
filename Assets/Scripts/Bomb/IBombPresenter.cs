using SceneLogic;

namespace Bomb
{
    public interface IBombPresenter
    {
        BombModel Model { get; }
        void Fall();
        void Explode();

        void DamageTarget(IBombExplosionObserver target);
    }
}