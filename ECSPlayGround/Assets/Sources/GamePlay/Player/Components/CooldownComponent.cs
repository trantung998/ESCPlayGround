using System.Collections.Generic;
using Entitas;
using Sources.GamePlay.Player.Scripts;

public class CooldownComponent : IComponent
{
    public List<SkillCooldownElement> SkillCooldownList;

    public bool IsContain(AtkId id)
    {
        return SkillCooldownList.Exists(element => element.id == id);
    }
}