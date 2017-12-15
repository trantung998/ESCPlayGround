using UnityEngine;

[CreateAssetMenu]
public class PlayerDataModel : ScriptableObject
{
    public GameObject playerModel;
    public GameObject bulletMoldel;
    public GameObject hitEffect;

    public float fireRate;
    public float moveSpeed;
    public float bulletSpeed;
}

