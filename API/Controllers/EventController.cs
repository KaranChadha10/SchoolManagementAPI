using API.DTOs;
using API.DTOs.Event;
using API.Filters;
using API.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]/[Action]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginatedList<GetEventDTO>>> GetAllEventDetails([FromQuery] EventFilter filter)
        {
            return Ok(await _eventService.GetAllEventDetails(filter));
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GetEventDTO), StatusCodes.Status200OK)]
        public async Task<ActionResult<GetEventDTO>> GetEventById(int id)
        {

            var eventdto = await _eventService.GetEventDetailById(id);
            if (eventdto == null) return NotFound();
            return Ok(eventdto);
        }

        [HttpPost]
        public async Task<ActionResult<GetEventDTO>> Create([FromBody] CreateEventDTO dto)
        {
            //dto.Created_By = Convert.ToInt64(User.Claims.ElementAt(0).Value);
            return Ok(await _eventService.CreateEventDetail(dto));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<GetEventDTO>> Update(int id, [FromBody] UpdateEventDTO dto)
        {
            //dto.Modified_By = Convert.ToInt64(User.Claims.ElementAt(0).Value);
            var eventDTO = await _eventService.UpdateEventDetail(id, dto);

            if (eventDTO == null) return NotFound();

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _eventService.DeleteEvent(id);
            if (deleted) return NoContent();
            return NotFound();
        }
    }
}
