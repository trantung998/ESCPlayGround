using System;
using UnityEngine;

namespace BulletPool
{
    public class BulletPool : UniRx.Toolkit.ObjectPool<Transform>
    {
        readonly Transform prefab;
        readonly Transform hierarchyParent;


        public BulletPool(Transform prefab, Transform hierarchyParent)
        {
            this.prefab = prefab;
            this.hierarchyParent = hierarchyParent;
        }
        
        protected override Transform CreateInstance()
        {
            var bulletObject = GameObject.Instantiate(prefab);
            bulletObject.transform.SetParent(hierarchyParent);
            return bulletObject.transform;
        }
    }
}
