using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MEC;
using UnityEngine;

namespace Gameplay.Obstacles
{
    public class ObstMoveable : MonoBehaviour
    {
        public float scroll_speed;

        private void Start()
        {
            Timing.RunCoroutine(Utilities._EmulateUpdate(MyUpdate, this));
        }

        private void MyUpdate()
        {

        }
    }
}
