using UnityEngine;

public interface IPoolService
{

    void Init(string poolname);
    void CreatePrefabPool(Transform prefab, int preloadAmount = 1, bool preloadTime = false, int preloadFrames = 2,
        float preloadDelay = 0, bool limitInstances = false, int limitAmount = 100, bool limitFIFO = false,
        bool cullDespawned = false, int cullAbove = 50, int cullDelay = 60, int cullMaxPerPass = 5);

    void CreatePrefabPool(Transform prefab);
    Transform Spawn(Transform prefab, Vector3 pos, Quaternion rot, Transform parent);
    Transform Spawn(Transform prefab, Vector3 pos, Quaternion rot);
    Transform Spawn(Transform prefab);
    Transform Spawn(Transform prefab, Transform parent);
    Transform Spawn(GameObject prefab, Vector3 pos, Quaternion rot, Transform parent);
    Transform Spawn(GameObject prefab, Vector3 pos, Quaternion rot);
    Transform Spawn(GameObject prefab);


    AudioSource Spawn(AudioSource prefab,
        Vector3 pos, Quaternion rot);

    AudioSource Spawn(AudioSource prefab);

    AudioSource Spawn(AudioSource prefab,
        Vector3 pos, Quaternion rot,
        Transform parent);


    ParticleSystem Spawn(ParticleSystem prefab,
        Vector3 pos, Quaternion rot);

    ParticleSystem Spawn(ParticleSystem prefab,
        Vector3 pos, Quaternion rot,
        Transform parent);

    void Despawn(Transform instance);

    void Despawn(Transform instance, Transform parent);

    void Despawn(Transform instance, float seconds);

    void Despawn(Transform instance, float seconds, Transform parent);

    void DespawnAll();
}