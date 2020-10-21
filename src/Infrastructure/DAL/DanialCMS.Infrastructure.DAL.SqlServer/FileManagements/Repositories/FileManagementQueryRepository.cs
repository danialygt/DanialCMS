using DanialCMS.Core.Domain.FileManagements.Entities;
using DanialCMS.Core.Domain.FileManagements.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DanialCMS.Infrastructure.DAL.SqlServer.FileManagements.Repositories
{
    public class FileManagementQueryRepository : IFileManagementQueryRepository
    {
        private readonly ContentDbContext _cmsDbContext;

        public FileManagementQueryRepository(ContentDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }
        
        public FileManagement Get(long id)
        {
            return _cmsDbContext.FileManager.AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }

        public List<FileManagement> GetAll()
        {
            return _cmsDbContext.FileManager.AsNoTracking()
                .ToList();
        }

        public List<FileManagement> GetWithType(string type)
        {
            return _cmsDbContext.FileManager.AsNoTracking()
                .Where(c => c.Type.Contains(type))
                .ToList();
        }

        public bool IsExist(long id)
        {
            return _cmsDbContext.FileManager.AsNoTracking()
                .Select(c => c.Id)
                .Contains(id);
        }
    }
}
