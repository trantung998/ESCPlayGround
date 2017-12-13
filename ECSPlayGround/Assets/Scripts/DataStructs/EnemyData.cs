using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DataStructs
{
    [CreateAssetMenu]
    public class EnemyData : ScriptableObject
    {
        public GameObject prefab;
        public Vector3 spawnPosition;
        public int moveSpeed;
    }
}
