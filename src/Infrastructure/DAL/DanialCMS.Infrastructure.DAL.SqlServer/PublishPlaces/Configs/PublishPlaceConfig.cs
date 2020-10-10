using DanialCMS.Core.Domain.PublishPlaces.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.PublishPlaces.Configs
{
    public class PublishPlaceConfig : IEntityTypeConfiguration<PublishPlace>
    {
        public void Configure(EntityTypeBuilder<PublishPlace> builder)
        {
            builder.Property(c => c.Name).IsRequired().HasMaxLength(30);
        }
    }
}
