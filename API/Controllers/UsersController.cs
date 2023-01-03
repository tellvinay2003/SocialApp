using System.Net;
using System.Runtime.CompilerServices;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;

        }

        [AllowAnonymous]
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