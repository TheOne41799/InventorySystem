using UnityEngine;

namespace InventorySystem.Items
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Inventory Item SO", fileName = "ItemSO")]
    public class ItemSO : ScriptableObject
    {
        public ItemID itemID;

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


    public enum ItemID
    {
        NONE,
        BLUE_ARROW,
        BLUE_GAUNTLET,
        BRONZE_GAUNTLET,
        BEIGE_HAND,
        BLUE_HAND,
        GOLDEN_SWORD,
        SILVER_SWORD
    }

    public enum ItemSource
    {
        NONE,
        SHOP_ITEM,
        INVENTORY_ITEM
    }
}


