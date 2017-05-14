using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entitas;

namespace Assets.Scripts.Components.GameInput
{
    [Input]
    public class InputComponent :IComponent
    {
        public int x;
        public int y;
    }
}
