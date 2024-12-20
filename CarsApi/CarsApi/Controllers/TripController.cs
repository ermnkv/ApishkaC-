using CarsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : Controller
    {
        private readonly CarsApiContext _context;

        public TripController(CarsApiContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetTrips()
        {
            return Ok(_context.Trips.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetTrip(long id)
        {
            var trip = _context.Trips.Find(id);
            if (trip == null) return NotFound();
            return Ok(trip);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTrip(Trip trip)
        {
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTrip), new { id = trip.IdTrip }, trip);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTrip(long id, Trip trip)
        {
            if (id != trip.IdTrip) return BadRequest();

            _context.Entry(trip).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrip(long id)
        {
            var trip = await _context.Trips.FindAsync(id);
            if (trip == null) return NotFound();

            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
