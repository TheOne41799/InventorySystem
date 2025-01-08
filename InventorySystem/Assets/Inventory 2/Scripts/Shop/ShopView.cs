using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewInventorySystem.Shop
{
    public class ShopView : MonoBehaviour
    {
        public GameObject slotPrefab;
        public Transform shopParent;
        public ShopController shopController;
        private List<ShopSlotView> slotViews = new List<ShopSlotView>();

        public void Initialize(ShopController controller)
        {
            shopController = controller;

            foreach (var slot in shopController.shopModel.GetShopSlots())
            {
                var slotView = Instantiate(slotPrefab, shopParent).GetComponent<ShopSlotView>();
                slotView.Initialize(slot);
                slotViews.Add(slotView);
            }
        }

        public void UpdateShopUI()
        {
            for (int i = 0; i < slotViews.Count; i++)
            {
                slotViews[i].UpdateSlotUI();
            }
        }
    }
}