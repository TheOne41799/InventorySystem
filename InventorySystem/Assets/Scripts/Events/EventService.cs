

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

        public EventController<ItemID> OnItemPurchased { get; private set; }



        public EventController<ItemID> OnItemSold { get; private set; }

        public EventService()
        {
            OnItemSelected = new EventController<UISlot>();
            OnItemPurchased = new EventController<ItemID>();


            OnItemSold = new EventController<ItemID>();
        }
    }
}