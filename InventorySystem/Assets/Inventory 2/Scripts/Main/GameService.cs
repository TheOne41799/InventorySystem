using InventorySystem.Items;
using NewInventorySystem.Inventory;
using NewInventorySystem.Shop;
using NewInventorySystem.Items;
using UnityEngine;

namespace NewInventorySystem.Main
{
    public class GameService : MonoBehaviour
    {
        public ItemDataBaseSO itemDatabase;
        public GameObject inventorySlotPrefab;
        public Transform inventoryParent;
        public GameObject shopSlotPrefab;
        public Transform shopParent;

        private InventoryModel inventoryModel;
        private ShopModel shopModel;
        private InventoryController inventoryController;
        private ShopController shopController;
        private InventoryView inventoryView;
        private ShopView shopView;

        private void Start()
        {
            inventoryModel = new InventoryModel(10);
            shopModel = new ShopModel(5);

            inventoryController = new InventoryController(inventoryModel);
            shopController = new ShopController(shopModel);

            inventoryView.Initialize(inventoryController);
            shopView.Initialize(shopController);

            foreach (var item in itemDatabase.items)
            {
                shopModel.AddItemToShop(item);
            }

            inventoryView.UpdateInventoryUI();
            shopView.UpdateShopUI();
        }
    }
}
