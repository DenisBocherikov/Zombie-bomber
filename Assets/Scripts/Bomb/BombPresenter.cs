using SceneLogic;
using UnityEngine;

namespace Bomb
{
    public delegate void OnBombExplodeDelegate(IBombView bomb);
    public class BombPresenter : IBombPresenter
    {
        private readonly BombModel _model;
        private readonly IBombView _view;

        public BombModel Model => _model;

        public BombPresenter(IBombView view, BombModel model)
        {
            _view = view;
            _model = model;
        }

        public void Fall()
        {
            _view.SetVelocity(Vector3.zero);
            _model.ResetParameters();
        }

        public void Explode()
        {
            
        }
        
        public void DamageTarget(IBombExplosionObserver target)
        {
            var distance = Vector3.Distance(_view.WorldPosition, target.WorldPosition);
            if (distance < _model.DamageDistance)
            {
                if (!Physics.Linecast(_view.WorldPosition, target.WorldPosition, _model.DamageObstacleMask))
                {
                    var damage = Mathf.Lerp(Model.MinExplosionForce, Model.MaxExplosionForce,
                        1f - distance / Model.DamageDistance);
                    target.BombDamage(damage);
                }
            }
        }
    }
}