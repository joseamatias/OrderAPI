using Microsoft.EntityFrameworkCore;
using OrderAPI.Domain.Models;

namespace OrderAPI.Infrastructure.Context
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Items> Items { get; set; }
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO
            //modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
            //modelBuilder.ApplyConfiguration(new ItemEntityConfiguration());
        }
    }
}
