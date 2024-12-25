using CarsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarsApi.Controllers
{
    public partial class UserModel
    {
        public long Id { get; set; }

        public string Login { get; set; } = null!;

        public string Name { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
        [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CarsApiContext _context;

        public UsersController(CarsApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_context.Users.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(long id)
        {
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserModel user)
        {
            var model1 = new User()
            {
                Name = user.Name,
                Login = user.Login,
                Password = user.Password,

            };
            _context.Users.Add(model1);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(long id, UserModel user)
        {
            var model1 = new User()
            {
                Name = user.Name,
                Login = user.Login,
                Password = user.Password,

            };
            if (id != model1.Id) return BadRequest();

            _context.Entry(model1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
