using System;
using System.Collections.Generic;
using DG.Tweening;
using MEC;
using PathologicalGames;
using UnityEngine;

[Serializable]
public class WaveData : MonoBehaviour
{
    [SerializeField] private int index;
    [SerializeField] private bool autoNextWave;
    [SerializeField] private float startDelay;

    [SerializeField] private List<MiniWaveData> miniWaveList;

    private SpawnPool pool;

    public void StartWave(SpawnPool pool)
    {
        if (miniWaveList != null)
        {
            SetupPool(pool);
            for (var i = 0; i < miniWaveList.Count; i++)
            {
                Timing.RunCoroutine(SpawnMiniwave(miniWaveList[i]));
            }
        }

    }
    
    private void SetupPool(SpawnPool pool)
    {
        PrefabPool prefabPool = null;
        foreach (var miniWaveData in miniWaveList)
        {
            prefabPool = new PrefabPool(miniWaveData.Prefab.transform);
            prefabPool.preloadAmount = miniWaveData.NumberEnemy;            
            pool.CreatePrefabPool(prefabPool);            
        }
        this.pool = pool;
    }
    
    public IEnumerator<float> SpawnMiniwave(MiniWaveData miniWaveData)
    {
        if (miniWaveData.StartDelay > 0)
        {
            yield return Timing.WaitForSeconds(miniWaveData.StartDelay);
        }
        for (int i = 0; i < miniWaveData.NumberEnemy; i++)
        {
            var enemy = pool.Spawn(miniWaveData.Prefab, pool.transform);
            enemy.DOPath(miniWaveData.MovePath.GetDrawPoints(), miniWaveData.Duration, PathType.CatmullRom, PathMode.TopDown2D)
                .SetLookAt(0.01f, enemy.forward, - enemy.right);
            if (miniWaveData.Type == WaveType.AutoDestroyEnenmy)
            {
                pool.Despawn(enemy, miniWaveData.LifeTime);
            }
            yield return Timing.WaitForSeconds(miniWaveData.DelaySpawnEnemy);
        }
    }
    
    public int Index
    {
        get { return index; }
    }

    public bool AutoNextWave
    {
        get { return autoNextWave; }
    }

    public float StartDelay
    {
        get { return startDelay; }
    }

    public List<MiniWaveData> MiniWaveList
    {
        get { return miniWaveList; }
    }
}