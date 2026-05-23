using Microsoft.EntityFrameworkCore;
using TechMoveAPI.Models;

namespace TechMoveAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<Contract> Contracts { get; set; }
    }
}
