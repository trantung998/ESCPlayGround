using System;
using System.Collections;
using DG.Tweening;
using DG.Tweening.Plugins.Core.PathCore;
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