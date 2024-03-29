
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment3_Nidhi.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Assignment3_Nidhi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AssignmentDbContext _context;

        public UserController(AssignmentDbContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _context.Users.ToList();
            if (users.Count == 0)
            {
                return NotFound("No users found");
            }
            return users;
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return NotFound("User does not exist");
            }

            return user;
        }

        // POST: api/User
        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid user data");
            }

            _context.Users.Add(user);
            _context.SaveChanges();

            var successMessage = "User created successfully";

            return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, new { user, message = successMessage } );
        }


        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest("Invalid user ID");
            }

            var existingUser = _context.Users.Find(id);
            if (existingUser == null)
            {
                return NotFound("User not found");
            }

            _context.Entry(existingUser).CurrentValues.SetValues(user);
            _context.SaveChanges();

            return Ok("User updated successfully");

        }


        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public ActionResult<User> DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound("User does not exist");
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return Ok($"User with ID {id} has been successfully deleted");
        }
    }
}

