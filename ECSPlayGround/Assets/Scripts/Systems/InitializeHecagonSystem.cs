using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class InitializeHecagonSystem : IInitializeSystem
{
    private Contexts contexts;

    public InitializeHecagonSystem(Contexts contexts)
    {
        this.contexts = contexts;
    }

	// Use this for initialization
    public void Initialize()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 14; j++)
            {
                var entity = contexts.game.CreateEntity();
                entity.AddPosition(new IntVector2() {x = j, y = i});
                entity.AddHexagonType(HexagonType.Empty);
                entity.isHexagon = true;
            }
        }   
    }
}
