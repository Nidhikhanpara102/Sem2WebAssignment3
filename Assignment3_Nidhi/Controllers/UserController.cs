using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment3_Nidhi.Entities;
using System.Collections.Generic;
using System.Linq;

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

    }
}
