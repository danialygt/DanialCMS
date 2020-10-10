using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.Contents.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Contents.Repositories
{
    public class ContentPlacesQueryRepository : IContentPlacesQueryRepository
    {
        private readonly ContentDbContext _contentDbContext;

        public ContentPlacesQueryRepository(ContentDbContext contentDbContext)
        {
            _contentDbContext = contentDbContext;
        }

        public ContentPlaces Get(long id)
        {
            return _contentDbContext.ContentPlaces.AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }

        public List<ContentPlaces> GetAll()
        {
            return _contentDbContext.ContentPlaces.AsNoTracking()
               .Include(c => c.PublishPlace)
               .Include(c => c.Content)
                .ToList();
        }

        public List<ContentPlaces> GetContents(long PlaceId)
        {
            return _contentDbContext.ContentPlaces.AsNoTracking()
               .Include(c => c.PublishPlace)
               .Include(c => c.Content)
               .Where(c => c.PublishPlaceId == PlaceId)
                .ToList();
        }

        public List<ContentPlaces> GetPlaces(long contentId)
        {
            return _contentDbContext.ContentPlaces.AsNoTracking()
                .Include(c => c.PublishPlace)
                .Include(c => c.Content)
               .Where(c => c.ContentId == contentId)
                 .ToList();
        }
    }
}
