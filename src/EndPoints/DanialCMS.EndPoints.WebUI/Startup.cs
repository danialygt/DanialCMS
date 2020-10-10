using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DanialCMS.Core.Domain.Analysis.Repositories;
using DanialCMS.Core.Domain.Categories.Repositories;
using DanialCMS.Core.Domain.Comments.Repositories;
using DanialCMS.Core.Domain.Contents.Repositories;
using DanialCMS.Core.Domain.FileManagements.Repositories;
using DanialCMS.Core.Domain.Keywords.Repositories;
using DanialCMS.Core.Domain.PublishPlaces.Repositories;
using DanialCMS.Core.Domain.Writers.Repositories;
using DanialCMS.Infrastructure.DAL.SqlServer;
using DanialCMS.Infrastructure.DAL.SqlServer.Analysis.Repositories;
using DanialCMS.Infrastructure.DAL.SqlServer.Categories.Repositories;
using DanialCMS.Infrastructure.DAL.SqlServer.Comments.Repositories;
using DanialCMS.Infrastructure.DAL.SqlServer.Contents.Repositories;
using DanialCMS.Infrastructure.DAL.SqlServer.FileManagements.Repositories;
using DanialCMS.Infrastructure.DAL.SqlServer.Keywords.Repositories;
using DanialCMS.Infrastructure.DAL.SqlServer.PublishPlaces.Repositories;
using DanialCMS.Infrastructure.DAL.SqlServer.Writers.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DanialCMS.EndPoints.WebUI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {




            services.AddDbContextPool<AnalysisDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("AnalysisDbConnection")));

            services.AddTransient<ICMSAnalysisCommandRepository, CMSAnalysisCommandRepository>();
            services.AddTransient<ICMSAnalysisQueryRepository, CMSAnalysisQueryRepository>();





            services.AddDbContextPool<ContentDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("ContentDbConnection")));

            services.AddTransient<ICategoryCommandRepository, CategoryCommandRepository>();
            services.AddTransient<ICategoryQueryRepository, CategoryQueryRepository>();

            services.AddTransient<ICommentCommandRepository, CommentCommandRepository>();
            services.AddTransient<ICommentQueryRepository, CommentQueryRepository>();

            services.AddTransient<IContentCommandRepository, ContentCommandRepository>();
            services.AddTransient<IContentQueryRepository, ContentQueryRepository>();

            services.AddTransient<IFileManagementCommandRepository, FileManagementCommandRepository>();
            services.AddTransient<IFileManagementQueryRepository, FileManagementQueryRepository>();

            services.AddTransient<IKeywordCommandRepository, KeywordCommandRepository>();
            services.AddTransient<IKeywordQueryRepository, KeywordQueryRepository>();

            //services.AddTransient<IPublishPlaceCommandRepository, PublishPlaceCommandRepository>();
            services.AddTransient<IPublishPlaceQueryRepository, PublishPlaceQueryRepository>();

            services.AddTransient<IWriterCommandRepository, WriterCommandRepository>();
            services.AddTransient<IWriterQueryRepository, WriterQueryRepository>();

            services.AddTransient<IContentKeywordsCommandRepository, ContentKeywordsCommandRepository>();
            services.AddTransient<IContentKeywordsQueryRepository, ContentKeywordsQueryRepository>();

            services.AddTransient<IContentPlacesCommandRepository, ContentPlacesCommandRepository>();
            services.AddTransient<IContentPlacesQueryRepository, ContentPlacesQueryRepository>();





            services.AddControllersWithViews();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
