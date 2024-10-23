using Event.Application;
using Event.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Event.Infrastructure
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDBContext _context;

        public EventRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public void AddEvent(Domain.Event @event)
        {
            _context.Events.Add(@event);
            _context.SaveChanges();
        }

        public void AddImageToEvent(Domain.Event @event)
        {
            var existingEvent = GetEventById(@event.Id);
            if (existingEvent != null)
            {
                existingEvent.ImageUrl = @event.ImageUrl;
                _context.SaveChanges();
            }
        }

        public List<Domain.Event> GetAllEvents()
        {
            return _context.Events.ToList();
        }

        public List<Domain.Event> GetEventByCategory(string category)
        {
            return _context.Events
                .Where(e => e.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public List<Domain.Event> GetEventByDate(DateTime date)
        {
            return _context.Events
                .Where(e => e.EventDateTime.Date == date.Date)
                .ToList();
        }

        public Domain.Event GetEventById(int id)
        {
            return _context.Events.Find(id);
        }

        public List<Domain.Event> GetEventByLocation(string location)
        {
            return _context.Events
                .Where(e => e.Location.Equals(location, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public Domain.Event GetEventByName(string name)
        {
            return _context.Events
                .FirstOrDefault(e => e.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        public void RemoveEvent(Domain.Event @event)
        {
            _context.Events.Remove(@event);
            _context.SaveChanges();
        }

        public void UpdateEvent(Domain.Event @event)
        {
            _context.Events.Update(@event);
            _context.SaveChanges();
        }
    }
}
