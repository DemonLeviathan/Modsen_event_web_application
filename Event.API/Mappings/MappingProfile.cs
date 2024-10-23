using AutoMapper;
using Event.API.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Event.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Event, EventDTO>();
            CreateMap<EventDTO, Domain.Event>();

            CreateMap<Domain.Participant, ParticipantDTO>();
            CreateMap<ParticipantDTO, Domain.Participant>();
        }
    }
}
