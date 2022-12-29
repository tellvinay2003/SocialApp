using System.Net;
using System.Runtime.CompilerServices;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    // [Route("api/v1/[controller]")]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;

        }


        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AppUser>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AppUser), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            // var user = _context.Users.Find(id);
            // return user;
            return await _context.Users.FindAsync(id);
        }
    }
}