
using InventorySystem.Items;
using InventorySystem.UI;
using System.Collections.Generic;
using UnityEngine;

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


        public InventoryService(ItemDatabaseSO db, UIService uiServ) 
        {
            this.database = db;
            this.uIService = uiServ;

            currentSlotIndex = 0;
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

        public void AddItem(ItemSO item)
        {
            if (inventoryItems.Count < totalInventorySlots)
            {
                inventoryItems.Add(item);

                uIService.SetSlotProperties(currentSlotIndex, item.quantity, item.itemIcon);

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