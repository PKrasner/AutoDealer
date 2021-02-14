using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.CatalogService.Data
{
    public class CatalogContext : DbContext
    {
        public DbSet<CarManufacturer> CarManufacturers { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarOption> CarOptions { get; set; }
        public DbSet<CarOptionGroup> CarOptionGroups { get; set; }

        public CatalogContext(DbContextOptions<CatalogContext> options)
         : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModel>()
                .HasMany(p => p.CarOptionGroups)
                .WithOne(b => b.CarModel)
                .HasForeignKey(x => x.CarModelId);


            modelBuilder.Entity<CarOptionGroup>()
                .HasMany(p => p.CarOptions)
                .WithOne(b => b.CarOptionGroup)
                .HasForeignKey(x => x.CarOptionGroupId);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

    }
}
