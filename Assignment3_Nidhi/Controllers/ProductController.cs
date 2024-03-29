using Microsoft.AspNetCore.Mvc;
using Assignment3_Nidhi.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Assignment3_Nidhi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AssignmentDbContext _context;

        public ProductController(AssignmentDbContext context)
        {
            _context = context;
        }

    }
}



