using Models;

namespace Logic
{
    public class EventManager
    {
        private IEventRepository eventRepository;
        public EventManager(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }
        public List<Event> GetAllEvents()
        {
            return eventRepository.GetAllEvents();
        }
        public List<Event> GetAllCurrentEvents()
        {
            return eventRepository.GetAllCurrentEvents();
        }
        public Event GetEventById(int id)
        {
            return eventRepository.GetEventById(id);
        }
        public Event CreateEvent(string title, string description, User author, DateTime publishDate, DateTime startDate, DateTime endDate)
        {
            return eventRepository.CreateEvent(title, description, author, publishDate, startDate, endDate);
        }
        public void UpdateEvent(int id, string title, string description, DateTime startDate, DateTime endDate)
        {
            eventRepository.UpdateEvent(id, title, description, startDate, endDate);
        }
        public void DeleteEvent(int id)
        {
            eventRepository.DeleteEvent(id);
        }
    }
}
