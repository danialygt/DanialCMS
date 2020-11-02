using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanialCMS.EndPoints.WebUI.Infrastructures.Identity
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(c => c.FirstName).HasMaxLength(256);
            builder.Property(c => c.LastName).HasMaxLength(256);
        }
    }
}
