
using Common;
using UnityEngine;

namespace Zombie
{
    public class ZombieView : BaseMonoBehaviourView, IZombieView
    {
        [SerializeField] private ZombieParameters _parameters; //Should be moved outside to prevent of a lot of copies with different parameters
        private IZombiePresenter _presenter;
        private CapsuleCollider _collider;

        public event OnDieDelegate OnDie;

        private void Awake()
        {
            _presenter = new ZombiePresenter(this, new ZombieModel(_parameters));
            _collider = GetComponent<CapsuleCollider>();
        }

        public void BombDamage(float value)
        {
            _presenter.BombDamage(value);
        }

        private void AnimateDie()
        {
            gameObject.SetActive(false);
        }

        public void Die()
        {
            AnimateDie();
            OnDie.Invoke(this);
        }

        public bool IsSafePlace(Vector3 worldPosition)
        {

            return Physics.CheckCapsule(worldPosition,
                new Vector3(worldPosition.x, worldPosition.y - _collider.height, worldPosition.z), _collider.radius);
        }

        public void ResetState()
        {
            gameObject.SetActive(true);
            _presenter.ResetState();
        }

        private void OnDestroy()
        {
            _presenter = null;
        }
    }
}