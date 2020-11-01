using DanialCMS.Core.Domain.Editors.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Editors.Config
{
    public class EditorConfig : IEntityTypeConfiguration<Editor>
    {
        public void Configure(EntityTypeBuilder<Editor> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(30);
        }
    }
}
