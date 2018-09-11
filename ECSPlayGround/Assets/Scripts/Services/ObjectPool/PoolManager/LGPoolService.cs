using PathologicalGames;
using UnityEngine;

public class LGPoolService : IPoolService
{
    private string poolName = "CommonPool";
    
    public LGPoolService()
    {
//        Init(poolName);
    }

    public void Init(string poolname)
    {
        GameObject pool = new GameObject("ObjectPool");
        var spawnPool = pool.AddComponent<SpawnPool>();
        spawnPool.poolName = poolname;
    }

    public void CreatePrefabPool(Transform prefab, int preloadAmount = 1, bool preloadTime = false,
        int preloadFrames = 2,
        float preloadDelay = 0, bool limitInstances = false, int limitAmount = 100, bool limitFIFO = false,
        bool cullDespawned = false, int cullAbove = 50, int cullDelay = 60, int cullMaxPerPass = 5)
    {
    }

    public void CreatePrefabPool(Transform prefab)
    {
    }

    public Transform Spawn(Transform prefab, Vector3 pos, Quaternion rot, Transform parent)
    {
        return PoolManager.Pools[poolName].Spawn(prefab, pos, rot, parent);
    }

    public Transform Spawn(Transform prefab, Vector3 pos, Quaternion rot)
    {
        return PoolManager.Pools[poolName].Spawn(prefab, pos, rot);
    }

    public Transform Spawn(Transform prefab)
    {
        return PoolManager.Pools[poolName].Spawn(prefab);
    }

    public Transform Spawn(Transform prefab, Transform parent)
    {
        return PoolManager.Pools[poolName].Spawn(prefab, parent);
    }

    public Transform Spawn(GameObject prefab, Vector3 pos, Quaternion rot, Transform parent)
    {
        return PoolManager.Pools[poolName].Spawn(prefab, pos, rot, parent);
    }

    public Transform Spawn(GameObject prefab, Vector3 pos, Quaternion rot)
    {
        return PoolManager.Pools[poolName].Spawn(prefab, pos, rot);
    }

    public Transform Spawn(GameObject prefab)
    {
        return PoolManager.Pools[poolName].Spawn(prefab);
    }

    public AudioSource Spawn(AudioSource prefab, Vector3 pos, Quaternion rot)
    {
        throw new System.NotImplementedException();
    }

    public AudioSource Spawn(AudioSource prefab)
    {
        throw new System.NotImplementedException();
    }

    public AudioSource Spawn(AudioSource prefab, Vector3 pos, Quaternion rot, Transform parent)
    {
        throw new System.NotImplementedException();
    }

    public ParticleSystem Spawn(ParticleSystem prefab, Vector3 pos, Quaternion rot)
    {
        throw new System.NotImplementedException();
    }

    public ParticleSystem Spawn(ParticleSystem prefab, Vector3 pos, Quaternion rot, Transform parent)
    {
        throw new System.NotImplementedException();
    }

    public void Despawn(Transform instance)
    {
        throw new System.NotImplementedException();
    }

    public void Despawn(Transform instance, Transform parent)
    {
        throw new System.NotImplementedException();
    }

    public void Despawn(Transform instance, float seconds)
    {
        throw new System.NotImplementedException();
    }

    public void Despawn(Transform instance, float seconds, Transform parent)
    {
        throw new System.NotImplementedException();
    }

    public void DespawnAll()
    {
        throw new System.NotImplementedException();
    }
}