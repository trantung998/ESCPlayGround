using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

public class GamePlayDataConfig : ScriptableObject
{
    [SerializeField] private int currentMapId;
    
    [Space(10)]
    [Information("Parallax back ground", InformationAttribute.InformationType.Info, false)]
    [SerializeField] private Texture backgroundTexture;
    [SerializeField] private Texture foregroundTexture;
    [SerializeField] private float backgroundSpeed;
    [SerializeField] private float foregroundSpeed;

    
}
