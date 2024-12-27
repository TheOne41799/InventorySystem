using UnityEngine;


[CreateAssetMenu(menuName = "Inventory Item/ Item", fileName = "Item")]
public class ItemSO : ScriptableObject
{
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
