using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewInventorySystem.Items
{
    [CreateAssetMenu(fileName = "ItemDatabase", menuName = "Inventory/Item Database")]
    public class ItemDataBaseSO : ScriptableObject
    {
        public ItemSO[] items;
    }
}
