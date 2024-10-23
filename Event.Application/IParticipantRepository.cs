using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Application
{
    public interface IParticipantRepository
    {
        List<Domain.Participant> GetAllParticipants();
        Domain.Participant GetParticipantById(int id);
        void AddParticipant(Domain.Participant participant);
        void RemoveParticipant(int id);
    }
}
