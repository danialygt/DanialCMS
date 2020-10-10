using DanialCMS.Core.Domain.Analysis.Entities;
using DanialCMS.Core.Domain.Categories.Entities;
using DanialCMS.Core.Domain.Comments.Entities;
using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.FileManagements.Entities;
using DanialCMS.Core.Domain.Keywords.Entities;
using DanialCMS.Core.Domain.PublishPlaces.Entities;
using DanialCMS.Core.Domain.Writers.Entities;
using DanialCMS.Infrastructure.DAL.SqlServer.Analysis.Configs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer
{
    public class AnalysisDbContext : DbContext
    {

        public DbSet<CMSAnalysis> CMSAnalysis { get; set; }


        public AnalysisDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CMSAnalysisConfig());
            base.OnModelCreating(modelBuilder);
        }



    }
}
