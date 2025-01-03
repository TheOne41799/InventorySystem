using InventorySystem.Items;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InventorySystem.UI
{
    public class UISlot : MonoBehaviour, IPointerDownHandler
    {
        public Image slotImage;
        public TextMeshProUGUI quantityText;

        public ItemID itemID;

        public void OnPointerDown(PointerEventData eventData)
        {
            Debug.Log(itemID.ToString());
        }
    }
}
