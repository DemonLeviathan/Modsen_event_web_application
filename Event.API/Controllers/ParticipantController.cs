using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Event.Application;

namespace Event.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly IParticipantService participantService;

        public ParticipantController(IParticipantService participantService)
        {
            this.participantService = participantService;
        }

        [HttpGet]
        public ActionResult<IList<Domain.Participant>> Get()
        {
            return Ok(this.participantService.GetAllParticipants());
        }

    }
}
