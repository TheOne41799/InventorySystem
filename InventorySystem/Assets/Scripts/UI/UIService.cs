

using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.UI
{
    public class UIService: MonoBehaviour
    {
        public GameObject slotPanel;
        public GameObject inventoryslot;

        public List<GameObject> items = new List<GameObject>();

        public int totalInventorySlots = 30;


        private void Start()
        {
            for (int i = 0; i < totalInventorySlots; i++)
            {
                GameObject newItem = Instantiate(inventoryslot);
                newItem.transform.SetParent(slotPanel.transform);

                RectTransform rectTransform = newItem.GetComponent<RectTransform>();
                rectTransform.localScale = Vector3.one;
                rectTransform.anchoredPosition3D = Vector3.zero;
                rectTransform.localRotation = Quaternion.identity;

                items.Add(newItem);
            }
        }
    }
}