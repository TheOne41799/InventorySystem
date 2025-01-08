using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NewInventorySystem.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        public GameObject slotPrefab;
        public Transform inventoryParent;
        public InventoryController inventoryController;
        private List<InventorySlotView> slotViews = new List<InventorySlotView>();

        public void Initialize(InventoryController controller)
        {
            inventoryController = controller;

            foreach (var slot in inventoryController.inventoryModel.GetInventorySlots())
            {
                var slotView = Instantiate(slotPrefab, inventoryParent).GetComponent<InventorySlotView>();
                slotView.Initialize(slot);
                slotViews.Add(slotView);
            }
        }

        public void UpdateInventoryUI()
        {
            for (int i = 0; i < slotViews.Count; i++)
            {
                slotViews[i].UpdateSlotUI();
            }
        }
    }
}
