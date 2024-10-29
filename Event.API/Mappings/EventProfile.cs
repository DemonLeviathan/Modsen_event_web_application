using AutoMapper;
using Event.API.DTO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Event.API.Mappings
{
    public class EventProfile : Profile
    {
        public EventProfile()
        {
            CreateMap<Domain.Event, EventDTO>();
            CreateMap<EventDTO, Domain.Event>()
             .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null && !srcMember.Equals(default(DateTime))));
        }
    }
}