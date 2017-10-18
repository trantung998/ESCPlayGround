using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class HexagonTypeView : MonoBehaviour
{
    public Image image;

    [SerializeField] private Sprite ricochetSpr;
    [SerializeField] private Sprite splitSpr;
    [SerializeField]
    private Sprite stopSpr;
    [SerializeField]
    private Sprite emitSpr;

    public void ShowType(HexagonType hexagonTypeValue)
    {
        switch (hexagonTypeValue)
        {
            case HexagonType.Empty:
                break;
            case HexagonType.Emit:
                image.sprite = emitSpr;
                break;
            case HexagonType.Ricochet:
                image.sprite = ricochetSpr;
                break;
            case HexagonType.Split:
                image.sprite = splitSpr;
                break;
            case HexagonType.Stop:
                image.sprite = stopSpr;
                break;
            default:
                throw new ArgumentOutOfRangeException("hexagonTypeValue", hexagonTypeValue, null);
        }
    }
}

