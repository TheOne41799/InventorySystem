using NewInventorySystem.Items;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewInventorySystem.Shop
{
    public class ShopModel
    {
        private List<ShopSlot> shopSlots;

        public ShopModel(int numSlots)
        {
            shopSlots = new List<ShopSlot>();

            for (int i = 0; i < numSlots; i++)
            {
                shopSlots.Add(new ShopSlot());
            }
        }

        public void AddItemToShop(ItemSO item)
        {
            for (int i = 0; i < shopSlots.Count; i++)
            {
                if (shopSlots[i].item == null)
                {
                    shopSlots[i].item = item;
                    return;
                }
            }
        }

        /*public void RemoveItemFromShop(Item item)
        {
            for (int i = 0; i < shopSlots.Count; i++)
            {
                if (shopSlots[i].item == item)
                {
                    shopSlots[i].item = null;
                    return;
                }
            }
        }*/

        public List<ShopSlot> GetShopSlots() => shopSlots;
    }
}