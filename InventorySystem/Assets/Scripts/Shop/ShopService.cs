
using InventorySystem.Items;
using InventorySystem.UI;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.Shop
{
    public class ShopService
    {
        private ItemDatabaseSO database;
        private UIService uIService;

        public int totalShopSlots = 7;

        public List<UISlot> slots = new List<UISlot>();


        public ShopService(ItemDatabaseSO db, UIService uiServ)
        {
            this.database = db;
            this.uIService = uiServ;
        }

        public void InitializeShopUI()
        {
            for (int i = 0; i < totalShopSlots; i++)
            {
                GameObject newItem = GameObject.Instantiate(uIService.uiSlotPrefab);
                newItem.transform.SetParent(uIService.shopSlotPanel.transform);

                RectTransform rectTransform = newItem.GetComponent<RectTransform>();
                rectTransform.localScale = Vector3.one;
                rectTransform.anchoredPosition3D = Vector3.zero;
                rectTransform.localRotation = Quaternion.identity;

                UISlot slot = newItem.GetComponent<UISlot>();
                slots.Add(slot);
                uIService.AddShopSlots(slot);

                slot.slotImage.sprite = database.items[i].itemIcon;
                slot.quantityText.text = database.items[i].quantity.ToString();
                slot.itemID = database.items[i].itemID;
            }
        }
    }
}
