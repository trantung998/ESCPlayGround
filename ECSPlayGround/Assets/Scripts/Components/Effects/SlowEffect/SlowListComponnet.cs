using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;

public class SlowListComponnet : IComponent
{
    public List<EffectData> listEffect;

    public EffectData GetActiveEffect()
    {
        int maxIndex = 0;
        float maxValue = 0;
        for (int i = 0; i < listEffect.Count; i++)
        {
            if (listEffect[i].value > maxValue)
            {
                maxIndex = i;
                maxValue = listEffect[i].value;
            }
        }
        return listEffect[maxIndex];
    }
}