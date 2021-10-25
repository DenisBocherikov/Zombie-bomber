namespace Zombie
{
    public delegate void OnDieDelegate(IZombieView zombieView);
    public class ZombiePresenter : IZombiePresenter
    {
        private readonly ZombieModel _model;
        private readonly IZombieView _view;

        public ZombiePresenter(IZombieView view, ZombieModel model)
        {
            _view = view;
            _model = model;
        }

        public void BombDamage(float value)
        {
            _model.AddDamage(value);
            if (_model.Health <= 0f)
            {
                _view.Die();
            }
        }

        public void ResetState()
        {
            _model.ResetParameters();
        }
    }
}