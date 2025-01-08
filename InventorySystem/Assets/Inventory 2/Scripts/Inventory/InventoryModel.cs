using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NewInventorySystem.Items;

namespace NewInventorySystem.Inventory
{
    public class InventoryModel
    {
        private List<InventorySlot> inventorySlots;

        public InventoryModel(int numSlots)
        {
            inventorySlots = new List<InventorySlot>();

            for (int i = 0; i < numSlots; i++)
            {
                inventorySlots.Add(new InventorySlot());
            }
        }

        public void AddItem(ItemSO item)
        {
            for (int i = 0; i < inventorySlots.Count; i++)
            {
                if (inventorySlots[i].item == null)
                {
                    inventorySlots[i].item = item;
                    return;
                }
            }
        }

        public void RemoveItem(ItemSO item)
        {
            for (int i = 0; i < inventorySlots.Count; i++)
            {
                if (inventorySlots[i].item == item)
                {
                    inventorySlots[i].item = null;
                    return;
                }
            }
        }

        public List<InventorySlot> GetInventorySlots() => inventorySlots;
    }
}
