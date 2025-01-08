using InventorySystem.Events;
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
        //public TextMeshProUGUI quantityText;

        public GameObject outline;

        public ItemID itemID;

        public ItemSource itemSource;

        

        public void OnPointerDown(PointerEventData eventData)
        {
            EventService.Instance.OnItemSelected.InvokeEvent(this);
        }

        public void SetOutline(bool isActive)
        {
            if (outline != null)
                outline.SetActive(isActive);
        }
    }
}
