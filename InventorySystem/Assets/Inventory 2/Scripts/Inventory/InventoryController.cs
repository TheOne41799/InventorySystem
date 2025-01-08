using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewInventorySystem.Items;

namespace NewInventorySystem.Inventory
{
    public class InventoryController
    {
        public InventoryModel inventoryModel;

        public InventoryController(InventoryModel model)
        {
            inventoryModel = model;
        }

        public void SellItem(ItemSO item)
        {
            inventoryModel.RemoveItem(item);
        }

        public void PurchaseItem(ItemSO item)
        {
            inventoryModel.AddItem(item);
        }
    }
}