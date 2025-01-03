
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.UI
{
    public class UIService: MonoBehaviour
    {
        public GameObject slotPanel;
        public GameObject inventorySlotPrefab;

        public List<UISlot> slots = new List<UISlot>();


        public void AddSlots(UISlot slot)
        {
            slots.Add(slot);
        }

        public void SetSlotProperties(int id, int quantity, Sprite sprite)
        {
            slots[id].quantityText.text = quantity.ToString();
            slots[id].slotImage.sprite = sprite;
        }
    }
}