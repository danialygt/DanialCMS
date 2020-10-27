using DanialCMS.Core.Domain.Keywords.Entities;
using DanialCMS.Core.Domain.Keywords.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Keywords.Repositories
{
    public class KeywordCommandRepository : IKeywordCommandRepository
    {
        private readonly ContentDbContext _cmsDbContext;

        public KeywordCommandRepository(ContentDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }

        public void Add(Keyword entity)
        {
            _cmsDbContext.Keywords.Add(entity);
            _cmsDbContext.SaveChanges();
        }

        public void Delete(Keyword entity)
        {
            var ent = _cmsDbContext.Keywords.AsNoTracking()
                .First(c => c.Id == entity.Id);
            _cmsDbContext.Keywords.Remove(ent);
            _cmsDbContext.SaveChanges();
        }

        public void Edit(Keyword entity)
        {
            _cmsDbContext.Keywords.Update(entity);
            _cmsDbContext.SaveChanges();
        }
    }
}
