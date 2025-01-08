using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NewInventorySystem.Shop
{
    public class ShopSlotView : MonoBehaviour
    {
        public Image itemImage;
        //public Image bgImage;
        public Button slotButton;
        public ShopSlot shopSlot;

        public void Initialize(ShopSlot slot)
        {
            shopSlot = slot;
            UpdateSlotUI();
            slotButton.onClick.AddListener(OnSlotClicked);
        }

        public void UpdateSlotUI()
        {
            if (shopSlot.item != null)
            {
                itemImage.sprite = shopSlot.item.itemIcon;
            }
            else
            {
                itemImage.sprite = null;
            }
        }

        private void OnSlotClicked()
        {
            if (shopSlot.item != null)
            {
                // what to do here?
                // change highlight color
                // fire an event - like 'OnItemSelected'
            }
        }
    }
}

