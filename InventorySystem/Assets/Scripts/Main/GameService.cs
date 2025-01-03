using UnityEngine;
using InventorySystem.Items;
using InventorySystem.UI;
using InventorySystem.Inventory;

namespace InventorySystem.Main
{
    public class GameService : MonoBehaviour
    {
        public ItemDatabaseSO itemDatabase;
        public UIService uiService;
        public InventoryService inventoryService;


        private void Start()
        {
            inventoryService = new InventoryService(itemDatabase, uiService);

            Init();
        }

        private void Init()
        {
            inventoryService.InitializeInventoryUI();
        }
    }
}
