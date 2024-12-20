using CarsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelController : Controller
    {
        private readonly CarsApiContext _context;

        public ChannelController(CarsApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetChannels()
        {
            return Ok(_context.Channels.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetChannel(long id)
        {
            var channel = _context.Channels.Find(id);
            if (channel == null) return NotFound();
            return Ok(channel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateChannel(Channel channel)
        {
            _context.Channels.Add(channel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetChannel), new { id = channel.Id }, channel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateChannel(long id, Channel channel)
        {
            if (id != channel.Id) return BadRequest();

            _context.Entry(channel).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChannel(long id)
        {
            var channel = await _context.Channels.FindAsync(id);
            if (channel == null) return NotFound();

            _context.Channels.Remove(channel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

