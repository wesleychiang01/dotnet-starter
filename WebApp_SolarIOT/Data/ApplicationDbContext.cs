using Microsoft.EntityFrameworkCore;
using WebApp_SolarIOT.Models;

namespace WebApp_SolarIOT.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        
        }

        public DbSet<ParameterEntities> parameters { get; set; }

    }
}
