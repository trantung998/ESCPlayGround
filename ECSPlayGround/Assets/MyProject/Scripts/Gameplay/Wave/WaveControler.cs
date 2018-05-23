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
        
        private SpawnPool enemyPool;
        private int currentWave = 0;
        
        private void Start()
        {
            enemyPool = PoolManager.Pools.Create("Enemies");
            SetupPoolData();
            StartWaves();
        }

        private void SetupPoolData()
        {
            foreach (var data in waveData)
            {
                data.SetupPool(enemyPool);
            }
        }

        private void StartWaves()
        {
            foreach (var data in waveData)
            {
                data.StartWave();
            }
        }
    }
}