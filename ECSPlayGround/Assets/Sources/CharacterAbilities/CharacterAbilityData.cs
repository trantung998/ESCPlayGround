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
    
    public class CharacterAbilityData
    {
        [SerializeField] private SkillId id;
        [SerializeField] private SkillCastType castType;
        [SerializeField] private float cooldownTime;
        [SerializeField] private float castRange;
        [SerializeField] private string name;
        [SerializeField] private string des;

        public SkillCastType CastType
        {
            get { return castType; }
            set { castType = value; }
        }

        public float CastRange
        {
            get { return castRange; }
            set { castRange = value; }
        }

        public SkillId Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Des
        {
            get { return des; }
            set { des = value; }
        }
    }
}