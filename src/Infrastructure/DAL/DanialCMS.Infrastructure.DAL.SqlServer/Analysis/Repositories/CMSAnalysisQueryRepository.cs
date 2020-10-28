using DanialCMS.Core.Domain.Analysis.Entities;
using DanialCMS.Core.Domain.Analysis.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Analysis.Repositories
{
    public class CMSAnalysisQueryRepository : ICMSAnalysisQueryRepository
    {
        private readonly AnalysisDbContext _cmsAnalysisDbContext;

        public CMSAnalysisQueryRepository(AnalysisDbContext cmsAnalysisDbContext)
        {
            _cmsAnalysisDbContext = cmsAnalysisDbContext;
        }


        public List<CMSAnalysis> GetAll()
        {
            return _cmsAnalysisDbContext.CMSAnalysis.AsNoTracking()
                .ToList();
        }

        public IQueryable<CMSAnalysis> GetByDate(DateTime date)
        {
            return _cmsAnalysisDbContext.CMSAnalysis.AsNoTracking()
                .Where(c => c.Date == date);
        }

        public IQueryable<CMSAnalysis> GetByType(string type)
        {
            return _cmsAnalysisDbContext.CMSAnalysis.AsNoTracking()
                .Where(c => c.ContentType.Contains(type));
        }
    }
}
