using UnityEngine;
using InventorySystem.Items;
using InventorySystem.UI;
using InventorySystem.Inventory;
using InventorySystem.Shop;

namespace InventorySystem.Main
{
    public class GameService : MonoBehaviour
    {
        public ItemDatabaseSO itemDatabase;
        public UIService uiService;
        public InventoryService inventoryService;
        public ShopService shopService;


        private void Start()
        {
            inventoryService = new InventoryService(itemDatabase, uiService);
            shopService = new ShopService(itemDatabase, uiService);

            Init();
        }

        private void Init()
        {
            inventoryService.InitializeInventoryUI();
            shopService.InitializeShopUI();
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.UpArrow))
            {
                //inventoryService.AddItem(itemDatabase.items[0]);
            }
        }
    }
}
