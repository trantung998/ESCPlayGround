using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sources.GamePlay.Player.Scripts
{
    public enum SkillId
    {
        None,
        MeleeAtk,
        RangeAtk,
        Skill_ABC1,
        Skill_ABC2,
        Skill_ABC3,
    }
    
    public enum SkillCastType
    {
        None,
        Active,
        Passive,
        Channing
    }

    public enum AbilityId
    {
        None,
        Damage,
        DamageImpact,
        HpImpact,
        MoveSpeedImact,
        Cooldown,
    }

    public class Ability
    {
        public AbilityId id;
        public float value;
    }

    [Serializable]
    public class CharacterAbilityData
    {
        [SerializeField] private SkillId id;
        [SerializeField] private SkillCastType castType;
        [SerializeField] private List<Ability> abilitieList;

        public List<Ability> AbilitieList
        {
            get { return abilitieList; }
            set { abilitieList = value; }
        }

        public SkillCastType CastType
        {
            get { return castType; }
            set { castType = value; }
        }

        public SkillId Id
        {
            get { return id; }
            set { id = value; }
        }
    }
}