using DanialCMS.Core.Domain.FileManagements.Entities;
using DanialCMS.Core.Domain.FileManagements.Repositories;
using System;
using System.Collections.Generic;
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

        public void Add(FileManagement entity)
        {
            _cmsDbContext.FileManager.Add(entity);
            _cmsDbContext.SaveChanges();
        }

        public void Delete(FileManagement entity)
        {
            _cmsDbContext.FileManager.Remove(entity);
            _cmsDbContext.SaveChanges();
        }
    }
}
