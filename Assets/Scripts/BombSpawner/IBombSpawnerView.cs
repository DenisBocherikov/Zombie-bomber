using System.Collections;
using System.Collections.Generic;
using Bomb;
using Common;
using Common.Interfaces;
using SceneLogic;
using UnityEngine;

public interface IBombSpawnerView : IMonoBehaviorView
{
    void Init(ObjectPool<IBombView> pool, ITargetManager targetManager);
    void StartSpawnBombs();
    
}
