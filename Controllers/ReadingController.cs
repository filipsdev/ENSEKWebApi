using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ENSEK.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingController : ControllerBase
    {
        private readonly DataContext _context;

        public ReadingController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Reading>>> Get()
        {
            return Ok(await _context.Readings.ToListAsync());
        }

        [HttpGet("{AccountId}")]
        public async Task<ActionResult<List<Reading>>> Get(int AccountId)
        {
            var reading = await _context.Readings.FindAsync(AccountId);
            if (reading == null)
                return BadRequest("Reading not found.");
            return Ok(reading);
        }

        [HttpPost]
        public async Task<ActionResult<List<Reading>>> AddReading(Reading reading)
        {
            _context.Readings.Add(reading);
            await _context.SaveChangesAsync();

            return Ok(await _context.Readings.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Reading>>> UpdateReading(Reading request)
        {
            var dbReading = await _context.Readings.FindAsync(request.Id);
            if (dbReading == null)
                return BadRequest("Reading not found.");

            dbReading.AccountId = request.AccountId;
            dbReading.MeterReadingDateTime = request.MeterReadingDateTime;
            dbReading.MeterReadValue = request.MeterReadValue;

            await _context.SaveChangesAsync();

            return Ok(await _context.Readings.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Reading>>> Delete(int id)
        {
            var dbReading = await _context.Readings.FindAsync(id);
            if (dbReading == null)
                return BadRequest("Reading not found.");

            _context.Readings.Remove(dbReading);
            await _context.SaveChangesAsync();

            return Ok(await _context.Readings.ToListAsync());
        }
    }
}
