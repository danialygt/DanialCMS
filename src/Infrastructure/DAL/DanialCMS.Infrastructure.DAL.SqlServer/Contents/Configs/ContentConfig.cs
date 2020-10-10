using DanialCMS.Core.Domain.Contents.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Contents.Configs
{
    public class ContentConfig : IEntityTypeConfiguration<Content>
    {
        
        public void Configure(EntityTypeBuilder<Content> builder)
        {
            builder.Property(c => c.PublishDate).IsRequired();
            builder.Property(c => c.Title).IsRequired().HasMaxLength(100);
            builder.Property(c => c.Body).IsRequired();
            builder.Property(c => c.Description).IsRequired().HasMaxLength(500);
            builder.Property(c => c.ContentStatus).IsRequired();
            builder.Property(c => c.Rate).HasMaxLength(10);
            


            builder.HasOne(c => c.Writer).WithMany(c => c.Contents)
                .HasForeignKey(c => c.WriterId).OnDelete(DeleteBehavior.Restrict);

           

        }
    }
}
