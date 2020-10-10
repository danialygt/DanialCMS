using DanialCMS.Core.Domain.Contents.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Contents.Configs
{
    internal class ContentPlacesConfig : IEntityTypeConfiguration<ContentPlaces>
    {
        public void Configure(EntityTypeBuilder<ContentPlaces> builder)
        {
            builder.Property(c => c.PublishPlaceId).IsRequired();
            builder.Property(c => c.ContentId).IsRequired();
        }
    }
}