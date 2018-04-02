using UnityEngine;

namespace Sources.GamePlay.Player.Scripts
{
    public enum AbilityId
    {
        None,
        MeleeAtk,
        RangeAtk,
        Skill_ABC1,
        Skill_ABC2,
        Skill_ABC3,
    }
    public class CharacterAbility
    {
        [SerializeField] private AbilityId id;
        [SerializeField] private float cooldown;
        [SerializeField] private string name;
        [SerializeField] private string des;

        public AbilityId Id
        {
            get { return id; }
            set { id = value; }
        }

        public float Cooldown
        {
            get { return cooldown; }
            set { cooldown = value; }
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