using System.Collections;
using Common.Interfaces;
using SceneLogic;
using UnityEngine;

namespace Zombie
{
    public interface IZombieView : IBombExplosionObserver
    {
        event OnDieDelegate OnDie;
        void Die();
        bool IsSafePlace(Vector3 worldPosition);
        void ResetState();
    }
}