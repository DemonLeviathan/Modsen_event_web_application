using Event.Application.Interfaces;
using Event.Domain;
using Event.Infrastructure.Interfaces;

namespace Event.Application
{
    public class EventParticipantService : IEventParticipantService
    {
        private readonly IUnitOfWork unitOfWork;
        public EventParticipantService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void SubscribeToEvent(int eventId, int participantId)
        {
            var eventParticipant = new EventParticipant { EventId = eventId, ParticipantId = participantId };
            unitOfWork.EventParticipants.SubscribeParticipant(eventId, participantId);
            unitOfWork.Commit();
        }

        public void UnsubscribeFromEvent(int eventId, int participantId)
        {
            throw new NotImplementedException();
        }
    }
}