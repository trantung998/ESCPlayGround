using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SourceMatchOne;
using UnityEngine;

namespace Assets.Scripts.Logic
{
    public static class GameBoardLogic
    {
        public static int GetNextEmptyRow(GameContext context, IntVector2 pos)
        {
            pos.y -= 1;
            while (pos.y >= 0 && context.GetEntitiesWithAssetsScriptsComponentsGameBoardPosition(pos).Count == 0)
            {
                pos.y -= 1;
            }
            return pos.y + 1;
        }
    }
}
