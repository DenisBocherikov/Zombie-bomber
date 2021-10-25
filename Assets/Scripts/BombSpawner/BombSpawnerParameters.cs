using UnityEngine;

namespace BombSpawner
{
    [CreateAssetMenu(fileName = "Parameters", menuName = "ZombieBomber/BombSpawner", order = 0)]
    public class BombSpawnerParameters : ScriptableObject
    {
        public float SpawnDelay;
        public float Width;
        public float Height;
    }
}