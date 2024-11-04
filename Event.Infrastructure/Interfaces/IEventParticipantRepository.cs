using Event.Domain;

namespace Event.Infrastructure.Interfaces
{
    public interface IEventParticipantRepository
    {
        void SubscribeParticipant(int eventId, int participantId);
        void UnsubscribeParticipant(int eventId, int participantId);
    }
}