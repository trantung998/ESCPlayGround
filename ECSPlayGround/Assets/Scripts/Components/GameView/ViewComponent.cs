using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;
using UnityEngine;

namespace Assets.Scripts.Components.GameView
{
    [Game]
    public class ViewComponent : IComponent
    {
        public GameObject viewObject;
    }
}
