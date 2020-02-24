using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyStore.Core.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore.Infrastructures.Dal.Categories
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(c => c.CategoryName).IsUnique();
            builder.Property(c => c.CategoryName).HasMaxLength(100).IsRequired();

            builder.HasData(
                new Category { CategoryId = 1, CategoryName = "Cat 01" },
                new Category { CategoryId = 2, CategoryName = "Cat 02" }
                );
        }
    }
}
