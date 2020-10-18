using DanialCMS.Core.Domain.Categories.Entities;
using DanialCMS.Core.Domain.Categories.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void Delete(long id)
        {
            var ent = _cmsDbContext.Categories.AsNoTracking().FirstOrDefault(c => c.Id == id);
            _cmsDbContext.Categories.Remove(ent);
            _cmsDbContext.SaveChanges();
        }

        public void Edit(Category entity)
        {
            _cmsDbContext.Categories.Update(entity);
            _cmsDbContext.SaveChanges();
        }

        public void EditName(Category entity)
        {
            var ent = _cmsDbContext.Categories.FirstOrDefault(c => c.Id == entity.Id);
            _cmsDbContext.Entry<Category>(ent).Entity.Name = entity.Name;
            _cmsDbContext.SaveChanges();
        }
    }
}
