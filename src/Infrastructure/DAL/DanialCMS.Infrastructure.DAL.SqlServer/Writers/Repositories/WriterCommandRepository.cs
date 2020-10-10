using DanialCMS.Core.Domain.Writers.Entities;
using DanialCMS.Core.Domain.Writers.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Writers.Repositories
{
    public class WriterCommandRepository : IWriterCommandRepository
    {
        private readonly ContentDbContext _cmsDbContext;

        public WriterCommandRepository(ContentDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }

        public void Add(Writer entity)
        {
            _cmsDbContext.Writers.Add(entity);
            _cmsDbContext.SaveChanges();
        }

        public void Edit(Writer entity)
        {
            _cmsDbContext.Writers.Update(entity);
            _cmsDbContext.SaveChanges();
        }
    }
}
