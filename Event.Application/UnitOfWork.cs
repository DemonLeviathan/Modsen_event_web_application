using Event.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using Event.Infrastructure;

namespace Event.Application
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext dbContext;
        public IEventRepository Events { get; }
        public IParticipantRepository Participants { get; }

        public IEventParticipantRepository EventParticipants {  get; }

        public IUserRepository Users { get; }

        public UnitOfWork(ApplicationDBContext dbContext, IEventRepository events, IParticipantRepository participants, IEventParticipantRepository eventParticipants, IUserRepository users)
        {
            this.dbContext = dbContext;
            Events = events;
            Participants = participants;
            EventParticipants = eventParticipants;
            Users = users;
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        public void Rollback()
        {
            
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}