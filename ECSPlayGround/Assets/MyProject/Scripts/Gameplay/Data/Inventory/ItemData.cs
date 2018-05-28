using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Data.Inventory
{
    public enum ItemType
    {
        None,
        Type1,
        Type2,
        Type3,
        Type4,
        Type5,
        Type6,
    }
    // Model in database
    public class ItemData
    {
        private string _id;
        private ItemType _type;
        private List<Attribute> _attributes;
        private Sprite icon;
    }
    //
    public class BaseItem
    {
        private string _id;
        private string _databaseId;
        private int upgradeLevel;
    }
}