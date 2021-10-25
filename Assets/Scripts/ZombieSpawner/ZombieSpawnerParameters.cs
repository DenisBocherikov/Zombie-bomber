using UnityEngine;
using UnityEngine.Serialization;

namespace ZombieSpawner
{
    [CreateAssetMenu(fileName = "Parameters", menuName = "ZombieBomber/ZombieSpawner", order = 0)]
    public class ZombieSpawnerParameters : ScriptableObject
    {
        public float SpawnDelay;
        public float Width;
        public float Height;
        public int MaxCreateAttempts;
    }
}