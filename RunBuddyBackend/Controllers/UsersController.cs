using Microsoft.AspNetCore.Mvc;
using RunBuddyBackend.BusinessLogic;
using RunBuddyBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RunBuddyBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: api/users - Create a new user
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var createdUser = await _userService.CreateUserAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        // GET: api/users/{id} - Get a user by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) return NotFound();

            return Ok(user);
        }

        // GET: api/users - Get all users
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // PUT: api/users/{id} - Update a user
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != user.Id) return BadRequest("User ID mismatch");

            var updatedUser = await _userService.UpdateUserAsync(user);
            if (updatedUser == null) return NotFound();

            return Ok(updatedUser);
        }

        // DELETE: api/users/{id} - Delete a user
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result) return NotFound();

            return NoContent();
        }
    }
}
