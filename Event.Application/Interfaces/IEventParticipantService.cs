using Event.Domain;

namespace Event.Application.Interfaces
{
    public interface IEventParticipantService
    {
        void SubscribeToEvent(int eventId, int participantId);
        void UnsubscribeFromEvent(int eventId, int participantId);
    }
}