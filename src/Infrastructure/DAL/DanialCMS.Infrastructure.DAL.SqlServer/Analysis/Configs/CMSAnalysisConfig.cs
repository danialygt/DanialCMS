using DanialCMS.Core.Domain.Analysis.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Analysis.Configs
{
    public class CMSAnalysisConfig : IEntityTypeConfiguration<CMSAnalysis>
    {
        public void Configure(EntityTypeBuilder<CMSAnalysis> builder)
        {
            builder.Property(c => c.Date).IsRequired();
            builder.Property(c => c.Time).IsRequired();
            builder.Property(c => c.OsName).IsRequired().HasMaxLength(15);
            builder.Property(c => c.BrowserName).IsRequired().HasMaxLength(15);
            builder.Property(c => c.Path).IsRequired().HasMaxLength(100);
            builder.Property(c => c.SatusCode).IsRequired();
            builder.Property(c => c.HttpMethod).IsRequired();
            builder.Property(c => c.IpAddress).IsRequired().HasMaxLength(15);
            builder.Property(c => c.Protocol).IsRequired().HasMaxLength(10);
            builder.Property(c => c.ContentType).IsRequired();
        }
    }
}
