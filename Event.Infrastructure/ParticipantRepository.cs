using Event.Application;
using Event.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Event.Infrastructure
{
    public class ParticipantRepository : IParticipantRepository
    {
        private readonly ApplicationDBContext _context;

        public ParticipantRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public void AddParticipant(Participant participant)
        {
            _context.Participants.Add(participant);
            _context.SaveChanges();
        }

        public List<Participant> GetAllParticipants()
        {
            return _context.Participants.ToList();
        }

        public Domain.Participant GetParticipantById(int id)
        {
            return _context.Participants.Find(id);
        }

        public void RemoveParticipant(int id)
        {
            var participant = GetParticipantById(id);
            if (participant != null)
            {
                _context.Participants.Remove(participant);
                _context.SaveChanges();
            }
        }
    }
}
