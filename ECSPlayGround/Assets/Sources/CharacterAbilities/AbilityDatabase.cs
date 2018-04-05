using System.Collections.Generic;
using UnityEngine;

namespace Sources.GamePlay.Player.Scripts
{

    public class AbilityDatabase: ScriptableObject
    {
        [SerializeField] private List<CharacterAbilityData> abilityDatas;

        public List<CharacterAbilityData> AbilityDatas
        {
            get { return abilityDatas; }
        }
    }
}