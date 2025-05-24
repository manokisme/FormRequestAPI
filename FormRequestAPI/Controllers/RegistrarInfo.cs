using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FormRequestAPI.Data;
using FormRequestAPI.Models;

namespace FormRequestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrarInfoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegistrarInfoController(AppDbContext context)
        {
            _context = context;
        }
        // POST: api/RegistrarInfo/Login
        [HttpPost("Login")]
        public async Task<ActionResult<RegistrarInfo>> Login([FromBody] LoginRequest loginRequest)
        {
            // Look for the registrar with the matching ID and Password
            var registrarInfo = await _context.RegistrarInfo
                .FirstOrDefaultAsync(r => r.IdNumber == loginRequest.IdNumber && r.Password == loginRequest.Password);

            if (registrarInfo == null)
            {
                return Unauthorized("Invalid login credentials.");
            }

            // If credentials are correct, return the registrar's info
            return Ok(registrarInfo);
        }

        // Define a simple LoginRequest DTO (Data Transfer Object)
        public class LoginRequest
        {
            public required string IdNumber { get; set; }
            public required string Password { get; set; }
        }

        // GET: api/RegistrarInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegistrarInfo>>> GetRegistrarInfo()
        {
            return await _context.RegistrarInfo.ToListAsync();
        }

        // GET: api/RegistrarInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegistrarInfo>> GetRegistrarInfo(int id)
        {
            var registrarInfo = await _context.RegistrarInfo.FindAsync(id);

            if (registrarInfo == null)
            {
                return NotFound();
            }

            return registrarInfo;
        }

        // POST: api/RegistrarInfo
        [HttpPost]
        public async Task<ActionResult<RegistrarInfo>> PostRegistrarInfo(RegistrarInfo registrarInfo)
        {
            _context.RegistrarInfo.Add(registrarInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegistrarInfo", new { id = registrarInfo.Id }, registrarInfo);
        }

        // PUT: api/RegistrarInfo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegistrarInfo(int id, RegistrarInfo registrarInfo)
        {
            if (id != registrarInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(registrarInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegistrarInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/RegistrarInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegistrarInfo(int id)
        {
            var registrarInfo = await _context.RegistrarInfo.FindAsync(id);
            if (registrarInfo == null)
            {
                return NotFound();
            }

            _context.RegistrarInfo.Remove(registrarInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegistrarInfoExists(int id)
        {
            return _context.RegistrarInfo.Any(e => e.Id == id);
        }
    }
}
