using DanialCMS.Core.Domain.PublishPlaces.Entities;
using DanialCMS.Core.Domain.PublishPlaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.PublishPlaces.Repositories
{
    public class PublishPlaceQueryRepository : IPublishPlaceQueryRepository
    {
        private readonly ContentDbContext _cmsDbContext;

        public PublishPlaceQueryRepository(ContentDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }

        public PublishPlace Get(long id)
        {
            return _cmsDbContext.PublishPlaces.AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }

        public List<PublishPlace> GetAll()
        {
            return _cmsDbContext.PublishPlaces.AsNoTracking()
                .ToList();
        }
    }
}
