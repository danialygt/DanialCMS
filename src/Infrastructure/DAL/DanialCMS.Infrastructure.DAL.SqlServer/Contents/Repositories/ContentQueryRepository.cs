using DanialCMS.Core.Domain.Contents.Dtos;
using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.Contents.Repositories;
using DanialCMS.Core.Domain.PublishPlaces.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DanialCMS.Infrastructure.DAL.SqlServer.Contents.Repositories
{
    public class ContentQueryRepository : IContentQueryRepository
    {
        private readonly ContentDbContext _cmsDbContext;

        public ContentQueryRepository(ContentDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }

        public DtoContent Get(long id)
        {
            return _cmsDbContext.Contents.AsNoTracking()
                .Include(c => c.Keyword)
                .Include(c => c.Photo)
                .Include(c => c.Category)
                .Include(c => c.PublishPlaces)
                .Include(c => c.Comments)
                .Include(c => c.Writer)
                .Select(c => new DtoContent()
                {
                    Body = c.Body,
                    CategoryId = c.CategoryId,
                    ContentStatus = c.ContentStatus,
                    Description = c.Description,    
                    Id = c.Id,
                    KeywordsId = c.Keyword.Select(k => k.KeywordId).ToList(),
                    PublishPlacesId = c.PublishPlaces.Select(k => k.PublishPlaceId).ToList(),
                    PhotoId = c.Photo.Id,
                    PublishDate = c.PublishDate,
                    Rate = c.Rate,
                    Title = c.Title,
                    CommentsId = c.Comments.Select(k => k.ContentId).ToList(),
                    WriterId = c.WriterId,
                    Writer = c.Writer,
                        
                    Category = c.Category,

                    Keywords = _cmsDbContext.Keywords.AsNoTracking()
                        .Where(w=>c.Keyword.Select(k=>k.KeywordId).Contains(w.Id)).ToList(),
                    PublishPlaces = _cmsDbContext.PublishPlaces.AsNoTracking()
                        .Where(cp => c.PublishPlaces.Select(p => p.PublishPlaceId).Contains(cp.Id)).ToList(),
                    Comments = _cmsDbContext.Comments.AsNoTracking()
                        .Where(cm=>cm.ContentId == c.Id).ToList(),
                })
                .FirstOrDefault(c => c.Id == id);
        }

        public List<DtoListContent> GetAll()
        {
            return _cmsDbContext.Contents.AsNoTracking()
                .Include(c => c.Keyword)
                .Include(c => c.Writer)
                .Include(c => c.Photo)
                .Include(c => c.Category)
                .Include(c=>c.Writer)
                .Select(c=>new DtoListContent() 
                { 
                    Id = c.Id,
                    Title = c.Title,
                    WriterName = c.Writer.Name,
                    ContentStatus = c.ContentStatus,
                    PublishDate = c.PublishDate,
                    PublishPlaces = _cmsDbContext.PublishPlaces.AsNoTracking()
                        .Where(cp => c.PublishPlaces.Select(p => p.PublishPlaceId).Contains(cp.Id)).ToList(),

                })
                .ToList();
        }

        public bool IsExist(long contentId)
        {
            return _cmsDbContext.Contents.AsNoTracking()
                .FirstOrDefault(c => c.Id == contentId) != null;
        }
    }
}
