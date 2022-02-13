using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.OrderService.Data
{
    public class OrderContext : DbContext
    {
        public DbSet<CarOrder> CarOrders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public OrderContext(DbContextOptions<OrderContext> options)
         : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarOrder>()
                .HasMany(p => p.CarOrderOptions)
                .WithOne(b => b.CarOrder);


            modelBuilder.Entity<Customer>()
                .HasMany(p => p.CarOrders)
                .WithOne(b => b.Customer);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

    }
}
