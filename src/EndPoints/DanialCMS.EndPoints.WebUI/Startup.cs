using DanialCMS.Core.ApplicationService.Analysis.Commands;
using DanialCMS.Core.ApplicationService.Analysis.Queries;
using DanialCMS.Core.ApplicationService.Categories.Commands;
using DanialCMS.Core.ApplicationService.Categories.Queries;
using DanialCMS.Core.ApplicationService.Comments.Commands;
using DanialCMS.Core.ApplicationService.Comments.Queries;
using DanialCMS.Core.ApplicationService.Contents.Commands;
using DanialCMS.Core.ApplicationService.Contents.Queries;
using DanialCMS.Core.ApplicationService.FileManagements.Commands;
using DanialCMS.Core.ApplicationService.FileManagements.Queries;
using DanialCMS.Core.ApplicationService.Keywords.Commands;
using DanialCMS.Core.ApplicationService.Keywords.Queries;
using DanialCMS.Core.ApplicationService.PublishPlaces.Queries;
using DanialCMS.Core.ApplicationService.Writers.Commands;
using DanialCMS.Core.ApplicationService.Writers.Queries;
using DanialCMS.Core.ApplicationService.Emails.Services;
using DanialCMS.Core.Domain.Emails.Services;
using DanialCMS.Core.Domain.Analysis.Commands;
using DanialCMS.Core.Domain.Analysis.Queries;
using DanialCMS.Core.Domain.Analysis.Repositories;
using DanialCMS.Core.Domain.Categories.Commands;
using DanialCMS.Core.Domain.Categories.Entities;
using DanialCMS.Core.Domain.Categories.Queries;
using DanialCMS.Core.Domain.Categories.Repositories;
using DanialCMS.Core.Domain.Comments.Commands;
using DanialCMS.Core.Domain.Comments.Entities;
using DanialCMS.Core.Domain.Comments.Queries;
using DanialCMS.Core.Domain.Comments.Repositories;
using DanialCMS.Core.Domain.Contents.Commands;
using DanialCMS.Core.Domain.Contents.Dtos;
using DanialCMS.Core.Domain.Contents.Queries;
using DanialCMS.Core.Domain.Contents.Repositories;
using DanialCMS.Core.Domain.FileManagements.Commands;
using DanialCMS.Core.Domain.FileManagements.Entities;
using DanialCMS.Core.Domain.FileManagements.Queries;
using DanialCMS.Core.Domain.FileManagements.Repositories;
using DanialCMS.Core.Domain.Keywords.Commands;
using DanialCMS.Core.Domain.Keywords.Entities;
using DanialCMS.Core.Domain.Keywords.Queries;
using DanialCMS.Core.Domain.Keywords.Repositories;
using DanialCMS.Core.Domain.PublishPlaces.Entities;
using DanialCMS.Core.Domain.PublishPlaces.Queries;
using DanialCMS.Core.Domain.PublishPlaces.Repositories;
using DanialCMS.Core.Domain.Writers.Commands;
using DanialCMS.Core.Domain.Writers.Dtos;
using DanialCMS.Core.Domain.Writers.Queries;
using DanialCMS.Core.Domain.Writers.Repositories;
using DanialCMS.EndPoints.WebUI.Infrastructures.Middlewares;
using DanialCMS.EndPoints.WebUI.Infrastructures.Identity;
using DanialCMS.Framework.Commands;
using DanialCMS.Framework.Queries;
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
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using DanialCMS.Core.Domain.FileManagements.Dtos;
using DanialCMS.EndPoints.WebUI.Infrastructures.Authorization.Contents;

namespace DanialCMS.EndPoints.WebUI
{
    public class Startup
    {


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            #region Aplication Services
            /*  Add Aplication Services  */
            services.AddTransient<CommandDispatcher>();
            services.AddTransient<QueryDispatcher>();
            /**/    /* writer controller  */
            services.AddTransient<CommandHandler<AddWriterCommand>, AddWriterCommandHandler>();
            services.AddTransient<CommandHandler<UpdateWriterCommand>, UpdateWriterCommandHandler>();
            services.AddTransient<IQueryHandler<AllWriterQuery, List<DtoWriter>>, AllWriterQueryHandler>();
            services.AddTransient<IQueryHandler<WriterDetailQuery, DtoWriterDetail>, WriterDetailQueryHandler>();
            services.AddTransient<IQueryHandler<WriterUpdateQuery, DtoUpdateWriter>, WriterUpdateQueryHandler>();
            services.AddTransient<IQueryHandler<GetWriterIdQuery, long>, GetWriterIdQueryHandler>();
        
            /**/    /* FileManagment */
            services.AddTransient<CommandHandler<AddFileCommand>, AddFileCommandHandler>();
            services.AddTransient<CommandHandler<RemoveFileCommand>, RemoveFileCommandHandler>();
            services.AddTransient<CommandHandler<RenameFileCommand>, RenameFileCommandHandler>();
            services.AddTransient<IQueryHandler<GetFilesQuery, List<FileManagement>>, GetFilesQueryHandler>();
            services.AddTransient<IQueryHandler<GetFileQuery, FileManagement>, GetFileQueryHandler>();
            services.AddTransient<IQueryHandler<GetPhotosQuery, List<DtoPhotoList>>, GetPhotosQueryHandler>();
            
            /**/    /* Category */
            services.AddTransient<CommandHandler<AddCategoryCommand>, AddCategoryCommandHandler>();
            services.AddTransient<CommandHandler<UpdateCategoryCommand>, UpdateCategoryCommandHandler>();
            services.AddTransient<CommandHandler<RemoveCategoryCommand>, RemoveCategoryCommandHandler>();
            services.AddTransient<IQueryHandler<GetCategoriesQuery, List<Category>>, GetCategoriesQueryHandler>();
            services.AddTransient<IQueryHandler<GetcategoryQuery, Category>, GetcategoryQueryHandler>();

            /**/    /* Keyword */
            services.AddTransient<CommandHandler<AddKeywordCommand>, AddKeywordCommandHandler>();
            services.AddTransient<CommandHandler<UpdateKeywordCommand>, UpdateKeywordCommandHandler>();
            services.AddTransient<CommandHandler<RemoveKeywordCommand>, RemoveKeywordCommandHandler>();
            services.AddTransient<IQueryHandler<GetKeywordsQuery, List<Keyword>>, GetKeywordsQueryHandler>();
            services.AddTransient<IQueryHandler<GetKeywordQuery, Keyword>, GetKeywordQueryHandler>();

            /**/    /* PublishPlaces */
            services.AddTransient<IQueryHandler<GetPlaceQuery, PublishPlace>, GetPlaceQueryHandler>();
            services.AddTransient<IQueryHandler<GetPlacesQuery, List<PublishPlace>>, GetPlacesQueryHandler>();

            /**/    /* Content */
            services.AddTransient<CommandHandler<AddContentCommand>, AddContentCommandHandler>();
            services.AddTransient<CommandHandler<EditContentCommand>, EditContentCommandHandler>();
            services.AddTransient<CommandHandler<EditStatusContentCommand>, EditStatusContentCommandHandler>();
            services.AddTransient<IQueryHandler<GetContentQuery, DtoContent>, GetContentQueryHandler>();
            services.AddTransient<IQueryHandler<GetContentQuery, DtoUpdateContent>, GetDtoUpdateContentQueryHandler>();
            services.AddTransient<IQueryHandler<GetContentsQuery, List<DtoListContent>>, GetContentsQueryHandler>();

            /**/    /* Comment */
            services.AddTransient<CommandHandler<ChangeStatusCommentCommand>, ChangeStatusCommentCommandHandler>();
            services.AddTransient<IQueryHandler<GetCommentsQuery, List<Comment>>, GetCommentsQueryHandler>();



            #endregion

            # region ContentDBServices

            /* Add Content DB Services  */
            services.AddDbContextPool<ContentDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("ContentDbConnection")));
            /**/    /* add repositories */
            services.AddTransient<ICategoryCommandRepository, CategoryCommandRepository>();
            services.AddTransient<ICommentCommandRepository, CommentCommandRepository>();
            services.AddTransient<IContentCommandRepository, ContentCommandRepository>();
            services.AddTransient<IFileManagementCommandRepository, FileManagementCommandRepository>();
            services.AddTransient<IKeywordCommandRepository, KeywordCommandRepository>();
            services.AddTransient<IWriterCommandRepository, WriterCommandRepository>();
            services.AddTransient<IContentKeywordsCommandRepository, ContentKeywordsCommandRepository>();
            services.AddTransient<IContentPlacesCommandRepository, ContentPlacesCommandRepository>();

            services.AddTransient<ICategoryQueryRepository, CategoryQueryRepository>();
            services.AddTransient<ICommentQueryRepository, CommentQueryRepository>();
            services.AddTransient<IContentQueryRepository, ContentQueryRepository>();
            services.AddTransient<IFileManagementQueryRepository, FileManagementQueryRepository>();
            services.AddTransient<IKeywordQueryRepository, KeywordQueryRepository>();
            services.AddTransient<IPublishPlaceQueryRepository, PublishPlaceQueryRepository>();
            services.AddTransient<IWriterQueryRepository, WriterQueryRepository>();
            services.AddTransient<IContentKeywordsQueryRepository, ContentKeywordsQueryRepository>();
            services.AddTransient<IContentPlacesQueryRepository, ContentPlacesQueryRepository>();

            #endregion

            #region AnalysisDBServices

            /* Add Analysis DB Services */
            services.AddDbContextPool<AnalysisDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("AnalysisDbConnection")));
            /**/    /* add repositories */
            services.AddScoped<ICMSAnalysisCommandRepository, CMSAnalysisCommandRepository>();
            services.AddTransient<ICMSAnalysisQueryRepository, CMSAnalysisQueryRepository>();
            /**/    /* getInformation */
            services.AddTransient<CommandHandler<AddRecordCommand>, AddRecordCommandHandler>();
            services.AddTransient<IQueryHandler<GetViewsOnDateQuery, int>, GetViewsOnDateQueryHandler>();
            #endregion

            #region Identity
            
            /* Add Identity DB Services */
            services.AddDbContextPool<CMSIdentityDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("IdentityDbConnection")));
            services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 8;
                options.Lockout = new LockoutOptions
                {
                    DefaultLockoutTimeSpan = new TimeSpan(1, 0, 0),
                    AllowedForNewUsers = false,
                    MaxFailedAccessAttempts = 5,
                };
            }).AddEntityFrameworkStores<CMSIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<DataProtectionTokenProviderOptions>(opt =>
                    opt.TokenLifespan = TimeSpan.FromHours(2));

            
            services.AddTransient<IPasswordValidator<User>, CustomPasswordValidator>();

            #endregion

            #region Email Services
            /* Email Services */
            services.AddSingleton<IEmailConfiguration>(
                Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>());
            services.AddTransient<IEmailService, EmailService>();
            #endregion


            #region Claims
            

            services.AddTransient<IAuthorizationHandler, ContentAuthorizationHandler>();
            services.AddAuthorization(opt =>
            {
                opt.AddPolicy("WriterAndEditors", policy =>
                {
                    policy.AddRequirements(new ContentAuthorizationRequirement
                    {
                        AllowWriter = true,
                        AllowEditors = true
                    });
                });

            });

            #endregion





            services.AddControllersWithViews();

        }


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


            app.UseErrorLoggerMiddleware();
            app.UseAnalysisMiddleware();


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
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
