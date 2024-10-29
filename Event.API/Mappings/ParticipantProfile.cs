using AutoMapper;
using Event.API.DTO;

namespace Event.API.Mappings
{
    public class ParticipantProfile : Profile
    {
        public ParticipantProfile()
        {
            CreateMap<Domain.Participant, ParticipantDTO>();
            CreateMap<ParticipantDTO, Domain.Participant>();
        }
        
    }
}
