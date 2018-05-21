using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MiniWaveData
{
	public float StartDelay;
	public float DelaySpawnEnemy;
	public float Duration;
	public float LifeTime;
	public int NumberEnemy;
	
	public GameObject Prefab;
	
	public Vector3[] Waypoints = new[] { new Vector3(-2.423138f,1.724428f,0f), new Vector3(-2.106345f,1.04647f,0f), new Vector3(-1.370572f,0.4896688f,0f), new Vector3(-0.8734285f,0.3604117f,0f), new Vector3(0.2600595f,0.32064f,0f), new Vector3(1.065433f,0.3106973f,0f), new Vector3(1.751491f,0.3604117f,0f), new Vector3(2.228749f,0.9967557f,0f), new Vector3(2.119377f,1.7027f,0f), new Vector3(1.12509f,1.941329f,0f), new Vector3(0.4092025f,1.722586f,0f), new Vector3(0.4489741f,1.026584f,0f), new Vector3(0.5185742f,-0.1765037f,0f), new Vector3(0.7770889f,-1.180734f,0f), new Vector3(1.532748f,-1.518792f,0f), new Vector3(2.457435f,-1.687821f,0f) };
}
