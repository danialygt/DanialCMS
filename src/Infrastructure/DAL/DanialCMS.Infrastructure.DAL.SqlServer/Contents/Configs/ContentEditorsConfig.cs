using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.Editors.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Contents.Configs
{
    public class ContentEditorsConfig : IEntityTypeConfiguration<ContentEditors>
    {
        public void Configure(EntityTypeBuilder<ContentEditors> builder)
        {
            builder.Property(c => c.EditorId).IsRequired();
            builder.Property(c => c.ContentId).IsRequired();
        }
    }
}
