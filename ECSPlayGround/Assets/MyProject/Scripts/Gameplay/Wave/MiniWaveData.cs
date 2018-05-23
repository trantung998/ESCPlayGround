using System;
using DG.Tweening;
using UnityEngine;

[Serializable]
public class MiniWaveData : MonoBehaviour
{
    public WaveType Type;
	public float StartDelay;
	public float DelaySpawnEnemy;
	public float Duration;
	public float LifeTime;
	public int NumberEnemy;
	
	public GameObject Prefab;
    public DOTweenPath MovePath;
}