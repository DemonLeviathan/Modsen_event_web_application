namespace Event.Application
{
    public class EventService : IEventService
    {
        private readonly IEventRepository eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            this.eventRepository = eventRepository;
        }

        public void AddEvent(Domain.Event @event)
        {
            eventRepository.AddEvent(@event);
        }

        public void AddImageToEvent(Domain.Event @event)
        {
            eventRepository.AddImageToEvent(@event);
        }

        public List<Domain.Event> GetEventByCategory(string category)
        {
            return eventRepository.GetEventByCategory(category);
        }

        public List<Domain.Event> GetEventByDate(DateTime date)
        {
            return eventRepository.GetEventByDate(date);
        }

        public Domain.Event GetEventById(int id)
        {
            return eventRepository.GetEventById(id);
        }

        public List<Domain.Event> GetEventByLocation(string location)
        {
            return eventRepository.GetEventByLocation(location);
        }

        public Domain.Event GetEventByName(string name)
        {
            return eventRepository.GetEventByName(name);
        }

        public void RemoveEvent(Domain.Event @event)
        {
            eventRepository.RemoveEvent(@event);
        }

        public void UpdateEvent(Domain.Event @event)
        {
            eventRepository.UpdateEvent(@event);
        }

        List<Domain.Event> IEventService.GetAllEvents()
        {
            return this.eventRepository.GetAllEvents();
        }
    }
}