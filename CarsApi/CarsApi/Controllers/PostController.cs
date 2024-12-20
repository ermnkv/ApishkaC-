using CarsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly CarsApiContext _context;

        public PostController(CarsApiContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetPosts()
        {
            return Ok(_context.Posts.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetPost(long id)
        {
            var post = _context.Posts.Find(id);
            if (post == null) return NotFound();
            return Ok(post);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPost), new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(long id, Post post)
        {
            if (id != post.Id) return BadRequest();

            _context.Entry(post).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(long id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return NotFound();

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
