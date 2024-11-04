namespace Event.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository Events { get; }
        IParticipantRepository Participants { get; }
        IEventParticipantRepository EventParticipants { get; }
        IUserRepository Users { get; }
        void Commit();
        void Rollback();
    }
}