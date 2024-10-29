namespace Event.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository Events { get; }
        IParticipantRepository Participants { get; }

        void Commit();
        void Rollback();
    }
}