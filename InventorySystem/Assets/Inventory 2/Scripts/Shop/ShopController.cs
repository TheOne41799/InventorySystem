using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewInventorySystem.Items;

namespace NewInventorySystem.Shop
{
    public class ShopController
    {
        public ShopModel shopModel;

        public ShopController(ShopModel model)
        {
            shopModel = model;
        }

        public void PurchaseItem(ItemSO item)
        {
            //shopModel.RemoveItemFromShop(item);
        }

        public void AddItemToShop(ItemSO item)
        {
            //shopModel.AddItemToShop(item);
        }
    }
}