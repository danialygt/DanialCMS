using DanialCMS.Core.Domain.FileManagements.Entities;
using DanialCMS.Core.Domain.FileManagements.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.FileManagements.Repositories
{
    public class FileManagementCommandRepository : IFileManagementCommandRepository
    {
        private readonly ContentDbContext _cmsDbContext;

        public FileManagementCommandRepository(ContentDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }

        public long Add(FileManagement entity)
        {
            var addedEntity = _cmsDbContext.FileManager.Add(entity);
            _cmsDbContext.SaveChanges();
            return addedEntity.Entity.Id;
        }

        public void Delete(FileManagement entity)
        {
            _cmsDbContext.FileManager.Remove(entity);
            _cmsDbContext.SaveChanges();
        }
        public void Delete(long id)
        {
            var ent = _cmsDbContext.FileManager.AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
            _cmsDbContext.FileManager.Remove(ent);
            _cmsDbContext.SaveChanges();
        }

        public void Rename(long id, string newName)
        {
            _cmsDbContext.FileManager.FirstOrDefault(c => c.Id == id)
                .Name = newName;
            _cmsDbContext.SaveChanges();
        }
    }
}
