using DanialCMS.Core.Domain.FileManagements.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.FileManagements.Configs
{
    public class FileManagementConfig : IEntityTypeConfiguration<FileManagement>
    {
        public void Configure(EntityTypeBuilder<FileManagement> builder)
        {
            builder.Property(c => c.Url).IsRequired();
            builder.Property(c => c.Type).IsRequired();
            builder.Property(c => c.Name).IsRequired().HasMaxLength(30);
            builder.Property(c => c.Date).IsRequired();
            builder.Property(c => c.Size).IsRequired();

            //builder.HasOne("PhotoId").WithOne("Id").OnDelete(DeleteBehavior.Cascade);
            

        }
    }
}
