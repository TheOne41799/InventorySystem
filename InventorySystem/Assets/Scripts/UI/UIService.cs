
using InventorySystem.Events;
using InventorySystem.Inventory;
using InventorySystem.Items;
using System;
using System.Collections.Generic;
using UnityEngine;


namespace InventorySystem.UI
{
    public class UIService: MonoBehaviour
    {
        public GameObject inventorySlotPanel;
        public GameObject shopSlotPanel;
        public GameObject uiSlotPrefab;

        public List<UISlot> inventorySlots = new List<UISlot>();
        public List<UISlot> shopSlots = new List<UISlot>();

        private UISlot selectedSlot;


        private void OnEnable()
        {
            EventService.Instance.OnItemSelected.AddListener(SlotSelected);
        }

        private void OnDisable()
        {
            EventService.Instance.OnItemSelected.RemoveListener(SlotSelected);
        }

        public void AddInventorySlots(UISlot slot)
        {
            inventorySlots.Add(slot);
        }

        public void AddShopSlots(UISlot slot)
        {
            shopSlots.Add(slot);
        }

        public void SetSlotProperties(int id, int quantity, Sprite sprite)
        {
            //inventorySlots[id].quantityText.text = quantity.ToString();
            inventorySlots[id].slotImage.sprite = sprite;
        }

        public void SlotSelected(UISlot slot)
        {
            if (selectedSlot != null)
                selectedSlot.SetOutline(false);

            selectedSlot = slot;
            if (selectedSlot != null)
                selectedSlot.SetOutline(true);
        }

        public void PurchaseItem()
        {
            if (selectedSlot == null || selectedSlot.itemSource != ItemSource.SHOP_ITEM)
            {
                Debug.LogWarning("No item selected from the shop.");
                return;
            }

            EventService.Instance.OnItemPurchased.InvokeEvent(selectedSlot.itemID);
        }

        public void SellItem()
        {
            if (selectedSlot == null || selectedSlot.itemSource != ItemSource.INVENTORY_ITEM)
            {
                Debug.LogWarning("No item selected from inventory to sell.");
                return;
            }

            EventService.Instance.OnItemSold.InvokeEvent(selectedSlot.itemID);
        }
    }
}