
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


        public InventoryService(ItemDatabaseSO db, UIService uiServ) 
        {
            this.database = db;
            this.uIService = uiServ;
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
    }
}