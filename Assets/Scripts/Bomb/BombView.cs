using System;
using Common;
using SceneLogic;
using Unity.VisualScripting;
using UnityEngine;

namespace Bomb
{
    public class BombView : BaseMonoBehaviourView, IBombView
    {
        [SerializeField] private BombParameters _parameters;//Should be moved outside to prevent of a lot of copies with different parameters
        private BombPresenter _presenter;
        
        public BombModel Model => _presenter.Model;
        public BombExplodeEvent OnBombExplode { get; } = new BombExplodeEvent();
        protected sealed override void Awake()
        {
            base.Awake();
            _presenter = new BombPresenter(this, new BombModel(_parameters));
        }

        public void Fall()
        {
            gameObject.SetActive(true);
            _presenter.Fall();
        }

        public void Explode()
        {
            OnBombExplode.Invoke(this);
            OnBombExplode.RemoveAllListeners();
            gameObject.SetActive(false);
            _presenter.Explode();
        }

        public void DamageTarget(IBombExplosionObserver target)
        {
            _presenter.DamageTarget(target);
        }

        private void OnCollisionEnter(Collision other)
        {
            Explode();
        }

        private void OnDestroy()
        {
            _presenter = null;
        }
    }
}