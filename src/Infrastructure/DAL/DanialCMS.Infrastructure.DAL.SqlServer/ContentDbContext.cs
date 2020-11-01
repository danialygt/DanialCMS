using DanialCMS.Core.Domain.Analysis.Entities;
using DanialCMS.Core.Domain.Categories.Entities;
using DanialCMS.Core.Domain.Comments.Entities;
using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.Editors.Entities;
using DanialCMS.Core.Domain.FileManagements.Entities;
using DanialCMS.Core.Domain.Keywords.Entities;
using DanialCMS.Core.Domain.PublishPlaces.Entities;
using DanialCMS.Core.Domain.Writers.Entities;
using DanialCMS.Infrastructure.DAL.SqlServer.Categories.Configs;
using DanialCMS.Infrastructure.DAL.SqlServer.Comments.Configs;
using DanialCMS.Infrastructure.DAL.SqlServer.Contents.Configs;
using DanialCMS.Infrastructure.DAL.SqlServer.Editors.Config;
using DanialCMS.Infrastructure.DAL.SqlServer.FileManagements.Configs;
using DanialCMS.Infrastructure.DAL.SqlServer.Keywords.Configs;
using DanialCMS.Infrastructure.DAL.SqlServer.PublishPlaces.Configs;
using DanialCMS.Infrastructure.DAL.SqlServer.Writers.Configs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer
{
    public class ContentDbContext : DbContext
    {

      
        public DbSet<Category> Categories { get; set; }

        internal void AsNoTracking()
        {
            throw new NotImplementedException();
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<FileManagement> FileManager { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<PublishPlace> PublishPlaces { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<ContentKeywords> ContentKeywords { get; set; }
        public DbSet<ContentPlaces> ContentPlaces { get; set; }
        public DbSet<ContentEditors> ContentEditors { get; set; }
        public DbSet<Editor> Editors { get; set; }



        public ContentDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new CommentConfig());
            modelBuilder.ApplyConfiguration(new ContentConfig());
            modelBuilder.ApplyConfiguration(new FileManagementConfig());
            modelBuilder.ApplyConfiguration(new KeywordConfig());
            modelBuilder.ApplyConfiguration(new PublishPlaceConfig());
            modelBuilder.ApplyConfiguration(new WriterConfig());
            modelBuilder.ApplyConfiguration(new ContentKeywordsConfig());
            modelBuilder.ApplyConfiguration(new ContentPlacesConfig());
            modelBuilder.ApplyConfiguration(new EditorConfig());
            modelBuilder.ApplyConfiguration(new ContentEditorsConfig());

        }



    }
}
