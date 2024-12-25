using CarsApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarsApi.Controllers
{
    public partial class CarModel
    {
        public long Id { get; set; }

        public long IdCar { get; set; }

        public string Brand { get; set; } = null!;

        public string Model { get; set; } = null!;

    }
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly CarsApiContext _context;

        public CarController(CarsApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCars()
        {
            return Ok(_context.Cars.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetCar(long id)
        {
            var car = _context.Cars.Find(id);
            if (car == null) return NotFound();
            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar(Car car)
        {
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCar), new { id = car.Id }, car);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCar(long id, Car car)
        {
            if (id != car.Id) return BadRequest();

            _context.Entry(car).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(long id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null) return NotFound();

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
