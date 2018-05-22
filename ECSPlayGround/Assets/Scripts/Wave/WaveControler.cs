using System.Collections.Generic;
using DG.Tweening;
using MEC;
using PathologicalGames;
using UnityEngine;

namespace UniBulletHell.Example.Script.Wave
{
    public class WaveControler : MonoBehaviour
    {        
        [SerializeField] private List<WaveData> waveData;

        private SpawnPool pool;
        
        private int currentWave = 0;
        
        private void Start()
        {
            pool = PoolManager.Pools["Enemy"];
            Timing.RunCoroutine(StartWave());
        }
        
        private IEnumerator<float> StartWave()
        {
            if (waveData != null && waveData.Count > 0)
            {
                var wave = waveData[currentWave];
                if (wave.StartDelay > 0)
                {
                    yield return Timing.WaitForSeconds(wave.StartDelay);
                    
                    var total = wave.NumberEnemy;
                    for (int i = 0; i < total; i++)
                    {
                        var enemy = pool.Spawn(wave.Prefab, pool.transform);
                        if (wave.Type == WaveType.AutoDestroyEnenmy)
                        {
                            pool.Despawn(enemy, wave.LifeTime);
                        }
                        
                        enemy.DOPath(wave.MovePath.GetDrawPoints(), wave.Duration, PathType.CatmullRom, PathMode.TopDown2D)
                            .SetLookAt(0.01f, enemy.forward, - enemy.right);
                        yield return Timing.WaitForSeconds(wave.DelaySpawnEnemy);
                    }

                }
            }
        }
    }
}