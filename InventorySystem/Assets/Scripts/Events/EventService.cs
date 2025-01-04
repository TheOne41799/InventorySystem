

using InventorySystem.Items;
using InventorySystem.UI;

namespace InventorySystem.Events
{
    public class EventService
    {
        private static EventService instance;
        public static EventService Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new EventService();
                }
                return instance;
            }
        }

        public EventController<UISlot> OnItemSelected { get; private set; }
        public EventController<ItemID, ItemSource> OnItemPurchaseClicked { get; private set; }

        public EventController<ItemID> OnItemPurchased { get; private set; }

        public EventService()
        {
            OnItemSelected = new EventController<UISlot>();
            OnItemPurchaseClicked = new EventController<ItemID, ItemSource>();
            OnItemPurchased = new EventController<ItemID>();
        }
    }
}