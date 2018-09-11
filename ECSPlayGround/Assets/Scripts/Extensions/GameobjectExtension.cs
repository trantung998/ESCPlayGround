using UnityEngine;

namespace Extensions
{
    public class GameobjectExtension
    {
        public static GameObject SpawObject(string prefapPath, Vector3 position = default(Vector3), Quaternion rotation = default(Quaternion))
        {
            var prefab = Resources.Load<GameObject>(prefapPath);
            return GameObject.Instantiate(prefab, position, rotation);
        }
    }
}