using Microsoft.AspNetCore.Mvc;
using Event.Application;

namespace Event.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        public ActionResult<IList<Domain.Event>> Get()
        {
            return Ok(this.eventService.GetAllEvents());
        }
    }
}