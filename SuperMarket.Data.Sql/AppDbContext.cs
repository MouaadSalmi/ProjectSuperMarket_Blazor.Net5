using Microsoft.EntityFrameworkCore;
using SuperMarket.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.Data.Sql
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transa> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);

            // sending some default data
            modelBuilder.Entity<Category>().HasData(
                    new Category { CategoryId = 1, Name = "Boissons", Description = "Boissons" },
                    new Category { CategoryId = 2, Name = "Pâtisserie", Description = "Pâtisserie" },
                    new Category { CategoryId = 3, Name = "Boucherie", Description = "Boucherie" }
                );

            modelBuilder.Entity<Product>().HasData(
                    new Product { ProductId = 1, CategoryId = 1, Name = "Coca Cola", Quantity = 100, Price = 1.99 },
                    new Product { ProductId = 2, CategoryId = 1, Name = "Red Bull", Quantity = 200, Price = 1.99 },
                    new Product { ProductId = 3, CategoryId = 2, Name = "Paint Complet", Quantity = 300, Price = 1.50 },
                    new Product { ProductId = 4, CategoryId = 2, Name = "Pain de mie", Quantity = 300, Price = 1.50 }
                );
        }
    }
}
