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
                if (wave.delay > 0)
                {
                    yield return Timing.WaitForSeconds(wave.delay);
                    var total = wave.numberEnemy;
                    for (int i = 0; i < total; i++)
                    {
                        var enemy = pool.Spawn("Enemy", pool.transform);
                        
                        enemy.DOPath(wave.waypoints, 10, PathType.CatmullRom, PathMode.TopDown2D)
                            .SetLookAt(0.01f, enemy.up, enemy.forward);
                        yield return Timing.WaitForSeconds(wave.delayEachEnemy);
                    }

                }
            }
        }
    }
}