using DanialCMS.Core.Domain.Keywords.Entities;
using DanialCMS.Core.Domain.Keywords.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Keywords.Repositories
{
    public class KeywordQueryRepository : IKeywordQueryRepository
    {
        private readonly ContentDbContext _cmsDbContext;

        public KeywordQueryRepository(ContentDbContext cmsDbContext)
        {
            _cmsDbContext = cmsDbContext;
        }

        public Keyword Get(long id)
        {
            return _cmsDbContext.Keywords.AsNoTracking()
                .FirstOrDefault(c => c.Id == id);
        }

        public List<Keyword> Getall()
        {
            return _cmsDbContext.Keywords.AsNoTracking()
                .ToList();
        }

        public bool IsExist(string name)
        {
            return _cmsDbContext.Keywords.AsNoTracking()
                .Select(c => c.Name)
                .Contains(name);
        }

        public bool IsExist(long id)
        {
            return _cmsDbContext.Keywords.AsNoTracking()
                .Select(c => c.Id)
                .Contains(id);
        }
    }
}
