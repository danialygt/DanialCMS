using DanialCMS.Core.Domain.Comments.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Comments.Configs
{
    public class CommentConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(30);
            builder.Property(c => c.Email).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Opinion).IsRequired().HasMaxLength(300);
            builder.Property(c => c.CanShow).IsRequired();
            builder.Property(c => c.PublishDate).IsRequired();

            builder.Property(c => c.ContentId).IsRequired();
            
            builder.HasMany(c => c.Children).WithOne(c => c.Parent)
                .HasForeignKey(c => c.ParentId).OnDelete(DeleteBehavior.Restrict);

            //builder.HasOne("ParentCommentId").WithOne("Id");
            //builder.Property(c => c.ParentComment);
        }
    }
}