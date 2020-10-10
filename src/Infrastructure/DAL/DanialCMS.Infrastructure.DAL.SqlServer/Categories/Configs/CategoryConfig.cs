using DanialCMS.Core.Domain.Categories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Categories.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
   
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            
            builder.HasMany(c => c.Children).WithOne(c => c.Parent)
                .HasForeignKey(c => c.ParentId).OnDelete(DeleteBehavior.Restrict);

            //builder.Property(c => c.ParentId);
            //builder.HasOne("ParentId").WithOne("Id");
        }
    }
}
