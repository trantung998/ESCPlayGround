using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MEC;
using UnityEngine;

namespace Gameplay
{
    public class Utilities
    {
        public static IEnumerator<float> _EmulateUpdate(System.Action func, MonoBehaviour scr)
        {
            yield return Timing.WaitForOneFrame;
            while (scr.gameObject != null)
            {
                if (scr.gameObject.activeInHierarchy && scr.enabled)
                    func();
 
                yield return Timing.WaitForOneFrame;
            }
        }
    }
}
