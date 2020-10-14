using DanialCMS.Core.Domain.Writers.Entities;
using DanialCMS.Core.Domain.Writers.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public void ChangePhoto(long writerId, long photoId)
        {
            _cmsDbContext.Writers.AsNoTracking()
                 .FirstOrDefault(c => c.Id == writerId)
                 .PhotoId = photoId;
            _cmsDbContext.SaveChanges();
        }

        public void Edit(Writer entity)
        {
            _cmsDbContext.Writers.Update(entity);
            _cmsDbContext.SaveChanges();
        }

        public void EditName(Writer entity)
        {
            _cmsDbContext.Writers.AsNoTracking()
                .FirstOrDefault(c => c.Id == entity.Id)
                .Name = entity.Name;
            _cmsDbContext.SaveChanges();
        }
    }
}
