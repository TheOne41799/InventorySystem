
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
            inventorySlots[id].quantityText.text = quantity.ToString();
            inventorySlots[id].slotImage.sprite = sprite;
        }
    }
}