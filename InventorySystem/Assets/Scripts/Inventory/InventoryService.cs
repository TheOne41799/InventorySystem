
using InventorySystem.Events;
using InventorySystem.Items;
using InventorySystem.UI;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem.Inventory
{
    public class InventoryService
    {
        private ItemDatabaseSO database;
        private UIService uIService;

        public int totalInventorySlots = 30;

        public List<UISlot> slots = new List<UISlot>();

        public List<ItemSO> inventoryItems = new List<ItemSO>();

        public int currentSlotIndex;


        //How to add an item
        //  Check for cash, weight of inventory, availability of slot in inventory
        //  Purchase item
        //  After purchasing check if the item is stackable
        //      If yes, look for the first similar item, look for stack amount, if enough place - add
        //      else keep looking until you find one
        //      If none found, add item in the first empty slot
        //      If not stackable, add item in the first empty slot


        public InventoryService(ItemDatabaseSO db, UIService uiServ)
        {
            this.database = db;
            this.uIService = uiServ;

            currentSlotIndex = 0;


            EventService.Instance.OnItemPurchased.AddListener(AddItem);


            EventService.Instance.OnItemSold.AddListener(RemoveItem);
        }

        ~InventoryService()
        {
            EventService.Instance.OnItemPurchased.RemoveListener(AddItem);


            EventService.Instance.OnItemSold.RemoveListener(RemoveItem);
        }

        public void InitializeInventoryUI()
        {
            for (int i = 0; i < totalInventorySlots; i++)
            {
                GameObject newItem = GameObject.Instantiate(uIService.uiSlotPrefab);
                newItem.transform.SetParent(uIService.inventorySlotPanel.transform);

                RectTransform rectTransform = newItem.GetComponent<RectTransform>();
                rectTransform.localScale = Vector3.one;
                rectTransform.anchoredPosition3D = Vector3.zero;
                rectTransform.localRotation = Quaternion.identity;

                UISlot slot = newItem.GetComponent<UISlot>();
                slots.Add(slot);
                uIService.AddInventorySlots(slot);


            }
        }



        /*public void AddItem(ItemID id)
        {
            if (inventoryItems.Count < totalInventorySlots)
            {
                for (int i = 0; i < database.items.Count; i++)
                {
                    if (database.items[i].itemID == id)
                    {
                        inventoryItems.Add(database.items[i]);
                        uIService.SetSlotProperties(currentSlotIndex, database.items[i].quantity, database.items[i].itemIcon);

                        UISlot slot = slots[currentSlotIndex].GetComponent<UISlot>();
                        slot.slotImage.sprite = database.items[i].itemIcon;
                        slot.quantityText.text = database.items[i].quantity.ToString();
                        slot.itemID = database.items[i].itemID;
                        slot.itemSource = ItemSource.INVENTORY_ITEM;
                    }
                }

                currentSlotIndex++;
            }
            else
            {
                Debug.Log("Not possible to purchase inventory item");
            }
        }*/


        public void AddItem(ItemID id)
        {
            ItemSO itemToAdd = null;
            for (int i = 0; i < database.items.Count; i++)
            {
                if (database.items[i].itemID == id)
                {
                    itemToAdd = database.items[i];
                    break;
                }
            }

            if (itemToAdd == null)
            {
                Debug.LogError("Item not found in database.");
                return;
            }

            if (inventoryItems.Count < totalInventorySlots)
            {
                inventoryItems.Add(itemToAdd);

                for (int i = 0; i < slots.Count; i++)
                {
                    if (slots[i].slotImage.sprite == null)
                    {
                        slots[i].slotImage.sprite = itemToAdd.itemIcon;
                        slots[i].itemID = itemToAdd.itemID;
                        slots[i].itemSource = ItemSource.INVENTORY_ITEM;
                        break;
                    }
                }
            }
            else
            {
                Debug.LogWarning("Inventory full, can't add item.");
            }
        }

        public void RemoveItem(ItemID id)
        {
            ItemSO itemToSell = null;
            int indexToRemove = -1;

            for (int i = 0; i < inventoryItems.Count; i++)
            {
                if (inventoryItems[i].itemID == id)
                {
                    itemToSell = inventoryItems[i];
                    indexToRemove = i;
                    break;
                }
            }

            if (itemToSell == null)
            {
                Debug.LogWarning("Item not found in inventory.");
                return;
            }

            inventoryItems.RemoveAt(indexToRemove);

            RemoveSlot(indexToRemove);
        }

        private void RemoveSlot(int index)
        {
            if (index < 0 || index >= slots.Count) return;

            slots[index].slotImage.sprite = null;
            slots[index].itemID = ItemID.NONE;
            slots[index].itemSource = ItemSource.NONE;

            for (int i = index; i < slots.Count - 1; i++)
            {
                slots[i].slotImage.sprite = slots[i + 1].slotImage.sprite;
                slots[i].itemID = slots[i + 1].itemID;
                slots[i].itemSource = slots[i + 1].itemSource;

                slots[i + 1].slotImage.sprite = null;
                slots[i + 1].itemID = ItemID.NONE;
                slots[i + 1].itemSource = ItemSource.NONE;
            }
        }










    }
}