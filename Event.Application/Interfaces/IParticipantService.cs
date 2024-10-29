namespace Event.Application.Interfaces
{
    public interface IParticipantService
    {
        List<Domain.Participant> GetAllParticipants();
        Domain.Participant GetParticipantById(int id);

        void RegisterParticipant(Domain.Participant participant);
        void UnregisterParticipant(Domain.Participant participant);
    }
}