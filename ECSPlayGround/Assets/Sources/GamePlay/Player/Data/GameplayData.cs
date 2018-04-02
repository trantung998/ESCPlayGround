using UnityEngine;

namespace Sources.GamePlay.Player.Data
{
    [CreateAssetMenu]
    public class GameplayData :ScriptableObject
    {
        public GameObject heroPrefab;

        public float tickInverter;
    }
}