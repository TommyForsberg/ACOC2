using ACOC2.BaristaApi._3_Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ACOC2.BaristaApi._3_Data
{
    public class BaristaDbContext : DbContext
    {
        public BaristaDbContext(DbContextOptions<BaristaDbContext> options)
        : base(options) { }

        public DbSet<CoffeeProduct> CoffeeProducts => Set<CoffeeProduct>();
        public DbSet<BrewRecipe> BrewRecipes => Set<BrewRecipe>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CoffeeProduct>()
                .HasOne(cp => cp.BrewRecipe)
                .WithOne(br => br.CoffeeProduct)
                .HasForeignKey<BrewRecipe>(br => br.CoffeeProductId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
