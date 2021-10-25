using System.Collections.Generic;
using Bomb;
using UnityEngine;

namespace SceneLogic
{
    public class TargetManager : ITargetManager
    {
        private readonly List<IBombExplosionObserver> _observers = new List<IBombExplosionObserver>();

        public void AddObserver(IBombExplosionObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IBombExplosionObserver observer)
        {
            _observers.Remove(observer);
        }

        public void BombExplode(IBombView bombView)
        {
            foreach (var bombExplosionObserver in _observers.ToArray())
            {
                bombView.DamageTarget(bombExplosionObserver);
            }
        }
    }
}