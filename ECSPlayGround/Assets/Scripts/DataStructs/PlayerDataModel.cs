using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.DataStructs
{
    public class PlayerDataModel : ScriptableObject
    {
        public GameObject playerModel;
        public float fireRate;
        public float moveSpeed;
    }
}
