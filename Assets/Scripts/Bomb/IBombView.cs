using Common.Interfaces;
using SceneLogic;
using UnityEngine;

namespace Bomb
{
    public interface IBombView : IMonoBehaviorView
    {
        BombExplodeEvent OnBombExplode { get; }
        BombModel Model { get; }
        void Fall();
        void Explode();
        void DamageTarget(IBombExplosionObserver target);
    }
}