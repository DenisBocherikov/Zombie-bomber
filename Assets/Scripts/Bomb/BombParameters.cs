using UnityEngine;

namespace Bomb
{
    [CreateAssetMenu(fileName = "Parameters", menuName = "ZombieBomber/Bomb", order = 0)]
    public class BombParameters : ScriptableObject
    {
        public float MaxExplosionForce;
        public float MinExplosionForce;
        public float Distance;
        public LayerMask DamageObstacleMask;
    }
}