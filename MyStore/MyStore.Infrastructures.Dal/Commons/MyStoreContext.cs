using Microsoft.EntityFrameworkCore;
using MyStore.Core.Domain.Categories;
using MyStore.Core.Domain.Orders;
using MyStore.Core.Domain.Products;
using MyStore.Infrastructures.Dal.Categories;
using MyStore.Infrastructures.Dal.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Infrastructures.Dal.Commons
{
    public class MyStoreContext : DbContext
    {
        public MyStoreContext(DbContextOptions<MyStoreContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
