using DanialCMS.Core.Domain.Writers.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Writers.Configs
{
    public class WriterConfig : IEntityTypeConfiguration<Writer>
    {
        public void Configure(EntityTypeBuilder<Writer> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(30);

            
            //builder.HasOne("PhotoId").WithOne("Id");
            //builder.Property(c => c.Contents);

        }
    }
}
