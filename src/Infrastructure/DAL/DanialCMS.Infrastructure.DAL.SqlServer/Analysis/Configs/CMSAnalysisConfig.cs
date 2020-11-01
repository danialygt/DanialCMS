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
            builder.Property(c => c.OsName).HasMaxLength(400);
            builder.Property(c => c.OSArchitecture).HasMaxLength(400);

            builder.Property(c => c.BrowserName).HasMaxLength(250);
            builder.Property(c => c.Scheme).HasMaxLength(50);
            builder.Property(c => c.Referer).HasMaxLength(700);

            builder.Property(c => c.Path).HasMaxLength(700);
            builder.Property(c => c.HttpMethod).HasMaxLength(10);
            builder.Property(c => c.RemoteIpAddress).HasMaxLength(15);
            builder.Property(c => c.Port).HasMaxLength(10);
            builder.Property(c => c.ContentType).HasMaxLength(100);
            builder.Property(c => c.UserName).HasMaxLength(256);

        }
    }
}
