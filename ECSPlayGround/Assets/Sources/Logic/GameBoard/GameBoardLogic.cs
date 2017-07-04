using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public static class GameBoardLogic
{
    public static int GetNextEmptyRow(GameContext c, IntVector2 position)
    {
        position.y -= 1;
        while (position.y >= 0 && c.GetEntitiesWithPosition(position).Count == 0)
        {
            position.y -= 1;
        }


        return position.y + 1;
    }
}

