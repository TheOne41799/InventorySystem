using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NewInventorySystem.Items
{
    [CreateAssetMenu(fileName = "NewItem", menuName = "Inventory/Item")]
    public class ItemSO : ScriptableObject
    {
        public string itemName;
        public int itemID;
        public Sprite itemIcon;
    }
}

namespace NewInventorySystem.Items
{
   
}
