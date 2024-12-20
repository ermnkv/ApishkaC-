using CarsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : Controller
    {
        private readonly CarsApiContext _context;

        public CommentController(CarsApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetComments()
        {
            return Ok(_context.Comments.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(long id)
        {
            var comment = _context.Comments.Find(id);
            if (comment == null) return NotFound();
            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetComment), new { id = comment.Id }, comment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(long id, Comment comment)
        {
            if (id != comment.Id) return BadRequest();

            _context.Entry(comment).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(long id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null) return NotFound();

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

