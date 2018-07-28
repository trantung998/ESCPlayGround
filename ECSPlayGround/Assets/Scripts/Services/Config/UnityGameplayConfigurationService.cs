using UnityEngine;

public class UnityGameplayConfigurationService : MonoBehaviour, IConfigurationService
{
    [SerializeField] private PlayerMovementConfigs playerGameplayConfigs;

    public PlayerMovementConfigs GetPlayerMovementConfigs
    {
        get { return playerGameplayConfigs; }
    }
}