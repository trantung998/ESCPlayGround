using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class GameBoardSystems  : Feature
{
    public GameBoardSystems(Contexts context) : base("GameBoardSystems")
    {
        Add(new GameBoardSystem(context));
        Add(new FillSystem(context));
        Add(new FallSystem(context));
    }
}

