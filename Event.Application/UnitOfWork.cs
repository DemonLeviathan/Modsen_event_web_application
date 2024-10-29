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

        public UnitOfWork(ApplicationDBContext dbContext, IEventRepository events, IParticipantRepository participants)
        {
            this.dbContext = dbContext;
            Events = events;
            Participants = participants;
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