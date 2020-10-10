using DanialCMS.Core.Domain.Contents.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Contents.Configs
{
    public class ContentKeywordsConfig : IEntityTypeConfiguration<ContentKeywords>
    {
        public void Configure(EntityTypeBuilder<ContentKeywords> builder)
        {
            builder.Property(c => c.ContentId).IsRequired();
            builder.Property(c => c.KeywordId).IsRequired();
        }
    }
}
