using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FormRequestAPI.Data;
using FormRequestAPI.Models;

namespace FormRequestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestInfoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RequestInfoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/RequestInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RequestInfo>>> GetRequestInfo()
        {
            return await _context.RequestInfo.ToListAsync();
        }

        // GET: api/RequestInfo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestInfo>> GetRequestInfo(int id)
        {
            var requestInfo = await _context.RequestInfo.FindAsync(id);

            if (requestInfo == null)
            {
                return NotFound();
            }

            return requestInfo;
        }

        // POST: api/RequestInfo
        [HttpPost]
        public async Task<ActionResult<RequestInfo>> PostRequestInfo(RequestInfo requestInfo)
        {
            _context.RequestInfo.Add(requestInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequestInfo", new { id = requestInfo.Id }, requestInfo);
        }

        // PUT: api/RequestInfo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequestInfo(int id, RequestInfo requestInfo)
        {
            if (id != requestInfo.Id)
            {
                return BadRequest();
            }

            // Handle the new fields here (age, address, etc.)
            _context.Entry(requestInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestInfoExists(id))
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

        // DELETE: api/RequestInfo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequestInfo(int id)
        {
            var requestInfo = await _context.RequestInfo.FindAsync(id);
            if (requestInfo == null)
            {
                return NotFound();
            }

            _context.RequestInfo.Remove(requestInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestInfoExists(int id)
        {
            return _context.RequestInfo.Any(e => e.Id == id);
        }
    }
}
