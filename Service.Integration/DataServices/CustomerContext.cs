using Microsoft.EntityFrameworkCore;
using Service.Integration.Models;

namespace Service.Integration.DataServices
{
    public class CustomerContext : DbContext
    {
        /// <summary>
        /// CustomerContext Constructor Method.
        /// </summary>
        /// <param name="options"></param>
        public CustomerContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(a => a.Address)
                .WithOne(b => b.Customer)
                .HasForeignKey<Address>(b => b.CustomerId);
        }
    }
}
