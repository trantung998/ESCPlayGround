using UnityEngine;

public class UnityGameplayConfigurationService : MonoBehaviour, IConfigurationService
{
    [SerializeField] private CharacterConfigs playerGameplayConfigs;
    private readonly Vector2 VIEW_PORT_LEFT_BOTTOM = new Vector2(0, 0);
    private readonly Vector2 VIEW_PORT_RIGHT_TOP = new Vector2(1, 1);

    private void Awake()
    {
        playerGameplayConfigs.botLeft = Camera.main.ViewportToWorldPoint(VIEW_PORT_LEFT_BOTTOM);
        playerGameplayConfigs.topRight = Camera.main.ViewportToWorldPoint(VIEW_PORT_RIGHT_TOP);
    }

    public CharacterConfigs GetCharacterConfigs
    {
        get { return playerGameplayConfigs; }
    }
}