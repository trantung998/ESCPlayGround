﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ViewSystems :Feature
{
    public ViewSystems(Contexts contexts) : base("View Systems")
    {
        Add(new AddViewSystem(contexts));
        Add(new MovePieceSystem(contexts));
        Add(new DestroyPieceSystem(contexts));
        Add(new SetViewSystem(contexts));
    }
}

