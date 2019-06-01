using Microsoft.EntityFrameworkCore;

namespace RescueRegister.Models
{
    public class RescueRegisterDbContext : DbContext
    {
        public RescueRegisterDbContext()
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Mountaineer> Mountaineers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-VN8E4A8\SQLEXPRESS;Database=RescueRegister;Integrated Security=True");
        }
    }
}
