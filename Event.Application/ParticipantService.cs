using Event.Application.Interfaces;
using Event.Domain;
using Event.Infrastructure.Interfaces;

namespace Event.Application
{
    public class ParticipantService : IParticipantService
    {
        private readonly IUnitOfWork unitOfWork;

        public ParticipantService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public List<Domain.Participant> GetAllParticipants()
        {
            return unitOfWork.Participants.GetAllParticipants();
        }

        public Domain.Participant GetParticipantById(int id)
        {
            return unitOfWork.Participants.GetParticipantById(id);
        }

        public void RegisterParticipant(Participant participant)
        {
            unitOfWork.Participants.AddParticipant(participant);
            unitOfWork.Commit();
        }

        public void UnregisterParticipant(Participant participant)
        {
            if (participant != null)
            {
                unitOfWork.Participants.RemoveParticipant(participant.Id);
                unitOfWork.Commit();
            }
        }
    }
}