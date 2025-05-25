using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using FormRequestAPI.Data;
using FormRequestAPI.Hubs;
using FormRequestAPI.Models;

namespace FormRequestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<RequestHub> _hubContext;

        public RequestController(AppDbContext context, IHubContext<RequestHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        // Create a new request
        [HttpPost]
        public async Task<IActionResult> CreateRequest([FromBody] RequestInfo request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

            _context.RequestInfo.Add(request);
            await _context.SaveChangesAsync();

            await _hubContext.Clients.All.SendAsync("ReceiveNewRequest", request);

            return CreatedAtAction(nameof(GetRequestById), new { id = request.Id }, request);
        }

        // Get request by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<RequestInfo>> GetRequestById(int id)
        {
            var request = await _context.RequestInfo.FindAsync(id);

            if (request == null)
            {
                return NotFound();
            }

            return Ok(request);
        }

        // Existing: Update status
        [HttpPost("updateStatus")]
        public async Task<IActionResult> UpdateStatus([FromBody] StatusUpdateRequest request)
        {
            var requestInfo = await _context.RequestInfo
                .FirstOrDefaultAsync(r => r.Id == request.Id);

            if (requestInfo == null)
            {
                return NotFound("Request not found.");
            }

            requestInfo.Status = request.Status;
            await _context.SaveChangesAsync();

            // Use SignalR to notify all connected clients about the status update
            await _hubContext.Clients.All.SendAsync("ReceiveStatusUpdate", requestInfo.StudentId, request.Status);

            return Ok("Status updated and notification sent.");
        }

    }

    public class StatusUpdateRequest
    {
        public int Id { get; set; }
        public string? Status { get; set; }
    }
}
