using Microsoft.EntityFrameworkCore;
using FormRequestAPI.Models;

namespace FormRequestAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<StudentInfo> StudentInfo { get; set; }
        public DbSet<RegistrarInfo> RegistrarInfo { get; set; }
        public DbSet<RequestInfo> RequestInfo { get; set; }
        public DbSet<RequestInfo> Requests { get; set; }

    }
}
