

using InventorySystem.Items;

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

        public EventController<ItemID> OnItemSelected { get; private set; }

        public EventService()
        {
            OnItemSelected = new EventController<ItemID>();
        }
    }
}