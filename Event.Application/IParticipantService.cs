using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Application
{
    public interface IParticipantService
    {
        List<Domain.Participant> GetAllParticipants();
        Domain.Participant GetParticipantById(int id);

        void RegisterParticipant(Domain.Participant participant);
        void UnregisterParticipant(Domain.Participant participant);
    }
}
