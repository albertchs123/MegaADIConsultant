using Microsoft.AspNetCore.Mvc;
using BpkbApi.Data;
using BpkbApi.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BpkbApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BpkbController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BpkbController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] Bpkb bpkb)
        {
            if (bpkb == null)
            {
                return BadRequest();
            }

            _context.Bpkbs.Add(bpkb);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Create), new { id = bpkb.AgreementNumber }, bpkb);
        }

        [HttpGet("locations")]
        public async Task<IActionResult> GetLocations()
        {
            var locations = await _context.StorageLocations.ToListAsync();
            return Ok(locations);
        }
    }
}
