namespace P03_SalesDatabase.Data
{
    using P03_SalesDatabase.Data.Models;

    using Microsoft.EntityFrameworkCore;

    public class SalesContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Store> Stores { get; set; }

        public DbSet<Sale> Sales { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=Sales;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasMany(c => c.Sales)
                .WithOne(s => s.Customer)  
                .HasForeignKey(s => s.CustomerId);

            modelBuilder.Entity<Product>()
                .HasMany(c => c.Sales)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Store>()
               .HasMany(c => c.Sales)
               .WithOne(s => s.Store)
               .HasForeignKey(s => s.StoreId);
        }
    }
}
