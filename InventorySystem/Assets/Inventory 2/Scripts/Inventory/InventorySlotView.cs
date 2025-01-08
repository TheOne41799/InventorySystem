using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NewInventorySystem.Inventory
{ 
    public class InventorySlotView : MonoBehaviour
    {
        public Image itemImage;
        //public Image bgImage;
        public Button slotButton;
        public InventorySlot inventorySlot;


        public void Initialize(InventorySlot slot)
        {
            inventorySlot = slot;
            UpdateSlotUI();
            slotButton.onClick.AddListener(OnSlotClicked);
        }

        public void UpdateSlotUI()
        {
            if (inventorySlot.item != null)
            {
                itemImage.sprite = inventorySlot.item.itemIcon;
            }
            else
            {
                itemImage.sprite = null;
            }
        }

        private void OnSlotClicked()
        {
            if (inventorySlot.item != null)
            {
                // what to do here?
                // change highlight color
                // fire an event - like 'OnItemSelected'
            }
        }
    }
}
