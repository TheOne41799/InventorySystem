
using InventorySystem.Events;
using InventorySystem.Items;
using InventorySystem.UI;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

namespace InventorySystem.Inventory
{
    public class InventoryService
    {
        private ItemDatabaseSO database;
        private UIService uIService;

        public int totalInventorySlots = 30;

        public List<UISlot> slots = new List<UISlot>();

        public List<ItemSO> inventoryItems = new List<ItemSO>();

        public int currentSlotIndex;


        //How to add an item
        //  Select an item from shop
        //  Check for cash, weight of inventory, availability of slot in inventory
        //  Purchase item
        //  After purchasing check if the item is stackable
        //      If yes, look for the first similar item, look for stack amount, if enough place - add
        //      else keep looking until you find one
        //      If none found, add item in the first empty slot
        //      If not stackable, add item in the first empty slot


        public InventoryService(ItemDatabaseSO db, UIService uiServ) 
        {
            this.database = db;
            this.uIService = uiServ;

            currentSlotIndex = 0;


            EventService.Instance.OnItemSelected.AddListener(AddItem);
        }

        ~InventoryService() 
        {
            EventService.Instance.OnItemSelected.RemoveListener(AddItem);
        }

        public void InitializeInventoryUI()
        {
            for (int i = 0; i < totalInventorySlots; i++)
            {
                GameObject newItem = GameObject.Instantiate(uIService.uiSlotPrefab);
                newItem.transform.SetParent(uIService.inventorySlotPanel.transform);

                RectTransform rectTransform = newItem.GetComponent<RectTransform>();
                rectTransform.localScale = Vector3.one;
                rectTransform.anchoredPosition3D = Vector3.zero;
                rectTransform.localRotation = Quaternion.identity;

                UISlot slot = newItem.GetComponent<UISlot>();
                slots.Add(slot);
                uIService.AddInventorySlots(slot);                
            }
        }

        /*public void AddItem(ItemSO item)
        {
            if (inventoryItems.Count < totalInventorySlots)
            {
                inventoryItems.Add(item);

                uIService.SetSlotProperties(currentSlotIndex, item.quantity, item.itemIcon);

                currentSlotIndex++;
            }
        }*/

        public void AddItem(ItemID id)
        {
            if (inventoryItems.Count < totalInventorySlots)
            {
                for (int i = 0; i < database.items.Count; i++)
                {
                    if (database.items[i].itemID == id)
                    {
                        inventoryItems.Add(database.items[i]);
                        uIService.SetSlotProperties(currentSlotIndex, database.items[i].quantity, database.items[i].itemIcon);
                    }
                }

                currentSlotIndex++;
            }
        }

        /*public void RemoveItem(int index)
        {
            if (inventoryItems.Count > 0)
            {
                inventoryItems.RemoveAt(index);

                uIService.SetSlotProperties(currentSlotIndex, 0, null);

                currentSlotIndex--;
            }
        }*/
    }
}