using Microsoft.EntityFrameworkCore;
using W9WebAPI_CRUD_Example.Models;

namespace W9WebAPI_CRUD_Example.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
    }

}
