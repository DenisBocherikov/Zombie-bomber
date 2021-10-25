using UnityEngine;

namespace Zombie
{
    [CreateAssetMenu(fileName = "Parameters", menuName = "ZombieBomber/Zombie", order = 0)]
    public class ZombieParameters : ScriptableObject
    {
        public float Health;
    }
}