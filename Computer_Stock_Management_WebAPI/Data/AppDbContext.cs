using Computer_Stock_Management_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Computer_Stock_Management_WebAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }
        public DbSet<Peripheral> Peripherals { get; set; }
    }
}
