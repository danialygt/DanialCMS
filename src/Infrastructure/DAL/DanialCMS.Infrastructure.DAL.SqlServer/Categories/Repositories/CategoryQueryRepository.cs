using DanialCMS.Core.Domain.Categories.Entities;
using DanialCMS.Core.Domain.Categories.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Categories.Repositories
{
    public class CategoryQueryRepository : ICategoryQueryRepository
    {
        private readonly ContentDbContext _cmsDbContext;

        public CategoryQueryRepository(ContentDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }

        public Category Get(long id)
        {
            return _cmsDbContext.Categories.AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }

        public List<Category> Getall()
        {
            return _cmsDbContext.Categories.AsNoTracking()
                .ToList();

        }

        public List<Category> GetFirstChild(Category entity)
        {
            return _cmsDbContext.Categories.AsNoTracking()
                .Where(c => c.Parent == entity || c.ParentId == entity.Id)
                .ToList();
        }
    }
}
