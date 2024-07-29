using Microsoft.AspNetCore.Mvc;
using BpkbApi.Data;
using BpkbApi.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BpkbApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User login)
        {
            var user = await _context.Users
                .Where(u => u.UserName == login.UserName && u.Password == login.Password && u.IsActive)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return Unauthorized();
            }

            // Here you might want to return a token or some user information
            return Ok(user);
        }
    }
}
