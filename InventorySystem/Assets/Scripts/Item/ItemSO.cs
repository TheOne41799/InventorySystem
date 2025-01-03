using UnityEngine;

namespace InventorySystem.Items
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Inventory Item SO", fileName = "ItemSO")]
    public class ItemSO : ScriptableObject
    {
        public int id;
        public ItemType itemType;
        public Sprite itemIcon;

        public string itemName;
        [TextArea(5, 5)]
        public string itemDescription;

        public int itemSellingPrice;
        public int itemBuyingPrice;

        public int itemWeight;

        public ItemRarity itemRarity;

        public int quantity;
    }
}