using Event.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Application
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository participantRepository;

        public ParticipantService(IParticipantRepository participantRepository)
        {
            this.participantRepository = participantRepository;
        }
        public List<Domain.Participant> GetAllParticipants()
        {
            return this.participantRepository.GetAllParticipants();
        }

        public Domain.Participant GetParticipantById(int id)
        {
            return participantRepository.GetParticipantById(id);
        }

        public void RegisterParticipant(Participant participant)
        {
            this.participantRepository.AddParticipant(participant);
        }

        public void UnregisterParticipant(Participant participant)
        {
            if (participant != null)
            {
                this.participantRepository.RemoveParticipant(participant.Id);
            }
        }
    }
}
