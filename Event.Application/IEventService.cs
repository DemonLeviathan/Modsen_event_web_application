using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Application
{
    public interface IEventService
    {
        List<Domain.Event> GetAllEvents();
        Domain.Event GetEventById(int id);
        Domain.Event GetEventByName(string name);
        void AddEvent(Domain.Event @event);
        void RemoveEvent(Domain.Event @event);
        void UpdateEvent(Domain.Event @event);
        List<Domain.Event> GetEventByDate(DateTime date);
        List<Domain.Event> GetEventByLocation(string location);
        List<Domain.Event> GetEventByCategory(string category);
        void AddImageToEvent(Domain.Event @event);
    }
}
