using Event.Application.Interfaces;
using Event.Infrastructure.Interfaces;

namespace Event.Application
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork unitOfWork;

        public EventService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Domain.Event> GetAllEvents()
        {
            return unitOfWork.Events.GetAllEvents();
        }

        public Domain.Event GetEventById(int id)
        {
            return unitOfWork.Events.GetEventById(id);
        }

        public Domain.Event GetEventByName(string name)
        {
            return unitOfWork.Events.GetEventByName(name);
        }

        public void AddEvent(Domain.Event @event)
        {
            unitOfWork.Events.AddEvent(@event);
            unitOfWork.Commit(); 
        }

        public void RemoveEvent(Domain.Event @event)
        {
            unitOfWork.Events.RemoveEvent(@event);
            unitOfWork.Commit();
        }

        public void UpdateEvent(Domain.Event @event)
        {
            unitOfWork.Events.UpdateEvent(@event);
            unitOfWork.Commit();
        }

        public List<Domain.Event> GetEventByDate(DateTime date)
        {
            return unitOfWork.Events.GetEventByDate(date);
        }

        public List<Domain.Event> GetEventByLocation(string location)
        {
            return unitOfWork.Events.GetEventByLocation(location);
        }

        public List<Domain.Event> GetEventByCategory(string category)
        {
            return unitOfWork.Events.GetEventByCategory(category);
        }

        public void AddImageToEvent(Domain.Event @event)
        {
            unitOfWork.Events.AddImageToEvent(@event);
            unitOfWork.Commit();
        }
    }
}
