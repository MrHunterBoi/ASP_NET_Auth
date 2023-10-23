using ASP_API.Configs;
using ASP_API.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP_API
{
    public class HospitalDBContext : DbContext
    {
        public HospitalDBContext(DbContextOptions<HospitalDBContext> options)
        : base(options)
        {
        }

        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Proced> Proced { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
