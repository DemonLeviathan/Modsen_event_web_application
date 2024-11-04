using Event.Domain;
using Event.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Infrastructure
{
    public class EventParticipantRepository : IEventParticipantRepository
    {
        private readonly ApplicationDBContext _context;

        public EventParticipantRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public void SubscribeParticipant(int eventId, int participantId)
        {
            var eventParticipant = new EventParticipant
            {
                EventId = eventId,
                ParticipantId = participantId
            };
            _context.EventParticipants.Add(eventParticipant);
        }

        public void UnsubscribeParticipant(int eventId, int participantId)
        {
            var eventParticipant = _context.EventParticipants
               .FirstOrDefault(ep => ep.EventId == eventId && ep.ParticipantId == participantId);
            if (eventParticipant != null)
            {
                _context.EventParticipants.Remove(eventParticipant);
            }
        }
    }
}
