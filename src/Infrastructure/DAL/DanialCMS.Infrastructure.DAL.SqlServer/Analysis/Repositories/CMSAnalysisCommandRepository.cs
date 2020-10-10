using DanialCMS.Core.Domain.Analysis.Entities;
using DanialCMS.Core.Domain.Analysis.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DanialCMS.Infrastructure.DAL.SqlServer.Analysis.Repositories
{
    public class CMSAnalysisCommandRepository : ICMSAnalysisCommandRepository
    {
        private readonly AnalysisDbContext _cmsAnalysisDbContext;

        public CMSAnalysisCommandRepository(AnalysisDbContext cmsAnalysisDbContext)
        {
            _cmsAnalysisDbContext = cmsAnalysisDbContext;
        }
        public void Add(CMSAnalysis entity)
        {
            _cmsAnalysisDbContext.CMSAnalysis.Add(entity);
            _cmsAnalysisDbContext.SaveChanges();
        }
    }
}