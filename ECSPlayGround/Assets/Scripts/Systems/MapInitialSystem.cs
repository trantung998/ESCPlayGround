using Entitas;
using Entitas.Unity;
using UnityCode.Core.Scripts.ObjectPooling;
using UnityEngine;

namespace Assets.Scripts.Systems
{
    public class MapInitialSystem : IInitializeSystem
    {
        private MapConfigs mapConfigs;
        private GameContext gameContext;
        
        public MapInitialSystem(Contexts contexts)
        {
            gameContext = contexts.game;
            mapConfigs = contexts.game.mapConfigs.value;
        }

        public void Initialize()
        {
            var boundPrefap = mapConfigs.boundPrefab;
            ObjectPool.manageRecycleBin(new ObjectRecycleBin()
            {
                instancesToPreallocate = 2,
                prefab = boundPrefap
            });

            var topBoundObject = ObjectPool.spawn(boundPrefap);
            topBoundObject.transform.localPosition = mapConfigs.topBoundData.position;
//            topBoundObject.transform.localRotation = Quaternion.AngleAxis(90.0f, Vector3.right);
            topBoundObject.transform.localScale = mapConfigs.topBoundData.scale;
            topBoundObject.Link(gameContext.CreateEntity(), gameContext);
            var bottomBoundObject = ObjectPool.spawn(boundPrefap);
            bottomBoundObject.transform.localPosition = mapConfigs.bottomBoundData.position;
//            bottomBoundObject.transform.localRotation = Quaternion.AngleAxis(90.0f, Vector3.right);
            bottomBoundObject.transform.localScale = mapConfigs.bottomBoundData.scale;
            bottomBoundObject.Link(gameContext.CreateEntity(), gameContext);
        }
    }
}