using DanialCMS.Core.Domain.Contents.Dtos;
using DanialCMS.Core.Domain.Contents.Entities;
using DanialCMS.Core.Domain.Contents.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Contents.Repositories
{
    public class ContentCommandRepository : IContentCommandRepository
    {
        private readonly ContentDbContext _cmsDbContext;

        public ContentCommandRepository(ContentDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }

        public long Add(Content entity)
        {
            var addedEntity = _cmsDbContext.Contents.Add(entity);
            _cmsDbContext.SaveChanges();

            return addedEntity.Entity.Id;
        }

        public void Edit(Content entity)
        {
            _cmsDbContext.Contents.Update(entity);
            _cmsDbContext.SaveChanges();
        }

        public void EditStatus(long id, ContentStatus status)
        {
            _cmsDbContext.Contents.FirstOrDefault(c => c.Id == id)
                .ContentStatus = status;
            _cmsDbContext.SaveChanges();
        }

        public void Update(DtoUpdateContent entity)
        {
            var dbEnt = _cmsDbContext.Contents.AsNoTracking()
                .FirstOrDefault(c => c.Id == entity.Id);

            dbEnt.Title = entity.Title;
            dbEnt.Body = entity.Body;
            dbEnt.Description = entity.Description;
            dbEnt.Rate = entity.Rate;
            dbEnt.PublishDate = entity.PublishDate;
            dbEnt.CategoryId = entity.CategoryId;

            _cmsDbContext.Contents.Update(dbEnt);
            _cmsDbContext.SaveChanges();

        }
    }
}
