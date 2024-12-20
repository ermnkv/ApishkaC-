using CarsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly CarsApiContext _context;

        public EventController(CarsApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetEvents()
        {
            return Ok(_context.Events.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetEvent(long id)
        {
            var events = _context.Events.Find(id);
            if (events == null) return NotFound();
            return Ok(events);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(Event events)
        {
            _context.Events.Add(events);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetEvent), new { id = events.IdEvent }, events);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEvent(long id, Event events)
        {
            if (id != events.IdEvent) return BadRequest();

            _context.Entry(events).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(long id)
        {
            var events = await _context.Events.FindAsync(id);
            if (events == null) return NotFound();

            _context.Events.Remove(events);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
