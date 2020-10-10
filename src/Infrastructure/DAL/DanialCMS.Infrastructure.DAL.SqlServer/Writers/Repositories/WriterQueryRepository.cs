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
                .FirstOrDefault(c => c.Id == id);
        }

        public List<Writer> Getall()
        {
            return _cmsDbContext.Writers.AsNoTracking()
                .Include(c => c.Photo)
                .Include(c => c.Contents)
                .ToList();
        }
    }
}
