﻿using UnityEngine;
using PathologicalGames;


public class InstanceHandlerDelegateExample : MonoBehaviour 
{
	public string poolName = "";

	private void Awake() 
	{
		// Set Global PoolManager delegates ASAP. These are always available.
		InstanceHandler.InstantiateDelegates += this.InstantiateDelegate;
		InstanceHandler.DestroyDelegates += this.DestroyDelegate;
	}

	private void Start() 
	{
		// Pools are often created in Awake so for SpawnPool delegates, use Start or later
		// You can also set an override destroy delegate, but only this one is here for this example.
		PoolManager.Pools[this.poolName].instantiateDelegates += this.InstantiateDelegateForShapesPool;
	}

	public GameObject InstantiateDelegate(GameObject prefab, Vector3 pos, Quaternion rot)
	{
		Debug.Log("Using my own instantiation delegate on Prefab '" + prefab.name + "'!");

		return Object.Instantiate(prefab, pos, rot) as GameObject;
	}

	public void DestroyDelegate(GameObject instance)
	{
		Debug.Log("Using my own destroy delegate on '" + instance.name + "'!");

		Object.Destroy(instance);
	}

	public GameObject InstantiateDelegateForShapesPool(GameObject prefab, Vector3 pos, Quaternion rot)
	{
		Debug.Log("Using my own instantiation delegate for just the 'Shapes' pool on Prefab '" + prefab.name + "'!");
		
		return Object.Instantiate(prefab, pos, rot) as GameObject;
	}

}
