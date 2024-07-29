using EventManager.Interfaces.Managers;
using EventManager.Shared.Modelviews;
using EventManager.Shared.Modelviews.Event;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventApi.Controllers.Event
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventManager  _eventManager;

        public EventController(IEventManager eventManager)
        {
            _eventManager = eventManager;
        }

        [HttpGet]
        [ProducesResponseType(typeof(EventView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get()
        {
            var events = await _eventManager.GetAllEventsAsync();

            if (events == null)
            {
                return NotFound();
            }
            return Ok(events);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EventView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Get(int id)
        {
            var eventFinded = await _eventManager.GetEventByIdAsync(id); 

            if (eventFinded.Id == 0)
            {
                return NotFound();
            }
            return Ok(eventFinded);
        }

        [HttpPost]
        [ProducesResponseType(typeof(EventView), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NewEvent newEvent)
        {
            var eventAdded = await _eventManager.InsertEventAsync(newEvent);
            if (eventAdded == null) { return NotFound(); }
            return CreatedAtAction(nameof(Get), new { eventAdded.Id }, eventAdded);
        }

        [HttpPut]
        [ProducesResponseType(typeof(EventView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(UpdateEvent updateEvent)
        {
            var eventUpdated = await _eventManager.UpdateEventAsync(updateEvent);
            if (eventUpdated == null)
            {
                return NotFound();
            }
            return Ok(eventUpdated);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            var eventExcluded = await _eventManager.DeleteEventAsync(id);
            if (eventExcluded == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}