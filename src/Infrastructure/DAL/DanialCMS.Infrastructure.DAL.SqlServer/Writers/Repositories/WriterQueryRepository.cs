using DanialCMS.Core.Domain.Writers.Dtos;
using DanialCMS.Core.Domain.Writers.Entities;
using DanialCMS.Core.Domain.Writers.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Writers.Repositories
{
    public class WriterQueryRepository : IWriterQueryRepository
    {
        private readonly ContentDbContext _cmsDbContext;

        public WriterQueryRepository(ContentDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }

        public Writer Get(long id)
        {
            return _cmsDbContext.Writers.AsNoTracking()
                .Include(p => p.Photo)
                .Include(c => c.Contents)
                .ThenInclude(d=>d.PublishPlaces).ThenInclude(p=>p.PublishPlace)
                .FirstOrDefault(c => c.Id == id);
        }

        public List<DtoWriter> GetAll()
        {
            return _cmsDbContext.Writers.AsNoTracking()
                .Include(c => c.Photo)
                .Include(c => c.Contents)
                .Select(c => new DtoWriter()
                {
                    Id = c.Id,
                    Name = c.Name,
                    PhotoUrl = c.Photo.Url,
                    CountOfContent = c.Contents.Count()
                })
                .ToList();
        }

        public bool IsExist(string name)
        {
            return _cmsDbContext.Writers.AsNoTracking()
                .Select(c => c.Name)
                .Contains(name);
        }

        public bool IsExist(long id)
        {
            return _cmsDbContext.Writers.AsNoTracking()
                .Select(c => c.Id)
                .Contains(id);
        }
    }
}
