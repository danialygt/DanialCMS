using DanialCMS.Core.Domain.Categories.Entities;
using DanialCMS.Core.Domain.Categories.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Categories.Repositories
{
    public class CategoryCommandRepository : ICategoryCommandRepository
    {
        private readonly ContentDbContext _cmsDbContext;

        public CategoryCommandRepository(ContentDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }

        public void Add(Category entity)
        {
            _cmsDbContext.Categories.Add(entity);
            _cmsDbContext.SaveChanges();
        }

        public void Delete(Category entity)
        {
            _cmsDbContext.Categories.Remove(entity);
            _cmsDbContext.SaveChanges();
        }

        public void Edit(Category entity)
        {
            _cmsDbContext.Categories.Update(entity);
            _cmsDbContext.SaveChanges();
        }
    }
}
