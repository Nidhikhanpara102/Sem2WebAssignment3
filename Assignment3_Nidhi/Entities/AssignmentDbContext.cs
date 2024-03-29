using Microsoft.EntityFrameworkCore;
using Assignment3_Nidhi.Entities;
using System.Collections.Generic;

namespace Assignment3_Nidhi.Entities
{
    public class AssignmentDbContext : DbContext
    {
        public AssignmentDbContext(DbContextOptions<AssignmentDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}
