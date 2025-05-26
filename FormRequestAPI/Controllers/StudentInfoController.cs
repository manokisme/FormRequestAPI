using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FormRequestAPI.Data;
using FormRequestAPI.Models;

namespace FormRequestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentInfoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentInfoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/StudentInfo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentInfo>>> GetStudentInfo()
        {
            return await _context.StudentInfo.ToListAsync();
        }

        // GET: api/StudentInfo/{idNumber} 
        [HttpGet("{idNumber}")]
        public async Task<ActionResult<StudentInfo>> GetStudentInfo(string idNumber)
        {
            // Search for student using IdNumber
            var studentInfo = await _context.StudentInfo
                                             .FirstOrDefaultAsync(s => s.IdNumber == idNumber);

            if (studentInfo == null)
            {
                return NotFound();
            }

            return studentInfo;
        }

        // POST: api/StudentInfo
        [HttpPost]
        public async Task<ActionResult<StudentInfo>> PostStudentInfo(StudentInfo studentInfo)
        {
            _context.StudentInfo.Add(studentInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentInfo", new { idNumber = studentInfo.IdNumber }, studentInfo); 
        }

        // PUT: api/StudentInfo/{idNumber}
        [HttpPut("{idNumber}")]
        public async Task<IActionResult> PutStudentInfo(string idNumber, StudentInfo studentInfo)
        {
            if (idNumber != studentInfo.IdNumber) 
            {
                return BadRequest();
            }

            _context.Entry(studentInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentInfoExists(idNumber)) // Check by IdNumber
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

        // DELETE: api/StudentInfo/{idNumber}
        [HttpDelete("{idNumber}")]
        public async Task<IActionResult> DeleteStudentInfo(string idNumber)
        {
            var studentInfo = await _context.StudentInfo
                                             .FirstOrDefaultAsync(s => s.IdNumber == idNumber); // Search by IdNumber
            if (studentInfo == null)
            {
                return NotFound();
            }

            _context.StudentInfo.Remove(studentInfo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // check if student exists by IdNumber
        private bool StudentInfoExists(string idNumber)
        {
            return _context.StudentInfo.Any(e => e.IdNumber == idNumber); 
        }
    }
}
