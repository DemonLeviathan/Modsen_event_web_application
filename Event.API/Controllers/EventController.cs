using Microsoft.AspNetCore.Mvc;
using Event.API.DTO;
using AutoMapper;
using Event.Application.Interfaces;

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

        [HttpGet("{id:int}")]
        public IActionResult GetEventById(int id)
        {            
            var eventItem = eventService.GetEventById(id);
            if (eventItem == null)
            {
                return BadRequest("Event not exist");
            }

            var eventDto = new EventDTO
            {
                Id = eventItem.Id,
                Name = eventItem.Name,
                Description = eventItem.Description,
                EventDateTime = eventItem.EventDateTime,
                Location = eventItem.Location,
                Category = eventItem.Category,
                ImageUrl = eventItem.ImageUrl
            };
            return Ok(eventDto);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetEventByName(string name)
        {
            var eventItem = eventService.GetEventByName(name);
            if (eventItem == null)
            {
                return NotFound("Event not exist");
            }

            var eventDto = new EventDTO
            {
                Id = eventItem.Id,
                Name = eventItem.Name,
                Description = eventItem.Description,
                EventDateTime = eventItem.EventDateTime,
                Location = eventItem.Location,
                Category = eventItem.Category,
                ImageUrl = eventItem.ImageUrl
            };
            return Ok(eventDto);
        }

        [HttpGet("location/{location}")]
        public IActionResult GetEventByLocation(string location)
        {
            var eventItem = eventService.GetEventByLocation(location);
            if (eventItem == null || eventItem.Count == 0)
            {
                return NotFound("Event not exist");
            }

            var eventDto = eventItem.Select(x => new EventDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                EventDateTime = x.EventDateTime,
                Location = x.Location,
                Category = x.Category,
                ImageUrl = x.ImageUrl  
            }).ToList();
            return Ok(eventDto);
        }

        [HttpGet("category/{category}")]
        public IActionResult GetEventByCategory(string category)
        {
            var eventItem = eventService.GetEventByCategory(category);
            if (eventItem == null || eventItem.Count ==0)
            {
                return NotFound("Event not exist");
            }

            var eventDto = eventItem.Select(x => new EventDTO
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                EventDateTime = x.EventDateTime,
                Location = x.Location,
                Category = x.Category,
                ImageUrl = x.ImageUrl
            }).ToList();
            return Ok(eventDto);
        }

        [HttpPost]
        public IActionResult CreateEvent([FromBody] EventDTO eventDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newEvent = new Domain.Event
            {
                Name = eventDTO.Name,
                Description = eventDTO.Description,
                EventDateTime = eventDTO.EventDateTime,
                Location = eventDTO.Location,
                Category = eventDTO.Category,
                ImageUrl = eventDTO.ImageUrl ?? string.Empty
            };

            eventService.AddEvent(newEvent);

            return CreatedAtAction(nameof(GetEventById), new { id = newEvent.Id }, newEvent);
        }
        
        [HttpPut("{id}")] 
        public IActionResult UpdateEvent(int id, [FromBody] EventDTO eventDTO, [FromServices] IMapper mapper)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var findEvent = eventService.GetEventById(eventDTO.Id);
            if (findEvent == null)
            {
                return NotFound("Event not exist");
            }

            mapper.Map(eventDTO, findEvent); 
            eventService.UpdateEvent(findEvent);
            return Ok();
        }

        [HttpPut]
        public IActionResult AddImageToEvent(int id, string link)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var findEvent = eventService.GetEventById(id);

            if (findEvent == null)
            {
                return NotFound("Event not exist");
            }

            findEvent.ImageUrl = link;
            return Ok("Image link successfully added to event");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEvent(int id)
        {
            var findEvent = eventService.GetEventById(id);
            if (findEvent == null)
            {
                return NotFound("Event not exist");
            }

            eventService.RemoveEvent(findEvent);
            return NoContent();
        }

    }
}