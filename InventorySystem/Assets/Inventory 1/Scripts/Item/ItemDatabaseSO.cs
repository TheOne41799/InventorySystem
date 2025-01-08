using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.Items
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Inventory ItemDatabase SO", fileName = "ItemDatabaseSO")]
    public class ItemDatabaseSO : ScriptableObject
    {
        public List<ItemSO> items;
    }
}