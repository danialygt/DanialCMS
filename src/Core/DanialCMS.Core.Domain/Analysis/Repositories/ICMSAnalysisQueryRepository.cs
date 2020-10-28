using DanialCMS.Core.Domain.Analysis.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DanialCMS.Core.Domain.Analysis.Repositories
{
    public interface ICMSAnalysisQueryRepository
    {
        IQueryable<CMSAnalysis> GetByDate(DateTime date);
        IQueryable<CMSAnalysis> GetByType(string type);
        List<CMSAnalysis> GetAll ();
    }
}
